using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace TrinityCoreAdmin
{
    public class AuthDatabase : MySQLConnection
    {
        public AuthDatabase(MySqlConnectionStringBuilder stringBuild)
            : base(stringBuild)
        { }

        public enum AuthDatabaseStatements
        {
            AUTH_SEL_ACCOUNTS
        }

        public void DoPrepareStatments()
        {
            PrepareStatement(AuthDatabaseStatements.AUTH_SEL_ACCOUNTS, "SELECT id, username, email, reg_mail,joindate, last_ip, failed_logins, last_login, online, expansion FROM account WHERE username=@name");
        }

        private void PrepareStatement(AuthDatabaseStatements index, string sql)
        {
            base.PrepareStatement((int)index, sql);
        }

        public MySqlCommand GetPreparedStatement(AuthDatabaseStatements index)
        {
            return base.GetPreparedStatement((int)index);
        }

        new public DataTable Execute(MySqlCommand stmt)
        {
            return base.Execute(stmt);
        }
    }
}
