using MySql.Data.MySqlClient;
using System;

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
            //ServerManager.currServer.authDBConn = this;
        }

        /// <summary>
        /// Stores the Auth database prepared statements.
        /// </summary>
        public enum AuthDatabaseStatements
        {
            AUTH_SEL_ACCOUNTS,
            AUTH_SEL_ACCOUNT_BY_ID,
            AUTH_UPD_ACCOUNT,
            AUTH_INS_ACCOUNT,
            AUTH_DEL_ACCOUNT,
            AUTH_INS_REALM_CHARACTERS_INIT,
            AUTH_DEL_ACCOUNT_ACCESS,
            AUTH_DEL_REALM_CHARACTERS,
            AUTH_DEL_ACCOUNT_BANNED
        }

        /// <summary>
        /// Prepare SQL statements
        /// </summary>
        public override bool DoPrepareStatements()
        {
            PrepareStatement(AuthDatabaseStatements.AUTH_SEL_ACCOUNTS, "SELECT id, username, email, reg_mail, joindate, last_ip, failed_logins, last_login, online, expansion, locked FROM account", (stmt) => { });
            PrepareStatement(AuthDatabaseStatements.AUTH_SEL_ACCOUNT_BY_ID, "SELECT 1 FROM account WHERE id=@id", (stmt) => {
                stmt.Parameters.Add("@id", MySqlDbType.UInt32);
            });
            PrepareStatement(AuthDatabaseStatements.AUTH_UPD_ACCOUNT, "UPDATE account SET username=@username, email=@email, reg_mail=@reg_mail, locked=@locked WHERE id=@id", (stmt) => {
                stmt.Parameters.Add("@username", MySqlDbType.VarChar);
                stmt.Parameters.Add("@reg_mail", MySqlDbType.VarChar);
                stmt.Parameters.Add("@email", MySqlDbType.VarChar);
                stmt.Parameters.Add("@locked", MySqlDbType.UByte);
                stmt.Parameters.Add("@id", MySqlDbType.UInt32);
            });
            PrepareStatement(AuthDatabaseStatements.AUTH_INS_ACCOUNT, "INSERT INTO account(username, sha_pass_hash, reg_mail, email, joindate, last_login) VALUES(@username, @sha_pass_hash, @reg_mail, @email, NOW(), NULL)", (stmt) => {
                stmt.Parameters.Add("@username", MySqlDbType.VarChar);
                stmt.Parameters.Add("@sha_pass_hash", MySqlDbType.VarChar);
                stmt.Parameters.Add("@reg_mail", MySqlDbType.VarChar);
                stmt.Parameters.Add("@email", MySqlDbType.VarChar);
            });
            PrepareStatement(AuthDatabaseStatements.AUTH_DEL_ACCOUNT, "DELETE FROM account WHERE id=@id", (stmt) => {
                stmt.Parameters.Add("@id", MySqlDbType.UInt32);
            });
            PrepareStatement(AuthDatabaseStatements.AUTH_INS_REALM_CHARACTERS_INIT, "INSERT INTO realmcharacters (realmid, acctid, numchars) SELECT realmlist.id, account.id, 0 FROM realmlist, account LEFT JOIN realmcharacters ON acctid=account.id WHERE acctid IS NULL", (stmt) => { });
            PrepareStatement(AuthDatabaseStatements.AUTH_DEL_ACCOUNT_ACCESS, "DELETE FROM account_access WHERE id=@id", (stmt) => {
                stmt.Parameters.Add("@id", MySqlDbType.UInt32);
            });
            PrepareStatement(AuthDatabaseStatements.AUTH_DEL_REALM_CHARACTERS, "DELETE FROM realmcharacters WHERE acctid=@acctid", (stmt) => {
                stmt.Parameters.Add("@acctid", MySqlDbType.UInt32);
            });
            PrepareStatement(AuthDatabaseStatements.AUTH_DEL_ACCOUNT_BANNED, "DELETE FROM account_banned WHERE id=@id", (stmt) => {
                stmt.Parameters.Add("@id", MySqlDbType.UInt32);
            });

            return !this.prepareError;
        }

        private void PrepareStatement(AuthDatabaseStatements index, string sql, Action<MySqlCommand> param)
        {
            base.PrepareStatement((int)index, sql, param);
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
    }
}