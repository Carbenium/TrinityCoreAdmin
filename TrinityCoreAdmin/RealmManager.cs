using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace TrinityCoreAdmin
{
    static class RealmManager
    {
        public static List<Realm> realms = new List<Realm>();

       

        public static RealmsStatus Status = RealmsStatus.SAVED;

        public static void LoadRealms()
        {
            FileInfo f = new FileInfo("D:\\config.xml");
            if (f.Exists)
            {
                using (FileStream fs = f.OpenRead())
                {
                    realms = DeserializeRealms(fs);
                }
            }
            else
            {
                Save(true);
            }

        }

        public static void Save(bool reload = false)
        {
            try
            {
                using (FileStream fs = new FileStream("D:\\config.xml", System.IO.FileMode.Create))
                {
                    bool success = SerializeRealms(realms, fs);

                    if (reload && success)
                    {
                        fs.Position = 0;
                        realms = DeserializeRealms(fs);
                    }
                }

                
            }
            catch (SystemException e)
            {
                MessageBox.Show(e.Message);
            }
            Status = RealmsStatus.SAVED;
        }

        private static bool SerializeRealms(List<Realm> realms, FileStream stream)
        {
            try
            {
                var serializer = new DataContractSerializer(typeof(List<Realm>));
                var settings = new XmlWriterSettings { Indent = true };
                using (var w = XmlWriter.Create(stream, settings))
                    serializer.WriteObject(w, realms);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        private static List<Realm> DeserializeRealms(FileStream stream)
        {
            var serializer = new DataContractSerializer(typeof(List<Realm>));
            try
            {
                List<Realm> l = (List<Realm>)serializer.ReadObject(stream);
                return l;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return realms;
            }
        }
    }
}
