using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SLaDE
{
    public static class Utilities
    {
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private const int SHOWMAXIMIZED = 5;

        private static TextStyle DarkBlueStyle = new TextStyle(Brushes.DarkBlue, null, FontStyle.Regular);
        private static TextStyle BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        private static TextStyle GrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        private static TextStyle MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
        private static TextStyle GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Regular);
        private static TextStyle BrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Regular);
        private static TextStyle MaroonStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);
        private static MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));

        public static IntPtr GetWindowHandle(string windowTitle)
        {
            return FindWindowByCaption(IntPtr.Zero, windowTitle);
        }

        public static void SetWindowMaximized(IntPtr handle)
        {
            ShowWindow(handle, SHOWMAXIMIZED);
        }

        public static void SetWindowVisible(IntPtr windowHandle, bool visible)
        {
            ShowWindow(windowHandle, Convert.ToInt32(visible));
        }

        public static void SetWindowVisible(string windowTitle, bool visible)
        {
            ShowWindow(GetWindowHandle(windowTitle), Convert.ToInt32(visible));
        }

        public static string GetBetween(string sourceText, string start, string end, int startIndex = 0)
        {
            int startIdx = sourceText.IndexOf(start, startIndex);
            int endIdx = sourceText.IndexOf(end, startIndex);
            if (endIdx == startIndex) endIdx = sourceText.IndexOf(end, startIndex + 1);
            if (startIdx >= endIdx || startIdx < 0 || endIdx < 0) return "";

            startIdx += start.Length;

            return sourceText.Substring(startIdx, endIdx - startIdx);
        }

        public static List<string> GetBetweenAll(string sourceText, string start, string end, int startIndex = 0)
        {
            List<string> results = new List<string>();
            int index = startIndex;

            while (index != -1 && index < sourceText.Length)
            {
                string getbetween = GetBetween(sourceText, start, end, index);

                if (!string.IsNullOrEmpty(getbetween) && !string.IsNullOrWhiteSpace(getbetween))
                    results.Add(getbetween);

                index = sourceText.IndexOf(end, index +1);
            }

            return results;
        }

        public static bool CheckBalancedBrackets(string input)
        {
            Dictionary<char, char> bracketPairs = new Dictionary<char, char>()
            {
                { '(', ')' },
                { '{', '}' },
                { '[', ']' },
                { '<', '>' }
            };

            Stack<char> brackets = new Stack<char>();

            try
            {
                foreach (char c in input)
                {
                    if (bracketPairs.Keys.Contains(c))
                    {
                        brackets.Push(c);
                    }
                    else if (bracketPairs.Values.Contains(c))
                    {
                        if (c == bracketPairs[brackets.First()])
                        {
                            brackets.Pop();
                        }
                        else
                            return false;
                    }
                    else
                        continue;
                }
            }
            catch
            {
                return false;
            }

            return brackets.Count() == 0 ? true : false;
        }

        public static bool BoolFromString(string strBool)
        {
            if (strBool.ToLower().Trim() == "false") return false;
            else if (strBool.ToLower().Trim() == "true") return true;

            return false;
        }

        public static void ImplementSyntaxHighlighting(ref FastColoredTextBoxNS.FastColoredTextBox txtEditor, ref FastColoredTextBoxNS.TextChangedEventArgs e)
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
        }
    }
}
