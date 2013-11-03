using System;
using System.Collections.Generic;
using System.Windows.Forms;

//using MySql.Data.MySqlClient;

namespace TrinityCoreAdmin.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private List<string> accountData = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            //string server = Settings1.Default.server;
            //string database = Settings1.Default.database;
            //string user = Settings1.Default.user;
            RealmManager.LoadRealms();

            MessageBox.Show(RealmManager.realms[0].Name);
            MySql.Data.MySqlClient.MySqlConnectionStringBuilder authString = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder();
            authString.Server = "localhost";
            authString.Port = 3306;
            authString.UserID = "root";

            AuthDatabase auth = new AuthDatabase(authString);
            auth.DoPrepareStatments();

            //listViewUsers.Columns.Add("Benutzername", 100);
            //listViewUsers.Columns.Add("E-Mail");
            //listViewUsers.Columns.Add("Online");
        }

        //private void btn_Connect_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string cmdtxt = "SELECT * FROM account";
        //        //string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + user + ";" + "PASSWORD=" + txt_Pass.Text + ";";
        //        MySqlConnection conn = new MySqlConnection(connectionString);
        //        MySqlCommand cmd = conn.CreateCommand();
        //        cmd.CommandText = cmdtxt;
        //        MySqlDataReader reader;
        //        conn.Open();
        //        reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            lst_Accounts.Items.Add(new ListViewItem(new string[]{reader["username"].ToString(), reader["email"].ToString(), reader["online"].ToString()}));
        //        }
        //        conn.Close();
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    catch (TimeoutException ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }

        //}

        //private void lst_Accounts_ColumnClick(object sender, ColumnClickEventArgs e)
        //{
        //    if (listViewUsers.Sorting == SortOrder.Ascending)
        //    {
        //        listViewUsers.Sorting = SortOrder.Descending;
        //        listViewUsers.ListViewItemSorter = new ListViewComparer(e.Column, SortOrder.Descending);
        //    }
        //    else
        //    {
        //        listViewUsers.Sorting = SortOrder.Ascending;
        //        listViewUsers.ListViewItemSorter = new ListViewComparer(e.Column, SortOrder.Ascending);
        //    }
        //}

        private void realmmanagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RealmManagerForm frmRealmManager = new RealmManagerForm();
            frmRealmManager.ShowInTaskbar = false;
            frmRealmManager.ShowDialog();
        }

        private void verbindenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string host;
            //string port;
            //string user;
            //string authdb;
            //string charactersdb;
            //string worlddb;

            //Settings settings = new Settings();
            //settings.ShowDialog();
            //host = settings.settinghost;
            //port = settings.settingport;
            //user = settings.settinguser;
            //authdb = settings.settingauthdb;
            //charactersdb = settings.settingcharacterdb;
            //worlddb = settings.settingworlddb;
            //if (settings.DialogResult == DialogResult.OK)
            //{
            //    try
            //    {
            //        string cmdtxt = "SELECT * FROM account";
            //        string connectionString = "SERVER=" + host + ";" + "DATABASE=" + authdb + ";" + "UID=" + user + ";" + "PASSWORD=" + "uvat6esu66" + ";";
            //        MySqlConnection conn = new MySqlConnection(connectionString);
            //        MySqlCommand cmd = conn.CreateCommand();
            //        cmd.CommandText = cmdtxt;
            //        MySqlDataReader reader;
            //        conn.Open();
            //        reader = cmd.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            lst_Accounts.Items.Add(new ListViewItem(new string[] { reader["username"].ToString(), reader["email"].ToString(), reader["online"].ToString() }));
            //        }
            //        conn.Close();
            //    }
            //    catch (MySqlException ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //    catch (TimeoutException ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }

            //}
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm frmSettings = new SettingsForm();
            frmSettings.ShowInTaskbar = false;
            frmSettings.ShowDialog();
        }

    }
}