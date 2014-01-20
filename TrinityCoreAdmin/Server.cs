using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using TrinityCoreAdmin.Security;

namespace TrinityCoreAdmin
{
    [DataContract]
    internal class Server
    {
        public AuthDatabase authDBConn;

        public CharDatabase charDBConn;

        public SshConnection sshConn;

        public bool worldConnected = false;

        public bool authConnected = false;

        public bool charConnected = false;

        [DataMember]
        public List<Realm> realms = new List<Realm>();

        [DataMember]
        private string _encryptedSqlPassword;

        [DataMember]
        private string _encryptedSshPassword;

        public Server()
        {
            this.name = String.Empty;

            this.sqlHost = String.Empty;
            this.sqlPort = 3306;
            this.sqlUser = String.Empty;
            this.sqlPassword = String.Empty;

            this.sshHost = String.Empty;
            this.sshPort = 22;
            this.sshUser = String.Empty;
            this.sshPassword = String.Empty;
            this.useSSHTunnel = false;

            RNGCryptoServiceProvider sqlRng = new RNGCryptoServiceProvider();
            byte[] sqlBuffer = new byte[1024];

            sqlRng.GetBytes(sqlBuffer);
            this.sqlEntropy = BitConverter.ToString(sqlBuffer);
            sqlRng.Dispose();

            RNGCryptoServiceProvider sshRng = new RNGCryptoServiceProvider();
            byte[] sshBuffer = new byte[1024];

            sshRng.GetBytes(sshBuffer);
            this.sshEntropy = BitConverter.ToString(sshBuffer);
            sshRng.Dispose();

            this._encryptedSqlPassword = String.Empty;
            this._encryptedSshPassword = String.Empty;
        }

        [DataMember]
        public string name
        { get; set; }

        [DataMember]
        public string sqlEntropy
        { get; private set; }

        [DataMember]
        public string sqlHost
        { get; set; }

        public string sqlPassword
        {
            get
            {
                if (_encryptedSqlPassword == null || _encryptedSqlPassword == String.Empty)
                    return String.Empty;
                else
                    return _encryptedSqlPassword.DecryptString(Encoding.Unicode.GetBytes(sqlEntropy)).ToInsecureString();
            }
            set
            {
                if (value != String.Empty)
                    _encryptedSqlPassword = value.ToSecureString().EncryptString(Encoding.Unicode.GetBytes(sqlEntropy));
            }
        }

        [DataMember]
        public uint sqlPort
        { get; set; }

        [DataMember]
        public string sqlUser
        { get; set; }

        [DataMember]
        public string authdb
        { get; set; }

        [DataMember]
        public string sshHost
        { get; set; }

        [DataMember]
        public int sshPort
        { get; set; }

        [DataMember]
        public uint sshForwardedPort
        { get; set; }

        [DataMember]
        public string sshUser
        { get; set; }

        public string sshPassword
        {
            get
            {
                if (_encryptedSshPassword == String.Empty)
                    return String.Empty;
                else
                    return _encryptedSshPassword.DecryptString(Encoding.Unicode.GetBytes(sshEntropy)).ToInsecureString();
            }
            set
            {
                if (value != String.Empty)
                    _encryptedSshPassword = value.ToSecureString().EncryptString(Encoding.Unicode.GetBytes(sshEntropy));
            }
        }

        [DataMember]
        public bool useSSHTunnel
        { get; set; }

        [DataMember]
        public string sshEntropy
        { get; private set; }
    }
}