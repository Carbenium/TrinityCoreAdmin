using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TrinityCoreAdmin
{
    class AuthDatabase : MySQLConnection
    {
        public AuthDatabase(MySqlConnectionStringBuilder stringBuild)
            : base(stringBuild)
        { }

        enum AuthDatabaseStatements
        {
            AUTH_SEL_ACCOUNTS 
        }

        public void DoPrepareStatments()
        {
            PrepareStatement((int)AuthDatabaseStatements.AUTH_SEL_ACCOUNTS, "SELECT * FROM account WHERE id = ?");
        }
    }
}
