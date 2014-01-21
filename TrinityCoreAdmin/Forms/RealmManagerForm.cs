using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Windows.Forms;

namespace TrinityCoreAdmin.Forms
{
    public partial class RealmManagerForm : Form
    {
        public bool connSuccess = false;
        private MainForm mainForm;

        public RealmManagerForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            LoadRealmsToTree();
        }

        private void LoadRealmsToTree()
        {
            FileInfo f = new FileInfo(Properties.Settings.Default.ServerSettingsSavePath + Path.DirectorySeparatorChar + Properties.Settings.Default.ServerSettingsFile);
            if (!f.Exists)
            {
                ServerManager.Save(true);
            }

            treeServers.Nodes.Clear();

            foreach (Server s in ServerManager.servers)
            {
                TreeNode sNode = new TreeNode(s.name);
                sNode.Tag = s;
                treeServers.Nodes.Add(sNode);

                foreach (Realm r in s.realms)
                {
                    TreeNode rNode = new TreeNode(r.name);
                    rNode.Tag = r;
                    sNode.Nodes.Add(rNode);
                }
            }
            treeServers.ExpandAll();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void treeServers_DoubleClick(object sender, EventArgs e)
        {
            Connect();
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

            ClearTextBoxes(panelSQL);
            numSQLPort.Value = 3306;
            ServerManager.Status = RealmsStatus.NEW;

            TreeNode newNode = new TreeNode("Neuer Realm");
            Realm newRealm = new Realm();

            newNode.Tag = newRealm;

            parentServer.realms.Add(newRealm);
            selectedNode.Nodes.Add(newNode);

            treeServers.SelectedNode = newNode;
            newNode.BeginEdit();
            SetEnabledControls(panelSQL, true);
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
                    r.name = selectedNode.Text;
                    UpdateRealm((Realm)selectedNode.Tag);
                }
                else if (selectedNode.Tag.GetType() == typeof(Server))
                {
                    Server s = (Server)selectedNode.Tag;
                    s.name = selectedNode.Text;
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

        private void SetEnabledControls(Panel p, bool enabled)
        {
            if (treeServers.SelectedNode.Tag.GetType() == typeof(Realm))
            {
                Realm r = (Realm)treeServers.SelectedNode.Tag;
                Server s = (Server)treeServers.SelectedNode.Parent.Tag;

                txtSQLHost.Enabled = false;
                numSQLPort.Enabled = false;
                txtSQLUser.Enabled = false;
                txtSQLPassword.Enabled = false;
                txtAuthDB.Enabled = false;
                txtSSHHost.Enabled = false;
                txtSSHUser.Enabled = false;
                txtSSSHPassword.Enabled = false;
                numSSHPort.Enabled = false;
                numLocalSSHPort.Enabled = false;
                chkUseSSH.Enabled = false;

                txtCharDB.Enabled = true;
                txtWorldDB.Enabled = true;
                numRealmId.Enabled = true;
                btnConnect.Enabled = true;

                txtSQLHost.Text = s.sqlHost;
                numSQLPort.Value = s.sqlPort;
                txtSQLUser.Text = s.sqlUser;
                txtSQLPassword.Text = s.sqlPassword;
                txtAuthDB.Text = s.authdb;
                numRealmId.Value = r.dbId;
                txtCharDB.Text = r.chardb;
                txtWorldDB.Text = r.worlddb;
                txtSSHHost.Text = s.sshHost;
                txtSSHUser.Text = s.sshUser;
                txtSSSHPassword.Text = s.sshPassword;
                numLocalSSHPort.Value = s.sshForwardedPort;
                chkUseSSH.Checked = s.useSSHTunnel;
            }
            else if (treeServers.SelectedNode.Tag.GetType() == typeof(Server))
            {
                Server s = (Server)treeServers.SelectedNode.Tag;
                txtSQLHost.Enabled = true;
                numSQLPort.Enabled = true;
                txtSQLUser.Enabled = true;
                txtSQLPassword.Enabled = true;
                txtAuthDB.Enabled = true;
                txtSSHHost.Enabled = true;
                txtSSHUser.Enabled = true;
                txtSSSHPassword.Enabled = true;
                numSSHPort.Enabled = true;
                numLocalSSHPort.Enabled = true;
                chkUseSSH.Enabled = true;

                txtCharDB.Enabled = false;
                txtWorldDB.Enabled = false;
                numRealmId.Enabled = false;
                btnConnect.Enabled = false;

                txtSQLHost.Text = s.sqlHost;
                numSQLPort.Value = s.sqlPort;
                txtSQLUser.Text = s.sqlUser;
                txtSQLPassword.Text = s.sqlPassword;
                txtAuthDB.Text = s.authdb;
                txtSSHHost.Text = s.sshHost;
                txtSSHUser.Text = s.sshUser;
                txtSSSHPassword.Text = s.sshPassword;
                numLocalSSHPort.Value = s.sshForwardedPort;
                chkUseSSH.Checked = s.useSSHTunnel;
            }
        }

        private void treeServers_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            this.BeginInvoke((MethodInvoker)delegate
                {
                    if (selectedNode.Tag.GetType() == typeof(Realm))
                    {
                        Realm r = (Realm)selectedNode.Tag;
                        r.name = e.Node.Text;
                        UpdateRealm((Realm)selectedNode.Tag);
                    }
                    else if (selectedNode.Tag.GetType() == typeof(Server))
                    {
                        Server s = (Server)selectedNode.Tag;
                        s.name = e.Node.Text;
                        UpdateServer((Server)treeServers.SelectedNode.Tag);
                    }
                });
        }

        private void treeServers_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ClearTextBoxes(panelSQL);
            SetEnabledControls(panelSQL, true);
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

        private void UpdateRealm(Realm r)
        {
            r.dbId = XConverter.ToInt32(numRealmId.Value);
            r.chardb = txtCharDB.Text;
            r.worlddb = txtWorldDB.Text;

            ServerManager.Status = RealmsStatus.SAVED;
        }

        private void UpdateServer(Server s)
        {
            s.sqlHost = txtSQLHost.Text;
            s.sqlPort = XConverter.ToUInt32(numSQLPort.Value);
            s.sqlUser = txtSQLUser.Text;
            s.sqlPassword = txtSQLPassword.Text;
            s.authdb = txtAuthDB.Text;

            s.sshHost = txtSSHHost.Text;
            s.sshPort = XConverter.ToInt32(numSSHPort.Value);
            s.sshUser = txtSSHUser.Text;
            s.sshPassword = txtSSSHPassword.Text;
            s.sshForwardedPort = XConverter.ToUInt32(numLocalSSHPort.Value);
            s.useSSHTunnel = chkUseSSH.Checked;

            ServerManager.Status = RealmsStatus.SAVED;
        }

        private async void Connect()
        {
            mainForm.ResetStatusStripColors();
            TreeNode selectedNode = treeServers.SelectedNode;

            if (selectedNode.Tag.GetType() == typeof(Realm))
            {
                Server selectedServer = (Server)selectedNode.Parent.Tag;
                Realm selectedRealm = (Realm)selectedNode.Tag;
                RealmManager.currRealm = selectedRealm;

                if (selectedServer.useSSHTunnel)
                {
                    if (selectedServer.sshHost != String.Empty && selectedServer.sshUser != String.Empty)
                    {
                        ServerManager.initSSH(new SshConnection(selectedServer.sshHost, selectedServer.sshPort, selectedServer.sshUser, selectedServer.sshPassword));
                        ServerManager.sshConn.AddForwardedPort(selectedServer.sshForwardedPort, selectedServer.sqlHost, selectedServer.sqlPort);
                    }
                }

                if (selectedServer.sqlHost != String.Empty && selectedServer.sqlUser != String.Empty)
                {
                    if (selectedServer.authdb != String.Empty)
                    {
                        MySqlConnectionStringBuilder authString = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder();
                        authString.Server = selectedServer.sqlHost;

                        if (ServerManager.sshConn != null && ServerManager.sshConn.isConnected)
                            authString.Port = selectedServer.sshForwardedPort;
                        else
                            authString.Port = selectedServer.sqlPort;

                        authString.UserID = selectedServer.sqlUser;
                        authString.Password = selectedServer.sqlPassword;
                        authString.Database = selectedServer.authdb;

                        connSuccess = ServerManager.InitDB(new AuthDatabase(authString));
                    }

                    if (selectedRealm.chardb != String.Empty)
                    {
                        MySqlConnectionStringBuilder charString = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder();
                        charString.Server = selectedServer.sqlHost;

                        if (ServerManager.sshConn != null && ServerManager.sshConn.isConnected)
                            charString.Port = selectedServer.sshForwardedPort;
                        else
                            charString.Port = selectedServer.sqlPort;

                        charString.UserID = selectedServer.sqlUser;
                        charString.Password = selectedServer.sqlPassword;
                        charString.Database = selectedRealm.chardb;

                        connSuccess = ServerManager.InitDB(new CharDatabase(charString));
                    }
                }
            }
            if (connSuccess)
            {
                await Account.LoadAccountsFromDB();
                ServerManager.Save();
                this.Close();
            }
        }
    }
}