using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLaDE
{
    public partial class SladeConsole : RichTextBox
    {
        public event EventHandler UserInputEntered;

        private string userInput = "";
        private string oldText = ""; // text from last Print() and before

        public string DefaultHeader { get; set; }
        public Color NormalTextColour { get; set; }
        public Color ErrorColour { get; set; }
        public Color WarningColour { get; set; }
        public Color SuccessColour { get; set; }
        public Color AnnounceColour { get; set; }

        public SladeConsole()
        {
            InitializeComponent();

            this.KeyDown += SladeConsole_KeyDown;

            this.BackColor = Color.Black;

            NormalTextColour = Color.WhiteSmoke;
            ErrorColour = Color.Red;
            WarningColour = Color.Yellow;
            SuccessColour = Color.Green;
            AnnounceColour = Color.Magenta;
        }

        public void ClearConsole()
        {
            userInput = "";
            oldText = "";
            this.Clear();

            Print(DefaultHeader, this.AnnounceColour);
            PutCaretAtBottomOfConsole();
        }

        private void PutCaretAtBottomOfConsole()
        {
            this.SelectionStart = this.TextLength;
            this.SelectionLength = 0;
        }

        public void PrintHeader()
        {
            Print(DefaultHeader, AnnounceColour);
            PutCaretAtBottomOfConsole();
        }

        private void SladeConsole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                List<char> oldChars = oldText.ToCharArray().ToList();
                List<char> newChars = this.Text.ToCharArray().ToList();

                List<char> difference = newChars.GetRange(oldChars.Count, newChars.Count - oldChars.Count);

                userInput = new string(difference.ToArray<char>());

                this.UserInputEntered(sender, e);
            }
        }

        public void Print(string text, Color colour, bool newLine = true)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    int textLen = this.TextLength;
                    this.AppendText(text + (newLine ? Environment.NewLine : ""));
                    this.SelectionStart = textLen;
                    this.SelectionLength = text.Length;
                    this.SelectionColor = colour;

                    userInput = "";
                    oldText = this.Text;
                    PutCaretAtBottomOfConsole();
                }));
            }
            else
            {
                int textLen = this.TextLength;
                this.AppendText(text + (newLine ? Environment.NewLine : ""));
                this.SelectionStart = textLen;
                this.SelectionLength = text.Length;
                this.SelectionColor = colour;

                userInput = "";
                oldText = this.Text;
                PutCaretAtBottomOfConsole();
            }
        }

        public string GetUserInput()
        {
            string temp = userInput;
            userInput = "";
            return temp;
        }

    }
}
