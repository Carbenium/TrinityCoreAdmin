using System.Runtime.Serialization;

namespace TrinityCoreAdmin
{
    [DataContract]
    public class Realm
    {
        public WorldDatabase worldDBConn;

        public static Realm currRealm;

        public Realm()
        { }

        public Realm(int dbId, string name, string chardb, string worlddb)
        {
            DbId = dbId;
            Name = name;
            Chardb = chardb;
            Worlddb = worlddb;

            currRealm = this;
        }

        [DataMember]
        public string Chardb
        { get; set; }

        [DataMember]
        public int DbId
        { get; set; }

        [DataMember]
        public string Name
        { get; set; }

        [DataMember]
        public string Worlddb
        { get; set; }
    }
}