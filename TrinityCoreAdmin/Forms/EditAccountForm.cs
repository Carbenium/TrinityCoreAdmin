using System;
using System.Windows.Forms;

namespace TrinityCoreAdmin.Forms
{
    public partial class EditAccountForm : Form
    {
        private Account currAcc;
        private bool dataChanged;
        private bool regEmailChanged;

        public EditAccountForm(Account acc)
        {
            this.currAcc = acc;
            InitializeComponent();
            SetData(acc);
        }

        private void SetData(Account acc)
        {
            this.lblIdData.Text = acc.id.ToString();
            this.txtUsername.Text = acc.username;
            this.txtRegMail.Text = acc.reg_mail;
            this.txtEmail.Text = acc.email;
            this.lblJoinDateData.Text = acc.joindate.ToString();
            this.lblLastLoginData.Text = acc.last_login.ToString(); ;
            this.lblLastIpData.Text = acc.last_ip;
            this.lblFailedLoginsData.Text = acc.failed_logins.ToString();
            this.lblExpansionData.Text = acc.expansion.ToString();
            this.chkLocked.Checked = acc.locked;

            this.dataChanged = false;
            this.regEmailChanged = false;

            // Save button should be only enabled if a auth database connection is established.
            this.toolStripBtnSave.Enabled = ServerManager.currServer.authConnected;
        }

        private void toolStripBtnNext_Click(object sender, EventArgs e)
        {
            NextAccount();
        }

        private void toolStripBtnPrevious_Click(object sender, EventArgs e)
        {
            PrevAccount();
        }

        private void EditAccountForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            else if (e.KeyData == (Keys.Right | Keys.Alt))
            {
                NextAccount();
                e.Handled = true;
            }
            else if (e.KeyData == (Keys.Left | Keys.Alt))
            {
                PrevAccount();
                e.Handled = true;
            }
        }

        private void NextAccount()
        {
            if (dataChanged && ServerManager.currServer.authConnected)
            {
                switch (MessageBox.Show("Möchten Sie die Änderungen speichern?", "Speichern?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
                {
                    case DialogResult.Yes:
                        Save();
                        break;
                    case DialogResult.Cancel:
                        return;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                } 
            }
            int id = currAcc.id;
            Account nextAcc;

            do
            {
                id++;
                nextAcc = Account.GetAccount(id);
            } while (nextAcc == null && id < Account.GetMaxID());

            if (nextAcc == null)
                return;

            SetData(nextAcc);
            currAcc = nextAcc;
        }

        private void PrevAccount()
        {
            if (dataChanged && ServerManager.currServer.authConnected)
            {
                switch (MessageBox.Show("Möchten Sie die Änderungen speichern?", "Speichern?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
                {
                    case DialogResult.Yes:
                        Save();
                        break;
                    case DialogResult.Cancel:
                        return;
                    case DialogResult.No:
                       break;
                    default:
                        break;
                } 
            }
            int id = currAcc.id;
            Account prevAcc;

            do
            {
                id--;
                prevAcc = Account.GetAccount(id);
            } while (prevAcc == null && id >= 1);

            if (prevAcc == null)
                return;

            SetData(prevAcc);
            currAcc = prevAcc;
        }

        private void OnDataChanged(object sender, EventArgs e)
        {
            dataChanged = true;
        }

        private async void Save()
        {
            if (dataChanged)
            {
                if (ServerManager.currServer.authConnected)
                {
                    currAcc.username = txtUsername.Text;
                    currAcc.email = txtEmail.Text;
                    currAcc.locked = chkLocked.Checked;

                    if (regEmailChanged && (MessageBox.Show("Wollen Sie die Registrations-Email wirklich ändern?", "Registrations-Email ändern?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes))
                        currAcc.reg_mail = txtRegMail.Text;

                    if (await currAcc.SaveAccountToDB())
                        dataChanged = false;
                    else
                        MessageBox.Show("Beim Speichern des Accounts ist ein Fehler aufgetreten.", "Fehler beim Speichern", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                    MessageBox.Show("Es besteht keine Verbindung zur Datenbank. Account konnte nicht gespeichert werden.", "Fehler beim Speichern", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripBtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void EditAccountForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataChanged && ServerManager.currServer.authConnected)
            {
                switch (MessageBox.Show("Möchten Sie die Änderungen speichern?", "Speichern?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
                {
                    case DialogResult.Yes:
                        Save();
                        return;
                    case DialogResult.No:
                        return;
                    default:
                        break;
                }
            }
        }

        private void txtRegMail_TextChanged(object sender, EventArgs e)
        {
            regEmailChanged = true;
            OnDataChanged(sender, e);
        }
    }
}
