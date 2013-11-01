using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace TrinityCoreAdmin
{
    internal class MySQLConnection
    {
        protected List<MySqlCommand> m_stmt;
        private MySql.Data.MySqlClient.MySqlConnection conn;

        public MySQLConnection(MySqlConnectionStringBuilder connBuilder)
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(connBuilder.ToString());
        }

        public MySQLConnection(string connString)
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
        }

        public DataTable Execute(string sql)
        {
            if (conn.State != System.Data.ConnectionState.Open)
                return new DataTable();

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    var dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
            }
        }

        public DataTable Execute(MySqlCommand stmt)
        {
            using (MySqlDataReader reader = stmt.ExecuteReader())
            {
                var dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
        }

        public bool Open()
        {
            try
            {
                conn.Open();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        protected void PrepareStatement(int index, string sql)
        {
            MySqlCommand stmt = new MySqlCommand(sql, conn);

            if (!stmt.IsPrepared)
            {
                MessageBox.Show("Fehler während PrepareStatement id: " + index.ToString() + " sql: " + sql, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                m_stmt[index] = stmt;
            }
        }
    }
}