using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinSiphon
{
    public class WindowHandleManager
    {
        private delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);
        private delegate bool EnumTopWindows(IntPtr hwnd, IntPtr lParam);

        [System.Runtime.InteropServices.DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int EnumWindows(EnumTopWindows callPtr, IntPtr lPar);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        public static string GetClassNameForHwnd(IntPtr hwnd)
        {
            StringBuilder sb = new StringBuilder(256);
            GetClassName(hwnd, sb, sb.Capacity);

            return sb.ToString();
        }

        public static string GetWindowTextWithHwnd(IntPtr hwnd)
        {
            StringBuilder sb = new StringBuilder(256);
            GetWindowText(hwnd, sb, sb.Capacity);

            return sb.ToString();
        }

        public static List<IntPtr> GetTopHandles()
        {
            List<IntPtr> handles = new List<IntPtr>();
            GCHandle listgc = GCHandle.Alloc(handles);
            EnumTopWindows callbackPtr = GetTopHandle;

            EnumWindows(callbackPtr, GCHandle.ToIntPtr(listgc));

            listgc.Free();
            return handles;
        }

        private static bool GetTopHandle(IntPtr handle, IntPtr lParam)
        {
            GCHandle gcChildhandlesList = GCHandle.FromIntPtr(lParam);

            if (gcChildhandlesList == null || gcChildhandlesList.Target == null)
            {
                return false;
            }

            List<IntPtr> childHandles = gcChildhandlesList.Target as List<IntPtr>;
            childHandles.Add(handle);
            return true;
        }

        public static List<IntPtr> GetAllChildHandles(IntPtr parentHwnd)
        {
            List<IntPtr> childHandles = new List<IntPtr>();

            GCHandle gcChildhandlesList = GCHandle.Alloc(childHandles);
            IntPtr pointerChildHandlesList = GCHandle.ToIntPtr(gcChildhandlesList);

            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                EnumChildWindows(parentHwnd, childProc, pointerChildHandlesList);
            }
            finally
            {
                gcChildhandlesList.Free();
            }

            return childHandles;
        }

        private static bool EnumWindow(IntPtr hWnd, IntPtr lParam)
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

        public static List<Process> GetAllProcesses()
        {
           

            return Process.GetProcesses().ToList<Process>();
        }

        public static List<IntPtr> GetAllProcessHandles()
        {
            List<IntPtr> handles = new List<IntPtr>();
            GetAllProcesses().ForEach((proc) => 
            {
                if (proc.MainWindowHandle != IntPtr.Zero)
                    handles.Add(proc.MainWindowHandle);
            });
            return handles;
        }


    }
}
