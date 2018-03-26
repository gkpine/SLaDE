using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLaDE
{
    public partial class frmAddNewClip : Form
    {

        private string originaltitle = "";

        private bool isEdit;

        private string clipdir;

        public frmAddNewClip(string clipdir)
        {
            InitializeComponent();
            this.clipdir = clipdir;
            isEdit = false;
        }

        public frmAddNewClip(string formtitle, string cliptitle, string edit, string clipdir)
        {
            InitializeComponent();

            this.Text = formtitle;
            txtClip.Text = edit;
            txtTitle.Text = cliptitle;

            isEdit = true;
            this.clipdir = clipdir;
            originaltitle = cliptitle;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.Cancel) return;

            txtClip.Text = File.ReadAllText(ofd.FileName);
        }
            
        private void btnSubmit_Click(object sender, EventArgs e)
        {

            if (txtTitle.Text.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
            {
                MessageBox.Show("The script title must work as a valid file name. You do not need to add a file extension, but the title itself should be a valid filename.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isEdit && File.Exists(clipdir + txtTitle.Text + ".txt"))
            {
                var result = MessageBox.Show("A clip by this name already exists. Would you like to overwrite it?", "Overwrite", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
            }

            if (isEdit && originaltitle != txtTitle.Text)
            {
                File.Delete(clipdir + originaltitle);
            }

            if (!txtTitle.Text.EndsWith(".txt")) File.WriteAllText(clipdir + txtTitle.Text + ".txt", txtClip.Text);
            else File.WriteAllText(clipdir + txtTitle.Text, txtClip.Text);

            this.DialogResult = DialogResult.OK;
        }

    }
}
