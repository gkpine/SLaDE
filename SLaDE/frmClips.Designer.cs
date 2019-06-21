namespace SLaDE
{
    partial class frmClips
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClips));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lstClipNames = new System.Windows.Forms.ListBox();
            this.txtClip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCopied = new System.Windows.Forms.Label();
            this.tmrCopied = new System.Windows.Forms.Timer(this.components);
            this.lnkClear = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(29, 80);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add new";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(191, 80);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(110, 80);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(272, 80);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(115, 23);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "Copy to Clipboard";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lstClipNames
            // 
            this.lstClipNames.FormattingEnabled = true;
            this.lstClipNames.Location = new System.Drawing.Point(29, 109);
            this.lstClipNames.Name = "lstClipNames";
            this.lstClipNames.Size = new System.Drawing.Size(156, 381);
            this.lstClipNames.TabIndex = 4;
            this.lstClipNames.SelectedIndexChanged += new System.EventHandler(this.lstClipNames_SelectedIndexChanged);
            // 
            // txtClip
            // 
            this.txtClip.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClip.Location = new System.Drawing.Point(191, 109);
            this.txtClip.Multiline = true;
            this.txtClip.Name = "txtClip";
            this.txtClip.ReadOnly = true;
            this.txtClip.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtClip.Size = new System.Drawing.Size(451, 381);
            this.txtClip.TabIndex = 5;
            this.txtClip.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 37);
            this.label1.TabIndex = 6;
            this.label1.Text = "SLaDE Clip Library";
            // 
            // lblCopied
            // 
            this.lblCopied.AutoSize = true;
            this.lblCopied.Location = new System.Drawing.Point(393, 85);
            this.lblCopied.Name = "lblCopied";
            this.lblCopied.Size = new System.Drawing.Size(47, 13);
            this.lblCopied.TabIndex = 8;
            this.lblCopied.Text = "Copied!";
            this.lblCopied.Visible = false;
            // 
            // tmrCopied
            // 
            this.tmrCopied.Interval = 2000;
            this.tmrCopied.Tick += new System.EventHandler(this.tmrCopied_Tick);
            // 
            // lnkClear
            // 
            this.lnkClear.AutoSize = true;
            this.lnkClear.Location = new System.Drawing.Point(25, 493);
            this.lnkClear.Name = "lnkClear";
            this.lnkClear.Size = new System.Drawing.Size(68, 13);
            this.lnkClear.TabIndex = 9;
            this.lnkClear.TabStop = true;
            this.lnkClear.Text = "Clear library";
            this.lnkClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClear_LinkClicked);
            // 
            // frmClips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 515);
            this.Controls.Add(this.lnkClear);
            this.Controls.Add(this.lblCopied);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtClip);
            this.Controls.Add(this.lstClipNames);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClips";
            this.Text = "Code Clips";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.ListBox lstClipNames;
        private System.Windows.Forms.TextBox txtClip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCopied;
        private System.Windows.Forms.Timer tmrCopied;
        private System.Windows.Forms.LinkLabel lnkClear;
    }
}