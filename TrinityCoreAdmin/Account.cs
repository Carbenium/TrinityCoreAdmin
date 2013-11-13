using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace TrinityCoreAdmin
{
    internal class Account
    {
        public static List<Account> accounts = new List<Account>();

        public Account(int Id, string Username, string Reg_mail, string Email, DateTime Joindate, string Last_ip, int Failed_logins, DateTime Last_login, bool Online, Expansion Expansion)
        {
            id = Id;
            username = Username;
            reg_mail = Reg_mail;
            email = Email;
            joindate = Joindate;
            last_ip = Last_ip;
            failed_logins = Failed_logins;
            last_login = Last_login;
            online = Online;
            expansion = Expansion;
        }

        public Account(object Id, object Username, object Reg_mail, object Email, object Joindate, object Last_ip, object Failed_logins, object Last_login, object Online, object Expansion)
        {
            id = XConverter.ToInt32(Id);
            username = Username.ToString();
            reg_mail = Reg_mail.ToString();
            email = Email.ToString();
            joindate = (DateTime)Joindate;
            last_ip = Last_ip.ToString();
            failed_logins = XConverter.ToInt32(Failed_logins);
            last_login = (DateTime)Last_login;
            online = Convert.ToBoolean(Online);
            expansion = (Expansion)Enum.ToObject(typeof(Expansion), Expansion);
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

        public static void LoadAccountsFromDB()
        {
            MySqlCommand stmt = ServerManager.currServer.authDBConn.GetPreparedStatement(AuthDatabase.AuthDatabaseStatements.AUTH_SEL_ACCOUNTS);

            DataTable dt = ServerManager.currServer.authDBConn.Execute(stmt);

            foreach (DataRow row in dt.Rows)
            {
                Account acc = new Account(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9]);

                accounts.Add(acc);
            }
        }
    }
}