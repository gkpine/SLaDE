using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLaDE
{
    public static class Constants
    {
        public static readonly string CurrentDirectory = Environment.CurrentDirectory;
        public static readonly string SytheLibPath = CurrentDirectory + "\\SytheLibProt.exe";
        public static readonly string TessdataPath = CurrentDirectory + "\\tessdata\\";
        public static readonly string BackupsPath = CurrentDirectory + "\\backups\\";
        public static readonly string ClipsPath = CurrentDirectory + "\\clips\\";
        public static readonly string DataPath = CurrentDirectory + "\\data\\";
        public static readonly string DocumentationPath = DataPath + "documentation.json";
        
    }
}
