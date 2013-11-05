using System;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using TrinityCoreAdmin.Security;

namespace TrinityCoreAdmin
{
    [DataContract]
    public class Realm
    {
        private string _authdb;

        private string _chardb;

        private int _dbId;

        [DataMember]
        private string _encryptedPassword;

        private string _entropy;

        private string _host;

        private string _name;

        private int _port;

        private string _user;

        private string _worlddb;

        public AuthDatabase authDBConn;

        public WorldDatabase worldDBConn;

        public Realm()
        { }

        public Realm(int dbId, string name, string host, int port, string user, string password, string authdb, string chardb, string worlddb)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[1024];

            rng.GetBytes(buffer);
            _entropy = BitConverter.ToString(buffer);
            rng.Dispose();

            DbId = dbId;
            Name = name;
            Host = host;
            Port = port;
            User = user;
            Password = password;
            Authdb = authdb;
            Chardb = chardb;
            Worlddb = worlddb;
        }

        [DataMember]
        public string Authdb
        { get;  set; }

        [DataMember]
        public string Chardb
        { get;  set; }

        [DataMember]
        public int DbId
        { get;  set; }

        [DataMember]
        public string Entropy

            { get;  private set; }


        [DataMember]
        public string Host
        { get;  set; }

        [DataMember]
        public string Name
        { get;  set; }

        public string Password
        {
            get { return _encryptedPassword.DecryptString(Encoding.Unicode.GetBytes(Entropy)).ToInsecureString(); }
            set
            {
                _encryptedPassword = value.ToSecureString().EncryptString(Encoding.Unicode.GetBytes(Entropy));
            }
        }

        [DataMember]
        public int Port
        { get;  set; }

        [DataMember]
        public string User
        { get;  set; }

        [DataMember]
        public string Worlddb
        { get;  set; }
    }
}