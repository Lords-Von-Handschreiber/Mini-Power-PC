using System;
using System.IO;
using System.Windows.Forms;
using Utils;

namespace Emulator
{
    public partial class Form1 : Form
    {
        private Cpu cpu;

        public Form1(string[] args)
        {
            InitializeComponent();

            cpu = new Cpu();
#if DEBUG
            args = new string[1];
            args[0] = "C:\\Users\\Thomas\\Dropbox\\_Todo\\minipowerpc\\Mini-Power-PC.lvhe";
#endif
            if (args.Length > 0)
            {
                var file = new FileInfo(args[0]);
                byte[] content;
                using (var br = new BinaryReader(file.OpenRead()))
                {
                    content = br.ReadBytes((int)file.Length);
                }
                cpu.ToMemory(content, 100);

                cpu.IsRunnung = true;
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                while (cpu.IsRunnung)
                {
                    cpu.Fetch();
                    cpu.Execute();
                }
                sw.Stop();
                Console.WriteLine("Time elapsed: " + sw.ElapsedMilliseconds + " ms");
            }
        }
    }
}
