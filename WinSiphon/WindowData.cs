using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinSiphon
{
    public class WindowData
    {
        public WindowData ParentWindow { get; set; }
        public IntPtr Handle { get; set; }
        public List<WindowData> ChildrenWindows { get; set; }
        public string Text { get; set; }
        public string Classname { get; set; }

        public WindowData(IntPtr handle, string text, string classname)
        {
            this.Handle = handle;
            this.Text = text;
            this.Classname = classname;
        }
    }
}
