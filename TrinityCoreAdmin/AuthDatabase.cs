using MySql.Data.MySqlClient;

namespace TrinityCoreAdmin
{
    /// <summary>
    /// Warps calls to the Auth database
    /// </summary>
    public class AuthDatabase : MySQLConnection
    {
        /// <summary>
        /// Creates a new database wrapper object that wraps around
        /// the auth database.
        /// </summary>
        /// <param name="connStrBld">A MySqlConnectionStringBuilder object</param>
        public AuthDatabase(MySqlConnectionStringBuilder connStrBld)
            : base(connStrBld)
        {
            RealmManager.currRealm.authDBConn = this;
        }

        /// <summary>
        /// Stores the Auth database prepared statements.
        /// </summary>
        public enum AuthDatabaseStatements
        {
            AUTH_SEL_ACCOUNTS
        }

        /// <summary>
        /// Prepare SQL statements
        /// </summary>
        public void DoPrepareStatments()
        {
            PrepareStatement(AuthDatabaseStatements.AUTH_SEL_ACCOUNTS, "SELECT id, username, email, reg_mail,joindate, last_ip, failed_logins, last_login, online, expansion FROM account");
        }

        private void PrepareStatement(AuthDatabaseStatements index, string sql)
        {
            base.PrepareStatement((int)index, sql);
        }

        /// <summary>
        /// Get a prepared statement.
        /// </summary>
        /// <param name="i">Which statement?</param>
        /// <returns>Returns a MySqlCommand object</returns>
        public MySqlCommand GetPreparedStatement(AuthDatabaseStatements i)
        {
            return base.GetPreparedStatement((int)i);
        }

        /// <summary>
        /// Execute a prepared statement on the Auth database
        /// </summary>
        /// <param name="stmt"></param>
        /// <returns>Returns the fetched data as DataTable</returns>
        //public DataTable Execute(MySqlCommand stmt)
        //{
        //    return base.Execute(stmt);
        //}

        ///// <summary>
        ///// Open the connection to the Auth database
        ///// </summary>
        ///// <returns>Returns true if connection is successfully established</returns>
        //public override bool Open()
        //{
        //    return base.Open();
        //}

        ///// <summary>
        ///// Closes the connection to the Auth database
        ///// </summary>
        //public override void Close()
        //{
        //    //OnConnectionStateSQLEventArgs e = new OnConnectionStateSQLEventArgs(this, ConnectionState.Closed);
        //    //OnToggleConnectionState(e);
        //    base.Close();
        //}
    }
}