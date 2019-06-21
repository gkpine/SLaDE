using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLaDE
{
    public partial class frmSettings : Form
    {
        frmMain parent;

        public frmSettings(frmMain parent)
        {
            InitializeComponent();
            this.FormClosing += FrmSettings_FormClosing;

            this.parent = parent;
        }

        private void FrmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (chkBackups.Checked && !IsNumeric(txtMinutes.Text))
            {
                MessageBox.Show("The value entered for the backup interval is not valid. Please revisit this value or disable backups.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void chkCoords_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MouseCoordinates = chkCoords.Checked;
            Properties.Settings.Default.Save();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            chkCoords.Checked = Properties.Settings.Default.MouseCoordinates;
            chkBackups.Checked = Properties.Settings.Default.Backups;
            chkUseOldSelector.Checked = Properties.Settings.Default.UseOldSelector;
            chkSyntaxHighlight.Checked = Properties.Settings.Default.UseSyntaxHighlighting;

            txtMinutes.Text = Properties.Settings.Default.BackupMins.ToString();
            txtMinutes.Enabled = chkBackups.Checked;
        }

        private bool IsNumeric(string val)
        {
            int ret = 0;
            return int.TryParse(val, out ret);
        }

        private void chkBackups_CheckedChanged(object sender, EventArgs e)
        {
            txtMinutes.Enabled = chkBackups.Checked;
            Properties.Settings.Default.Backups = chkBackups.Checked;

            if (IsNumeric(txtMinutes.Text))
                Properties.Settings.Default.BackupMins = Convert.ToInt32(txtMinutes.Text);

            Properties.Settings.Default.Save();
        }

        private void lnkOpenFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\backups\\");
        }

        private void chkUseOldSelector_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.UseOldSelector = chkUseOldSelector.Checked;
            Properties.Settings.Default.Save();
        }

        private void chkSyntaxHighlight_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.UseSyntaxHighlighting = chkSyntaxHighlight.Checked;
            Properties.Settings.Default.Save();

            parent.OnSettingsChanged();
        }
    }
}
