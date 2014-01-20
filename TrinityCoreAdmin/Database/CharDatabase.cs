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
            CHAR_SEL_CHARS_BY_ACCOUNT_ID,
            CHAR_SEL_CHARACTER
        }

        /// <summary>
        /// Prepare SQL statements
        /// </summary>
        public void DoPrepareStatments()
        {
            PrepareStatement(CharDatabaseStatements.CHAR_SEL_CHARS_BY_ACCOUNT_ID, "SELECT guid FROM characters WHERE account=@account");
            PrepareStatement(CharDatabaseStatements.CHAR_SEL_CHARACTER, "SELECT guid, account, name, race, class, gender, level, xp, money, playerBytes, playerBytes2, playerFlags, " +
                     "position_x, position_y, position_z, map, orientation, taximask, cinematic, totaltime, leveltime, rest_bonus, logout_time, is_logout_resting, resettalents_cost, " +
                     "resettalents_time, trans_x, trans_y, trans_z, trans_o, transguid, extra_flags, stable_slots, at_login, zone, online, death_expire_time, taxi_path, instance_mode_mask, " +
                     "arenaPoints, totalHonorPoints, todayHonorPoints, yesterdayHonorPoints, totalKills, todayKills, yesterdayKills, chosenTitle, knownCurrencies, watchedFaction, drunk, " +
                     "health, power1, power2, power3, power4, power5, power6, power7, instance_id, speccount, activespec, exploredZones, equipmentCache, ammoId, knownTitles, actionBars, grantableLevels " +
                     "FROM characters WHERE guid=@guid");
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
