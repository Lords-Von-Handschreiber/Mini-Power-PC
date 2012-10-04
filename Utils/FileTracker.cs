using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class FileTracker
    {
        public static bool IsSaved { get; set; }
        public static FileInfo ActiveFile { get; set; }

        static FileTracker()
        {
            IsSaved = true;
            ActiveFile = new FileInfo("NewSource.lvhc");
        }

        public static void SaveFile(string content)
        {
            using (var fs = ActiveFile.CreateText())
            {
                fs.Write(content);
            }
            IsSaved = true;
        }
        public static string OpenFile(FileInfo file)
        {
            using (var fs = file.OpenText())
            {
                return fs.ReadToEnd();
            }
        }
    }
}
