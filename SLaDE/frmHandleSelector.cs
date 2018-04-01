using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLaDE
{
    public partial class frmHandleSelector : Form
    {

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private Process[] CurrentProcesses = null;
        public string GlobalHwnd = "N/A";

        public frmHandleSelector(string currentHandle)
        {
            InitializeComponent();



            GlobalHwnd = currentHandle;
            lblCurrentHandle.Text = "Current Global Window Handle: " + currentHandle;
                
        }



        private void GetWindowHandles()
        {
            lstWindowTitles.Items.Clear();

            CurrentProcesses = Process.GetProcesses();
            foreach (Process proc in CurrentProcesses)
            {
                if (!string.IsNullOrEmpty(proc.MainWindowTitle))
                    lstWindowTitles.Items.Add("[" + proc.MainWindowHandle.ToString() + "]" + proc.MainWindowTitle);
            }
        }

        private void frmHandleSelector_Load(object sender, EventArgs e)
        {
            GetWindowHandles();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetWindowHandles();
        }

        private void lstWindowTitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSelectedHandle.Text = lstWindowTitles.SelectedItem.ToString().Substring(1, lstWindowTitles.SelectedItem.ToString().IndexOf(']') - 1);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtSelectedHandle.Text);
            lblCopied.Visible = true;
            tmrCopiedLabel.Enabled = true;
        }

        private void tmrCopiedLabel_Tick(object sender, EventArgs e)
        {
            lblCopied.Visible = false;
            tmrCopiedLabel.Enabled = false;

        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (lstWindowTitles.SelectedIndex < 0)
            {
                MessageBox.Show("No window handle was selected in the list. Please select a window handle to make it global.", "Handle", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GlobalHwnd = txtSelectedHandle.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBlank_Click(object sender, EventArgs e)
        {
            txtSelectedHandle.Text = "N/A";
        }
    }
}
