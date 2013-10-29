using System;

namespace TrinityCoreAdmin
{
    internal class Account
    {
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
    }
}