namespace SLaDE
{
    partial class frmAddNewClip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddNewClip));
            this.txtClip = new FastColoredTextBoxNS.FastColoredTextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtClip)).BeginInit();
            this.SuspendLayout();
            // 
            // txtClip
            // 
            this.txtClip.AutoCompleteBrackets = true;
            this.txtClip.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtClip.AutoScrollMinSize = new System.Drawing.Size(25, 15);
            this.txtClip.BackBrush = null;
            this.txtClip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClip.CharHeight = 15;
            this.txtClip.CharWidth = 7;
            this.txtClip.CurrentLineColor = System.Drawing.Color.DarkGray;
            this.txtClip.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtClip.DescriptionFile = "";
            this.txtClip.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtClip.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtClip.IsReplaceMode = false;
            this.txtClip.Location = new System.Drawing.Point(5, 41);
            this.txtClip.Name = "txtClip";
            this.txtClip.Paddings = new System.Windows.Forms.Padding(0);
            this.txtClip.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtClip.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtClip.ServiceColors")));
            this.txtClip.ShowFoldingLines = true;
            this.txtClip.Size = new System.Drawing.Size(397, 236);
            this.txtClip.TabIndex = 1;
            this.txtClip.Zoom = 100;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(210, 283);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open file";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(291, 283);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(111, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(36, 11);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(366, 22);
            this.txtTitle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Title:";
            // 
            // frmAddNewClip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 313);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtClip);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddNewClip";
            this.Text = "Add Clip";
            ((System.ComponentModel.ISupportInitialize)(this.txtClip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox txtClip;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
    }
}