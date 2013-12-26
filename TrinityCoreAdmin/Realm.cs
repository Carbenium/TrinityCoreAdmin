using System.Runtime.Serialization;

namespace TrinityCoreAdmin
{
    [DataContract]
    public class Realm
    {
        public Realm()
        { }

        public Realm(int dbId, string name, string chardb, string worlddb)
        {
            this.dbId = dbId;
            this.name = name;
            this.chardb = chardb;
            this.worlddb = worlddb;
        }

        [DataMember]
        public string chardb
        { get; set; }

        [DataMember]
        public int dbId
        { get; set; }

        [DataMember]
        public string name
        { get; set; }

        [DataMember]
        public string worlddb
        { get; set; }

        public WorldDatabase worldDBConn
        { get; set; }

        public CharDatabase charDBConn
        { get; set; }
    }
}