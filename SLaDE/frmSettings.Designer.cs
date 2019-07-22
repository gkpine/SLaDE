namespace SLaDE
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCoords = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lnkOpenFolder = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMinutes = new System.Windows.Forms.TextBox();
            this.chkBackups = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkUseOldSelector = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkSyntaxHighlight = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkClearConsole = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkCoords);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bottom Status Bar";
            // 
            // chkCoords
            // 
            this.chkCoords.AutoSize = true;
            this.chkCoords.Location = new System.Drawing.Point(21, 30);
            this.chkCoords.Name = "chkCoords";
            this.chkCoords.Size = new System.Drawing.Size(164, 17);
            this.chkCoords.TabIndex = 0;
            this.chkCoords.Text = "Display mouse coordinates";
            this.chkCoords.UseVisualStyleBackColor = true;
            this.chkCoords.CheckedChanged += new System.EventHandler(this.chkCoords_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lnkOpenFolder);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtMinutes);
            this.groupBox2.Controls.Add(this.chkBackups);
            this.groupBox2.Location = new System.Drawing.Point(12, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 83);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Backups";
            // 
            // lnkOpenFolder
            // 
            this.lnkOpenFolder.AutoSize = true;
            this.lnkOpenFolder.Location = new System.Drawing.Point(18, 58);
            this.lnkOpenFolder.Name = "lnkOpenFolder";
            this.lnkOpenFolder.Size = new System.Drawing.Size(136, 13);
            this.lnkOpenFolder.TabIndex = 3;
            this.lnkOpenFolder.TabStop = true;
            this.lnkOpenFolder.Text = "Open the backups folder";
            this.lnkOpenFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOpenFolder_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "minutes";
            // 
            // txtMinutes
            // 
            this.txtMinutes.Location = new System.Drawing.Point(161, 28);
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.Size = new System.Drawing.Size(36, 22);
            this.txtMinutes.TabIndex = 1;
            this.txtMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkBackups
            // 
            this.chkBackups.AutoSize = true;
            this.chkBackups.Location = new System.Drawing.Point(21, 30);
            this.chkBackups.Name = "chkBackups";
            this.chkBackups.Size = new System.Drawing.Size(134, 17);
            this.chkBackups.TabIndex = 0;
            this.chkBackups.Text = "Create backups every";
            this.chkBackups.UseVisualStyleBackColor = true;
            this.chkBackups.CheckedChanged += new System.EventHandler(this.chkBackups_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkUseOldSelector);
            this.groupBox3.Location = new System.Drawing.Point(12, 174);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 64);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Handle Selector";
            // 
            // chkUseOldSelector
            // 
            this.chkUseOldSelector.AutoSize = true;
            this.chkUseOldSelector.Location = new System.Drawing.Point(21, 29);
            this.chkUseOldSelector.Name = "chkUseOldSelector";
            this.chkUseOldSelector.Size = new System.Drawing.Size(192, 17);
            this.chkUseOldSelector.TabIndex = 0;
            this.chkUseOldSelector.Text = "Use old window handle selector";
            this.chkUseOldSelector.UseVisualStyleBackColor = true;
            this.chkUseOldSelector.CheckedChanged += new System.EventHandler(this.chkUseOldSelector_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkSyntaxHighlight);
            this.groupBox4.Location = new System.Drawing.Point(12, 244);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(275, 64);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Text Editor";
            // 
            // chkSyntaxHighlight
            // 
            this.chkSyntaxHighlight.AutoSize = true;
            this.chkSyntaxHighlight.Location = new System.Drawing.Point(21, 29);
            this.chkSyntaxHighlight.Name = "chkSyntaxHighlight";
            this.chkSyntaxHighlight.Size = new System.Drawing.Size(148, 17);
            this.chkSyntaxHighlight.TabIndex = 0;
            this.chkSyntaxHighlight.Text = "Use syntax highlighting";
            this.chkSyntaxHighlight.UseVisualStyleBackColor = true;
            this.chkSyntaxHighlight.CheckedChanged += new System.EventHandler(this.chkSyntaxHighlight_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkClearConsole);
            this.groupBox5.Location = new System.Drawing.Point(12, 314);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(275, 63);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Console";
            // 
            // chkClearConsole
            // 
            this.chkClearConsole.AutoSize = true;
            this.chkClearConsole.Location = new System.Drawing.Point(21, 26);
            this.chkClearConsole.Name = "chkClearConsole";
            this.chkClearConsole.Size = new System.Drawing.Size(216, 17);
            this.chkClearConsole.TabIndex = 0;
            this.chkClearConsole.Text = "Clear console on each new script run";
            this.chkClearConsole.UseVisualStyleBackColor = true;
            this.chkClearConsole.CheckedChanged += new System.EventHandler(this.chkClearConsole_CheckedChanged);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 388);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkCoords;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel lnkOpenFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMinutes;
        private System.Windows.Forms.CheckBox chkBackups;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkUseOldSelector;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkSyntaxHighlight;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkClearConsole;
    }
}