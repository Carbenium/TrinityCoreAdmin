using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrinityCoreAdmin.Database;

namespace TrinityCoreAdmin
{
    public class Account
    {
        private static List<Account> accounts = new List<Account>();

        private Account(int id, string username, string reg_mail, string email, DateTime joindate, string last_ip, int failed_logins, DateTime last_login, bool online, Expansion expansion, bool locked)
        {
            this.id = id;
            this.username = username;
            this.reg_mail = reg_mail;
            this.email = email;
            this.joindate = joindate;
            this.last_ip = last_ip;
            this.failed_logins = failed_logins;
            this.last_login = last_login;
            this.online = online;
            this.expansion = expansion;
            this.locked = locked;
        }

        private Account(object id, object username, object reg_mail, object email, object joindate, object last_ip, object failed_logins, object last_login, object online, object expansion, object locked)
        {
            this.id = XConverter.ToInt32(id);
            this.username = Convert.ToString(username);
            this.reg_mail = Convert.ToString(reg_mail);
            this.email = Convert.ToString(email);
            this.joindate = Convert.ToDateTime(joindate);
            this.last_ip = Convert.ToString(last_ip);
            this.failed_logins = XConverter.ToInt32(failed_logins);
            this.last_login = Convert.ToDateTime(last_login);
            this.online = Convert.ToBoolean(online);
            this.expansion = (Expansion)Enum.ToObject(typeof(Expansion), expansion);
            this.locked = Convert.ToBoolean(locked);
        }

        public int id { get; set; }

        public string username { get; set; }

        public string reg_mail { get; set; }

        public string email { get; set; }

        public DateTime joindate { get; set; }

        public string last_ip { get; set; }

        public int failed_logins { get; set; }

        public DateTime last_login { get; set; }

        public bool online { get; set; }

        public Expansion expansion { get; set; }

        public bool locked { get; set; }

        private List<Player> characters = new List<Player>();

        /// <summary>
        /// Load the accounts from the database.
        /// </summary>
        public static async Task LoadFromDB()
        {
            accounts.Clear();
            var stmt = ServerManager.authDB.GetPreparedStatement(AuthDatabase.AuthDatabaseStatements.AUTH_SEL_ACCOUNTS);
            var dt = await stmt.Execute();

            foreach (DataRow row in dt.Rows)
            {
                var acc = new Account(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10]);
                await acc.LoadCharacters();
                accounts.Add(acc);
            }

            // Debug purpose only
            /*for (int i = 2; i < 10000; i++)
            {
                accounts.Add(new Account(i, "user" + i.ToString(),"","",DateTime.Today,"123.456.789.000",0, DateTime.Today,true,Expansion.CLASSIC,false));
            }*/
        }

        private async Task LoadCharacters()
        {
            var stmt = ServerManager.charDB.GetPreparedStatement(CharDatabase.CharDatabaseStatements.CHAR_SEL_CHARS_BY_ACCOUNT_ID);
            stmt.Parameters["@account"].Value = this.id;

            var dt = await stmt.Execute();

            foreach (DataRow row in dt.Rows)
            {
                var player = await Player.LoadFromDB(XConverter.ToInt32(row[0]));
                characters.Add(player);
            }
        }

        /// <summary>
        /// Gets the account with the specified id.
        /// </summary>
        /// <param name="id">Id of the account.</param>
        /// <returns>Returns the account with the specified id.</returns>
        public static Account GetAccount(int id)
        {
            return accounts.Find((e) => { return (e.id == id); });
        }

        public static Account GetAccount(string username)
        {
            return accounts.Find((e) => { return (e.username == username); });
        }

        /// <summary>
        /// Returns the highest account id.
        /// </summary>
        /// <returns></returns>
        public static int GetMaxID()
        {
            if (accounts.Count == 0)
            {
                throw new InvalidOperationException("Empty accounts list.");
            }
            int maxId = int.MinValue;

            foreach (var acc in accounts)
            {
                if (acc.id > maxId)
                {
                    maxId = acc.id;
                }
            }
            return maxId;
        }

        public static ReadOnlyCollection<Account> GetAccounts()
        {
            return accounts.AsReadOnly();
        }

        /// <summary>
        /// Clears the account list.
        /// </summary>
        public static void ClearAccounts()
        {
            accounts.Clear();
        }

        /// <summary>
        /// Updates the account data in the database.
        /// </summary>
        /// <returns>True if successful, otherwise false.</returns>
        public async Task<bool> UpdateAccount()
        {
            var stmt = ServerManager.authDB.GetPreparedStatement(AuthDatabase.AuthDatabaseStatements.AUTH_UPD_ACCOUNT);

            if (stmt == null)
                return false;
            stmt.Parameters["@username"].Value = this.username;
            stmt.Parameters["@email"].Value = this.email;
            stmt.Parameters["@reg_mail"].Value = this.reg_mail;
            stmt.Parameters["@locked"].Value = this.locked;
            stmt.Parameters["@id"].Value = this.id;

            int result = await stmt.ExNonQuery();
            return result == 1;
        }

        public static async Task<AccountOpResult> CreateAccount(string username, string password, string email)
        {
            if (username.Length > 16) // username is too long
                return AccountOpResult.AOR_NAME_TOO_LONG;

            if (password.Length > 16)
                return AccountOpResult.AOR_PASS_TOO_LONG;

            if (email.Length > 64)
                return AccountOpResult.AOR_EMAIL_TOO_LONG;

            username = username.ToUpper().Normalize();
            password = password.ToUpper().Normalize();
            email = email.Normalize();

            if (GetAccount(username) != null)
                return AccountOpResult.AOR_NAME_ALREADY_EXIST;

            var stmt = ServerManager.authDB.GetPreparedStatement(AuthDatabase.AuthDatabaseStatements.AUTH_INS_ACCOUNT);

            if (stmt == null)
                return AccountOpResult.AOR_INTERNAL_ERROR;

            stmt.Parameters["@username"].Value = username;
            stmt.Parameters["@sha_pass_hash"].Value = CalculateShaPassHash(username, password);
            stmt.Parameters["@reg_mail"].Value = email;
            stmt.Parameters["@email"].Value = email;

            if (await ServerManager.authDB.ExecuteNonQuery(stmt) != 1)
                return AccountOpResult.AOR_INTERNAL_ERROR;

            stmt = ServerManager.authDB.GetPreparedStatement(AuthDatabase.AuthDatabaseStatements.AUTH_INS_REALM_CHARACTERS_INIT);
            await stmt.ExNonQuery();

            await LoadFromDB();

            return AccountOpResult.AOR_OK;
        }

        public async Task<AccountOpResult> DeleteAccount()
        {
            var stmt = ServerManager.authDB.GetPreparedStatement(AuthDatabase.AuthDatabaseStatements.AUTH_SEL_ACCOUNT_BY_ID);

            if (stmt == null)
                return AccountOpResult.AOR_INTERNAL_ERROR;

            stmt.Parameters["@id"].Value = this.id;

            if (await stmt.ExScalar() == null)
                return AccountOpResult.AOR_NAME_NOT_EXIST;

            foreach (var p in this.characters)
            {
                await p.DeleteFromDB(true);
                characters.Remove(p);
            }

            stmt = ServerManager.charDB.GetPreparedStatement(CharDatabase.CharDatabaseStatements.CHAR_DEL_TUTORIALS);
            stmt.Parameters["@accountId"].Value = this.id;
            await stmt.ExNonQuery();

            stmt = ServerManager.charDB.GetPreparedStatement(CharDatabase.CharDatabaseStatements.CHAR_DEL_ACCOUNT_DATA);
            stmt.Parameters["@accountId"].Value = this.id;
            await stmt.ExNonQuery();

            stmt = ServerManager.charDB.GetPreparedStatement(CharDatabase.CharDatabaseStatements.CHAR_DEL_CHARACTER_BAN);
            stmt.Parameters["@accountId"].Value = this.id;
            await stmt.ExNonQuery();

            stmt = ServerManager.authDB.GetPreparedStatement(AuthDatabase.AuthDatabaseStatements.AUTH_DEL_ACCOUNT);
            stmt.Parameters["@id"].Value = this.id;
            await stmt.ExNonQuery();

            stmt = ServerManager.authDB.GetPreparedStatement(AuthDatabase.AuthDatabaseStatements.AUTH_DEL_ACCOUNT_ACCESS);
            stmt.Parameters["@id"].Value = this.id;
            await stmt.ExNonQuery();

            stmt = ServerManager.authDB.GetPreparedStatement(AuthDatabase.AuthDatabaseStatements.AUTH_DEL_REALM_CHARACTERS);
            stmt.Parameters["@acctid"].Value = this.id;
            await stmt.ExNonQuery();

            stmt = ServerManager.authDB.GetPreparedStatement(AuthDatabase.AuthDatabaseStatements.AUTH_DEL_ACCOUNT_BANNED);
            stmt.Parameters["@id"].Value = this.id;
            await stmt.ExNonQuery();

            await LoadFromDB();

            return AccountOpResult.AOR_OK;
        }

        private static string CalculateShaPassHash(string username, string password)
        {
            var SHA1 = new SHA1CryptoServiceProvider();

            byte[] arrayData;
            byte[] arrayResult;
            string result = null;
            string temp = null;

            arrayData = Encoding.ASCII.GetBytes(username + ":" + password);
            arrayResult = SHA1.ComputeHash(arrayData);
            for (int i = 0; i < arrayResult.Length; i++)
            {
                temp = Convert.ToString(arrayResult[i], 16);
                if (temp.Length == 1)
                    temp = "0" + temp;
                result += temp;
            }

            return result.ToUpper();
        }

        /// <summary>
        /// Sorts the account list.
        /// </summary>
        /// <param name="order">Sort order</param>
        /// <param name="comparer">The comparer</param>
        public static void SortBy(SortOrder order, Comparison<Account> comparer)
        {
            accounts.Sort((a, b) =>
            {
                int lret = comparer(a, b); // Do the actual comparison

                if (order == SortOrder.Descending) // reverse when necessary
                {
                    lret *= -1;
                }
                return lret;
            });
        }
    }
}