using MySql.Data.MySqlClient;

namespace TrinityCoreAdmin
{
    public class WorldDatabase : MySQLConnection
    {
        public WorldDatabase(MySqlConnectionStringBuilder stringBuild)
            : base(stringBuild)
        { }

        public enum WorldDatabaseStatements : int
        {
        }

        public void DoPrepareStatments()
        {
        }

        public MySqlCommand GetPreparedStatement(WorldDatabaseStatements index)
        {
            return base.GetPreparedStatement((int)index);
        }
    }
}