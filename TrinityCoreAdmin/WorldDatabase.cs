using MySql.Data.MySqlClient;

namespace TrinityCoreAdmin
{
    internal class WorldDatabase : MySQLConnection
    {
        public WorldDatabase(MySqlConnectionStringBuilder stringBuild)
            : base(stringBuild)
        { }

        private enum WorldDatabaseStatements : int
        {
        }

        public void DoPrepareStatments()
        {
        }
    }
}