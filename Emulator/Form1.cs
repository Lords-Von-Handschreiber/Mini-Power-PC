﻿using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Utils;

namespace Emulator
{
    public partial class Form1 : Form
    {
        private Cpu cpu;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1" /> class.
        /// </summary>
        /// <param name="args">The args.</param>
        public Form1(string[] args)
        {
            InitializeComponent();

            cpu = new Cpu();
#if DEBUG
            args = new string[1];
            args[0] = @"C:\Users\peacemaker\Desktop\Mini-Power-PC.lvhe";
            args[0] = @"C:\Users\Thomas\Dropbox\ZHAW\LVH\Informatik\Semester-3\Aufgaben\Mini Power PC\Addition.lvhe";
#endif
            // Falls ein File als Parameter mit angegeben wurde, den Emulator damit starten
            if (args.Length > 0)
            {
                var file = new FileInfo(args[0]);
                // Das Programm in den Speicher #100 schreiben
                using (var br = new BinaryReader(file.OpenRead()))
                {
                    cpu.ToMemory(br.ReadBytes((int)file.Length), 100);
                }

                var paramFile = new FileInfo(args[0] + ".param");
                // Falls Parameter mitangegeben wurden, den Speicher ab #500 damit befüllen
                if (paramFile.Exists)
                {
                    using (var br = new BinaryReader(paramFile.OpenRead()))
                    {
                        cpu.ToMemory(br.ReadBytes((int)paramFile.Length), 500);
                    }
                }

                cpu.IsRunnung = true;
                var t = new System.Threading.Thread(new System.Threading.ThreadStart(delegate
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        updateGui(); // runs on UI thread
                    });
                    System.Threading.Thread.Sleep(1000);

                    while (cpu.IsRunnung)
                    {
                        cpu.Fetch();
                        this.Invoke((MethodInvoker)delegate
                        {
                            updateGui(); // runs on UI thread
                        });


                        cpu.Execute();
                        this.Invoke((MethodInvoker)delegate
                        {
                            updateGui(); // runs on UI thread
                        });
                        System.Threading.Thread.Sleep(25);
                    }
                }));

                t.Start();
            }
        }

        /// <summary>
        /// Updates the GUI.
        /// </summary>
        private void updateGui()
        {
            if (listBoxReg0.Items.Count != 2)
                listBoxReg0.Items.Add(Cpu.ToBinaryString(cpu.Register[0]));
            //listBoxReg0.Items.Add(cpu.Register[0][0] + " " + cpu.Register[0][1]);
            else
                listBoxReg0.Items[1] = Cpu.ToBinaryString(cpu.Register[0]);
            //listBoxReg0.Items[1] = cpu.Register[0][0] + " " + cpu.Register[0][1];

            if (listBoxReg1.Items.Count != 2)
                listBoxReg1.Items.Add(Cpu.ToBinaryString(cpu.Register[1]));
                //listBoxReg1.Items.Add(cpu.Register[1][0] + " " + cpu.Register[1][1]);
            else
                listBoxReg1.Items[1] = Cpu.ToBinaryString(cpu.Register[1]);
            //listBoxReg1.Items[1] = cpu.Register[1][0] + " " + cpu.Register[1][1];

            if (listBoxReg2.Items.Count != 2)
                listBoxReg2.Items.Add(Cpu.ToBinaryString(cpu.Register[2]));
            //listBoxReg2.Items.Add(cpu.Register[2][0] + " " + cpu.Register[2][1]);
            else
                listBoxReg2.Items[1] = Cpu.ToBinaryString(cpu.Register[2]);
            //listBoxReg2.Items[1] = cpu.Register[2][0] + " " + cpu.Register[2][1];

            if (listBoxReg3.Items.Count != 2)
                listBoxReg3.Items.Add(Cpu.ToBinaryString(cpu.Register[3]));
            //listBoxReg3.Items.Add(cpu.Register[3][0] + " " + cpu.Register[3][1]);
            else
                listBoxReg3.Items[1] = Cpu.ToBinaryString(cpu.Register[3]);
            //listBoxReg3.Items[1] = cpu.Register[3][0] + " " + cpu.Register[3][1];

            if (listBoxRegCommand.Items.Count != 2)
                listBoxRegCommand.Items.Add(Cpu.ToBinaryString(cpu.CommandRegister));
            //listBoxRegCommand.Items.Add(cpu.CommandRegister[0] + " " + cpu.CommandRegister[1]);
            else
                listBoxRegCommand.Items[1] = Cpu.ToBinaryString(cpu.CommandRegister);
            //listBoxRegCommand.Items[1] = cpu.CommandRegister[0] + " " + cpu.CommandRegister[1];

            if (listBoxCommandCounter.Items.Count != 2)
                listBoxCommandCounter.Items.Add(Cpu.ToBinaryString(cpu.CommandCounter));
                //listBoxCommandCounter.Items.Add(cpu.CommandCounter[0] + " " + cpu.CommandCounter[1]);
            else
                listBoxCommandCounter.Items[1] = Cpu.ToBinaryString(cpu.CommandCounter);
            //listBoxCommandCounter.Items[1] = cpu.CommandCounter[0] + " " + cpu.CommandCounter[1];

            checkBoxCarry.Enabled = cpu.CarryFlag;

            listBoxCommandStack.Items.Clear();
            var cc = Cpu.ToShort(cpu.CommandCounter);
            for (var i = (cc - 5 * Cpu.WORD_LENGTH); i <= (cc + 10 * Cpu.WORD_LENGTH); i += Cpu.WORD_LENGTH)
            {
                listBoxCommandStack.Items.Add(i + ":\t" + Cpu.ToBinaryString(cpu.FromMemory(i, 2)));
                //listBoxCommandStack.Items.Add(i + ":\t" + cpu.FromMemory(i, 1)[0] + " " + cpu.FromMemory(i + 1, 1)[0]);
            }
            listBoxCommandStack.SelectedIndex = 5;

            listBoxMemoryStack.Items.Clear();
            for (var i = 500; i <= 529; i += Cpu.WORD_LENGTH)
            {

                listBoxMemoryStack.Items.Add(i + ":\t" + Cpu.ToBinaryString(cpu.FromMemory(i, 2)));
                //listBoxMemoryStack.Items.Add(i + ":\t" + cpu.FromMemory(i, 1)[0] + " " + cpu.FromMemory(i + 1, 1)[0]);
            }

            toolStripStatusLabel1.Text = "Schritte: " + cpu.StepCounter;
        }
    }
}
