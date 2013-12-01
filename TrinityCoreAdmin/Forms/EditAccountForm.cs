using System;
using System.Windows.Forms;

namespace TrinityCoreAdmin.Forms
{
    public partial class EditAccountForm : Form
    {
        private Account currAcc;

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
            this.dateTimePickerJoinDate.Value = acc.joindate;
            this.dateTimePickerLastLogin.Value = acc.last_login;
            this.lblLastIpData.Text = acc.last_ip;
            this.lblFailedLoginsData.Text = acc.failed_logins.ToString();
            this.lblExpansionData.Text = acc.expansion.ToString();
            this.chkLocked.Checked = acc.locked;
        }

        private void toolStripBtnNext_Click(object sender, EventArgs e)
        {
            NextAccount();
        }

        private void toolStripBtnPrevious_Click(object sender, EventArgs e)
        {
            PrevAccount();
        }

        private void toolStripBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
