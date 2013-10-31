namespace TrinityCoreAdmin
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verbindenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.einstellungenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sOAPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewAccounts = new TrinityCoreAdmin.AccountListView();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.einstellungenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(493, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verbindenToolStripMenuItem,
            this.toolStripSeparator2,
            this.einstellungenToolStripMenuItem1,
            this.toolStripSeparator1,
            this.beendenToolStripMenuItem,
            this.sOAPToolStripMenuItem});
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.einstellungenToolStripMenuItem.Text = "Datei";
            // 
            // verbindenToolStripMenuItem
            // 
            this.verbindenToolStripMenuItem.Name = "verbindenToolStripMenuItem";
            this.verbindenToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.verbindenToolStripMenuItem.Text = "Verbinden";
            this.verbindenToolStripMenuItem.Click += new System.EventHandler(this.verbindenToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(151, 6);
            // 
            // einstellungenToolStripMenuItem1
            // 
            this.einstellungenToolStripMenuItem1.Name = "einstellungenToolStripMenuItem1";
            this.einstellungenToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.einstellungenToolStripMenuItem1.Text = "Realmmanager";
            this.einstellungenToolStripMenuItem1.Click += new System.EventHandler(this.einstellungenToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // sOAPToolStripMenuItem
            // 
            this.sOAPToolStripMenuItem.Name = "sOAPToolStripMenuItem";
            this.sOAPToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.sOAPToolStripMenuItem.Text = "SOAP";
            this.sOAPToolStripMenuItem.Click += new System.EventHandler(this.sOAPToolStripMenuItem_Click);
            // 
            // listViewAccounts
            // 
            this.listViewAccounts.AutoArrange = false;
            this.listViewAccounts.Location = new System.Drawing.Point(12, 27);
            this.listViewAccounts.Name = "listViewAccounts";
            this.listViewAccounts.Size = new System.Drawing.Size(469, 234);
            this.listViewAccounts.TabIndex = 8;
            this.listViewAccounts.UseCompatibleStateImageBehavior = false;
            this.listViewAccounts.View = System.Windows.Forms.View.Details;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(493, 273);
            this.Controls.Add(this.listViewAccounts);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "TrinityAdmin";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verbindenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem sOAPToolStripMenuItem;
        private AccountListView listViewAccounts;
    }
}

