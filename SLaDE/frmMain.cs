using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using WinSiphon;
using System.Threading;
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SLaDE
{

    // Documentation
    // Colour picker: https://stackoverflow.com/questions/1483928/how-to-read-the-color-of-a-screen-pixel

    public partial class frmMain : Form
    {
        private const string ConsoleTitle = "SLaDE Console";

        public const string CurrentVersion = "alpha2.02";
        public const string UpdateURL = "https://www.sythe.org/threads/slade-alpha-release-testing-but-kinda-sorta-stable/";

        // We run into access issues if the GlobalHwnd is IntPtr,
        // and since we only ever use it as a string it will be 
        // stored as such.
        public string GlobalHwnd = "N/A";

        private string SytheLibExecutable;
        private string DataDirectory;
        private string TessdataDirectory;
        private string BackupDir;
        private string ReceivedJson = "";

        private string currentScriptFile;

        // The SytheLibProt.exe instance
        private Process proc;
        // The SytheLib thread
        private Task ScriptTask;

        private bool isDirty = false;
        private bool isRunning = false;

        // Used to silence the process listener events when running script
        // based tools
        private bool SilentPipe = false;

        TextStyle DarkBlueStyle = new TextStyle(Brushes.DarkBlue, null, FontStyle.Regular);
        TextStyle BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        TextStyle GrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        TextStyle MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
        TextStyle GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Regular);
        TextStyle BrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Regular);
        TextStyle MaroonStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);
        MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));

        private enum Selector
        {
            SLBitmap, SLColour, BluBitmap, BluColour
        }

        #region Variable Init and Data Checks (Startup)

        private void InitVariables()
        {
            DataDirectory = Environment.CurrentDirectory + "\\data\\";
            SytheLibExecutable = "SytheLibProt.exe";
            currentScriptFile = "";
            TessdataDirectory = Environment.CurrentDirectory + "\\tessdata\\";
            BackupDir = Environment.CurrentDirectory + "\\backups\\";
        }

        private void CheckFilesAndFolders()
        {
            Startup.CheckDataDir(DataDirectory);
            Startup.CheckBackupDir(BackupDir);

            // both of the following conditions have to be true for the run button to be enabled
            bool canRun = Startup.CheckSLExecutable(SytheLibExecutable) && Startup.CheckTessdataDir(TessdataDirectory);
            btnRun.Enabled = canRun;
        }

        #endregion

        #region Constructor

        public frmMain()
        {
            InitializeComponent();

            this.FormClosing += FrmMain_FormClosing;
            txtEditor.TextChanged += TxtEditor_TextChanged;
            debugConsole.UserInputEntered += DebugConsole_UserInputEntered;

            InitVariables();
            CheckFilesAndFolders();

            txtEditor.Language = FastColoredTextBoxNS.Language.Custom;

            ApplySettings();

            debugConsole.DefaultHeader = "== Welcome to SLaDE ==";
            debugConsole.PrintHeader();
        }

        #endregion

        #region Tool Selectors

        private void RunToolScript(Selector selector)
        {

            if (GlobalHwnd == "N/A")
            {
                var result = MessageBox.Show("You cannot use a colour or bitmap selector without first setting a global window handle. Would you like to set a global window handle now?", "Handle", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes) windowHandleSelectorToolStripMenuItem.PerformClick();
                return;
            }

            switch (selector)
            {
                case Selector.SLColour:
                    File.Delete(Environment.CurrentDirectory + "\\data\\SLColour.dat");
                    File.WriteAllText(
                        Environment.CurrentDirectory + "\\data\\SLColour.dat",
                        "global GUI_PASSED_HWND = " + GlobalHwnd + ";\n" +
                        "SetWindowByHWND(GUI_PASSED_HWND);\n" +
                        "Scrape();\n" +
                        "print(ShowColorPicker());\n" +
                        "//<SCRIPT END>"
                    );
                    currentScriptFile = Environment.CurrentDirectory + "\\data\\SLColour.dat";
                    break;

                case Selector.SLBitmap:
                    File.Delete(Environment.CurrentDirectory + "\\data\\SLBitmap.dat");
                    File.WriteAllText(
                        Environment.CurrentDirectory + "\\data\\SLBitmap.dat",
                        "global GUI_PASSED_HWND = " + GlobalHwnd + ";\n" +
                        "SetWindowByHWND(GUI_PASSED_HWND);\n" +
                        "Scrape();\n" +
                        "print(ShowBitmapPicker());\n" +
                        "//<SCRIPT END>"
                    );
                    currentScriptFile = Environment.CurrentDirectory + "\\data\\SLBitmap.dat";
                    break;

                default:
                    break;
            }

            SilentPipe = true;
            (new Task(() => { StartSytheLibInstance(true); })).Start();
        }



        #endregion

        #region Main toolbar

        private void btnConsoleVisible_Click(object sender, EventArgs e)
        {
            mainContainer.Panel2Collapsed = !mainContainer.Panel2Collapsed;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            txtEditor.ShowFindDialog();
        }

        private void lblHwnd_Click(object sender, EventArgs e)
        {
            if (GlobalHwnd == "N/A")
            {
                var result = MessageBox.Show("You haven't selected a global window handle to use with the current script. Would you like to set one now?", "Window Handle", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;

                // if yes...
                windowHandleSelectorToolStripMenuItem.PerformClick();
                return;
            }
            else
            {
                var result = MessageBox.Show("Would you like to reset the global window handle?", "Window Handle", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) GlobalHwnd = "N/A";
            }
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            if (ScriptTask != null && ScriptTask.Status == TaskStatus.Running)
            {
                KillSytheLib();
                Application.DoEvents();
                SystemLog("Script manually stopped.", debugConsole.WarningColour);
                return;
            }

            currentScriptFile = DataDirectory + Guid.NewGuid().ToString() + ".txt";
            string fullscript = txtEditor.Text + "\n//<SCRIPT END>\n";

            if (GlobalHwnd != "N/A") fullscript = "global GUI_PASSED_HWND = " + GlobalHwnd + ";\n" + fullscript;

            File.WriteAllText(currentScriptFile, fullscript);

            btnRun.Image = Properties.Resources.Stop_16px;

            SilentPipe = false;

            ScriptTask = new Task(() => { StartSytheLibInstance(false); });
            ScriptTask.Start();

            ChangeStatus("Running.", Color.Blue);
            isRunning = true;

            if (Properties.Settings.Default.ClearConsoleOnScriptRun) debugConsole.ClearConsole();

            await ScriptTask;

            //ScriptThreadStatus();
            KillSytheLib();
        }

        private void btnClips_Click(object sender, EventArgs e)
        {
            frmClips frm = new frmClips();
            frm.ShowDialog();
        }

        private void SaveScript()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (sfd.ShowDialog() == DialogResult.Cancel) return;

            File.WriteAllText(sfd.FileName, txtEditor.Text);

            isDirty = false;
        }

        private void OpenScript()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.Cancel) return;

            txtEditor.Text = File.ReadAllText(ofd.FileName);

            isDirty = false;
        }

        private void NewScript()
        {
            isDirty = false;
            txtEditor.Text = "";
        }

        // Return false if user chooses to cancel (do not proceed with action and do not save)
        // Return true if user chooses to continue/save in some capacity, or if document isn't even dirty
        private bool SaveIfDirty()
        {
            if (isDirty)
            {
                var result = MessageBox.Show("This script has been changed. Would you like to save it before continuing?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) SaveScript();
                else if (result == DialogResult.Cancel) return false;
                return true;
            }
            else
                return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveScript();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (SaveIfDirty()) OpenScript();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (SaveIfDirty()) NewScript();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsFormDialog(this);
        }

        private void ApplySettings()
        {
            tmrBackup.Enabled = Properties.Settings.Default.Backups;
            tmrBackup.Interval = Properties.Settings.Default.BackupMins * 60000;
            tmrBackgroundMonitor.Enabled = Properties.Settings.Default.MouseCoordinates;
            lblCoordinates.Visible = Properties.Settings.Default.MouseCoordinates;
        }

        private void SettingsFormDialog(frmMain parent)
        {
            frmSettings frm = new frmSettings(parent);
            var result = frm.ShowDialog();

            if (result == DialogResult.OK) ApplySettings();
        }

        #endregion

        #region Form and Editor Events

        private void frmMain_Load(object sender, EventArgs e)
        {
            CheckForUpdates();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (string file in Directory.GetFiles(DataDirectory))
                if (file.EndsWith(".txt")) File.Delete(file);


            if (isDirty)
            {
                var result = MessageBox.Show("Would you like to save before closing?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                else if (result == DialogResult.Yes) btnSave.PerformClick();
            }
        }

        private void TxtEditor_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            if (txtEditor.Text == "") isDirty = false;
            else isDirty = true;
            
            if (Properties.Settings.Default.UseSyntaxHighlighting)
            {
                txtEditor.LeftBracket = '(';
                txtEditor.RightBracket = ')';
                txtEditor.LeftBracket2 = '\x0';
                txtEditor.RightBracket2 = '\x0';
                //clear style of changed range
                e.ChangedRange.ClearStyle(BlueStyle, GrayStyle, MagentaStyle, GreenStyle, BrownStyle);

                //string highlighting
                e.ChangedRange.SetStyle(BrownStyle, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");
                //comment highlighting
                e.ChangedRange.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
                e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
                e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft);
                //number highlighting
                e.ChangedRange.SetStyle(MagentaStyle, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");
                //attribute highlighting
                e.ChangedRange.SetStyle(GrayStyle, @"^\s*(?<range>\[.+?\])\s*$", RegexOptions.Multiline);
                //class name highlighting
                e.ChangedRange.SetStyle(DarkBlueStyle, @"\b(class|struct|enum|interface)\s+(?<range>\w+?)\b");
                //keyword highlighting
                e.ChangedRange.SetStyle(BlueStyle, @"\b(auto|abstract|def|as|base|bool|break|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|in|int|interface|internal|is|lock|long|namespace|new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while|add|alias|ascending|descending|dynamic|from|get|global|group|into|join|let|orderby|partial|remove|select|set|value|var|where|yield)\b|#region\b|#endregion\b");

                //clear folding markers
                e.ChangedRange.ClearFoldingMarkers();

                //set folding markers
                e.ChangedRange.SetFoldingMarkers("{", "}");//allow to collapse brackets block
                e.ChangedRange.SetFoldingMarkers(@"#region\b", @"#endregion\b");//allow to collapse #region blocks
                e.ChangedRange.SetFoldingMarkers(@"/\*", @"\*/");//allow to collapse comment block
            }
        }

        #endregion

        #region Process Events

        private void ManageStdErrData(string data)
        {
            if (string.IsNullOrEmpty(data)) return;
            if (string.IsNullOrWhiteSpace(data)) return;

            if (data.StartsWith("{"))
            {
                ReceivedJson = "";
            }

            ReceivedJson += data;

            if (ReceivedJson.EndsWith("}"))
            {         
                if (Utilities.CheckBalancedBrackets(ReceivedJson))
                {
                    EndOfTransmissionHandler();
                }
            }

        }

        private void EndOfTransmissionHandler()
        {
            JObject jsonObj = JObject.Parse(ReceivedJson);

            bool error = Utilities.BoolFromString((string)jsonObj.SelectToken("error"));
            bool fatal = Utilities.BoolFromString((string)jsonObj.SelectToken("fatal"));
            string message = (string)jsonObj.SelectToken("message");
            string dataClass = (string)jsonObj.SelectToken("data_class");
            string dataLine = (string)jsonObj.SelectToken("data.line");
            string dataCol = (string)jsonObj.SelectToken("data.column");
            string returnValue = (string)jsonObj.SelectToken("data.return_value");

            System.Threading.Thread.Sleep(10);

            if (!error && fatal)
            {
                SystemLog("Return value, if any, was: " + returnValue.ToString(), debugConsole.NormalTextColour);
                SystemLog(message, debugConsole.SuccessColour);
            }
            else if (error && fatal)
            {
                if (dataLine != null && dataCol != null) SystemLog(string.Format("Error detected at line {0}, column {1}.", dataLine, dataCol), debugConsole.ErrorColour);
                else SystemLog("Could not determine error line or column.", debugConsole.ErrorColour);

                if (message != null) SystemLog(message, debugConsole.ErrorColour);
                else SystemLog("No error message associated with this error.", debugConsole.ErrorColour);

                if (dataClass != null) SystemLog("Error type: " + dataClass, debugConsole.ErrorColour);
                else SystemLog("No error type associated with this error.", debugConsole.ErrorColour);
            }
            else if (error && !fatal)
            {
                if (message != null) SystemLog(message, debugConsole.WarningColour);
                if (dataClass != null) SystemLog("Data class: " + dataClass, debugConsole.WarningColour);
            }
        }

        private void ManageStdOutData(string data)
        {
            if (string.IsNullOrEmpty(data)) return;
            if (string.IsNullOrWhiteSpace(data)) return;

            ScriptLog(data, debugConsole.NormalTextColour);
        }

        private void Proc_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (SilentPipe) return;
            ManageStdErrData(e.Data);
        }

        private void Proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            ManageStdOutData(e.Data);
        }

        private void Proc_Exited(object sender, EventArgs e)
        {
            KillSytheLib();
        }

        #endregion

        #region Status, Logging, and Console

        private void btnClear_Click(object sender, EventArgs e)
        {
            debugConsole.ClearConsole();
        }

        private void DebugConsole_UserInputEntered(object sender, EventArgs e)
        {
            try
            {
                if (proc != null && isRunning)
                {
                    proc.StandardInput.WriteLine(debugConsole.GetUserInput());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChangeStatus("Error sending input.", Color.Red);
            }
        }

        private void ScriptThreadStatus()
        {
            if (ScriptTask == null) log("SYSTEM: Script thread has yet to be initialised.", debugConsole.ErrorColour);
            else log("SYSTEM: Current script thread status is \"" + ScriptTask.Status.ToString() + "\".", debugConsole.SuccessColour);
        }

        private void ChangeStatus(string text, Color color)
        {
            if (tsControls.InvokeRequired)
            {
                tsControls.Invoke(new MethodInvoker(() =>
                {
                    lblStatus.ForeColor = color;
                    lblStatus.Text = "Status: " + text;
                }));
            }
            else
            {
                lblStatus.ForeColor = color;
                lblStatus.Text = "Status: " + text;
            }
        }

        private void SystemLog(string text, Color colour)
        {
            string timestamp = DateTime.Now.ToLongTimeString();
            string print = string.Format("[{0}] [{1}] {2}", timestamp, "SYSTEM", text);
            log(print, colour);
        }

        private void ScriptLog(string text, Color colour)
        {
            string timestamp = DateTime.Now.ToShortTimeString();
            string print = string.Format("[{0}] [{1}] {2}", timestamp, "SCRIPT", text);
            log(print, colour);
        }

        private void log(string text, Color colour)
        {
            debugConsole.Print(text, colour);
        }

        #endregion

        #region Process Interactions

        // Starts an instance of SytheLibProt.exe and maps events and StartInfo properly
        private void StartSytheLibInstance(bool silent)
        {
            if (!silent) ChangeStatus("Spawning SytheLib process...", Color.Blue);

            proc = new Process();
            proc.StartInfo.FileName = SytheLibExecutable;
            proc.StartInfo.Arguments = "\"" + currentScriptFile + "\"";

            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.UseShellExecute = false;

            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;

            proc.OutputDataReceived += Proc_OutputDataReceived;
            proc.ErrorDataReceived += Proc_ErrorDataReceived;
            proc.Exited += Proc_Exited;

            try
            {
                currentScriptFile = "\"" + currentScriptFile + "\"";


                bool start = proc.Start();
                isRunning = start;

                if (start)
                {
                    if (!silent) ChangeStatus("Running...", Color.Blue);
                    proc.BeginErrorReadLine();
                    proc.BeginOutputReadLine();
                    proc.WaitForExit();
                }
                else
                {
                    if (!silent) ChangeStatus("Error starting SytheLib. Check console.", Color.Red);
                    if (!silent) log("SYSTEM: Error starting SytheLib.", debugConsole.ErrorColour);
                }
            }
            catch (Exception ex)
            {
                log("SYSTEM: " + ex.Message, debugConsole.ErrorColour);
            }

        }

        private void KillSytheLib()
        {
            if (!(proc == null || proc.HasExited)) proc.Kill();

            if (!string.IsNullOrEmpty(currentScriptFile) && File.Exists(currentScriptFile)) File.Delete(currentScriptFile);

            btnRun.Image = Properties.Resources.Play_16px;

            ChangeStatus("Idle.", Color.Blue);

            isRunning = false;
        }

        #endregion

        #region Menu

        private void colourSelectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunToolScript(Selector.SLColour);
        }

        private void bitmapSelectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunToolScript(Selector.SLBitmap);
        }

        private void windowHandleSelectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool useOldSelector = Properties.Settings.Default.UseOldSelector;

            if (useOldSelector)
            {
                frmHandleSelector handleSelector = new frmHandleSelector(GlobalHwnd);
                handleSelector.ShowDialog();
                if (handleSelector.DialogResult != DialogResult.OK) return;
                GlobalHwnd = handleSelector.GlobalHwnd;
            }
            else
            {
                frmWinSiphon handleSelector = new frmWinSiphon(true);
                handleSelector.ShowDialog();
                if (handleSelector.DialogResult != DialogResult.OK) return;
                GlobalHwnd = handleSelector.GlobalHwnd;
            }

            lblHwnd.Text = "Global Window Handle: " + GlobalHwnd;
        }

        private void checkScriptTaskStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScriptThreadStatus();
        }

        private void freeIconsByIcons8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Clicking this link will open a web browser. Continue?", "Opening Link", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            if (result != DialogResult.Yes) return;

            Process.Start("http://www.icons8.com/");
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsFormDialog(this);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNew.PerformClick();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnOpen.PerformClick();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion

        #region Status strip

        private void tmrBackgroundMonitor_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.MouseCoordinates) lblCoordinates.Text = Cursor.Position.ToString();
        }

        #endregion

        #region Backups

        private void tmrBackup_Tick(object sender, EventArgs e)
        {
            Startup.CheckBackupDir(BackupDir);

            if (Properties.Settings.Default.Backups)
            {
                string orig_filename = DateTime.Now.ToString();
                string filename = orig_filename;
                int counter = 2;
                while (File.Exists(BackupDir + filename + ".txt"))
                {
                    filename = orig_filename + "_" + counter.ToString();
                    counter++;
                }

                File.WriteAllText(BackupDir + filename.Replace(":", ";") + ".txt", txtEditor.Text);
            }
        }


        #endregion

        #region Updates

        public void CheckForUpdates()
        {
            string updatefile = (new System.Net.WebClient()).DownloadString("http://www.dangk.net/files/updateserver/slade.txt");

            string updateMessage =
                string.Format("SLaDE has been updated. The newest version is version {0}. Your current version is {1}. Click yes to visit the Sythe.org thread for the new version.", updatefile, CurrentVersion);


            if (updatefile != CurrentVersion)
            {
                var result = MessageBox.Show(updateMessage, "Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;

                Process.Start(UpdateURL);
            }
        }


        #endregion

        #region Settings Interaction

        public void OnSettingsChanged()
        {
            if (!Properties.Settings.Default.UseSyntaxHighlighting)
            {
                txtEditor.Language = Language.Custom;
                txtEditor.ClearStylesBuffer();
                txtEditor.ClearStyle(StyleIndex.All);

                txtEditor.OnTextChanged();
            }
            else
            {
                txtEditor.OnTextChanged();
            }
        }

        #endregion

    }
}
