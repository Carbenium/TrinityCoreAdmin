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
            this.lblHost = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblAuthDB = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtAuthDB = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.treeServers = new System.Windows.Forms.TreeView();
            this.btnNewRealm = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtCharDB = new System.Windows.Forms.TextBox();
            this.txtWorldDB = new System.Windows.Forms.TextBox();
            this.lblCharDB = new System.Windows.Forms.Label();
            this.lblWorldDB = new System.Windows.Forms.Label();
            this.panelRealm = new System.Windows.Forms.Panel();
            this.numDbId = new System.Windows.Forms.NumericUpDown();
            this.lblDbId = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnNewServer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.panelRealm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDbId)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(7, 56);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(79, 13);
            this.lblHost.TabIndex = 0;
            this.lblHost.Text = "Hostname / IP:";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(7, 108);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(78, 13);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Benutzername:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(7, 134);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(50, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Passwort";
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
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(94, 53);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(100, 20);
            this.txtHost.TabIndex = 2;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(94, 105);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 4;
            // 
            // txtAuthDB
            // 
            this.txtAuthDB.Location = new System.Drawing.Point(94, 172);
            this.txtAuthDB.Name = "txtAuthDB";
            this.txtAuthDB.Size = new System.Drawing.Size(100, 20);
            this.txtAuthDB.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(94, 131);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(7, 81);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 9;
            this.lblPort.Text = "Port:";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(94, 79);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(57, 20);
            this.numPort.TabIndex = 3;
            this.numPort.Value = new decimal(new int[] {
            3306,
            0,
            0,
            0});
            // 
            // treeServers
            // 
            this.treeServers.HideSelection = false;
            this.treeServers.LabelEdit = true;
            this.treeServers.Location = new System.Drawing.Point(12, 12);
            this.treeServers.Name = "treeServers";
            this.treeServers.ShowPlusMinus = false;
            this.treeServers.ShowRootLines = false;
            this.treeServers.Size = new System.Drawing.Size(147, 295);
            this.treeServers.TabIndex = 11;
            this.treeServers.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeServers_AfterLabelEdit);
            this.treeServers.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeServers_BeforeSelect);
            this.treeServers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeServers_AfterSelect);
            // 
            // btnNewRealm
            // 
            this.btnNewRealm.Location = new System.Drawing.Point(12, 343);
            this.btnNewRealm.Name = "btnNewRealm";
            this.btnNewRealm.Size = new System.Drawing.Size(78, 23);
            this.btnNewRealm.TabIndex = 12;
            this.btnNewRealm.Text = "Neuer Realm";
            this.btnNewRealm.UseVisualStyleBackColor = true;
            this.btnNewRealm.Click += new System.EventHandler(this.btnNewRealm_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(96, 314);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(63, 23);
            this.btnRemove.TabIndex = 14;
            this.btnRemove.Text = "Löschen";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtCharDB
            // 
            this.txtCharDB.Location = new System.Drawing.Point(94, 198);
            this.txtCharDB.Name = "txtCharDB";
            this.txtCharDB.Size = new System.Drawing.Size(100, 20);
            this.txtCharDB.TabIndex = 7;
            // 
            // txtWorldDB
            // 
            this.txtWorldDB.Location = new System.Drawing.Point(94, 224);
            this.txtWorldDB.Name = "txtWorldDB";
            this.txtWorldDB.Size = new System.Drawing.Size(100, 20);
            this.txtWorldDB.TabIndex = 8;
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
            // lblWorldDB
            // 
            this.lblWorldDB.AutoSize = true;
            this.lblWorldDB.Location = new System.Drawing.Point(7, 227);
            this.lblWorldDB.Name = "lblWorldDB";
            this.lblWorldDB.Size = new System.Drawing.Size(56, 13);
            this.lblWorldDB.TabIndex = 20;
            this.lblWorldDB.Text = "World-DB:";
            // 
            // panelRealm
            // 
            this.panelRealm.Controls.Add(this.numDbId);
            this.panelRealm.Controls.Add(this.lblDbId);
            this.panelRealm.Controls.Add(this.lblWorldDB);
            this.panelRealm.Controls.Add(this.lblCharDB);
            this.panelRealm.Controls.Add(this.txtWorldDB);
            this.panelRealm.Controls.Add(this.txtCharDB);
            this.panelRealm.Controls.Add(this.numPort);
            this.panelRealm.Controls.Add(this.lblPort);
            this.panelRealm.Controls.Add(this.txtPassword);
            this.panelRealm.Controls.Add(this.txtAuthDB);
            this.panelRealm.Controls.Add(this.txtUser);
            this.panelRealm.Controls.Add(this.txtHost);
            this.panelRealm.Controls.Add(this.lblAuthDB);
            this.panelRealm.Controls.Add(this.lblPassword);
            this.panelRealm.Controls.Add(this.lblUser);
            this.panelRealm.Controls.Add(this.lblHost);
            this.panelRealm.Location = new System.Drawing.Point(165, 12);
            this.panelRealm.Name = "panelRealm";
            this.panelRealm.Size = new System.Drawing.Size(290, 278);
            this.panelRealm.TabIndex = 21;
            // 
            // numDbId
            // 
            this.numDbId.Location = new System.Drawing.Point(94, 21);
            this.numDbId.Name = "numDbId";
            this.numDbId.Size = new System.Drawing.Size(57, 20);
            this.numDbId.TabIndex = 22;
            // 
            // lblDbId
            // 
            this.lblDbId.AutoSize = true;
            this.lblDbId.Location = new System.Drawing.Point(7, 23);
            this.lblDbId.Name = "lblDbId";
            this.lblDbId.Size = new System.Drawing.Size(49, 13);
            this.lblDbId.TabIndex = 21;
            this.lblDbId.Text = "Realm-Id";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(299, 343);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 22;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(380, 343);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(175, 343);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 24;
            this.btnConnect.Text = "Verbinden";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnNewServer
            // 
            this.btnNewServer.Location = new System.Drawing.Point(12, 314);
            this.btnNewServer.Name = "btnNewServer";
            this.btnNewServer.Size = new System.Drawing.Size(78, 23);
            this.btnNewServer.TabIndex = 25;
            this.btnNewServer.Text = "Neuer Server";
            this.btnNewServer.UseVisualStyleBackColor = true;
            this.btnNewServer.Click += new System.EventHandler(this.btnNewServer_Click);
            // 
            // RealmManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 384);
            this.Controls.Add(this.btnNewServer);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panelRealm);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnNewRealm);
            this.Controls.Add(this.treeServers);
            this.Name = "RealmManagerForm";
            this.Text = "Realmmanager";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.panelRealm.ResumeLayout(false);
            this.panelRealm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDbId)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblAuthDB;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtAuthDB;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.TreeView treeServers;
        private System.Windows.Forms.Button btnNewRealm;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtCharDB;
        private System.Windows.Forms.TextBox txtWorldDB;
        private System.Windows.Forms.Label lblCharDB;
        private System.Windows.Forms.Label lblWorldDB;
        private System.Windows.Forms.Panel panelRealm;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numDbId;
        private System.Windows.Forms.Label lblDbId;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnNewServer;

    }
}