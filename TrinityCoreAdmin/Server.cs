using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using TrinityCoreAdmin.Security;

namespace TrinityCoreAdmin
{
    [DataContract]
    //[KnownType(typeof(List<Realm>))]
    internal class Server
    {
        [DataMember]
        public List<Realm> realms = new List<Realm>();

        public AuthDatabase authDBConn;

        [DataMember]
        private string _encryptedPassword;

        //private string _entropy;

        [DataMember]
        public string Authdb
        { get; set; }

        [DataMember]
        public string Host
        { get; set; }

        [DataMember]
        public string Name
        { get; set; }

        [DataMember]
        public int Port
        { get; set; }

        [DataMember]
        public string User
        { get; set; }

        public string Password
        {
            get
            {
                if (_encryptedPassword == String.Empty)
                    return String.Empty;
                else
                    return _encryptedPassword.DecryptString(Encoding.Unicode.GetBytes(Entropy)).ToInsecureString();
            }
            set
            {
                if (value != String.Empty)
                    _encryptedPassword = value.ToSecureString().EncryptString(Encoding.Unicode.GetBytes(Entropy));
            }
        }

        [DataMember]
        public string Entropy

        { get; private set; }

        public Server()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[1024];

            rng.GetBytes(buffer);
            Entropy = BitConverter.ToString(buffer);
            rng.Dispose();

            _encryptedPassword = String.Empty;
            Host = String.Empty;
            Name = String.Empty;
            Port = 0;
            User = String.Empty;
            Password = String.Empty;
        }
    }
}