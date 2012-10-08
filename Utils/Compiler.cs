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

                        var cmd = Command.Commands[cmdString];
                        Console.WriteLine(cmd + " = " + cmdString);
                        if (!string.IsNullOrEmpty(args))
                        {
                            foreach (var a in args.Split(','))
                            {
                                var arg = a.Replace("#", "").Trim();
                                short s = Command.ToShort(cmd);
                                cmd = Command.FromShort(s += short.TryParse(arg, out s) ? s : (short)0);
                                Console.WriteLine(cmd);
                                //cmd += short.TryParse(arg, out s) ? s : (short)0;
                            }
                        }
                        //var buffer = new byte[2];
                        //Command.FromShort(cmd, out buffer[0], out buffer[1]);
                        //w.Write(buffer);
                        w.Write(cmd);
                    }
                }
            }
        }
    }
}
