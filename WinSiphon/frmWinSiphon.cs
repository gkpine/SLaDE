using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinSiphon
{
    public partial class frmWinSiphon : Form
    {

        public string GlobalHwnd = "";
        private string SelectedHwnd = "";

        public frmWinSiphon(bool enableGlobal = false)
        {
            InitializeComponent();

            InitTopNodes();
            this.FormClosing += FrmWinSiphon_FormClosing;

            btnSetGlobal.Visible = enableGlobal;
            lblGlobalHandle.Visible = enableGlobal;
        }

        private void FrmWinSiphon_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;    
        }

        private void InitTopNodes()
        {
            tvHandles.BeginUpdate();
            tvHandles.Nodes.Clear();

            Task mainTask = new Task(() =>
            {
                List<IntPtr> topHandles;

                if (!chkUseShown.Checked)
                    topHandles = WindowHandleManager.GetTopHandles();
                else
                    topHandles = WindowHandleManager.GetAllProcessHandles();

                foreach (IntPtr handle in topHandles)
                {
                    TreeNode parentNode = null;
                    if (tvHandles.InvokeRequired)
                        tvHandles.Invoke(new Action(() => { parentNode = tvHandles.Nodes.Add(AssembleNodeText(handle)); }));
                    
                    PopulateTreeRecursive(parentNode, handle);
                }
            });

            mainTask.Start();

            tvHandles.EndUpdate();

        }

        private string AssembleNodeText(IntPtr handle)
        {
            string windowText = WindowHandleManager.GetWindowTextWithHwnd(handle);
            string windowClass = WindowHandleManager.GetClassNameForHwnd(handle);
            string handleStr = handle.ToString();

            windowText = (string.IsNullOrEmpty(windowText) ? "NO TITLE" : windowText);
            windowClass = (string.IsNullOrEmpty(windowClass) ? "NO CLASSNAME" : windowClass);

            return "Handle: " + handleStr + ", Title: " + windowText + ", Class: " + windowClass;
        }

        private void PopulateTreeRecursive(TreeNode parentNode, IntPtr parentHwnd)
        {
            List<IntPtr> children = WindowHandleManager.GetAllChildHandles(parentHwnd);
            foreach(IntPtr child in children)
            {
                TreeNode currentNode = null;
                if (tvHandles.InvokeRequired)
                    tvHandles.Invoke(new Action(() => { currentNode = parentNode.Nodes.Add(AssembleNodeText(child)); }));

                PopulateTreeRecursive(currentNode, child);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitTopNodes();
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            tvHandles.CollapseAll();
        }

        private void btnSetGlobal_Click(object sender, EventArgs e)
        {
            if (tvHandles.SelectedNode == null)
            {
                MessageBox.Show("You must select a node first to set its handle as global.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GlobalHwnd = SelectedHwnd;
            lblGlobalHandle.Text = "Global handle will be set to: " + SelectedHwnd;
        }

        private void tvHandles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string[] items = tvHandles.SelectedNode.Text.ToString().Split(',');
            SelectedHwnd = items[0].Replace("Handle: ", "").Trim();
        }

        private void txtCopyHandle_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(SelectedHwnd);
        }
    }
}
