using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace TrinityCoreAdmin.Database
{
    public static class PreparedStatementExt
    {
        public async static Task<DataTable> Execute(this MySqlCommand stmt, bool enforceConstraints = true, string[] pKeys = null)
        {
            Logger.LOG_GENERAL.Debug(stmt.Connection.ConnectionString);

            if (stmt.Connection.Database == ServerManager.authDB.sqlConn.Database)
            {
                return await ServerManager.authDB.Execute(stmt, enforceConstraints, pKeys);
            }
            else if (stmt.Connection.Database == ServerManager.charDB.sqlConn.Database)
            {
                return await ServerManager.charDB.Execute(stmt, enforceConstraints, pKeys);
            }
            else if (stmt.Connection.Database == ServerManager.worldDB.sqlConn.Database)
            {
                return await ServerManager.worldDB.Execute(stmt, enforceConstraints, pKeys);
            }
            return null;
        }

        public async static Task<object> ExScalar(this MySqlCommand stmt)
        {
            Logger.LOG_GENERAL.Debug(stmt.Connection.ConnectionString);

            if (stmt.Connection.Database == ServerManager.authDB.sqlConn.Database)
            {
                return await ServerManager.authDB.ExecuteScalar(stmt);
            }
            else if (stmt.Connection.Database == ServerManager.charDB.sqlConn.Database)
            {
                return await ServerManager.charDB.ExecuteScalar(stmt);
            }
            else if (stmt.Connection.Database == ServerManager.worldDB.sqlConn.Database)
            {
                return await ServerManager.worldDB.ExecuteScalar(stmt);
            }
            return null;
        }

        public async static Task<int> ExNonQuery(this MySqlCommand stmt)
        {
            Logger.LOG_GENERAL.Debug(stmt.Connection.ConnectionString);

            if (stmt.Connection.Database == ServerManager.authDB.sqlConn.Database)
            {
                return await ServerManager.authDB.ExecuteNonQuery(stmt);
            }
            else if (stmt.Connection.Database == ServerManager.charDB.sqlConn.Database)
            {
                return await ServerManager.charDB.ExecuteNonQuery(stmt);
            }
            else if (stmt.Connection.Database == ServerManager.worldDB.sqlConn.Database)
            {
                return await ServerManager.worldDB.ExecuteNonQuery(stmt);
            }
            return 0;
        }
    }
}