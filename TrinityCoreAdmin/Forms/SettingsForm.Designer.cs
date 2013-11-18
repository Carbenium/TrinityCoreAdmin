namespace TrinityCoreAdmin.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpFolders = new System.Windows.Forms.GroupBox();
            this.txtSettingsFolder = new System.Windows.Forms.TextBox();
            this.btnSelSettingsFolder = new System.Windows.Forms.Button();
            this.lblSettingsFolder = new System.Windows.Forms.Label();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.folderSettings = new System.Windows.Forms.FolderBrowserDialog();
            this.tabPage1.SuspendLayout();
            this.grpFolders.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpFolders);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(452, 160);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Allgemein";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grpFolders
            // 
            this.grpFolders.Controls.Add(this.txtSettingsFolder);
            this.grpFolders.Controls.Add(this.btnSelSettingsFolder);
            this.grpFolders.Controls.Add(this.lblSettingsFolder);
            this.grpFolders.Location = new System.Drawing.Point(6, 6);
            this.grpFolders.Name = "grpFolders";
            this.grpFolders.Size = new System.Drawing.Size(437, 55);
            this.grpFolders.TabIndex = 3;
            this.grpFolders.TabStop = false;
            this.grpFolders.Text = "Speicherorte";
            // 
            // txtSettingsFolder
            // 
            this.txtSettingsFolder.Location = new System.Drawing.Point(85, 19);
            this.txtSettingsFolder.Name = "txtSettingsFolder";
            this.txtSettingsFolder.Size = new System.Drawing.Size(307, 20);
            this.txtSettingsFolder.TabIndex = 1;
            // 
            // btnSelSettingsFolder
            // 
            this.btnSelSettingsFolder.Location = new System.Drawing.Point(398, 16);
            this.btnSelSettingsFolder.Name = "btnSelSettingsFolder";
            this.btnSelSettingsFolder.Size = new System.Drawing.Size(32, 23);
            this.btnSelSettingsFolder.TabIndex = 2;
            this.btnSelSettingsFolder.Text = "...";
            this.btnSelSettingsFolder.UseVisualStyleBackColor = true;
            this.btnSelSettingsFolder.Click += new System.EventHandler(this.btnSelSettingsFolder_Click);
            // 
            // lblSettingsFolder
            // 
            this.lblSettingsFolder.AutoSize = true;
            this.lblSettingsFolder.Location = new System.Drawing.Point(6, 22);
            this.lblSettingsFolder.Name = "lblSettingsFolder";
            this.lblSettingsFolder.Size = new System.Drawing.Size(74, 13);
            this.lblSettingsFolder.TabIndex = 0;
            this.lblSettingsFolder.Text = "Server Config:";
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabPage1);
            this.tabSettings.Location = new System.Drawing.Point(12, 12);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(460, 186);
            this.tabSettings.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(312, 204);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(393, 204);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(483, 247);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::TrinityCoreAdmin.Properties.Resources.TrinityCore;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.Text = "Einstellungen";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tabPage1.ResumeLayout(false);
            this.grpFolders.ResumeLayout(false);
            this.grpFolders.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblSettingsFolder;
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FolderBrowserDialog folderSettings;
        private System.Windows.Forms.Button btnSelSettingsFolder;
        private System.Windows.Forms.TextBox txtSettingsFolder;
        private System.Windows.Forms.GroupBox grpFolders;
    }
}