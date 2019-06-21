using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace SLaDE
{
    public static class Startup
    {

        public static bool CheckTessdataDir(string tessdatadir)
        {
            if (!Directory.Exists(tessdatadir))
            {
                MessageBox.Show("The tessdata folder was not found. This folder is required to properly execute SytheLib. You will not be able to run scripts.", "Tessdata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public static void CheckClipsDir(string clipsdir)
        {
            if (!Directory.Exists(clipsdir)) Directory.CreateDirectory(clipsdir);
        }

        public static void CheckBackupDir(string backupdir)
        {
            if (!Directory.Exists(backupdir)) Directory.CreateDirectory(backupdir);
        }

        public static void CheckDataDir(string datadir)
        {
            if (!Directory.Exists(datadir)) Directory.CreateDirectory(datadir);         
        }

        public static bool CheckSLExecutable(string SLpath)
        {
            if (!File.Exists(SLpath))
            {
                MessageBox.Show("The SytheLib executable was not found. This executable is required to run scripts. As a result, running scripts will be disabled.", "SytheLib", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

    }
}
