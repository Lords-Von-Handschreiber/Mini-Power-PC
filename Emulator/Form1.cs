using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            }
        }
    }
}
