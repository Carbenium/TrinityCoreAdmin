using System;
using System.Collections.Generic;
using System.Data;
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

        public WorldDatabase worldDB;
        public AuthDatabase authDB;

        private void Form1_Load(object sender, EventArgs e)
        {
            ServerManager.LoadRealms();
            StartDB();
        }

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

            if (frmRealmManager.connSuccess)
                LoadAccounts();
        }

        private void verbindenToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        private void StartDB()
        {
            //MySql.Data.MySqlClient.MySqlConnectionStringBuilder authString = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder();
            //authString.Server = "localhost";
            //authString.UserID = "root";
            //authString.Password = "";
            //authString.Database = "auth";

            //authDB = new AuthDatabase(authString);
            //authDB.Open();
            //authDB.DoPrepareStatments();

            //MySql.Data.MySqlClient.MySqlConnectionStringBuilder worldString = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder();
            //worldString.Server = "192.168.2.10";
            //worldString.Port = 3306;
            //worldString.UserID = "root";
            //worldString.Database = "world";

            //worldDB = new WorldDatabase(worldString);
            //worldDB.Open();
            //worldDB.DoPrepareStatments();

            //MySql.Data.MySqlClient.MySqlCommand stmt =  authDB.GetPreparedStatement(AuthDatabase.AuthDatabaseStatements.AUTH_SEL_ACCOUNTS);

            //stmt.Parameters.AddWithValue("@name", "d-sat");

            //try
            //{
            //    dt = authDB.Execute(stmt);
            //}
            //catch (MySql.Data.MySqlClient.MySqlException e)
            //{

            //    MessageBox.Show(e.Message);
            //}
            

            //foreach (DataRow row in dt.Rows)
            //{
            //    ListViewItem item = new ListViewItem(row[0].ToString());
            //    for (int i = 1; i < dt.Columns.Count; i++)
            //    {
            //        item.SubItems.Add(row[i].ToString());
            //    }

            //    listViewAccounts.Items.Add(item);
            //}
        }

        private void LoadAccounts()
        {
            foreach (Account acc in Account.accounts)
            {
                ListViewItem item = new ListViewItem(acc.id.ToString());
                item.SubItems.Add(acc.username);
                item.SubItems.Add(acc.reg_mail);
                item.SubItems.Add(acc.email);
                item.SubItems.Add(acc.joindate.ToShortDateString());
                item.SubItems.Add(acc.last_ip);
                item.SubItems.Add(acc.failed_logins.ToString());
                item.SubItems.Add(acc.last_login.ToString());
                item.SubItems.Add(acc.online.ToString());
                item.SubItems.Add(acc.expansion.ToString());

                listViewAccounts.Items.Add(item);
            }

            listViewAccounts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void StopDB()
        {
            MySQLConnection.CloseConnections();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopDB();
        }
    }
}