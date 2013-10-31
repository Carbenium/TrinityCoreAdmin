using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace TrinityCoreAdmin
{
    internal class MySQLConnection
    {
        private MySql.Data.MySqlClient.MySqlConnection conn;

        public MySQLConnection(MySqlConnectionStringBuilder connBuilder)
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(connBuilder.ToString());
        }

        public MySQLConnection(string connString)
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
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

        public bool Execute(string sql)
        {
            if (conn.State != System.Data.ConnectionState.Open)
                return false;

            using (var cmd = conn.CreateCommand())
            {
                return true;
            }
        }
    }
}