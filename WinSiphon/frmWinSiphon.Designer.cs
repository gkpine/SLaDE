namespace WinSiphon
{
    partial class frmWinSiphon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWinSiphon));
            this.panToolbar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.chkUseShown = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCollapse = new System.Windows.Forms.Button();
            this.btnSetGlobal = new System.Windows.Forms.Button();
            this.btnCopyHandle = new System.Windows.Forms.Button();
            this.tvHandles = new System.Windows.Forms.TreeView();
            this.lblGlobalHandle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panToolbar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panToolbar
            // 
            this.panToolbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panToolbar.Controls.Add(this.label1);
            this.panToolbar.Controls.Add(this.chkUseShown);
            this.panToolbar.Controls.Add(this.btnRefresh);
            this.panToolbar.Controls.Add(this.btnCollapse);
            this.panToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panToolbar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panToolbar.Location = new System.Drawing.Point(0, 0);
            this.panToolbar.Name = "panToolbar";
            this.panToolbar.Size = new System.Drawing.Size(556, 43);
            this.panToolbar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 40);
            this.label1.TabIndex = 8;
            this.label1.Text = "WinSiphon";
            // 
            // chkUseShown
            // 
            this.chkUseShown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkUseShown.AutoSize = true;
            this.chkUseShown.Checked = true;
            this.chkUseShown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseShown.Location = new System.Drawing.Point(373, 13);
            this.chkUseShown.Name = "chkUseShown";
            this.chkUseShown.Size = new System.Drawing.Size(170, 17);
            this.chkUseShown.TabIndex = 2;
            this.chkUseShown.Text = "Only check shown windows";
            this.chkUseShown.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(176, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(79, 32);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCollapse
            // 
            this.btnCollapse.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapse.Image")));
            this.btnCollapse.Location = new System.Drawing.Point(261, 4);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(94, 32);
            this.btnCollapse.TabIndex = 0;
            this.btnCollapse.Text = "Collapse All";
            this.btnCollapse.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCollapse.UseVisualStyleBackColor = true;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // btnSetGlobal
            // 
            this.btnSetGlobal.Image = ((System.Drawing.Image)(resources.GetObject("btnSetGlobal.Image")));
            this.btnSetGlobal.Location = new System.Drawing.Point(111, 4);
            this.btnSetGlobal.Name = "btnSetGlobal";
            this.btnSetGlobal.Size = new System.Drawing.Size(150, 32);
            this.btnSetGlobal.TabIndex = 6;
            this.btnSetGlobal.Text = "Set Selected as Global";
            this.btnSetGlobal.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSetGlobal.UseVisualStyleBackColor = true;
            this.btnSetGlobal.Click += new System.EventHandler(this.btnSetGlobal_Click);
            // 
            // btnCopyHandle
            // 
            this.btnCopyHandle.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyHandle.Image")));
            this.btnCopyHandle.Location = new System.Drawing.Point(3, 4);
            this.btnCopyHandle.Name = "btnCopyHandle";
            this.btnCopyHandle.Size = new System.Drawing.Size(104, 32);
            this.btnCopyHandle.TabIndex = 3;
            this.btnCopyHandle.Text = "Copy Selected";
            this.btnCopyHandle.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCopyHandle.UseVisualStyleBackColor = true;
            this.btnCopyHandle.Click += new System.EventHandler(this.txtCopyHandle_Click);
            // 
            // tvHandles
            // 
            this.tvHandles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvHandles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvHandles.Location = new System.Drawing.Point(0, 43);
            this.tvHandles.Name = "tvHandles";
            this.tvHandles.Size = new System.Drawing.Size(556, 334);
            this.tvHandles.TabIndex = 1;
            this.tvHandles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvHandles_AfterSelect);
            // 
            // lblGlobalHandle
            // 
            this.lblGlobalHandle.AutoSize = true;
            this.lblGlobalHandle.Location = new System.Drawing.Point(267, 14);
            this.lblGlobalHandle.Name = "lblGlobalHandle";
            this.lblGlobalHandle.Size = new System.Drawing.Size(174, 13);
            this.lblGlobalHandle.TabIndex = 7;
            this.lblGlobalHandle.Text = "Global handle will be set to: N/A";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSetGlobal);
            this.panel1.Controls.Add(this.lblGlobalHandle);
            this.panel1.Controls.Add(this.btnCopyHandle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 377);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 43);
            this.panel1.TabIndex = 2;
            // 
            // frmWinSiphon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 420);
            this.Controls.Add(this.tvHandles);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panToolbar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmWinSiphon";
            this.Text = "WinSiphon";
            this.panToolbar.ResumeLayout(false);
            this.panToolbar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panToolbar;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCollapse;
        private System.Windows.Forms.TreeView tvHandles;
        private System.Windows.Forms.CheckBox chkUseShown;
        private System.Windows.Forms.Button btnSetGlobal;
        private System.Windows.Forms.Button btnCopyHandle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGlobalHandle;
        private System.Windows.Forms.Panel panel1;
    }
}

