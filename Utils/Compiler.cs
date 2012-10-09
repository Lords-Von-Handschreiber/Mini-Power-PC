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
            if (file.Exists)
                file.Delete();

            using (var w = new System.IO.BinaryWriter(file.OpenWrite()))
            {
                foreach (var line in content.Trim().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.None))
                {
                    if (!string.IsNullOrEmpty(line.Trim()))
                    {
                        var l = line.Trim().Split(' ');
                        var cmdString = l[0].Trim();
                        var args = line.Replace(cmdString, "").Replace(" ", "").Trim(); ;

                        var cmd = Command.FromShort((short)Enum.Parse(typeof(Command.Cmds), cmdString));
                        if (!string.IsNullOrEmpty(args))
                        {
                            foreach (var a in args.Split(','))
                            {
                                var arg = short.Parse(a.Replace("#", "").Trim());
                                var s = (short)(Command.ToShort(cmd) + arg);
                                cmd = Command.FromShort(s);
                            }
                        }
                        //Console.WriteLine(cmd[1] + "-" + cmd[0] + " = " + cmdString + " " + args + "(" + Command.ToShort(cmd) + ")");
                        w.Write(cmd);
                    }
                }
            }
        }
    }
}
