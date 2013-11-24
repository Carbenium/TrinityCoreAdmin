using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml;

namespace TrinityCoreAdmin
{
    internal static class ServerManager
    {
        public static List<Server> servers = new List<Server>();
        public static Server currServer;

        public static RealmsStatus Status = RealmsStatus.SAVED;

        public static void LoadRealms()
        {
            FileInfo f = new FileInfo(Properties.Settings.Default.ServerSettingsSavePath + Path.DirectorySeparatorChar + Properties.Settings.Default.ServerSettingsFile);
            if (f.Exists)
            {
                using (FileStream fs = f.OpenRead())
                {
                    servers = DeserializeServers(fs);
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
                using (FileStream fs = new FileStream(Properties.Settings.Default.ServerSettingsSavePath + Path.DirectorySeparatorChar  + Properties.Settings.Default.ServerSettingsFile, System.IO.FileMode.Create))
                {
                    bool success = SerializeServers(servers, fs);

                    if (reload && success)
                    {
                        fs.Position = 0;
                        servers = DeserializeServers(fs);
                    }
                }
            }
            catch (SystemException e)
            {
                MessageBox.Show(e.Message);
            }
            Status = RealmsStatus.SAVED;
        }

        private static bool SerializeServers(List<Server> s, FileStream stream)
        {
            try
            {
                var serializer = new DataContractSerializer(typeof(List<Server>));
                var settings = new XmlWriterSettings { Indent = true };
                using (var w = XmlWriter.Create(stream, settings))
                    serializer.WriteObject(w, s);
            }
            catch (Exception e)
            {
                Logger.LOG_GENERAL.Error("Could not serialize server: " + e.Message);

                return false;
            }
            Logger.LOG_GENERAL.Info(s.Count + " server(s) successfully saved.");
            return true;
        }

        private static List<Server> DeserializeServers(FileStream stream)
        {
            var serializer = new DataContractSerializer(typeof(List<Server>));
            try
            {
                List<Server> l = (List<Server>)serializer.ReadObject(stream);
                Logger.LOG_GENERAL.Info(l.Count + " server(s) successfully loaded.");

                return l;
            }
            catch (Exception e)
            {
                Logger.LOG_GENERAL.Error("Could not deserialize servers: " + e.Message);

                return servers;
            }
        }
    }
}