using MySql.Data.MySqlClient;

namespace TrinityCoreAdmin
{
    /// <summary>
    /// Warps calls to the Characters database
    /// </summary>
    public class CharDatabase : MySQLConnection
    {
        /// <summary>
        /// Creates a new database wrapper object that wraps around
        /// the char database.
        /// </summary>
        /// <param name="connStrBld">A MySqlConnectionStringBuilder object</param>
        public CharDatabase(MySqlConnectionStringBuilder connStrBld)
            : base(connStrBld)
        {
            RealmManager.currRealm.charDBConn = this;
        }

        /// <summary>
        /// Stores the Char database prepared statements.
        /// </summary>
        public enum CharDatabaseStatements
        {
        }

        /// <summary>
        /// Prepare SQL statements
        /// </summary>
        public void DoPrepareStatments()
        {
        }

        private void PrepareStatement(CharDatabaseStatements index, string sql)
        {
            base.PrepareStatement((int)index, sql);
        }

        /// <summary>
        /// Get a prepared statement.
        /// </summary>
        /// <param name="i">Which statement?</param>
        /// <returns>Returns a MySqlCommand object</returns>
        public MySqlCommand GetPreparedStatement(CharDatabaseStatements i)
        {
            return base.GetPreparedStatement((int)i);
        }
    }
}
