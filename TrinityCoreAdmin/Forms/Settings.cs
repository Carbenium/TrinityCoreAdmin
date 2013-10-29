using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.Serialization;
using System.Security;
using TrinityCoreAdmin.Security;

namespace TrinityCoreAdmin
{
    public partial class Settings : Form
    {
        public static List<Realm> realms = new List<Realm>();

        private enum RealmsStatus
        {
            SAVED = 0,
            CHANGED = 1,
            NEW = 2
        }

        private RealmsStatus Status = RealmsStatus.SAVED;

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            LoadRealms();
        }

        private void LoadRealms()
        {
            FileInfo f = new FileInfo("D:\\config.xml");
            if (f.Exists)
            {
                using (FileStream fs = f.OpenRead())
                {
                    realms = DeserializeRealms(fs);
                }
            }
            else
            {
                Save(true);
            }

            treeRealm.Nodes.Clear();
            TreeNode node = treeRealm.Nodes.Add("Realms");
            treeRealm.SelectedNode = node;

            foreach (Realm r in realms)
            {
                treeRealm.Nodes[0].Nodes.Add(r.Name);
                treeRealm.ExpandAll();
            }
        }

        private void btnNewRealm_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(panelRealm);
            numPort.Value = 3306;
            Status = RealmsStatus.NEW;

            TreeNode newNode = new TreeNode("Neuer Realm");
            TreeNode selectedNode = treeRealm.SelectedNode;

            if (selectedNode.Parent != null)
                selectedNode = selectedNode.Parent;

            selectedNode.Nodes.Add(newNode);
            treeRealm.SelectedNode = newNode;
            newNode.BeginEdit();
            SetEnabledControls(panelRealm, true);
        }

        private void Save(bool reload = false)
        {
            try
            {
                using (FileStream fs = new FileStream("D:\\config.xml", System.IO.FileMode.Create))
                {
                    bool success = SerializeRealms(realms, fs);

                    if (reload && success)
                    {
                        fs.Position = 0;
                        realms = DeserializeRealms(fs);
                    }
                }

                Status = RealmsStatus.SAVED;
            }
            catch (SystemException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (treeRealm.SelectedNode.Level != 0) //Root darf nicht gelöscht werden
            {
                Realm selectedRealm = realms.ElementAt(treeRealm.SelectedNode.Index);
                realms.Remove(selectedRealm);
                treeRealm.SelectedNode.Remove();
            }
        }

        private void treeRealm_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeRealm.SelectedNode.Level == 0)
            {
                ClearTextBoxes(panelRealm);
                SetEnabledControls(panelRealm, false);

                numPort.Value = 3306;
                treeRealm.LabelEdit = false; //Root-Element darf nicht editiert werden
            }
            else
            {
                treeRealm.LabelEdit = true; //Nicht-Root-Elemente dürfen editiert werden

                if (Status == RealmsStatus.NEW)
                    return;

                SetEnabledControls(panelRealm, true);
                Realm selectedRealm = realms.ElementAt(treeRealm.SelectedNode.Index);

                numId.Value = selectedRealm.DbId;
                treeRealm.SelectedNode.Text = selectedRealm.Name;
                txtHost.Text = selectedRealm.Host;
                numPort.Value = selectedRealm.Port;
                txtUser.Text = selectedRealm.User;
                txtPassword.Text = selectedRealm.Password;
                txtAuthDB.Text = selectedRealm.Authdb;
                txtCharDB.Text = selectedRealm.Chardb;
                txtWorldDB.Text = selectedRealm.Worlddb;
            }
        }

        private void treeRealm_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (Status == RealmsStatus.NEW)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    Realm r = new Realm(1, treeRealm.SelectedNode.Text, txtHost.Text, XConverter.ToInt32(numPort.Value), txtUser.Text, txtPassword.Text, txtAuthDB.Text, txtCharDB.Text, txtWorldDB.Text);
                    realms.Add(r);
                });
            }
            else
            {
                Realm selectedRealm = realms.ElementAt(treeRealm.SelectedNode.Index);
                string oldName = selectedRealm.Name;
                this.BeginInvoke((MethodInvoker)delegate
                {
                    selectedRealm.Name = e.Node.Text;
                });
            }
        }

        private void ClearTextBoxes(Panel p)
        {
            for (int i = 0; i < p.Controls.Count; i++)
            {
                if (p.Controls[i].GetType() == typeof(TextBox))
                {
                    p.Controls[i].Text = string.Empty;
                }
            }
        }

        private void SetEnabledControls(Panel p, bool enabled)
        {
            for (int i = 0; i < p.Controls.Count; i++)
            {
                p.Controls[i].Enabled = enabled;
            }
        }

        public static bool SerializeRealms(List<Realm> realms, FileStream stream)
        {
            try
            {
                var serializer = new DataContractSerializer(typeof(List<Realm>));
                var settings = new XmlWriterSettings { Indent = true };
                using (var w = XmlWriter.Create(stream, settings))
                    serializer.WriteObject(w, realms);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        public static List<Realm> DeserializeRealms(FileStream stream)
        {
            var serializer = new DataContractSerializer(typeof(List<Realm>));
            try
            {
                List<Realm> l = (List<Realm>)serializer.ReadObject(stream);
                return l;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return realms;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            UpdateRealm(realms.ElementAt(treeRealm.SelectedNode.Index));
            Save();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateRealm(Realm r)
        {
            r.DbId = XConverter.ToInt32(numId.Value);
            r.Host = txtHost.Text;
            r.Port = XConverter.ToInt32(numPort.Value);
            r.User = txtUser.Text;
            r.Password = txtPassword.Text;
            r.Authdb = txtAuthDB.Text;
            r.Chardb = txtCharDB.Text;
            r.Worlddb = txtWorldDB.Text;
        }
    }
}