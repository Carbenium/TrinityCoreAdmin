using log4net.Config;
using System;
using System.Windows.Forms;
using TrinityCoreAdmin.Forms;

namespace TrinityCoreAdmin
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // Configure log4net
            // TODO: Convert to XmlConfigurator
            BasicConfigurator.Configure();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}