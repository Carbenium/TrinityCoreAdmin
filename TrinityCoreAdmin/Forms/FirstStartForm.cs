using System;
using System.Windows.Forms;

namespace TrinityCoreAdmin.Forms
{
    public partial class FirstStartForm : Form
    {
        private bool okClicked = false;
        public FirstStartForm()
        {
            InitializeComponent();
        }

        private void FirstStartForm_Load(object sender, EventArgs e)
        {
            lblGitLink.Links.Add(0, 12, "https://github.com/Carbenium/TrinityCoreAdmin");
            txtSettingsFolder.Text = Application.StartupPath;
        }

        private void lblGitLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ServerSettingsSavePath = txtSettingsFolder.Text;
            Properties.Settings.Default.firstStart = false;
            Properties.Settings.Default.Save();
            okClicked = true;
            this.Close();
        }

        private void btnSelSettingsFolder_Click(object sender, EventArgs e)
        {
            if (folderSettings.ShowDialog() == DialogResult.OK)
                txtSettingsFolder.Text = folderSettings.SelectedPath + "config.xml";
        }

        private void FirstStartForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void FirstStartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !okClicked)
                Application.Exit();
        }
    }
}
