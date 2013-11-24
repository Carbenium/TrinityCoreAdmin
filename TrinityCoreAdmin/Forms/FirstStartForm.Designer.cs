namespace TrinityCoreAdmin.Forms
{
    partial class FirstStartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstStartForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblGitLink = new System.Windows.Forms.LinkLabel();
            this.txtSettingsFolder = new System.Windows.Forms.TextBox();
            this.btnSelSettingsFolder = new System.Windows.Forms.Button();
            this.lblSettingsFolder = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.folderSettings = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(114, 12);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(265, 42);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "TrinityCoreAdmin";
            // 
            // lblGitLink
            // 
            this.lblGitLink.AutoSize = true;
            this.lblGitLink.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGitLink.Location = new System.Drawing.Point(118, 67);
            this.lblGitLink.Name = "lblGitLink";
            this.lblGitLink.Size = new System.Drawing.Size(88, 18);
            this.lblGitLink.TabIndex = 2;
            this.lblGitLink.TabStop = true;
            this.lblGitLink.Text = "GitHub-Seite";
            this.lblGitLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblGitLink_LinkClicked);
            // 
            // txtSettingsFolder
            // 
            this.txtSettingsFolder.Location = new System.Drawing.Point(12, 146);
            this.txtSettingsFolder.Name = "txtSettingsFolder";
            this.txtSettingsFolder.Size = new System.Drawing.Size(307, 20);
            this.txtSettingsFolder.TabIndex = 4;
            // 
            // btnSelSettingsFolder
            // 
            this.btnSelSettingsFolder.Location = new System.Drawing.Point(325, 146);
            this.btnSelSettingsFolder.Name = "btnSelSettingsFolder";
            this.btnSelSettingsFolder.Size = new System.Drawing.Size(32, 20);
            this.btnSelSettingsFolder.TabIndex = 5;
            this.btnSelSettingsFolder.Text = "...";
            this.btnSelSettingsFolder.UseVisualStyleBackColor = true;
            this.btnSelSettingsFolder.Click += new System.EventHandler(this.btnSelSettingsFolder_Click);
            // 
            // lblSettingsFolder
            // 
            this.lblSettingsFolder.AutoSize = true;
            this.lblSettingsFolder.Location = new System.Drawing.Point(9, 130);
            this.lblSettingsFolder.Name = "lblSettingsFolder";
            this.lblSettingsFolder.Size = new System.Drawing.Size(158, 13);
            this.lblSettingsFolder.TabIndex = 3;
            this.lblSettingsFolder.Text = "Speicherplatz der Einstellungen:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(451, 171);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "Fortfahren";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FirstStartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 206);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtSettingsFolder);
            this.Controls.Add(this.btnSelSettingsFolder);
            this.Controls.Add(this.lblSettingsFolder);
            this.Controls.Add(this.lblGitLink);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FirstStartForm";
            this.Text = "Erster Start";
            this.Load += new System.EventHandler(this.FirstStartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.LinkLabel lblGitLink;
        private System.Windows.Forms.TextBox txtSettingsFolder;
        private System.Windows.Forms.Button btnSelSettingsFolder;
        private System.Windows.Forms.Label lblSettingsFolder;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.FolderBrowserDialog folderSettings;
    }
}