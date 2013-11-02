using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml;

namespace TrinityCoreAdmin.Forms
{
    public partial class RealmManagerForm : Form
    {

        public RealmManagerForm()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            LoadRealmsToTree();
        }

        private void LoadRealmsToTree()
        {
            FileInfo f = new FileInfo("D:\\config.xml");
            if (f.Exists)
            {
                using (FileStream fs = f.OpenRead())
                {
                    //RealmManager.realms = DeserializeRealms(fs);
                }
            }
            else
            {
                RealmManager.Save(true);
            }

            treeRealm.Nodes.Clear();
            TreeNode node = treeRealm.Nodes.Add("Realms");


            foreach (Realm r in RealmManager.realms)
            {
                treeRealm.Nodes[0].Nodes.Add(r.Name);
                treeRealm.ExpandAll();
            }
            treeRealm.SelectedNode = node;
        }
        

        private void UpdateRealm(Realm r)
        {
            r.DbId = XConverter.ToInt32(numDbId.Value);
            r.Host = txtHost.Text;
            r.Port = XConverter.ToInt32(numPort.Value);
            r.User = txtUser.Text;
            r.Password = txtPassword.Text;
            r.Authdb = txtAuthDB.Text;
            r.Chardb = txtCharDB.Text;
            r.Worlddb = txtWorldDB.Text;
            
            RealmManager.Status = RealmsStatus.SAVED;
        }

        private void btnNewRealm_Click(object sender, EventArgs e)
        {
            

            if (treeRealm.SelectedNode.Parent != null)
                UpdateRealm(RealmManager.realms.ElementAt(treeRealm.SelectedNode.Index));

            ClearTextBoxes(panelRealm);
            numPort.Value = 3306;
            RealmManager.Status = RealmsStatus.NEW;

            TreeNode newNode = new TreeNode("Neuer Realm");
            TreeNode selectedNode = treeRealm.SelectedNode;

            if (selectedNode.Parent != null)
                selectedNode = selectedNode.Parent;

            selectedNode.Nodes.Add(newNode);
            treeRealm.SelectedNode = newNode;
            newNode.BeginEdit();
            SetEnabledControls(panelRealm, true);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(treeRealm.SelectedNode.Parent != null)
                UpdateRealm(RealmManager.realms.ElementAt(treeRealm.SelectedNode.Index));

            RealmManager.Save();
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (treeRealm.SelectedNode.Level != 0) //Root darf nicht gelöscht werden
            {
                Realm selectedRealm = RealmManager.realms.ElementAt(treeRealm.SelectedNode.Index);
                RealmManager.realms.Remove(selectedRealm);
                treeRealm.SelectedNode.Remove();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeRealm_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeRealm.SelectedNode.Parent == null)
            {
                ClearTextBoxes(panelRealm);
                SetEnabledControls(panelRealm, false);

                numPort.Value = 3306;
                treeRealm.LabelEdit = false; //Root-Element darf nicht editiert werden
            }
            else
            {
                treeRealm.LabelEdit = true; //Nicht-Root-Elemente dürfen editiert werden

                if (RealmManager.Status == RealmsStatus.NEW)
                    return;

                SetEnabledControls(panelRealm, true);
                Realm selectedRealm = RealmManager.realms.ElementAt(treeRealm.SelectedNode.Index);

                numDbId.Value = selectedRealm.DbId;
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
            if (RealmManager.Status == RealmsStatus.NEW)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    Realm r = new Realm(XConverter.ToInt32(numDbId.Value), treeRealm.SelectedNode.Text, txtHost.Text, XConverter.ToInt32(numPort.Value), txtUser.Text, txtPassword.Text, txtAuthDB.Text, txtCharDB.Text, txtWorldDB.Text);
                    RealmManager.realms.Add(r);
                    RealmManager.Status = RealmsStatus.SAVED;
                });
            }
            else
            {
                Realm selectedRealm = RealmManager.realms.ElementAt(treeRealm.SelectedNode.Index);
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

        private void treeRealm_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (treeRealm.SelectedNode != null && treeRealm.SelectedNode.Parent != null && RealmManager.Status != RealmsStatus.NEW)
                UpdateRealm(RealmManager.realms.ElementAt(treeRealm.SelectedNode.Index));
        }
    }
}