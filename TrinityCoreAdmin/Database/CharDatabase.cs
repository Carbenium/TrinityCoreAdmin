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
            CHAR_SEL_CHARACTER,
            CHAR_SEL_GUILD_LEADER_BY_GUILD_ID,
            CHAR_SEL_GUILDID_BY_GUID,
            CHAR_DEL_GUILD_MEMBER,
            CHAR_SEL_PLAYER_ARENA_TEAMS,
            CHAR_DEL_ARENA_TEAM_MEMBER,
            CHAR_SEL_GROUP_MEMBER,
            CHAR_DEL_GROUP_MEMBER,
            CHAR_DEL_ALL_PETITION_SIGNATURES,
            CHAR_DEL_PETITION_BY_OWNER,
            CHAR_DEL_PETITION_SIGNATURE_BY_OWNER,
            CHAR_SEL_CHAR_COD_ITEM_MAIL,
            CHAR_DEL_MAIL_BY_ID,
            CHAR_DEL_MAIL_ITEM_BY_ID,
            CHAR_SEL_MAILITEMS,
            CHAR_DEL_ITEM_INSTANCE,
            CHAR_SEL_CHAR_PETS,
            CHAR_DEL_CHAR_PET_BY_ID,
            CHAR_DEL_CHAR_PET_DECLINEDNAME,
            CHAR_DEL_PET_AURAS,
            CHAR_DEL_PET_SPELLS,
            CHAR_DEL_PET_SPELL_COOLDOWNS,
            CHAR_DEL_CHARACTER,
            CHAR_DEL_PLAYER_ACCOUNT_DATA,
            CHAR_DEL_CHAR_DECLINED_NAME,
            CHAR_DEL_CHAR_ACTION,
            CHAR_DEL_CHAR_AURA,
            CHAR_DEL_CHAR_GIFT,
            CHAR_DEL_PLAYER_HOMEBIND,
            CHAR_DEL_CHAR_INSTANCE,
            CHAR_DEL_CHAR_INVENTORY,
            CHAR_DEL_CHAR_QUESTSTATUS,
            CHAR_DEL_CHAR_QUESTSTATUS_REWARDED,
            CHAR_DEL_CHAR_REPUTATION,
            CHAR_DEL_CHAR_SPELL,
            CHAR_DEL_CHAR_SPELL_COOLDOWN,
            CHAR_DEL_PLAYER_GM_TICKETS,
            CHAR_DEL_ITEM_INSTANCE_BY_OWNER,
            CHAR_DEL_CHAR_SOCIAL_BY_FRIEND,
            CHAR_DEL_CHAR_SOCIAL_BY_GUID,
            CHAR_DEL_MAIL,
            CHAR_DEL_MAIL_ITEMS,
            CHAR_DEL_CHAR_PET_BY_OWNER,
            CHAR_DEL_CHAR_PET_DECLINEDNAME_BY_OWNER,
            CHAR_DEL_CHAR_ACHIEVEMENTS,
            CHAR_DEL_CHAR_ACHIEVEMENT_PROGRESS,
            CHAR_DEL_CHAR_EQUIPMENTSETS,
            CHAR_DEL_GUILD_EVENTLOG_BY_PLAYER,
            CHAR_DEL_GUILD_BANK_EVENTLOG_BY_PLAYER,
            CHAR_DEL_PLAYER_BGDATA,
            CHAR_DEL_CHAR_GLYPHS,
            CHAR_DEL_CHAR_QUESTSTATUS_DAILY,
            CHAR_DEL_CHAR_TALENT,
            CHAR_DEL_CHAR_SKILLS,
            CHAR_UPD_DELETE_INFO,
            CHAR_DEL_TUTORIALS,
            CHAR_DEL_ACCOUNT_DATA,
            CHAR_DEL_CHARACTER_BAN,
            LOGIN_DEL_ACCOUNT,
            LOGIN_DEL_ACCOUNT_ACCESS,
            LOGIN_DEL_REALM_CHARACTERS,
            LOGIN_DEL_ACCOUNT_BANNED
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
            PrepareStatement(CharDatabaseStatements.CHAR_SEL_GUILD_LEADER_BY_GUILD_ID, "SELECT leaderguid FROM guild WHERE guildid=@guildid");
            PrepareStatement(CharDatabaseStatements.CHAR_SEL_GUILDID_BY_GUID, "SELECT guildid FROM guild_member WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_GUILD_MEMBER, "DELETE FROM guild_member WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_SEL_PLAYER_ARENA_TEAMS, "SELECT arena_team_member.arenaTeamId FROM arena_team_member JOIN arena_team ON arena_team_member.arenaTeamId = arena_team.arenaTeamId WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_ARENA_TEAM_MEMBER, "DELETE FROM arena_team_member WHERE arenaTeamId=@arenaTeamId  AND guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_SEL_GROUP_MEMBER, "SELECT guid FROM group_member WHERE memberGuid=@memberGuid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_GROUP_MEMBER, "DELETE FROM group_member WHERE memberGuid=@memberGuid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_ALL_PETITION_SIGNATURES, "DELETE FROM petition_sign WHERE playerguid=@playerguid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_PETITION_BY_OWNER, "DELETE FROM petition WHERE ownerguid=@ownerguid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_PETITION_SIGNATURE_BY_OWNER, "DELETE FROM petition_sign WHERE ownerguid=@ownerguid");
            PrepareStatement(CharDatabaseStatements.CHAR_SEL_CHAR_COD_ITEM_MAIL, "SELECT id, messageType, mailTemplateId, sender, subject, body, money, has_items FROM mail WHERE receiver=@receiver AND has_items <> 0 AND cod <> 0");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_MAIL_BY_ID, "DELETE FROM mail WHERE id=@id");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_MAIL_ITEM_BY_ID, "DELETE FROM mail_items WHERE mail_id=@mail_id");
            PrepareStatement(CharDatabaseStatements.CHAR_SEL_MAILITEMS, "SELECT creatorGuid, giftCreatorGuid, count, duration, charges, flags, enchantments, randomPropertyId, durability, playedTime, text, item_guid, itemEntry, owner_guid FROM mail_items mi JOIN item_instance ii ON mi.item_guid = ii.guid WHERE mail_id=@mail_id");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_ITEM_INSTANCE, "DELETE FROM item_instance WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_SEL_CHAR_PETS, "SELECT id FROM character_pet WHERE owner=@owner");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_PET_BY_ID, "DELETE FROM character_pet WHERE id=@id");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_PET_DECLINEDNAME, "DELETE FROM character_pet_declinedname WHERE id=@id");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_PET_AURAS, "DELETE FROM pet_aura WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_PET_SPELLS, "DELETE FROM pet_spell WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_PET_SPELL_COOLDOWNS, "DELETE FROM pet_spell_cooldown WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHARACTER, "DELETE FROM characters WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_PLAYER_ACCOUNT_DATA, "DELETE FROM character_account_data WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_DECLINED_NAME, "DELETE FROM character_declinedname WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_ACTION, "DELETE FROM character_action WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_AURA, "DELETE FROM character_aura WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_GIFT, "DELETE FROM character_gifts WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_PLAYER_HOMEBIND, "DELETE FROM character_homebind WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_INSTANCE, "DELETE FROM character_instance WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_INVENTORY, "DELETE FROM character_inventory WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_QUESTSTATUS, "DELETE FROM character_queststatus WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_QUESTSTATUS_REWARDED, "DELETE FROM character_queststatus_rewarded WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_REPUTATION, "DELETE FROM character_reputation WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_SPELL, "DELETE FROM character_spell WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_SPELL_COOLDOWN, "DELETE FROM character_spell_cooldown WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_PLAYER_GM_TICKETS, "DELETE FROM gm_tickets WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_ITEM_INSTANCE_BY_OWNER, "DELETE FROM item_instance WHERE owner_guid=@owner_guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_SOCIAL_BY_FRIEND, "DELETE FROM character_social WHERE friend=@friend");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_SOCIAL_BY_GUID, "DELETE FROM character_social WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_MAIL, "DELETE FROM mail WHERE receiver=@receiver");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_MAIL_ITEMS, "DELETE FROM mail_items WHERE receiver=@receiver");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_PET_BY_OWNER, "DELETE FROM character_pet WHERE owner=@owner");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_PET_DECLINEDNAME_BY_OWNER, "DELETE FROM character_pet_declinedname WHERE owner=@owner");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_ACHIEVEMENTS, "DELETE FROM character_achievement WHERE guid=@guid AND achievement NOT BETWEEN '456' AND '467' AND achievement NOT BETWEEN '1400' AND '1427' AND achievement NOT IN(1463, 3117, 3259)");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_ACHIEVEMENT_PROGRESS, "DELETE FROM character_achievement_progress WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_EQUIPMENTSETS, "DELETE FROM character_equipmentsets WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_GUILD_EVENTLOG_BY_PLAYER, "DELETE FROM guild_eventlog WHERE PlayerGuid1=@PlayerGuid1 OR PlayerGuid2=@PlayerGuid2");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_GUILD_BANK_EVENTLOG_BY_PLAYER, "DELETE FROM guild_bank_eventlog WHERE PlayerGuid=@PlayerGuid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_PLAYER_BGDATA, "DELETE FROM character_battleground_data WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_GLYPHS, "DELETE FROM character_glyphs WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_QUESTSTATUS_DAILY, "DELETE FROM character_queststatus_daily WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_TALENT, "DELETE FROM character_talent WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHAR_SKILLS, "DELETE FROM character_skills WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_UPD_DELETE_INFO, "UPDATE characters SET deleteInfos_Name = name, deleteInfos_Account = account, deleteDate = UNIX_TIMESTAMP(), name = '', account = 0 WHERE guid=@guid");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_TUTORIALS, "DELETE FROM account_tutorial WHERE accountId=@accountId");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_ACCOUNT_DATA, "DELETE FROM account_data WHERE accountId=@accountId");
            PrepareStatement(CharDatabaseStatements.CHAR_DEL_CHARACTER_BAN, "DELETE cb FROM character_banned cb INNER JOIN characters c ON c.guid = cb.guid WHERE c.account=@accountId");
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
