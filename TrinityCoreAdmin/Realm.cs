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
        public Realm()
        {
        }

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

        private int _dbId;

        [DataMember]
        public int DbId
        {
            get { return _dbId; }
            set { _dbId = value; }
        }

        private string _name;

        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _host;

        [DataMember]
        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }

        private int _port;

        [DataMember]
        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        private string _user;

        [DataMember]
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        public string Password
        {
            get { return _encryptedPassword.DecryptString(Encoding.Unicode.GetBytes(_entropy)).ToInsecureString(); }
            set
            {
                _encryptedPassword = value.ToSecureString().EncryptString(Encoding.Unicode.GetBytes(_entropy));
            }
        }

        [DataMember]
        private string _encryptedPassword;

        private string _authdb;

        [DataMember]
        public string Authdb
        {
            get { return _authdb; }
            set { _authdb = value; }
        }

        private string _chardb;

        [DataMember]
        public string Chardb
        {
            get { return _chardb; }
            set { _chardb = value; }
        }

        private string _worlddb;

        [DataMember]
        public string Worlddb
        {
            get { return _worlddb; }
            set { _worlddb = value; }
        }

        private string _entropy;

        [DataMember]
        public string Entropy
        {
            get { return _entropy; }
            set { _entropy = value; }
        }
    }
}