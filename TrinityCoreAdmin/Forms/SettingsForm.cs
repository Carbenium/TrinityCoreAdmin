using System.Windows.Forms;

namespace TrinityCoreAdmin.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, System.EventArgs e)
        {
            txtSettingsFolder.Text = Properties.Settings.Default.ServerSettingsSavePath;
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            Properties.Settings.Default.ServerSettingsSavePath = txtSettingsFolder.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void btnSelSettingsFolder_Click(object sender, System.EventArgs e)
        {
            folderSettings.SelectedPath = Properties.Settings.Default.ServerSettingsSavePath;
            if (folderSettings.ShowDialog() == DialogResult.OK)
            {
                txtSettingsFolder.Text = folderSettings.SelectedPath;
            }
        }


    }
}