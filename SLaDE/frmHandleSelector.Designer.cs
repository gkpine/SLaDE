namespace SLaDE
{
    partial class frmHandleSelector
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHandleSelector));
            this.lstWindowTitles = new System.Windows.Forms.ListBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.lblCurrentHandle = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSelectedHandle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblCopied = new System.Windows.Forms.Label();
            this.tmrCopiedLabel = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBlank = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstWindowTitles
            // 
            this.lstWindowTitles.FormattingEnabled = true;
            this.lstWindowTitles.Location = new System.Drawing.Point(12, 48);
            this.lstWindowTitles.Name = "lstWindowTitles";
            this.lstWindowTitles.Size = new System.Drawing.Size(364, 108);
            this.lstWindowTitles.TabIndex = 0;
            this.lstWindowTitles.SelectedIndexChanged += new System.EventHandler(this.lstWindowTitles_SelectedIndexChanged);
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(245, 13);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(112, 30);
            this.btnSet.TabIndex = 1;
            this.btnSet.Text = "Set As Global";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // lblCurrentHandle
            // 
            this.lblCurrentHandle.AutoSize = true;
            this.lblCurrentHandle.Location = new System.Drawing.Point(50, 17);
            this.lblCurrentHandle.Name = "lblCurrentHandle";
            this.lblCurrentHandle.Size = new System.Drawing.Size(227, 13);
            this.lblCurrentHandle.TabIndex = 2;
            this.lblCurrentHandle.Text = "Current Script Global Window Handle: N/A";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::SLaDE.Properties.Resources.restart_24px;
            this.btnRefresh.Location = new System.Drawing.Point(12, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(32, 32);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSelectedHandle
            // 
            this.txtSelectedHandle.Location = new System.Drawing.Point(111, 164);
            this.txtSelectedHandle.Name = "txtSelectedHandle";
            this.txtSelectedHandle.ReadOnly = true;
            this.txtSelectedHandle.Size = new System.Drawing.Size(153, 22);
            this.txtSelectedHandle.TabIndex = 4;
            this.txtSelectedHandle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Selected Handle:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(6, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            this.btnCopy.Image = global::SLaDE.Properties.Resources.copy_16px;
            this.btnCopy.Location = new System.Drawing.Point(353, 163);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(24, 24);
            this.btnCopy.TabIndex = 7;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblCopied
            // 
            this.lblCopied.AutoSize = true;
            this.lblCopied.ForeColor = System.Drawing.Color.Green;
            this.lblCopied.Location = new System.Drawing.Point(159, 22);
            this.lblCopied.Name = "lblCopied";
            this.lblCopied.Size = new System.Drawing.Size(47, 13);
            this.lblCopied.TabIndex = 8;
            this.lblCopied.Text = "Copied!";
            this.lblCopied.Visible = false;
            // 
            // tmrCopiedLabel
            // 
            this.tmrCopiedLabel.Interval = 2000;
            this.tmrCopiedLabel.Tick += new System.EventHandler(this.tmrCopiedLabel_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.lblCopied);
            this.groupBox1.Controls.Add(this.btnSet);
            this.groupBox1.Location = new System.Drawing.Point(14, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 50);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // btnBlank
            // 
            this.btnBlank.Location = new System.Drawing.Point(272, 163);
            this.btnBlank.Name = "btnBlank";
            this.btnBlank.Size = new System.Drawing.Size(75, 24);
            this.btnBlank.TabIndex = 10;
            this.btnBlank.Text = "Make Blank";
            this.btnBlank.UseVisualStyleBackColor = true;
            this.btnBlank.Click += new System.EventHandler(this.btnBlank_Click);
            // 
            // frmHandleSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 252);
            this.Controls.Add(this.btnBlank);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSelectedHandle);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblCurrentHandle);
            this.Controls.Add(this.lstWindowTitles);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHandleSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Handle Selector";
            this.Load += new System.EventHandler(this.frmHandleSelector_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstWindowTitles;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Label lblCurrentHandle;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSelectedHandle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblCopied;
        private System.Windows.Forms.Timer tmrCopiedLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBlank;
    }
}