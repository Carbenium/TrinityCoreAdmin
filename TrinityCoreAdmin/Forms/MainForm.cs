using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrinityCoreAdmin.Forms
{
    public partial class MainForm : Form
    {
        private List<Account> filteredAccounts = new List<Account>();

        public MainForm()
        {
            InitializeComponent();

            if (Properties.Settings.Default.firstStart)
                new FirstStartForm().ShowDialog();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            ServerManager.LoadRealms();
        }

        private Dictionary<int, SortOrder> SortOrderMap = new Dictionary<int, SortOrder>
        {
            {0, SortOrder.None},
            {1, SortOrder.None},
            {2, SortOrder.None},
            {3, SortOrder.None},
            {4, SortOrder.None},
            {5, SortOrder.None},
            {6, SortOrder.None},
            {7, SortOrder.None},
            {8, SortOrder.None},
            {9, SortOrder.None}
        };

        private Dictionary<int, Comparison<Account>> SortComparers = new Dictionary<int, Comparison<Account>>
        {
            {0, (a,b) => a.online.CompareTo(b.online)},
            {1, (a,b) => a.id.CompareTo(b.id)},
            {2, (a,b) => a.username.CompareTo(b.username)},
            {3, (a,b) => a.reg_mail.CompareTo(b.reg_mail)},
            {4, (a,b) => a.email.CompareTo(b.email)},
            {5, (a,b) => a.joindate.CompareTo(b.joindate)},
            {6, (a,b) => a.last_ip.CompareTo(b.last_ip)},
            {7, (a,b) => a.failed_logins.CompareTo(b.failed_logins)},
            {8, (a,b) => a.last_login.CompareTo(b.last_login)},
            {9, (a,b) => a.expansion.CompareTo(b.expansion)}
        };

        /// <summary>
        /// State transitions from one sort order to another
        /// </summary>
        private Dictionary<SortOrder, SortOrder> SortToggle = new Dictionary<SortOrder, SortOrder>
        {
            {SortOrder.None, SortOrder.Ascending },
            {SortOrder.Ascending, SortOrder.Descending},
            {SortOrder.Descending, SortOrder.Ascending}
        };

        private void listViewAccounts_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var newSortOrder = SortToggle[SortOrderMap[e.Column]];
            SortOrderMap[e.Column] = newSortOrder;     // Store sort order for current column

            // Perform the sort with these new sort options.
            Account.SortBy(newSortOrder, SortComparers[e.Column]);
            this.listViewAccounts.Refresh();
        }

        public void authDBConn_OnToggleConnectionStateHandler(object sender, OnConnectionStateEventArgs e)
        {
            if (e.connState == ConnectionState.Open)
            {
                this.statusStripChar.ForeColor = Color.Green;
            }
            else if (e.connState == ConnectionState.Closed)
            {
                this.statusStripChar.ForeColor = Color.Red;
            }
        }

        public void sshConn_OnToggleConnectionStateHandler(object sender, OnConnectionStateEventArgs e)
        {
            if (e.connState == ConnectionState.Open)
            {
                this.statusStripSSH.ForeColor = Color.Green;
            }
            else if (e.connState == ConnectionState.Closed)
            {
                this.statusStripSSH.ForeColor = Color.Red;
            }
        }

        private void realmmanagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RealmManagerForm frmRealmManager = new RealmManagerForm(this);
            frmRealmManager.ShowInTaskbar = false;
            frmRealmManager.ShowDialog();

            if (frmRealmManager.connSuccess)
            {
                filteredAccounts = new List<Account>(Account.GetAccounts());
                listViewAccounts.VirtualListSize = filteredAccounts.Count;
            }
        }

        private void toolStripCloseConnections_Click(object sender, EventArgs e)
        {
            MySQLConnection.CloseConnections();
            SshConnection.CloseConnections();
            Account.ClearAccounts();
        }

        private void toolStripBtnDisconnect_Click(object sender, EventArgs e)
        {
            MySQLConnection.CloseConnections();
            SshConnection.CloseConnections();
            Account.ClearAccounts();
        }

        private void listViewAccounts_DoubleClick(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = this.listViewAccounts.SelectedIndices;

            for (int i = 0; i < 1; i++)
            {
                int index = indexes[i];
                new EditAccountForm((Account)this.listViewAccounts.Items[index].Tag).ShowDialog();
            }
        }

        public void ResetStatusStripColors()
        {
            statusStripAuth.ForeColor = Color.Gray;
            statusStripChar.ForeColor = Color.Gray;
            statusStripWorld.ForeColor = Color.Gray;
            statusStripSSH.ForeColor = Color.Gray;
        }

        private void listViewAccounts_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            var acc = filteredAccounts[e.ItemIndex];

            ListViewItem item = new ListViewItem();
            item.UseItemStyleForSubItems = false;

            if (acc.online)
                item.SubItems[0].BackColor = Color.Green;
            else
                item.SubItems[0].BackColor = Color.Red;

            item.SubItems.Add(acc.id.ToString());
            item.SubItems.Add(acc.username);
            item.SubItems.Add(acc.reg_mail);
            item.SubItems.Add(acc.email);
            item.SubItems.Add(acc.joindate.ToShortDateString());
            item.SubItems.Add(acc.last_ip);
            item.SubItems.Add(acc.failed_logins.ToString());
            item.SubItems.Add(acc.last_login.ToString());
            item.SubItems.Add(acc.expansion.ToString());

            item.Tag = acc;

            e.Item = item;
        }

        private void listViewAccounts_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Cancel = true;
                e.NewWidth = this.listViewAccounts.Columns[e.ColumnIndex].Width;
            }
        }

        private void listViewAccounts_SearchForVirtualItem(object sender, SearchForVirtualItemEventArgs e)
        {
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Suche...")
                txtSearch.Text = "";
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                return;

            txtSearch.Text = "Suche...";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string s = txtSearch.Text;
            List<Account> accs = Account.GetAccounts();

            if (s != "Suche...")
            {
                filteredAccounts.Clear();

                foreach (var acc in accs.Where(acc => (acc.id.ToString().IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                  acc.username.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                  acc.reg_mail.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                  acc.email.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                  acc.joindate.ToString().IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                  acc.last_ip.ToString().IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                  acc.last_login.ToString().IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                  acc.expansion.ToString().IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0)))
                {
                    filteredAccounts.Add(acc);
                }
                listViewAccounts.VirtualListSize = filteredAccounts.Count;
                listViewAccounts.Invalidate();
            }
        }
    }
}
