using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SLaDE
{
    public partial class frmClips : Form
    {
        public frmClips()
        {
            InitializeComponent();
            Startup.CheckClipsDir(Constants.ClipsPath);
            lstClipNames.Sorted = true;
            RefreshClipBin(Constants.ClipsPath);
        }  

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddNewClip frm = new frmAddNewClip(Constants.ClipsPath);
            if (frm.ShowDialog() != DialogResult.OK) return;
            
            RefreshClipBin(Constants.ClipsPath);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClip.Text)) return;

            Clipboard.SetText(txtClip.Text);
            tmrCopied.Enabled = true;
            lblCopied.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstClipNames.SelectedIndex < 0) return;

            var result = MessageBox.Show("Are you sure you want to delete this clip? This will also delete the clip file.", "Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            File.Delete(Constants.ClipsPath + lstClipNames.SelectedItem.ToString());
            RefreshClipBin(Constants.ClipsPath);

            txtClip.Text = "";
        }

        private void tmrCopied_Tick(object sender, EventArgs e)
        {
            lblCopied.Visible = false;
            tmrCopied.Enabled = false;
        }

        private void RefreshClipBin(string clipdirectory)
        {
            lstClipNames.Items.Clear();

            foreach(string filestr in Directory.GetFiles(clipdirectory))
            {
                FileInfo fi = new FileInfo(filestr);
                lstClipNames.Items.Add(fi.Name);
            }


            txtClip.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstClipNames.SelectedIndex < 0) return;
                

            frmAddNewClip frm = new frmAddNewClip("Edit Clip", lstClipNames.SelectedItem.ToString(), txtClip.Text, Constants.ClipsPath);
            if (frm.ShowDialog() != DialogResult.OK) return;

            RefreshClipBin(Constants.ClipsPath);
        }

        private void lstClipNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstClipNames.SelectedIndex < 0)
            {
                txtClip.Text = "";
                return;
            }

            txtClip.Text = File.ReadAllText(Constants.ClipsPath + lstClipNames.SelectedItem.ToString());
        }

        private void lnkClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to clear the entire clip library? This will also remove all clip files.", "Clear", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            foreach(string file in Directory.GetFiles(Constants.ClipsPath))
            {
                File.Delete(file);
            }

            RefreshClipBin(Constants.ClipsPath);
        }
    }
}
