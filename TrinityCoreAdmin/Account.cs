using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace TrinityCoreAdmin
{
    public class Account
    {
        private static List<Account> accounts = new List<Account>();

        public Account(int id, string username, string reg_mail, string email, DateTime joindate, string last_ip, int failed_logins, DateTime last_login, bool online, Expansion expansion, bool locked)
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

        public Account(object id, object username, object reg_mail, object email, object joindate, object last_ip, object failed_logins, object last_login, object online, object expansion, object locked)
        {
            this.id = XConverter.ToInt32(id);
            this.username = Convert.ToString(username);
            this.reg_mail = Convert.ToString(reg_mail);
            this.email = Convert.ToString(email);
            this.joindate = (DateTime)joindate;
            this.last_ip = Convert.ToString(last_ip);
            this.failed_logins = XConverter.ToInt32(failed_logins);
            this.last_login = (DateTime)last_login;
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

        public static void LoadAccountsFromDB()
        {
            accounts.Clear();
            MySqlCommand stmt = ServerManager.currServer.authDBConn.GetPreparedStatement(AuthDatabase.AuthDatabaseStatements.AUTH_SEL_ACCOUNTS);
            DataTable dt = ServerManager.currServer.authDBConn.Execute(stmt);

            foreach (DataRow row in dt.Rows)
            {
                Account acc = new Account(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10]);
                accounts.Add(acc);
            }

            // Debug purpose only
            /*for (int i = 2; i < 10000; i++)
            {
                accounts.Add(new Account(i, "user" + i.ToString(),"","",DateTime.Today,"123.456.789.000",0, DateTime.Today,true,Expansion.CLASSIC,false));
            }*/
        }

        public static Account GetAccount(int id)
        {
            return accounts.Find((e) => { return (e.id == id); });
        }

        public static int GetMaxID()
        {
            if (accounts.Count == 0)
            {
                throw new InvalidOperationException("Empty accounts list.");
            }
            int maxId = int.MinValue;

            foreach (Account acc in accounts)
            {
                if (acc.id > maxId)
                {
                    maxId = acc.id;
                }
            }
            return maxId;
        }

        public static List<Account> GetAccounts()
        {
            return accounts;
        }

        public static void ClearAccounts()
        {
            accounts.Clear();
        }

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