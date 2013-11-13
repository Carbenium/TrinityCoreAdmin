using System;
using System.IO;
using System.Windows.Forms;

namespace TrinityCoreAdmin.Forms
{
    public partial class RealmManagerForm : Form
    {
        public bool connSuccess = false;

        public RealmManagerForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeServers.SelectedNode;

            if (selectedNode.Tag.GetType() == typeof(Realm))
            {
                Server selectedServer = (Server)selectedNode.Parent.Tag;
                Realm selectedRealm = (Realm)selectedNode.Tag;

                if (selectedServer.Host != String.Empty && selectedServer.User != String.Empty)
                {
                    if (selectedServer.Authdb != String.Empty)
                    {
                        MySql.Data.MySqlClient.MySqlConnectionStringBuilder authString = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder();
                        authString.Server = selectedServer.Host;
                        authString.UserID = selectedServer.User;
                        authString.Password = selectedServer.Password;
                        authString.Database = selectedServer.Authdb;

                        selectedServer.authDBConn = new AuthDatabase(authString);
                        connSuccess = selectedServer.authDBConn.Open();

                        ServerManager.currServer = selectedServer;
                        ServerManager.currRealm = selectedRealm;
                        selectedServer.authDBConn.DoPrepareStatments();

                        Account.LoadAccountsFromDB();
                    }
                }
            }
            if (connSuccess)
                this.Close();
        }

        private void btnNewRealm_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeServers.SelectedNode;
            Server parentServer;

            if (selectedNode.Tag.GetType() == typeof(Realm))
            {
                parentServer = (Server)selectedNode.Parent.Tag;
                selectedNode = selectedNode.Parent;
            }
            else
            {
                parentServer = (Server)selectedNode.Tag;
            }

            if (treeServers.SelectedNode.Tag.GetType() == typeof(Realm))
                UpdateRealm((Realm)treeServers.SelectedNode.Tag);

            if (treeServers.SelectedNode.Tag.GetType() == typeof(Server))
                UpdateServer((Server)treeServers.SelectedNode.Tag);

            ClearTextBoxes(panelRealm);
            numPort.Value = 3306;
            ServerManager.Status = RealmsStatus.NEW;

            TreeNode newNode = new TreeNode("Neuer Realm");
            Realm newRealm = new Realm();

            newNode.Tag = newRealm;

            parentServer.realms.Add(newRealm);
            selectedNode.Nodes.Add(newNode);

            treeServers.SelectedNode = newNode;
            newNode.BeginEdit();
            SetEnabledControls(panelRealm, true);
        }

        private void btnNewServer_Click(object sender, EventArgs e)
        {
            TreeNode newNode = new TreeNode("Neuer Server");
            Server newServer = new Server();
            newNode.Tag = newServer;

            ServerManager.servers.Add(newServer);
            treeServers.Nodes.Add(newNode);

            treeServers.SelectedNode = newNode;
            newNode.BeginEdit();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeServers.SelectedNode;
            if (selectedNode != null)
            {
                if (selectedNode.Tag.GetType() == typeof(Realm))
                {
                    Realm r = (Realm)selectedNode.Tag;
                    r.Name = selectedNode.Text;
                    UpdateRealm((Realm)selectedNode.Tag);
                }
                else if (selectedNode.Tag.GetType() == typeof(Server))
                {
                    Server s = (Server)selectedNode.Tag;
                    s.Name = selectedNode.Text;
                    UpdateServer((Server)treeServers.SelectedNode.Tag);
                }
            }

            ServerManager.Save();
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeServers.SelectedNode;
            if (selectedNode.Tag.GetType() == typeof(Realm))
            {
                Server s = (Server)selectedNode.Parent.Tag;
                s.realms.Remove((Realm)selectedNode.Tag);
            }
            else if (selectedNode.Tag.GetType() == typeof(Server))
            {
                Server s = (Server)selectedNode.Tag;
                ServerManager.servers.Remove(s);
            }
            treeServers.SelectedNode.Remove();
        }

        private void ClearTextBoxes(Panel p)
        {
            for (int i = 0; i < p.Controls.Count; i++)
            {
                if (p.Controls[i].GetType() == typeof(TextBox))
                {
                    p.Controls[i].Text = string.Empty;
                }
            }
        }

        private void LoadRealmsToTree()
        {
            FileInfo f = new FileInfo("D:\\config.xml");
            if (!f.Exists)
            {
                ServerManager.Save(true);
            }

            treeServers.Nodes.Clear();

            foreach (Server s in ServerManager.servers)
            {
                TreeNode sNode = new TreeNode(s.Name);
                sNode.Tag = s;
                treeServers.Nodes.Add(sNode);

                foreach (Realm r in s.realms)
                {
                    TreeNode rNode = new TreeNode(r.Name);
                    rNode.Tag = r;
                    sNode.Nodes.Add(rNode);
                }
            }
            treeServers.ExpandAll();
        }

        private void SetEnabledControls(Panel p, bool enabled)
        {
            if (treeServers.SelectedNode.Tag.GetType() == typeof(Realm))
            {
                Realm r = (Realm)treeServers.SelectedNode.Tag;
                Server s = (Server)treeServers.SelectedNode.Parent.Tag;

                txtHost.Enabled = false;
                numPort.Enabled = false;
                txtUser.Enabled = false;
                txtPassword.Enabled = false;
                txtAuthDB.Enabled = false;

                txtCharDB.Enabled = true;
                txtWorldDB.Enabled = true;
                numDbId.Enabled = true;

                txtHost.Text = s.Host;
                numPort.Value = s.Port;
                txtUser.Text = s.User;
                txtPassword.Text = s.Password;
                txtAuthDB.Text = s.Authdb;
                numDbId.Value = r.DbId;
                txtCharDB.Text = r.Chardb;
                txtWorldDB.Text = r.Worlddb;
            }
            else if (treeServers.SelectedNode.Tag.GetType() == typeof(Server))
            {
                Server s = (Server)treeServers.SelectedNode.Tag;
                txtHost.Enabled = true;
                numPort.Enabled = true;
                txtUser.Enabled = true;
                txtPassword.Enabled = true;
                txtAuthDB.Enabled = true;

                txtCharDB.Enabled = false;
                txtWorldDB.Enabled = false;
                numDbId.Enabled = false;

                numPort.Value = 3306;
                txtHost.Text = s.Host;
                numPort.Value = s.Port;
                txtUser.Text = s.User;
                txtPassword.Text = s.Password;
                txtAuthDB.Text = s.Authdb;
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            LoadRealmsToTree();
        }

        private void treeServers_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            this.BeginInvoke((MethodInvoker)delegate
                {
                    if (selectedNode.Tag.GetType() == typeof(Realm))
                    {
                        Realm r = (Realm)selectedNode.Tag;
                        r.Name = e.Node.Text;
                        UpdateRealm((Realm)selectedNode.Tag);
                    }
                    else if (selectedNode.Tag.GetType() == typeof(Server))
                    {
                        Server s = (Server)selectedNode.Tag;
                        s.Name = e.Node.Text;
                        UpdateServer((Server)treeServers.SelectedNode.Tag);
                    }
                });
        }

        private void treeServers_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ClearTextBoxes(panelRealm);
            SetEnabledControls(panelRealm, true);
        }

        private void treeServers_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (treeServers.SelectedNode != null && ServerManager.Status != RealmsStatus.NEW)
            {
                if (treeServers.SelectedNode.Tag.GetType() == typeof(Realm))
                {
                    UpdateRealm((Realm)treeServers.SelectedNode.Tag);
                }
                else if (treeServers.SelectedNode.Tag.GetType() == typeof(Server))
                {
                    UpdateServer((Server)treeServers.SelectedNode.Tag);
                }
            }
        }

        private void UpdateRealm(Realm r)
        {
            r.DbId = XConverter.ToInt32(numDbId.Value);
            r.Chardb = txtCharDB.Text;
            r.Worlddb = txtWorldDB.Text;

            ServerManager.Status = RealmsStatus.SAVED;
        }

        private void UpdateServer(Server s)
        {
            s.Host = txtHost.Text;
            s.Port = XConverter.ToInt32(numPort.Value);
            s.User = txtUser.Text;
            s.Password = txtPassword.Text;
            s.Authdb = txtAuthDB.Text;

            ServerManager.Status = RealmsStatus.SAVED;
        }
    }
}