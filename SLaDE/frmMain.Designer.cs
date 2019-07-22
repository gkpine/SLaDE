namespace SLaDE
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tsControls = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClips = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRun = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblHwnd = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.lblStatus = new System.Windows.Forms.ToolStripLabel();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkScriptTaskStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.windowHandleSelectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colourSelectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitmapSelectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licensingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freeIconsByIcons8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssData = new System.Windows.Forms.StatusStrip();
            this.lblCoordinates = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrBackgroundMonitor = new System.Windows.Forms.Timer(this.components);
            this.tmrBackup = new System.Windows.Forms.Timer(this.components);
            this.txtEditor = new FastColoredTextBoxNS.FastColoredTextBox();
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConsoleVisible = new System.Windows.Forms.ToolStripButton();
            this.debugConsole = new SLaDE.SladeConsole();
            this.tsControls.SuspendLayout();
            this.msMenu.SuspendLayout();
            this.ssData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsControls
            // 
            this.tsControls.AutoSize = false;
            this.tsControls.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnSettings,
            this.toolStripSeparator4,
            this.btnNew,
            this.btnSave,
            this.btnOpen,
            this.btnFind,
            this.toolStripSeparator6,
            this.btnClips,
            this.toolStripSeparator2,
            this.btnRun,
            this.toolStripSeparator3,
            this.lblHwnd,
            this.toolStripSeparator5,
            this.btnConsoleVisible,
            this.toolStripSeparator7,
            this.lblStatus});
            this.tsControls.Location = new System.Drawing.Point(0, 24);
            this.tsControls.Name = "tsControls";
            this.tsControls.Size = new System.Drawing.Size(775, 36);
            this.tsControls.TabIndex = 9;
            this.tsControls.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // btnSettings
            // 
            this.btnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(23, 33);
            this.btnSettings.Text = "Settings";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 36);
            // 
            // btnNew
            // 
            this.btnNew.AutoSize = false;
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = global::SLaDE.Properties.Resources.Add_New_16px;
            this.btnNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(32, 32);
            this.btnNew.Text = "New";
            this.btnNew.ToolTipText = "New Script";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::SLaDE.Properties.Resources.Save_16px;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(32, 32);
            this.btnSave.Text = "Save";
            this.btnSave.ToolTipText = "Save Script";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.AutoSize = false;
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = global::SLaDE.Properties.Resources.Open_16px;
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(32, 32);
            this.btnOpen.Text = "Open";
            this.btnOpen.ToolTipText = "Open Script";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnFind
            // 
            this.btnFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(23, 33);
            this.btnFind.Text = "Find (Ctrl+F)";
            this.btnFind.ToolTipText = "Find (Ctrl+F)";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 36);
            // 
            // btnClips
            // 
            this.btnClips.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClips.Image = ((System.Drawing.Image)(resources.GetObject("btnClips.Image")));
            this.btnClips.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClips.Name = "btnClips";
            this.btnClips.Size = new System.Drawing.Size(71, 33);
            this.btnClips.Text = "Clip Library";
            this.btnClips.Click += new System.EventHandler(this.btnClips_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 36);
            // 
            // btnRun
            // 
            this.btnRun.AutoSize = false;
            this.btnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRun.Image = global::SLaDE.Properties.Resources.Play_16px;
            this.btnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(32, 32);
            this.btnRun.Text = "Run Script";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 36);
            // 
            // lblHwnd
            // 
            this.lblHwnd.Name = "lblHwnd";
            this.lblHwnd.Size = new System.Drawing.Size(157, 33);
            this.lblHwnd.Text = "Global Window Handle: N/A";
            this.lblHwnd.Click += new System.EventHandler(this.lblHwnd_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 36);
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(64, 33);
            this.lblStatus.Text = "Status: Idle";
            this.lblStatus.ToolTipText = "Current Status";
            // 
            // msMenu
            // 
            this.msMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.licensingToolStripMenuItem});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(775, 24);
            this.msMenu.TabIndex = 13;
            this.msMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 6);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkScriptTaskStatusToolStripMenuItem,
            this.toolStripMenuItem3,
            this.windowHandleSelectorToolStripMenuItem,
            this.colourSelectorToolStripMenuItem,
            this.bitmapSelectorToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // checkScriptTaskStatusToolStripMenuItem
            // 
            this.checkScriptTaskStatusToolStripMenuItem.Name = "checkScriptTaskStatusToolStripMenuItem";
            this.checkScriptTaskStatusToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.checkScriptTaskStatusToolStripMenuItem.Text = "Script Thread Status (Debug)";
            this.checkScriptTaskStatusToolStripMenuItem.Click += new System.EventHandler(this.checkScriptTaskStatusToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(222, 6);
            // 
            // windowHandleSelectorToolStripMenuItem
            // 
            this.windowHandleSelectorToolStripMenuItem.Name = "windowHandleSelectorToolStripMenuItem";
            this.windowHandleSelectorToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.windowHandleSelectorToolStripMenuItem.Text = "Window Handle Selector";
            this.windowHandleSelectorToolStripMenuItem.Click += new System.EventHandler(this.windowHandleSelectorToolStripMenuItem_Click);
            // 
            // colourSelectorToolStripMenuItem
            // 
            this.colourSelectorToolStripMenuItem.Name = "colourSelectorToolStripMenuItem";
            this.colourSelectorToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.colourSelectorToolStripMenuItem.Text = "Colour Selector";
            this.colourSelectorToolStripMenuItem.Click += new System.EventHandler(this.colourSelectorToolStripMenuItem_Click);
            // 
            // bitmapSelectorToolStripMenuItem
            // 
            this.bitmapSelectorToolStripMenuItem.Name = "bitmapSelectorToolStripMenuItem";
            this.bitmapSelectorToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.bitmapSelectorToolStripMenuItem.Text = "Bitmap Selector";
            this.bitmapSelectorToolStripMenuItem.Click += new System.EventHandler(this.bitmapSelectorToolStripMenuItem_Click);
            // 
            // licensingToolStripMenuItem
            // 
            this.licensingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.freeIconsByIcons8ToolStripMenuItem});
            this.licensingToolStripMenuItem.Name = "licensingToolStripMenuItem";
            this.licensingToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.licensingToolStripMenuItem.Text = "&Licensing";
            // 
            // freeIconsByIcons8ToolStripMenuItem
            // 
            this.freeIconsByIcons8ToolStripMenuItem.Name = "freeIconsByIcons8ToolStripMenuItem";
            this.freeIconsByIcons8ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.freeIconsByIcons8ToolStripMenuItem.Text = "Free Icons by Icons8";
            this.freeIconsByIcons8ToolStripMenuItem.Click += new System.EventHandler(this.freeIconsByIcons8ToolStripMenuItem_Click);
            // 
            // ssData
            // 
            this.ssData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCoordinates});
            this.ssData.Location = new System.Drawing.Point(0, 508);
            this.ssData.Name = "ssData";
            this.ssData.Size = new System.Drawing.Size(775, 22);
            this.ssData.TabIndex = 10;
            this.ssData.Text = "statusStrip1";
            // 
            // lblCoordinates
            // 
            this.lblCoordinates.Name = "lblCoordinates";
            this.lblCoordinates.Size = new System.Drawing.Size(61, 17);
            this.lblCoordinates.Text = "0000, 0000";
            // 
            // tmrBackgroundMonitor
            // 
            this.tmrBackgroundMonitor.Enabled = true;
            this.tmrBackgroundMonitor.Interval = 15;
            this.tmrBackgroundMonitor.Tick += new System.EventHandler(this.tmrBackgroundMonitor_Tick);
            // 
            // tmrBackup
            // 
            this.tmrBackup.Tick += new System.EventHandler(this.tmrBackup_Tick);
            // 
            // txtEditor
            // 
            this.txtEditor.AutoCompleteBrackets = true;
            this.txtEditor.AutoCompleteBracketsList = new char[] {
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
            this.txtEditor.AutoScrollMinSize = new System.Drawing.Size(25, 15);
            this.txtEditor.BackBrush = null;
            this.txtEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEditor.CharHeight = 15;
            this.txtEditor.CharWidth = 7;
            this.txtEditor.CurrentLineColor = System.Drawing.Color.DarkGray;
            this.txtEditor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEditor.DescriptionFile = "";
            this.txtEditor.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEditor.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.txtEditor.IsReplaceMode = false;
            this.txtEditor.Location = new System.Drawing.Point(0, 0);
            this.txtEditor.Name = "txtEditor";
            this.txtEditor.Paddings = new System.Windows.Forms.Padding(0);
            this.txtEditor.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtEditor.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtEditor.ServiceColors")));
            this.txtEditor.ShowFoldingLines = true;
            this.txtEditor.Size = new System.Drawing.Size(775, 245);
            this.txtEditor.TabIndex = 14;
            this.txtEditor.Zoom = 100;
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(0, 60);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.Controls.Add(this.txtEditor);
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.Controls.Add(this.debugConsole);
            this.mainContainer.Panel2.Controls.Add(this.panel1);
            this.mainContainer.Size = new System.Drawing.Size(775, 448);
            this.mainContainer.SplitterDistance = 245;
            this.mainContainer.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 28);
            this.panel1.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(3, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(104, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear Console";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 36);
            // 
            // btnConsoleVisible
            // 
            this.btnConsoleVisible.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnConsoleVisible.Image = ((System.Drawing.Image)(resources.GetObject("btnConsoleVisible.Image")));
            this.btnConsoleVisible.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConsoleVisible.Name = "btnConsoleVisible";
            this.btnConsoleVisible.Size = new System.Drawing.Size(91, 33);
            this.btnConsoleVisible.Text = "Console Visible";
            this.btnConsoleVisible.Click += new System.EventHandler(this.btnConsoleVisible_Click);
            // 
            // debugConsole
            // 
            this.debugConsole.AnnounceColour = System.Drawing.Color.Magenta;
            this.debugConsole.BackColor = System.Drawing.Color.Black;
            this.debugConsole.DefaultHeader = "== Welcome to SLaDE ==";
            this.debugConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debugConsole.ErrorColour = System.Drawing.Color.Red;
            this.debugConsole.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debugConsole.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.debugConsole.Location = new System.Drawing.Point(0, 28);
            this.debugConsole.Name = "debugConsole";
            this.debugConsole.NormalTextColour = System.Drawing.Color.WhiteSmoke;
            this.debugConsole.Size = new System.Drawing.Size(775, 171);
            this.debugConsole.SuccessColour = System.Drawing.Color.Green;
            this.debugConsole.TabIndex = 2;
            this.debugConsole.Text = "";
            this.debugConsole.WarningColour = System.Drawing.Color.Yellow;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 530);
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.tsControls);
            this.Controls.Add(this.msMenu);
            this.Controls.Add(this.ssData);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMenu;
            this.Name = "frmMain";
            this.Text = "SLaDE";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tsControls.ResumeLayout(false);
            this.tsControls.PerformLayout();
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.ssData.ResumeLayout(false);
            this.ssData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditor)).EndInit();
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip tsControls;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnRun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel lblStatus;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licensingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freeIconsByIcons8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnClips;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkScriptTaskStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.StatusStrip ssData;
        private System.Windows.Forms.ToolStripStatusLabel lblCoordinates;
        private System.Windows.Forms.Timer tmrBackgroundMonitor;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Timer tmrBackup;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem windowHandleSelectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel lblHwnd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem bitmapSelectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colourSelectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private FastColoredTextBoxNS.FastColoredTextBox txtEditor;
        private System.Windows.Forms.SplitContainer mainContainer;
        private System.Windows.Forms.Panel panel1;
        private SladeConsole debugConsole;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolStripButton btnConsoleVisible;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    }
}

