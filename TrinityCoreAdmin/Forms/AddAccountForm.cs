using System;
using System.Windows.Forms;

namespace TrinityCoreAdmin.Forms
{
    public partial class AddAccountForm : Form
    {
        public AddAccountForm()
        {
            InitializeComponent();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            AccountOpResult res = await Account.CreateAccount(txtUsename.Text, txtPassword.Text, txtEmail.Text);
            if (res == AccountOpResult.AOR_OK)
                this.Close();
            else
            {
                string message = String.Empty;
                switch (res)
                {
                    case AccountOpResult.AOR_NAME_TOO_LONG:
                        message = "Der Username ist zu lang. Maximal 16 Zeichen";
                        break;
                    case AccountOpResult.AOR_PASS_TOO_LONG:
                        message = "Das Passwort ist zu lang. Maximal 16 Zeichen";
                        break;
                    case AccountOpResult.AOR_EMAIL_TOO_LONG:
                        message = "Die E-Mail Adresse ist zu lang. Maximal 64 Zeichen.";
                        break;
                    case AccountOpResult.AOR_NAME_ALREADY_EXIST:
                        message = "Der Benutzername ist bereits vergeben.";
                        break;
                    case AccountOpResult.AOR_INTERNAL_ERROR:
                        message = "Es ist ein interner Fehler während der Accounterstellung aufgetreten.";
                        break;
                    default:
                        break;
                }
                MessageBox.Show(message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}