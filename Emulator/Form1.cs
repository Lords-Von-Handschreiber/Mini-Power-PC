using Emulator.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (args.Length > 0)
            {
                var file = new FileInfo(args[0]);
                using (var br = new BinaryReader(file.OpenRead()))
                {
                    cpu.Memory = br.ReadBytes((int)file.Length);
                }

                for (var i = 0; i < cpu.Memory.Length; i += Cpu.WORD_LENGTH)
                {
                    byte[] asdf = new byte[Cpu.WORD_LENGTH];
                    for (int x = 0; x < Cpu.WORD_LENGTH; x++)
                    {
                        asdf[x] = cpu.Memory[i + x];
                    }

                    var s = Command.ToShort(asdf);
                    textBox1.Text += s.ToString() + " = " + Command.Find(s).ToString() + Environment.NewLine;
                }
            }
        }
    }
}
