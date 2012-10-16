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
            toolStripStatusLabel2.Text = string.Empty;

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
            textBoxReg0.Text = Cpu.ToBinaryString(cpu.Register[0]);
            textBoxReg1.Text = Cpu.ToBinaryString(cpu.Register[1]);
            textBoxReg2.Text = Cpu.ToBinaryString(cpu.Register[2]);
            textBoxReg3.Text = Cpu.ToBinaryString(cpu.Register[3]);
            textBoxRegCommand.Text = Cpu.ToBinaryString(cpu.CommandRegister);
            textBoxCommandCounter.Text = Cpu.ToBinaryString(cpu.CommandCounter);
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
        private void startStopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cpu.IsRunnung = !cpu.IsRunnung;

            if (cpu.IsRunnung)
            {
                toolStripStatusLabel2.Text = string.Empty;
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

                if (StepMode == StepModeEnum.Slow)
                    System.Threading.Thread.Sleep(100);
                else if (StepMode == StepModeEnum.Step)
                    if (MessageBox.Show("Proceed to the next step?", "Next step?", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                        break;
            }
            sq.Stop();
            cpu.IsRunnung = false;

            toolStripStatusLabel2.Text = "Elapsed time: " + sq.Elapsed.ToString();

            this.Invoke((MethodInvoker)delegate()
            {
                updateGui(); // runs on UI thread
            });

            // re-init for a next run
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

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
