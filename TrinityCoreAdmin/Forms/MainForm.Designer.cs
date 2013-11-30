namespace TrinityCoreAdmin.Forms
{
    partial class MainForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.dateiMenuStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realmmanagerMenuStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trennenMenuStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.beendenMenuStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenMenuStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenMenuStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripSSH = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripAuth = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripChar = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripWorld = new System.Windows.Forms.ToolStripStatusLabel();
            this.listViewAccounts = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reg_mail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.joindate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.last_ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.failed_logins = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.last_login = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.expansion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnDisconnect = new System.Windows.Forms.ToolStripButton();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiMenuStripMenuItem,
            this.bearbeitenMenuStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(804, 24);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Text = "menuStrip1";
            // 
            // dateiMenuStripMenuItem
            // 
            this.dateiMenuStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.realmmanagerMenuStripMenuItem,
            this.trennenMenuStripMenuItem,
            this.MenuStripSeparator,
            this.beendenMenuStripMenuItem});
            this.dateiMenuStripMenuItem.Name = "dateiMenuStripMenuItem";
            this.dateiMenuStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiMenuStripMenuItem.Text = "Datei";
            // 
            // realmmanagerMenuStripMenuItem
            // 
            this.realmmanagerMenuStripMenuItem.Name = "realmmanagerMenuStripMenuItem";
            this.realmmanagerMenuStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.realmmanagerMenuStripMenuItem.Text = "Realmmanager";
            this.realmmanagerMenuStripMenuItem.Click += new System.EventHandler(this.realmmanagerToolStripMenuItem_Click);
            // 
            // trennenMenuStripMenuItem
            // 
            this.trennenMenuStripMenuItem.Name = "trennenMenuStripMenuItem";
            this.trennenMenuStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.trennenMenuStripMenuItem.Text = "Trennen";
            this.trennenMenuStripMenuItem.Click += new System.EventHandler(this.toolStripCloseConnections_Click);
            // 
            // MenuStripSeparator
            // 
            this.MenuStripSeparator.Name = "MenuStripSeparator";
            this.MenuStripSeparator.Size = new System.Drawing.Size(151, 6);
            // 
            // beendenMenuStripMenuItem
            // 
            this.beendenMenuStripMenuItem.Name = "beendenMenuStripMenuItem";
            this.beendenMenuStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.beendenMenuStripMenuItem.Text = "Beenden";
            this.beendenMenuStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // bearbeitenMenuStripMenuItem
            // 
            this.bearbeitenMenuStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.einstellungenMenuStripMenuItem});
            this.bearbeitenMenuStripMenuItem.Name = "bearbeitenMenuStripMenuItem";
            this.bearbeitenMenuStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.bearbeitenMenuStripMenuItem.Text = "Bearbeiten";
            // 
            // einstellungenMenuStripMenuItem
            // 
            this.einstellungenMenuStripMenuItem.Name = "einstellungenMenuStripMenuItem";
            this.einstellungenMenuStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.einstellungenMenuStripMenuItem.Text = "Einstellungen";
            this.einstellungenMenuStripMenuItem.Click += new System.EventHandler(this.einstellungenToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripSSH,
            this.statusStripAuth,
            this.statusStripChar,
            this.statusStripWorld});
            this.statusStrip.Location = new System.Drawing.Point(0, 299);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(804, 22);
            this.statusStrip.TabIndex = 9;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusStripSSH
            // 
            this.statusStripSSH.ForeColor = System.Drawing.Color.Gray;
            this.statusStripSSH.Name = "statusStripSSH";
            this.statusStripSSH.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.statusStripSSH.Size = new System.Drawing.Size(38, 17);
            this.statusStripSSH.Text = "SSH";
            // 
            // statusStripAuth
            // 
            this.statusStripAuth.ForeColor = System.Drawing.Color.Gray;
            this.statusStripAuth.Name = "statusStripAuth";
            this.statusStripAuth.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.statusStripAuth.Size = new System.Drawing.Size(58, 17);
            this.statusStripAuth.Text = "AuthDB";
            // 
            // statusStripChar
            // 
            this.statusStripChar.ForeColor = System.Drawing.Color.Gray;
            this.statusStripChar.Name = "statusStripChar";
            this.statusStripChar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.statusStripChar.Size = new System.Drawing.Size(57, 17);
            this.statusStripChar.Text = "CharDB";
            // 
            // statusStripWorld
            // 
            this.statusStripWorld.ForeColor = System.Drawing.Color.Gray;
            this.statusStripWorld.Name = "statusStripWorld";
            this.statusStripWorld.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.statusStripWorld.Size = new System.Drawing.Size(64, 17);
            this.statusStripWorld.Text = "WorldDB";
            // 
            // listViewAccounts
            // 
            this.listViewAccounts.AutoArrange = false;
            this.listViewAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.username,
            this.reg_mail,
            this.email,
            this.joindate,
            this.last_ip,
            this.failed_logins,
            this.last_login,
            this.expansion});
            this.listViewAccounts.FullRowSelect = true;
            this.listViewAccounts.Location = new System.Drawing.Point(12, 52);
            this.listViewAccounts.Name = "listViewAccounts";
            this.listViewAccounts.Size = new System.Drawing.Size(780, 227);
            this.listViewAccounts.TabIndex = 8;
            this.listViewAccounts.UseCompatibleStateImageBehavior = false;
            this.listViewAccounts.View = System.Windows.Forms.View.Details;
            this.listViewAccounts.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewAccounts_ColumnClick);
            this.listViewAccounts.DoubleClick += new System.EventHandler(this.listViewAccounts_DoubleClick);
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 31;
            // 
            // username
            // 
            this.username.Text = "Username";
            this.username.Width = 67;
            // 
            // reg_mail
            // 
            this.reg_mail.Text = "Reg. Email";
            this.reg_mail.Width = 135;
            // 
            // email
            // 
            this.email.Text = "Email";
            this.email.Width = 139;
            // 
            // joindate
            // 
            this.joindate.Text = "Erstellungsdatum";
            this.joindate.Width = 94;
            // 
            // last_ip
            // 
            this.last_ip.Text = "Letzte IP";
            this.last_ip.Width = 79;
            // 
            // failed_logins
            // 
            this.failed_logins.Text = "Loginvers.";
            this.failed_logins.Width = 64;
            // 
            // last_login
            // 
            this.last_login.Text = "Letzter Login";
            this.last_login.Width = 83;
            // 
            // expansion
            // 
            this.expansion.Text = "Erweiterung";
            this.expansion.Width = 78;
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnDisconnect});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(804, 25);
            this.toolStrip.TabIndex = 10;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripBtnDisconnect
            // 
            this.toolStripBtnDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnDisconnect.Image = global::TrinityCoreAdmin.Properties.Resources.network_offline_2;
            this.toolStripBtnDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnDisconnect.Name = "toolStripBtnDisconnect";
            this.toolStripBtnDisconnect.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnDisconnect.Text = "Trennen";
            this.toolStripBtnDisconnect.Click += new System.EventHandler(this.toolStripBtnDisconnect_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(804, 321);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.listViewAccounts);
            this.Controls.Add(this.menuStrip);
            this.Icon = global::TrinityCoreAdmin.Properties.Resources.TrinityCore;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "TrinityAdmin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripSeparator MenuStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem beendenMenuStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateiMenuStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realmmanagerMenuStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenMenuStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenMenuStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trennenMenuStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ListView listViewAccounts;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader username;
        private System.Windows.Forms.ColumnHeader reg_mail;
        private System.Windows.Forms.ColumnHeader email;
        private System.Windows.Forms.ColumnHeader joindate;
        private System.Windows.Forms.ColumnHeader last_ip;
        private System.Windows.Forms.ColumnHeader failed_logins;
        private System.Windows.Forms.ColumnHeader last_login;
        private System.Windows.Forms.ColumnHeader expansion;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripBtnDisconnect;
        private System.Windows.Forms.ToolStripStatusLabel statusStripSSH;
        private System.Windows.Forms.ToolStripStatusLabel statusStripAuth;
        private System.Windows.Forms.ToolStripStatusLabel statusStripChar;
        private System.Windows.Forms.ToolStripStatusLabel statusStripWorld;
    }
}

