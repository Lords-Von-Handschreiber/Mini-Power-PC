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
                byte[] content;
                using (var br = new BinaryReader(file.OpenRead()))
                {
                    content = br.ReadBytes((int)file.Length);
                }

                for (var i = 0; i < content.Length; i += 2)
                {
                    textBox1.Text += Command.ToShort(content[i], content[i+1]).ToString() + Environment.NewLine;
                }
            }
        }
    }
}
