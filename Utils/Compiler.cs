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
        public static void Compile(string content, string parameter, FileInfo file)
        {
            var paramFile = new FileInfo(file.FullName + ".param");

            if (file.Exists)
                file.Delete();

            if (paramFile.Exists)
                paramFile.Delete();

            if (!string.IsNullOrEmpty(parameter.Trim()))
            {
                using (var w = new System.IO.BinaryWriter(paramFile.OpenWrite()))
                {
                    foreach (var line in parameter.Trim().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                    {
                        w.Write(short.Parse(line));
                    }
                }
            }

            using (var w = new System.IO.BinaryWriter(file.OpenWrite()))
            {
                foreach (var line in content.Trim().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                {
                    var l = line.Trim().Split(' ');
                    var cmdString = l[0].Trim();
                    var args = line.Replace(cmdString, "").Replace(" ", "").Trim(); ;

                    var cmd = Cpu.FromShort((short)Enum.Parse(typeof(Cpu.Cmds), cmdString));
                    if (!string.IsNullOrEmpty(args))
                    {
                        foreach (var a in args.Split(','))
                        {
                            short arg = 0;
                            if (!a.StartsWith("#"))
                            {
                                arg = (short)(short.Parse(a.Trim()) << 10);
                            }
                            else
                            {
                                arg = short.Parse(a.Replace("#", "").Trim());
                            }
                            //var arg = short.Parse(a.Replace("#", "").Trim());
                            var s = (short)(Cpu.ToShort(cmd) + arg);
                            cmd = Cpu.FromShort(s);
                        }
                    }
                    //Console.WriteLine(cmd[1] + "-" + cmd[0] + " = " + cmdString + " " + args + "(" + Command.ToShort(cmd) + ")");
                    w.Write(cmd);
                }
            }
        }
    }
}
