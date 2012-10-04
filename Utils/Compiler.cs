using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class Compiler
    {
        public static void Compile(string content, FileInfo file)
        {
            using (var w = new System.IO.BinaryWriter(file.OpenWrite()))
            {
                foreach (var line in content.Trim().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.None))
                {
                    if (!string.IsNullOrEmpty(line.Trim()))
                    {
                        var l = line.Trim().Split(' ');
                        var cmdString = l[0].Trim();
                        var args = line.Replace(cmdString, "").Replace(" ", "").Trim(); ;

                        var cmd = Command.Find(cmdString);
                        if (!string.IsNullOrEmpty(args))
                        {
                            foreach (var a in args.Split(','))
                            {
                                var arg = a.Replace("#", "").Trim();

                                cmd += short.Parse(arg);
                            }
                        }
                        w.Write(cmd);
                    }
                }
            }
        }
    }
}
