using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using System;
using System.Windows.Forms;
using TrinityCoreAdmin.Forms;

namespace TrinityCoreAdmin
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point of the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // Configure log4net
            // TODO: Convert to XmlConfigurator
            FileAppender fileAppender = new FileAppender();
            fileAppender.AppendToFile = true;
            fileAppender.LockingModel = new FileAppender.MinimalLock();
            fileAppender.File = "log.txt";
            PatternLayout pl = new PatternLayout();
            pl.ConversionPattern = "%d [%2%t] %-5p [%-10c]   %m%n%n";
            pl.ActivateOptions();
            fileAppender.Layout = pl;
            fileAppender.ActivateOptions();
            BasicConfigurator.Configure(fileAppender);

            Application.ApplicationExit += Application_ApplicationExit;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainForm.GetInstance());
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            MySQLConnection.CloseConnections();
            SshConnection.CloseConnections();
        }
    }
}