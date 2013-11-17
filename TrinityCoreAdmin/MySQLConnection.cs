using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace TrinityCoreAdmin
{
    public class MySQLConnection : BaseConnection, IDisposable
    {
        /// <summary>
        /// List of open MySQL connections.
        /// </summary>
        protected static List<MySQLConnection> m_conn = new List<MySQLConnection>();

        /// <summary>
        /// List of prepared statements.
        /// </summary>
        protected List<MySqlCommand> m_stmts = new List<MySqlCommand>();

        private string connStr;
        private MySqlConnection sqlConn;
        private static ConnectionState connState = ConnectionState.Closed;
        private static bool isPrepared = false;

        /// <summary>
        /// Creates a new MySQL connection.
        /// </summary>
        protected MySQLConnection()
        {
            this.sqlConn = new MySqlConnection();
            sqlConn.StateChange += sqlConn_StateChange;
        }

        /// <summary>
        /// Creates a new MySQL connection.
        /// </summary>
        /// <param name="cb">The MySqlConnectionStringBuilder</param>
        protected MySQLConnection(MySqlConnectionStringBuilder cb)
        {
            this.connStr = cb.ConnectionString;
            this.sqlConn = new MySqlConnection(connStr);
            this.sqlConn.StateChange += sqlConn_StateChange;
        }

        /// <summary>
        /// Creates a new MySQL connection.
        /// </summary>
        /// <param name="connStr">A connection string to provide to connect to the database</param>
        protected MySQLConnection(string connStr)
        {
            this.connStr = connStr;
            this.sqlConn = new MySqlConnection(this.connStr);
            this.sqlConn.StateChange += sqlConn_StateChange;
        }

        public void OnToggleConnectionState(OnConnectionStateEventArgs e)
        {
            if (OnToggleConnectionStateHandler != null)
                OnToggleConnectionStateHandler(this, e);
        }

        private void sqlConn_StateChange(object sender, StateChangeEventArgs e)
        {
            OnToggleConnectionState(new OnConnectionStateEventArgs(this, e.CurrentState));
        }

        public delegate void ToggleConnectionStateHandler(object sender, OnConnectionStateEventArgs e);

        public event ToggleConnectionStateHandler OnToggleConnectionStateHandler;

        /// <summary>
        /// Disposes a SQL connection.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes a SQL connection.
        /// </summary>
        /// <param name="disposing">Dispose managed resources</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.sqlConn != null)
                {
                    this.sqlConn.Close();
                    this.sqlConn = null;
                }
            }
        }

        /// <summary>
        /// Opens the connection to the SQL database.
        /// </summary>
        /// <returns>Returns true if the opening procedure successfully completed</returns>
        public override bool Open()
        {
            try
            {
                if (connState == ConnectionState.Closed)
                {
                    sqlConn.Open();
                }
                else
                {
                    Logger.LOG_DATABASE.Warn("Can't connect to an open database connection at " + sqlConn.DataSource + " DB: " + sqlConn.Database);
                    return false;
                }
            }
            catch (MySqlException e)
            {
                Logger.LOG_DATABASE.Error("Could not connect to MySQL database at " + sqlConn.DataSource + ": " + e.Message);
                MessageBox.Show("Konnte keine Verbindung zur MySQL-Datenbank herstellen. Bitte überprüfen Sie die Einstellungen.", "Verbindungsfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (sqlConn.State == ConnectionState.Open)
            {
                m_conn.Add(this);
                connState = ConnectionState.Open;

                Logger.LOG_DATABASE.Info("MySQL server ver: " + sqlConn.ServerVersion);
                Logger.LOG_DATABASE.Info("Connected to MySQL database " + sqlConn.Database + " at " + sqlConn.DataSource);

                return true;
            }
            return false;
        }

        /// <summary>
        /// Closes the connection to the SQL database.
        /// </summary>
        public override void Close()
        {
            sqlConn.Close();
            m_conn.Remove(this);
            connState = ConnectionState.Closed;
            isPrepared = false;

            Logger.LOG_DATABASE.Info("Closed MySQL connection to database " + sqlConn.Database + " at " + sqlConn.DataSource);
        }

        /// <summary>
        /// Closes all open SQL connections.
        /// </summary>
        public static void CloseConnections()
        {
            for (int i = m_conn.Count - 1; i >= 0; i--)
            {
                m_conn[i].Close();
            }
        }

        /// <summary>
        /// Execute a SQL command on the database.
        /// </summary>
        /// <param name="sql">The SQL command</param>
        /// <returns>Returns the fetched data as DataTable</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:SQL-Abfragen auf Sicherheitsrisiken überprüfen")]
        public DataTable Execute(string sql)
        {
            if (connState != ConnectionState.Open)
                return new DataTable();

            using (MySqlCommand cmd = new MySqlCommand(sql, sqlConn))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    var dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
            }
        }

        /// <summary>
        /// Execute a SQL prepared statement on the database.
        /// </summary>
        /// <param name="stmt"></param>
        /// <returns></returns>
        public DataTable Execute(MySqlCommand stmt)
        {
            if (connState == ConnectionState.Open)
            {
                using (MySqlDataReader reader = stmt.ExecuteReader())
                {
                    var dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
            }
            return null;
        }

        public object ExecuteScalar(MySqlCommand stmt)
        {
            if (connState == ConnectionState.Open)
            {
                try
                {
                    return stmt.ExecuteScalar();
                }
                catch (MySqlException e)
                {
                    Logger.LOG_DATABASE.Error("Could not execute prepared statement " + stmt.ToString() + " as scalar. " + e.Message);
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets a prepared SQL statement.
        /// </summary>
        /// <param name="index">Which statement?</param>
        /// <returns>Returns a SQL statement</returns>
        protected MySqlCommand GetPreparedStatement(int index)
        {
            if (!isPrepared)
            {
                Logger.LOG_DATABASE.Error("Could not fetch prepared statement " + index.ToString() + " on database " + sqlConn.Database.ToString() + ".");
                return null;
            }
            MySqlCommand ret = m_stmts[index];
            if (ret == null)
                Logger.LOG_DATABASE.Error("Could not fetch prepared statement " + index.ToString() + " on database " + sqlConn.Database.ToString() + ".");

            return ret;
        }

        /// <summary>
        /// Prepares a SQL command.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="sql">The SQL command</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:SQL-Abfragen auf Sicherheitsrisiken überprüfen")]
        protected void PrepareStatement(int index, string sql)
        {
            try
            {
                if (connState == ConnectionState.Open && !isPrepared)
                {
                    MySqlCommand stmt = new MySqlCommand(sql, sqlConn);
                    stmt.Prepare();

                    m_stmts.Insert(index, stmt);
                    isPrepared = true;
                }
            }
            catch (Exception e)
            {
                Logger.LOG_DATABASE.Error("Could not prepare statement. Id: " + index + ", sql: " + sql + e.Message);
            }
        }
    }
}