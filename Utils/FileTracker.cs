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
        public static FileInfo ActiveCompileFile
        {
            get
            {
                return new FileInfo(ActiveFile.FullName.Replace(ActiveFile.Extension, ".lvhe"));
            }
        }

        /// <summary>
        /// Initializes the static <see cref="FileTracker" /> class.
        /// </summary>
        static FileTracker()
        {
            IsSaved = true;
            ActiveFile = new FileInfo("NewSource.lvhc");
        }

        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <param name="content">The content.</param>
        public static void SaveFile(string content)
        {
            using (var fs = ActiveFile.CreateText())
            {
                fs.Write(content);
            }
            IsSaved = true;
        }

        /// <summary>
        /// Opens the file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        public static string OpenFile(FileInfo file)
        {
            using (var fs = file.OpenText())
            {
                return fs.ReadToEnd();
            }
        }
    }
}
