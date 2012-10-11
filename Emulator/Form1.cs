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
            args[0] = @"C:\Users\Thomas\Dropbox\ZHAW\LVH\Informatik\Semester-3\Aufgaben\Mini Power PC\Mini-Power-PC.lvhe";
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
                var t = new System.Threading.Thread(new System.Threading.ThreadStart(delegate
                {
                    updateGui();
                    System.Threading.Thread.Sleep(750);

                    while (cpu.IsRunnung)
                    {
                        cpu.Fetch();
                        updateGui();

                        cpu.Execute();
                        updateGui();

                        System.Threading.Thread.Sleep(50);
                    }
                }));

                t.Start();
            }
        }

        private void updateGui()
        {
            if (listBoxReg0.Items.Count != 2)
                listBoxReg0.Items.Add(cpu.Register[0][0] + " " + cpu.Register[0][1]);
            else
                listBoxReg0.Items[1] = cpu.Register[0][0] + " " + cpu.Register[0][1];

            if (listBoxReg1.Items.Count != 2)
                listBoxReg1.Items.Add(cpu.Register[1][0] + " " + cpu.Register[1][1]);
            else
                listBoxReg1.Items[1] = cpu.Register[1][0] + " " + cpu.Register[1][1];

            if (listBoxReg2.Items.Count != 2)
                listBoxReg2.Items.Add(cpu.Register[2][0] + " " + cpu.Register[2][1]);
            else
                listBoxReg2.Items[1] = cpu.Register[2][0] + " " + cpu.Register[2][1];

            if (listBoxReg3.Items.Count != 2)
                listBoxReg3.Items.Add(cpu.Register[3][0] + " " + cpu.Register[3][1]);
            else
                listBoxReg3.Items[1] = cpu.Register[3][0] + " " + cpu.Register[3][1];

            if (listBoxRegCommand.Items.Count != 2)
                listBoxRegCommand.Items.Add(cpu.CommandRegister[0] + " " + cpu.CommandRegister[1]);
            else
                listBoxRegCommand.Items[1] = cpu.CommandRegister[0] + " " + cpu.CommandRegister[1];

            if (listBoxCommandCounter.Items.Count != 2)
                listBoxCommandCounter.Items.Add(cpu.CommandCounter[0] + " " + cpu.CommandCounter[1]);
            else
                listBoxCommandCounter.Items[1] = cpu.CommandCounter[0] + " " + cpu.CommandCounter[1];

            checkBoxCarry.Checked = cpu.CarryFlag;

            listBoxCommandStack.Items.Clear();
            var cc = Cpu.ToShort(cpu.CommandCounter);
            for (var i = (cc - 5*2); i <= (cc + 10*2); i += Cpu.WORD_LENGTH)
            {
                listBoxCommandStack.Items.Add(i + ": " + cpu.FromMemory(i, 1)[0] + " " + cpu.FromMemory(i + 1, 1)[0]);
            }
            listBoxCommandStack.SelectedIndex = 5;

            listBoxMemoryStack.Items.Clear();
            for (var i = 500; i <= 529; i += Cpu.WORD_LENGTH)
            {
                listBoxMemoryStack.Items.Add(i + ": " + cpu.FromMemory(i, 1)[0] + " " + cpu.FromMemory(i + 1, 1)[0]);
            }
        }
    }
}
