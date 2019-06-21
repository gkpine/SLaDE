using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SLaDE
{
    public partial class frmHandleSelector : Form
    {

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private Process[] CurrentProcesses = null;
        public string GlobalHwnd = "N/A";

        private List<IntPtr> handles = new List<IntPtr>();

        public frmHandleSelector(string currentHandle)
        {
            InitializeComponent();



            GlobalHwnd = currentHandle;
            lblCurrentHandle.Text = "Current Global Window Handle: " + currentHandle;
                
        }



        private void GetWindowHandles()
        {
            handles.Clear();
            lstWindowTitles.Items.Clear();

            CurrentProcesses = Process.GetProcesses();
            foreach (Process proc in CurrentProcesses)
            {
                if (!string.IsNullOrEmpty(proc.MainWindowTitle))
                    lstWindowTitles.Items.Add("[" + proc.MainWindowHandle.ToString() + "]" + proc.MainWindowTitle);

                handles.Add(proc.MainWindowHandle);
            }
        }

        private void frmHandleSelector_Load(object sender, EventArgs e)
        {
            GetWindowHandles();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetWindowHandles();
        }

        private void lstWindowTitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedHandle = lstWindowTitles.SelectedItem.ToString().Substring(1, lstWindowTitles.SelectedItem.ToString().IndexOf(']') - 1);
            txtSelectedHandle.Text = selectedHandle;

            // Selected process info
            string windowTitle = lstWindowTitles.SelectedItem.ToString().Substring(lstWindowTitles.SelectedItem.ToString().IndexOf(']') + 1);
            IntPtr windowHandle = FindWindow(null, windowTitle);

            WindowHandleInfo whi = new WindowHandleInfo(handles[lstWindowTitles.SelectedIndex]);
            foreach (IntPtr c in whi.GetAllChildHandles())
            {
                Console.WriteLine("Title: " + WindowInfo.GetText(c) + " ;; Classname: " + WindowInfo.GetClassNameCS(c));
            }

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtSelectedHandle.Text);
            lblCopied.Visible = true;
            tmrCopiedLabel.Enabled = true;
        }

        private void tmrCopiedLabel_Tick(object sender, EventArgs e)
        {
            lblCopied.Visible = false;
            tmrCopiedLabel.Enabled = false;

        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (lstWindowTitles.SelectedIndex < 0)
            {
                MessageBox.Show("No window handle was selected in the list. Please select a window handle to make it global.", "Handle", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GlobalHwnd = txtSelectedHandle.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBlank_Click(object sender, EventArgs e)
        {
            txtSelectedHandle.Text = "N/A";
        }

    }

    public static class WindowInfo
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);

        public static string GetText(IntPtr hWnd)
        {
            // Allocate correct string length first
            int length = GetWindowTextLength(hWnd);
            StringBuilder sb = new StringBuilder(length + 1);
            GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }

        public static string GetClassNameCS(IntPtr hwnd)
        {
            StringBuilder sb = new StringBuilder(512);
            GetClassName(hwnd, sb, sb.Capacity);

            return sb.ToString();
        }

        public static IntPtr GetParentHwnd(IntPtr ChildHwnd)
        {
            return GetParent(ChildHwnd);
        }

        public static IntPtr FindWindowByIndex(IntPtr hWndParent, int index)
        {
            if (index == 0)
                return hWndParent;
            else
            {
                int ct = 0;
                IntPtr result = IntPtr.Zero;
                do
                {
                    result = FindWindowEx(hWndParent, result, "Button", null);
                    if (result != IntPtr.Zero)
                        ++ct;
                }
                while (ct < index && result != IntPtr.Zero);
                return result;
            }
        }
    }

    public class WindowHandleInfo
    {
        private delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lParam);

        private IntPtr _MainHandle;

        public WindowHandleInfo(IntPtr handle)
        {
            this._MainHandle = handle;
        }

        public List<IntPtr> GetAllChildHandles()
        {
            List<IntPtr> childHandles = new List<IntPtr>();

            GCHandle gcChildhandlesList = GCHandle.Alloc(childHandles);
            IntPtr pointerChildHandlesList = GCHandle.ToIntPtr(gcChildhandlesList);

            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                EnumChildWindows(this._MainHandle, childProc, pointerChildHandlesList);
            }
            finally
            {
                gcChildhandlesList.Free();
            }

            return childHandles;
        }

        private bool EnumWindow(IntPtr hWnd, IntPtr lParam)
        {
            GCHandle gcChildhandlesList = GCHandle.FromIntPtr(lParam);

            if (gcChildhandlesList == null || gcChildhandlesList.Target == null)
            {
                return false;
            }

            List<IntPtr> childHandles = gcChildhandlesList.Target as List<IntPtr>;
            childHandles.Add(hWnd);

            return true;
        }
    }
}
