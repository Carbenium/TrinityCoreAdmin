namespace TrinityCoreAdmin.Forms
{
    partial class EditAccountForm
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
            this.lblId = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblRegMail = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblJoinDate = new System.Windows.Forms.Label();
            this.lblLastIp = new System.Windows.Forms.Label();
            this.lblFailedLogins = new System.Windows.Forms.Label();
            this.lblLocked = new System.Windows.Forms.Label();
            this.lblLastLogin = new System.Windows.Forms.Label();
            this.lblExpansion = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnPrevious = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnSave = new System.Windows.Forms.ToolStripButton();
            this.txtRegMail = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.chkLocked = new System.Windows.Forms.CheckBox();
            this.lblIdData = new System.Windows.Forms.Label();
            this.lblLastIpData = new System.Windows.Forms.Label();
            this.lblFailedLoginsData = new System.Windows.Forms.Label();
            this.lblExpansionData = new System.Windows.Forms.Label();
            this.lblLastLoginData = new System.Windows.Forms.Label();
            this.lblJoinDateData = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(12, 36);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 64);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username:";
            // 
            // lblRegMail
            // 
            this.lblRegMail.AutoSize = true;
            this.lblRegMail.Location = new System.Drawing.Point(12, 90);
            this.lblRegMail.Name = "lblRegMail";
            this.lblRegMail.Size = new System.Drawing.Size(99, 13);
            this.lblRegMail.TabIndex = 3;
            this.lblRegMail.Text = "Registrations-Email:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(12, 116);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "E-Mail:";
            // 
            // lblJoinDate
            // 
            this.lblJoinDate.AutoSize = true;
            this.lblJoinDate.Location = new System.Drawing.Point(12, 145);
            this.lblJoinDate.Name = "lblJoinDate";
            this.lblJoinDate.Size = new System.Drawing.Size(90, 13);
            this.lblJoinDate.TabIndex = 5;
            this.lblJoinDate.Text = "Erstellungsdatum:";
            // 
            // lblLastIp
            // 
            this.lblLastIp.AutoSize = true;
            this.lblLastIp.Location = new System.Drawing.Point(12, 199);
            this.lblLastIp.Name = "lblLastIp";
            this.lblLastIp.Size = new System.Drawing.Size(52, 13);
            this.lblLastIp.TabIndex = 6;
            this.lblLastIp.Text = "Letzte IP:";
            // 
            // lblFailedLogins
            // 
            this.lblFailedLogins.AutoSize = true;
            this.lblFailedLogins.Location = new System.Drawing.Point(212, 199);
            this.lblFailedLogins.Name = "lblFailedLogins";
            this.lblFailedLogins.Size = new System.Drawing.Size(125, 13);
            this.lblFailedLogins.TabIndex = 7;
            this.lblFailedLogins.Text = "Fehlgeschlagene Logins:";
            // 
            // lblLocked
            // 
            this.lblLocked.AutoSize = true;
            this.lblLocked.Location = new System.Drawing.Point(12, 258);
            this.lblLocked.Name = "lblLocked";
            this.lblLocked.Size = new System.Drawing.Size(49, 13);
            this.lblLocked.TabIndex = 8;
            this.lblLocked.Text = "Locked?";
            // 
            // lblLastLogin
            // 
            this.lblLastLogin.AutoSize = true;
            this.lblLastLogin.Location = new System.Drawing.Point(12, 171);
            this.lblLastLogin.Name = "lblLastLogin";
            this.lblLastLogin.Size = new System.Drawing.Size(68, 13);
            this.lblLastLogin.TabIndex = 9;
            this.lblLastLogin.Text = "Letzer Login:";
            // 
            // lblExpansion
            // 
            this.lblExpansion.AutoSize = true;
            this.lblExpansion.Location = new System.Drawing.Point(12, 229);
            this.lblExpansion.Name = "lblExpansion";
            this.lblExpansion.Size = new System.Drawing.Size(66, 13);
            this.lblExpansion.TabIndex = 10;
            this.lblExpansion.Text = "Erweiterung:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(117, 61);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(116, 20);
            this.txtUsername.TabIndex = 11;
            this.txtUsername.TextChanged += new System.EventHandler(this.OnDataChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnPrevious,
            this.toolStripBtnNext,
            this.toolStripSeparator1,
            this.toolStripBtnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(428, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtnPrevious
            // 
            this.toolStripBtnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnPrevious.Image = global::TrinityCoreAdmin.Properties.Resources.arrowLeft;
            this.toolStripBtnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnPrevious.Name = "toolStripBtnPrevious";
            this.toolStripBtnPrevious.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnPrevious.Text = "Vorheriger Account";
            this.toolStripBtnPrevious.Click += new System.EventHandler(this.toolStripBtnPrevious_Click);
            // 
            // toolStripBtnNext
            // 
            this.toolStripBtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnNext.Image = global::TrinityCoreAdmin.Properties.Resources.arrowRight;
            this.toolStripBtnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnNext.Name = "toolStripBtnNext";
            this.toolStripBtnNext.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnNext.Text = "Nächster Account";
            this.toolStripBtnNext.Click += new System.EventHandler(this.toolStripBtnNext_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripBtnSave
            // 
            this.toolStripBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnSave.Image = global::TrinityCoreAdmin.Properties.Resources.documentSave;
            this.toolStripBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSave.Name = "toolStripBtnSave";
            this.toolStripBtnSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnSave.Text = "Speichern";
            this.toolStripBtnSave.Click += new System.EventHandler(this.toolStripBtnSave_Click);
            // 
            // txtRegMail
            // 
            this.txtRegMail.Location = new System.Drawing.Point(117, 87);
            this.txtRegMail.Name = "txtRegMail";
            this.txtRegMail.Size = new System.Drawing.Size(200, 20);
            this.txtRegMail.TabIndex = 13;
            this.txtRegMail.TextChanged += new System.EventHandler(this.txtRegMail_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(117, 113);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 14;
            this.txtEmail.TextChanged += new System.EventHandler(this.OnDataChanged);
            // 
            // chkLocked
            // 
            this.chkLocked.AutoSize = true;
            this.chkLocked.Location = new System.Drawing.Point(117, 257);
            this.chkLocked.Name = "chkLocked";
            this.chkLocked.Size = new System.Drawing.Size(15, 14);
            this.chkLocked.TabIndex = 20;
            this.chkLocked.UseVisualStyleBackColor = true;
            this.chkLocked.Click += new System.EventHandler(this.OnDataChanged);
            // 
            // lblIdData
            // 
            this.lblIdData.AutoSize = true;
            this.lblIdData.Location = new System.Drawing.Point(114, 36);
            this.lblIdData.Name = "lblIdData";
            this.lblIdData.Size = new System.Drawing.Size(35, 13);
            this.lblIdData.TabIndex = 21;
            this.lblIdData.Text = "label1";
            // 
            // lblLastIpData
            // 
            this.lblLastIpData.AutoSize = true;
            this.lblLastIpData.Location = new System.Drawing.Point(114, 199);
            this.lblLastIpData.Name = "lblLastIpData";
            this.lblLastIpData.Size = new System.Drawing.Size(35, 13);
            this.lblLastIpData.TabIndex = 22;
            this.lblLastIpData.Text = "label2";
            // 
            // lblFailedLoginsData
            // 
            this.lblFailedLoginsData.AutoSize = true;
            this.lblFailedLoginsData.Location = new System.Drawing.Point(343, 199);
            this.lblFailedLoginsData.Name = "lblFailedLoginsData";
            this.lblFailedLoginsData.Size = new System.Drawing.Size(35, 13);
            this.lblFailedLoginsData.TabIndex = 23;
            this.lblFailedLoginsData.Text = "label3";
            // 
            // lblExpansionData
            // 
            this.lblExpansionData.AutoSize = true;
            this.lblExpansionData.Location = new System.Drawing.Point(114, 229);
            this.lblExpansionData.Name = "lblExpansionData";
            this.lblExpansionData.Size = new System.Drawing.Size(35, 13);
            this.lblExpansionData.TabIndex = 24;
            this.lblExpansionData.Text = "label4";
            // 
            // lblLastLoginData
            // 
            this.lblLastLoginData.AutoSize = true;
            this.lblLastLoginData.Location = new System.Drawing.Point(114, 171);
            this.lblLastLoginData.Name = "lblLastLoginData";
            this.lblLastLoginData.Size = new System.Drawing.Size(35, 13);
            this.lblLastLoginData.TabIndex = 25;
            this.lblLastLoginData.Text = "label2";
            // 
            // lblJoinDateData
            // 
            this.lblJoinDateData.AutoSize = true;
            this.lblJoinDateData.Location = new System.Drawing.Point(114, 145);
            this.lblJoinDateData.Name = "lblJoinDateData";
            this.lblJoinDateData.Size = new System.Drawing.Size(35, 13);
            this.lblJoinDateData.TabIndex = 26;
            this.lblJoinDateData.Text = "label2";
            // 
            // EditAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 307);
            this.Controls.Add(this.lblJoinDateData);
            this.Controls.Add(this.lblLastLoginData);
            this.Controls.Add(this.lblExpansionData);
            this.Controls.Add(this.lblFailedLoginsData);
            this.Controls.Add(this.lblLastIpData);
            this.Controls.Add(this.lblIdData);
            this.Controls.Add(this.chkLocked);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtRegMail);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblExpansion);
            this.Controls.Add(this.lblLastLogin);
            this.Controls.Add(this.lblLocked);
            this.Controls.Add(this.lblFailedLogins);
            this.Controls.Add(this.lblLastIp);
            this.Controls.Add(this.lblJoinDate);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblRegMail);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblId);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditAccountForm";
            this.ShowIcon = false;
            this.Text = "Account bearbeiten";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditAccountForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditAccountForm_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblRegMail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblJoinDate;
        private System.Windows.Forms.Label lblLastIp;
        private System.Windows.Forms.Label lblFailedLogins;
        private System.Windows.Forms.Label lblLocked;
        private System.Windows.Forms.Label lblLastLogin;
        private System.Windows.Forms.Label lblExpansion;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TextBox txtRegMail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.CheckBox chkLocked;
        private System.Windows.Forms.Label lblIdData;
        private System.Windows.Forms.Label lblLastIpData;
        private System.Windows.Forms.Label lblFailedLoginsData;
        private System.Windows.Forms.Label lblExpansionData;
        private System.Windows.Forms.ToolStripButton toolStripBtnPrevious;
        private System.Windows.Forms.ToolStripButton toolStripBtnNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripBtnSave;
        private System.Windows.Forms.Label lblLastLoginData;
        private System.Windows.Forms.Label lblJoinDateData;
    }
}