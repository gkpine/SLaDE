using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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
    }
}
