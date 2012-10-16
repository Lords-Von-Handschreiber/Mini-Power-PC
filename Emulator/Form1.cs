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
        private ToolStripMenuItem activeMode;

        public enum StepModeEnum
        {
            Slow,
            Step,
            Fast
        }

        public StepModeEnum StepMode { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1" /> class.
        /// </summary>
        /// <param name="args">The args.</param>
        public Form1(string[] args)
        {
            InitializeComponent();

            cpu = new Cpu();
            cpu.CommandCounter = Cpu.FromShort(100);
            cpu.StepCounter = 0;

            activeMode = slowToolStripMenuItem;
            StepMode = (StepModeEnum)Enum.Parse(typeof(StepModeEnum), activeMode.Text);
#if DEBUG
            args = new string[1];
            args[0] = @"C:\Users\peacemaker\Desktop\Mini-Power-PC.lvhe";
            args[0] = @"C:\Users\Thomas\Dropbox\ZHAW\LVH\Informatik\Semester-3\Aufgaben\Mini Power PC\Addition.lvhe";
#endif
            // Falls ein File als Parameter mit angegeben wurde, den Emulator damit starten
            if (args.Length > 0)
            {
                FileTracker.ActiveFile = new FileInfo(args[0]);
                initGui();
            }
            updateGui();
        }

        /// <summary>
        /// Inits the GUI.
        /// </summary>
        private void initGui()
        {
            // Das Programm in den Speicher #100 schreiben
            using (var br = new BinaryReader(FileTracker.ActiveFile.OpenRead()))
            {
                cpu.ToMemory(br.ReadBytes((int)FileTracker.ActiveFile.Length), 100);
            }

            FileTracker.ActiveCompileFile = new FileInfo(FileTracker.ActiveFile.FullName + ".param");
            // Falls Parameter mitangegeben wurden, den Speicher ab #500 damit befüllen
            if (FileTracker.ActiveCompileFile.Exists)
            {
                using (var br = new BinaryReader(FileTracker.ActiveCompileFile.OpenRead()))
                {
                    cpu.ToMemory(br.ReadBytes((int)FileTracker.ActiveCompileFile.Length), 500);
                }
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

            toolStripStatusLabel1.Text = "Steps: " + cpu.StepCounter;
        }

        /// <summary>
        /// Handles the Click event of the startToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cpu.IsRunnung = !cpu.IsRunnung;

            if (cpu.IsRunnung)
            {
                var t = new System.Threading.Thread(new System.Threading.ThreadStart(run));
                t.Start();
            }
        }

        private void run()
        {
            var sq = new System.Diagnostics.Stopwatch();
            sq.Start();
            while (cpu.IsRunnung)
            {
                cpu.Fetch();
                if (StepMode != StepModeEnum.Fast)
                    this.Invoke((MethodInvoker)delegate()
                    {
                        updateGui(); // runs on UI thread
                    });

                cpu.Execute();
                if (StepMode != StepModeEnum.Fast)
                    this.Invoke((MethodInvoker)delegate()
                    {
                        updateGui(); // runs on UI thread
                    });

                if (StepMode != StepModeEnum.Fast)
                    System.Threading.Thread.Sleep(25);
            }
            sq.Stop();

            toolStripStatusLabel2.Text = "Elapsed time: " + sq.Elapsed.ToString();

            this.Invoke((MethodInvoker)delegate()
            {
                updateGui(); // runs on UI thread
            });

            // re-init for a next run ssh check
            cpu.CommandCounter = Cpu.FromShort(100);
            cpu.StepCounter = 0;

            initGui();
        }

        /// <summary>
        /// Handles the Click event of the resetToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cpu.CommandCounter = Cpu.FromShort(100);
            cpu.StepCounter = 0;

            initGui();
            updateGui();
        }

        /// <summary>
        /// Handles the Click event of the stepMode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void stepMode_Click(object sender, EventArgs e)
        {
            if (activeMode == (ToolStripMenuItem)sender)
                return;

            activeMode.Checked = false;
            activeMode = (ToolStripMenuItem)sender;
            StepMode = (StepModeEnum)Enum.Parse(typeof(StepModeEnum), activeMode.Text);
        }
    }
}
