using System;
using System.Windows.Forms;
using TrinityCoreAdmin.TheRaidersAPI;

namespace TrinityCoreAdmin
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new TheRaidersAPISoapClient();
            textBox2.Text = client.HelloWorld(textBox1.Text);
        }
    }
}