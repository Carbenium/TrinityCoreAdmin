namespace TrinityCoreAdmin.Forms
{
    partial class RealmManagerForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeServers = new System.Windows.Forms.TreeView();
            this.btnNewRealm = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnNewServer = new System.Windows.Forms.Button();
            this.tabPSSH = new System.Windows.Forms.TabPage();
            this.panelSSH = new System.Windows.Forms.Panel();
            this.numLocalSSHPort = new System.Windows.Forms.NumericUpDown();
            this.lblLocalSSHPort = new System.Windows.Forms.Label();
            this.numSSHPort = new System.Windows.Forms.NumericUpDown();
            this.lblSSHPort = new System.Windows.Forms.Label();
            this.txtSSSHPassword = new System.Windows.Forms.TextBox();
            this.txtSSHUser = new System.Windows.Forms.TextBox();
            this.txtSSHHost = new System.Windows.Forms.TextBox();
            this.lblSSHPassword = new System.Windows.Forms.Label();
            this.lblSSHUser = new System.Windows.Forms.Label();
            this.lblSSHHost = new System.Windows.Forms.Label();
            this.tabPSQL = new System.Windows.Forms.TabPage();
            this.panelSQL = new System.Windows.Forms.Panel();
            this.chkUseSSH = new System.Windows.Forms.CheckBox();
            this.numRealmId = new System.Windows.Forms.NumericUpDown();
            this.lblRealmId = new System.Windows.Forms.Label();
            this.lblWorldDB = new System.Windows.Forms.Label();
            this.lblCharDB = new System.Windows.Forms.Label();
            this.txtWorldDB = new System.Windows.Forms.TextBox();
            this.txtCharDB = new System.Windows.Forms.TextBox();
            this.numSQLPort = new System.Windows.Forms.NumericUpDown();
            this.lblSQLPort = new System.Windows.Forms.Label();
            this.txtSQLPassword = new System.Windows.Forms.TextBox();
            this.txtAuthDB = new System.Windows.Forms.TextBox();
            this.txtSQLUser = new System.Windows.Forms.TextBox();
            this.txtSQLHost = new System.Windows.Forms.TextBox();
            this.lblAuthDB = new System.Windows.Forms.Label();
            this.lblSQLPassword = new System.Windows.Forms.Label();
            this.lblSQLUser = new System.Windows.Forms.Label();
            this.lblSQLHost = new System.Windows.Forms.Label();
            this.tabRealmManager = new System.Windows.Forms.TabControl();
            this.tabPSSH.SuspendLayout();
            this.panelSSH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLocalSSHPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSSHPort)).BeginInit();
            this.tabPSQL.SuspendLayout();
            this.panelSQL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRealmId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSQLPort)).BeginInit();
            this.tabRealmManager.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeServers
            // 
            this.treeServers.HideSelection = false;
            this.treeServers.LabelEdit = true;
            this.treeServers.Location = new System.Drawing.Point(12, 12);
            this.treeServers.Name = "treeServers";
            this.treeServers.ShowPlusMinus = false;
            this.treeServers.ShowRootLines = false;
            this.treeServers.Size = new System.Drawing.Size(147, 317);
            this.treeServers.TabIndex = 11;
            this.treeServers.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeServers_AfterLabelEdit);
            this.treeServers.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeServers_BeforeSelect);
            this.treeServers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeServers_AfterSelect);
            // 
            // btnNewRealm
            // 
            this.btnNewRealm.Location = new System.Drawing.Point(12, 364);
            this.btnNewRealm.Name = "btnNewRealm";
            this.btnNewRealm.Size = new System.Drawing.Size(78, 23);
            this.btnNewRealm.TabIndex = 12;
            this.btnNewRealm.Text = "Neuer Realm";
            this.btnNewRealm.UseVisualStyleBackColor = true;
            this.btnNewRealm.Click += new System.EventHandler(this.btnNewRealm_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(96, 335);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(63, 23);
            this.btnRemove.TabIndex = 14;
            this.btnRemove.Text = "Löschen";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(323, 364);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 22;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(404, 364);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(182, 335);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 24;
            this.btnConnect.Text = "Verbinden";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnNewServer
            // 
            this.btnNewServer.Location = new System.Drawing.Point(12, 335);
            this.btnNewServer.Name = "btnNewServer";
            this.btnNewServer.Size = new System.Drawing.Size(78, 23);
            this.btnNewServer.TabIndex = 25;
            this.btnNewServer.Text = "Neuer Server";
            this.btnNewServer.UseVisualStyleBackColor = true;
            this.btnNewServer.Click += new System.EventHandler(this.btnNewServer_Click);
            // 
            // tabPSSH
            // 
            this.tabPSSH.Controls.Add(this.panelSSH);
            this.tabPSSH.Location = new System.Drawing.Point(4, 22);
            this.tabPSSH.Name = "tabPSSH";
            this.tabPSSH.Padding = new System.Windows.Forms.Padding(3);
            this.tabPSSH.Size = new System.Drawing.Size(303, 291);
            this.tabPSSH.TabIndex = 2;
            this.tabPSSH.Text = "SSH";
            this.tabPSSH.UseVisualStyleBackColor = true;
            // 
            // panelSSH
            // 
            this.panelSSH.Controls.Add(this.numLocalSSHPort);
            this.panelSSH.Controls.Add(this.lblLocalSSHPort);
            this.panelSSH.Controls.Add(this.numSSHPort);
            this.panelSSH.Controls.Add(this.lblSSHPort);
            this.panelSSH.Controls.Add(this.txtSSSHPassword);
            this.panelSSH.Controls.Add(this.txtSSHUser);
            this.panelSSH.Controls.Add(this.txtSSHHost);
            this.panelSSH.Controls.Add(this.lblSSHPassword);
            this.panelSSH.Controls.Add(this.lblSSHUser);
            this.panelSSH.Controls.Add(this.lblSSHHost);
            this.panelSSH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSSH.Location = new System.Drawing.Point(3, 3);
            this.panelSSH.Name = "panelSSH";
            this.panelSSH.Size = new System.Drawing.Size(297, 285);
            this.panelSSH.TabIndex = 22;
            // 
            // numLocalSSHPort
            // 
            this.numLocalSSHPort.Location = new System.Drawing.Point(92, 124);
            this.numLocalSSHPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numLocalSSHPort.Name = "numLocalSSHPort";
            this.numLocalSSHPort.Size = new System.Drawing.Size(57, 20);
            this.numLocalSSHPort.TabIndex = 11;
            this.numLocalSSHPort.Value = new decimal(new int[] {
            3307,
            0,
            0,
            0});
            // 
            // lblLocalSSHPort
            // 
            this.lblLocalSSHPort.AutoSize = true;
            this.lblLocalSSHPort.Location = new System.Drawing.Point(7, 126);
            this.lblLocalSSHPort.Name = "lblLocalSSHPort";
            this.lblLocalSSHPort.Size = new System.Drawing.Size(67, 13);
            this.lblLocalSSHPort.TabIndex = 10;
            this.lblLocalSSHPort.Text = "Lokaler Port:";
            // 
            // numSSHPort
            // 
            this.numSSHPort.Location = new System.Drawing.Point(92, 46);
            this.numSSHPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numSSHPort.Name = "numSSHPort";
            this.numSSHPort.Size = new System.Drawing.Size(57, 20);
            this.numSSHPort.TabIndex = 3;
            this.numSSHPort.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            // 
            // lblSSHPort
            // 
            this.lblSSHPort.AutoSize = true;
            this.lblSSHPort.Location = new System.Drawing.Point(7, 48);
            this.lblSSHPort.Name = "lblSSHPort";
            this.lblSSHPort.Size = new System.Drawing.Size(29, 13);
            this.lblSSHPort.TabIndex = 9;
            this.lblSSHPort.Text = "Port:";
            // 
            // txtSSSHPassword
            // 
            this.txtSSSHPassword.Location = new System.Drawing.Point(92, 98);
            this.txtSSSHPassword.Name = "txtSSSHPassword";
            this.txtSSSHPassword.Size = new System.Drawing.Size(100, 20);
            this.txtSSSHPassword.TabIndex = 5;
            this.txtSSSHPassword.UseSystemPasswordChar = true;
            // 
            // txtSSHUser
            // 
            this.txtSSHUser.Location = new System.Drawing.Point(92, 72);
            this.txtSSHUser.Name = "txtSSHUser";
            this.txtSSHUser.Size = new System.Drawing.Size(100, 20);
            this.txtSSHUser.TabIndex = 4;
            // 
            // txtSSHHost
            // 
            this.txtSSHHost.Location = new System.Drawing.Point(92, 20);
            this.txtSSHHost.Name = "txtSSHHost";
            this.txtSSHHost.Size = new System.Drawing.Size(100, 20);
            this.txtSSHHost.TabIndex = 2;
            // 
            // lblSSHPassword
            // 
            this.lblSSHPassword.AutoSize = true;
            this.lblSSHPassword.Location = new System.Drawing.Point(7, 101);
            this.lblSSHPassword.Name = "lblSSHPassword";
            this.lblSSHPassword.Size = new System.Drawing.Size(53, 13);
            this.lblSSHPassword.TabIndex = 2;
            this.lblSSHPassword.Text = "Passwort:";
            // 
            // lblSSHUser
            // 
            this.lblSSHUser.AutoSize = true;
            this.lblSSHUser.Location = new System.Drawing.Point(7, 75);
            this.lblSSHUser.Name = "lblSSHUser";
            this.lblSSHUser.Size = new System.Drawing.Size(78, 13);
            this.lblSSHUser.TabIndex = 1;
            this.lblSSHUser.Text = "Benutzername:";
            // 
            // lblSSHHost
            // 
            this.lblSSHHost.AutoSize = true;
            this.lblSSHHost.Location = new System.Drawing.Point(7, 23);
            this.lblSSHHost.Name = "lblSSHHost";
            this.lblSSHHost.Size = new System.Drawing.Size(79, 13);
            this.lblSSHHost.TabIndex = 0;
            this.lblSSHHost.Text = "Hostname / IP:";
            // 
            // tabPSQL
            // 
            this.tabPSQL.Controls.Add(this.panelSQL);
            this.tabPSQL.Location = new System.Drawing.Point(4, 22);
            this.tabPSQL.Name = "tabPSQL";
            this.tabPSQL.Padding = new System.Windows.Forms.Padding(3);
            this.tabPSQL.Size = new System.Drawing.Size(303, 291);
            this.tabPSQL.TabIndex = 0;
            this.tabPSQL.Text = "SQL";
            this.tabPSQL.UseVisualStyleBackColor = true;
            // 
            // panelSQL
            // 
            this.panelSQL.Controls.Add(this.chkUseSSH);
            this.panelSQL.Controls.Add(this.numRealmId);
            this.panelSQL.Controls.Add(this.lblRealmId);
            this.panelSQL.Controls.Add(this.lblWorldDB);
            this.panelSQL.Controls.Add(this.lblCharDB);
            this.panelSQL.Controls.Add(this.txtWorldDB);
            this.panelSQL.Controls.Add(this.txtCharDB);
            this.panelSQL.Controls.Add(this.numSQLPort);
            this.panelSQL.Controls.Add(this.lblSQLPort);
            this.panelSQL.Controls.Add(this.txtSQLPassword);
            this.panelSQL.Controls.Add(this.txtAuthDB);
            this.panelSQL.Controls.Add(this.txtSQLUser);
            this.panelSQL.Controls.Add(this.txtSQLHost);
            this.panelSQL.Controls.Add(this.lblAuthDB);
            this.panelSQL.Controls.Add(this.lblSQLPassword);
            this.panelSQL.Controls.Add(this.lblSQLUser);
            this.panelSQL.Controls.Add(this.lblSQLHost);
            this.panelSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSQL.Location = new System.Drawing.Point(3, 3);
            this.panelSQL.Name = "panelSQL";
            this.panelSQL.Size = new System.Drawing.Size(297, 285);
            this.panelSQL.TabIndex = 21;
            // 
            // chkUseSSH
            // 
            this.chkUseSSH.AutoSize = true;
            this.chkUseSSH.Location = new System.Drawing.Point(94, 250);
            this.chkUseSSH.Name = "chkUseSSH";
            this.chkUseSSH.Size = new System.Drawing.Size(84, 17);
            this.chkUseSSH.TabIndex = 24;
            this.chkUseSSH.Text = "SSH Tunnel";
            this.chkUseSSH.UseVisualStyleBackColor = true;
            // 
            // numRealmId
            // 
            this.numRealmId.Location = new System.Drawing.Point(94, 21);
            this.numRealmId.Name = "numRealmId";
            this.numRealmId.Size = new System.Drawing.Size(57, 20);
            this.numRealmId.TabIndex = 22;
            // 
            // lblRealmId
            // 
            this.lblRealmId.AutoSize = true;
            this.lblRealmId.Location = new System.Drawing.Point(7, 23);
            this.lblRealmId.Name = "lblRealmId";
            this.lblRealmId.Size = new System.Drawing.Size(52, 13);
            this.lblRealmId.TabIndex = 21;
            this.lblRealmId.Text = "Realm-Id:";
            // 
            // lblWorldDB
            // 
            this.lblWorldDB.AutoSize = true;
            this.lblWorldDB.Location = new System.Drawing.Point(7, 227);
            this.lblWorldDB.Name = "lblWorldDB";
            this.lblWorldDB.Size = new System.Drawing.Size(56, 13);
            this.lblWorldDB.TabIndex = 20;
            this.lblWorldDB.Text = "World-DB:";
            // 
            // lblCharDB
            // 
            this.lblCharDB.AutoSize = true;
            this.lblCharDB.Location = new System.Drawing.Point(7, 201);
            this.lblCharDB.Name = "lblCharDB";
            this.lblCharDB.Size = new System.Drawing.Size(79, 13);
            this.lblCharDB.TabIndex = 19;
            this.lblCharDB.Text = "Characters-DB:";
            // 
            // txtWorldDB
            // 
            this.txtWorldDB.Location = new System.Drawing.Point(94, 224);
            this.txtWorldDB.Name = "txtWorldDB";
            this.txtWorldDB.Size = new System.Drawing.Size(100, 20);
            this.txtWorldDB.TabIndex = 8;
            // 
            // txtCharDB
            // 
            this.txtCharDB.Location = new System.Drawing.Point(94, 198);
            this.txtCharDB.Name = "txtCharDB";
            this.txtCharDB.Size = new System.Drawing.Size(100, 20);
            this.txtCharDB.TabIndex = 7;
            // 
            // numSQLPort
            // 
            this.numSQLPort.Location = new System.Drawing.Point(94, 79);
            this.numSQLPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numSQLPort.Name = "numSQLPort";
            this.numSQLPort.Size = new System.Drawing.Size(57, 20);
            this.numSQLPort.TabIndex = 3;
            this.numSQLPort.Value = new decimal(new int[] {
            3306,
            0,
            0,
            0});
            // 
            // lblSQLPort
            // 
            this.lblSQLPort.AutoSize = true;
            this.lblSQLPort.Location = new System.Drawing.Point(7, 81);
            this.lblSQLPort.Name = "lblSQLPort";
            this.lblSQLPort.Size = new System.Drawing.Size(29, 13);
            this.lblSQLPort.TabIndex = 9;
            this.lblSQLPort.Text = "Port:";
            // 
            // txtSQLPassword
            // 
            this.txtSQLPassword.Location = new System.Drawing.Point(94, 131);
            this.txtSQLPassword.Name = "txtSQLPassword";
            this.txtSQLPassword.Size = new System.Drawing.Size(100, 20);
            this.txtSQLPassword.TabIndex = 5;
            this.txtSQLPassword.UseSystemPasswordChar = true;
            // 
            // txtAuthDB
            // 
            this.txtAuthDB.Location = new System.Drawing.Point(94, 172);
            this.txtAuthDB.Name = "txtAuthDB";
            this.txtAuthDB.Size = new System.Drawing.Size(100, 20);
            this.txtAuthDB.TabIndex = 6;
            // 
            // txtSQLUser
            // 
            this.txtSQLUser.Location = new System.Drawing.Point(94, 105);
            this.txtSQLUser.Name = "txtSQLUser";
            this.txtSQLUser.Size = new System.Drawing.Size(100, 20);
            this.txtSQLUser.TabIndex = 4;
            // 
            // txtSQLHost
            // 
            this.txtSQLHost.Location = new System.Drawing.Point(94, 53);
            this.txtSQLHost.Name = "txtSQLHost";
            this.txtSQLHost.Size = new System.Drawing.Size(100, 20);
            this.txtSQLHost.TabIndex = 2;
            // 
            // lblAuthDB
            // 
            this.lblAuthDB.AutoSize = true;
            this.lblAuthDB.Location = new System.Drawing.Point(7, 175);
            this.lblAuthDB.Name = "lblAuthDB";
            this.lblAuthDB.Size = new System.Drawing.Size(50, 13);
            this.lblAuthDB.TabIndex = 3;
            this.lblAuthDB.Text = "Auth-DB:";
            // 
            // lblSQLPassword
            // 
            this.lblSQLPassword.AutoSize = true;
            this.lblSQLPassword.Location = new System.Drawing.Point(7, 134);
            this.lblSQLPassword.Name = "lblSQLPassword";
            this.lblSQLPassword.Size = new System.Drawing.Size(53, 13);
            this.lblSQLPassword.TabIndex = 2;
            this.lblSQLPassword.Text = "Passwort:";
            // 
            // lblSQLUser
            // 
            this.lblSQLUser.AutoSize = true;
            this.lblSQLUser.Location = new System.Drawing.Point(7, 108);
            this.lblSQLUser.Name = "lblSQLUser";
            this.lblSQLUser.Size = new System.Drawing.Size(78, 13);
            this.lblSQLUser.TabIndex = 1;
            this.lblSQLUser.Text = "Benutzername:";
            // 
            // lblSQLHost
            // 
            this.lblSQLHost.AutoSize = true;
            this.lblSQLHost.Location = new System.Drawing.Point(7, 56);
            this.lblSQLHost.Name = "lblSQLHost";
            this.lblSQLHost.Size = new System.Drawing.Size(79, 13);
            this.lblSQLHost.TabIndex = 0;
            this.lblSQLHost.Text = "Hostname / IP:";
            // 
            // tabRealmManager
            // 
            this.tabRealmManager.Controls.Add(this.tabPSQL);
            this.tabRealmManager.Controls.Add(this.tabPSSH);
            this.tabRealmManager.Location = new System.Drawing.Point(175, 12);
            this.tabRealmManager.Name = "tabRealmManager";
            this.tabRealmManager.SelectedIndex = 0;
            this.tabRealmManager.Size = new System.Drawing.Size(311, 317);
            this.tabRealmManager.TabIndex = 26;
            // 
            // RealmManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 399);
            this.Controls.Add(this.tabRealmManager);
            this.Controls.Add(this.btnNewServer);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnNewRealm);
            this.Controls.Add(this.treeServers);
            this.Icon = global::TrinityCoreAdmin.Properties.Resources.TrinityCore;
            this.Name = "RealmManagerForm";
            this.Text = "Realmmanager";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tabPSSH.ResumeLayout(false);
            this.panelSSH.ResumeLayout(false);
            this.panelSSH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLocalSSHPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSSHPort)).EndInit();
            this.tabPSQL.ResumeLayout(false);
            this.panelSQL.ResumeLayout(false);
            this.panelSQL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRealmId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSQLPort)).EndInit();
            this.tabRealmManager.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeServers;
        private System.Windows.Forms.Button btnNewRealm;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnNewServer;
        private System.Windows.Forms.TabPage tabPSSH;
        private System.Windows.Forms.Panel panelSSH;
        private System.Windows.Forms.NumericUpDown numSSHPort;
        private System.Windows.Forms.Label lblSSHPort;
        private System.Windows.Forms.TextBox txtSSSHPassword;
        private System.Windows.Forms.TextBox txtSSHUser;
        private System.Windows.Forms.TextBox txtSSHHost;
        private System.Windows.Forms.Label lblSSHPassword;
        private System.Windows.Forms.Label lblSSHUser;
        private System.Windows.Forms.Label lblSSHHost;
        private System.Windows.Forms.TabPage tabPSQL;
        private System.Windows.Forms.Panel panelSQL;
        private System.Windows.Forms.CheckBox chkUseSSH;
        private System.Windows.Forms.NumericUpDown numRealmId;
        private System.Windows.Forms.Label lblRealmId;
        private System.Windows.Forms.Label lblWorldDB;
        private System.Windows.Forms.Label lblCharDB;
        private System.Windows.Forms.TextBox txtWorldDB;
        private System.Windows.Forms.TextBox txtCharDB;
        private System.Windows.Forms.NumericUpDown numSQLPort;
        private System.Windows.Forms.Label lblSQLPort;
        private System.Windows.Forms.TextBox txtSQLPassword;
        private System.Windows.Forms.TextBox txtAuthDB;
        private System.Windows.Forms.TextBox txtSQLUser;
        private System.Windows.Forms.TextBox txtSQLHost;
        private System.Windows.Forms.Label lblAuthDB;
        private System.Windows.Forms.Label lblSQLPassword;
        private System.Windows.Forms.Label lblSQLUser;
        private System.Windows.Forms.Label lblSQLHost;
        private System.Windows.Forms.TabControl tabRealmManager;
        private System.Windows.Forms.NumericUpDown numLocalSSHPort;
        private System.Windows.Forms.Label lblLocalSSHPort;

    }
}