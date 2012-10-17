namespace Emulator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxCommandStack = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxMemoryStack = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxCarry = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxCommandCounter = new System.Windows.Forms.TextBox();
            this.labelCommandCounter = new System.Windows.Forms.Label();
            this.textBoxRegCommand = new System.Windows.Forms.TextBox();
            this.labelRegCommand = new System.Windows.Forms.Label();
            this.textBoxReg3 = new System.Windows.Forms.TextBox();
            this.labelReg3 = new System.Windows.Forms.Label();
            this.textBoxReg2 = new System.Windows.Forms.TextBox();
            this.labelReg2 = new System.Windows.Forms.Label();
            this.textBoxReg1 = new System.Windows.Forms.TextBox();
            this.labelReg1 = new System.Windows.Forms.Label();
            this.textBoxReg0 = new System.Windows.Forms.TextBox();
            this.labelReg0 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxCommandStack
            // 
            this.listBoxCommandStack.Enabled = false;
            this.listBoxCommandStack.FormattingEnabled = true;
            this.listBoxCommandStack.ItemHeight = 16;
            this.listBoxCommandStack.Location = new System.Drawing.Point(3, 20);
            this.listBoxCommandStack.Name = "listBoxCommandStack";
            this.listBoxCommandStack.Size = new System.Drawing.Size(198, 260);
            this.listBoxCommandStack.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Speicher Stack";
            // 
            // listBoxMemoryStack
            // 
            this.listBoxMemoryStack.Enabled = false;
            this.listBoxMemoryStack.FormattingEnabled = true;
            this.listBoxMemoryStack.ItemHeight = 16;
            this.listBoxMemoryStack.Location = new System.Drawing.Point(411, 20);
            this.listBoxMemoryStack.Name = "listBoxMemoryStack";
            this.listBoxMemoryStack.Size = new System.Drawing.Size(198, 244);
            this.listBoxMemoryStack.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(411, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Speicher [500-529] Stack";
            // 
            // checkBoxCarry
            // 
            this.checkBoxCarry.AutoSize = true;
            this.checkBoxCarry.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxCarry.Enabled = false;
            this.checkBoxCarry.Location = new System.Drawing.Point(207, 273);
            this.checkBoxCarry.Name = "checkBoxCarry";
            this.checkBoxCarry.Size = new System.Drawing.Size(96, 21);
            this.checkBoxCarry.TabIndex = 10;
            this.checkBoxCarry.Text = "Carry-Flag";
            this.checkBoxCarry.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 326);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(614, 25);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxCommandCounter);
            this.panel1.Controls.Add(this.labelCommandCounter);
            this.panel1.Controls.Add(this.textBoxRegCommand);
            this.panel1.Controls.Add(this.labelRegCommand);
            this.panel1.Controls.Add(this.textBoxReg3);
            this.panel1.Controls.Add(this.labelReg3);
            this.panel1.Controls.Add(this.textBoxReg2);
            this.panel1.Controls.Add(this.labelReg2);
            this.panel1.Controls.Add(this.textBoxReg1);
            this.panel1.Controls.Add(this.labelReg1);
            this.panel1.Controls.Add(this.textBoxReg0);
            this.panel1.Controls.Add(this.labelReg0);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.listBoxCommandStack);
            this.panel1.Controls.Add(this.checkBoxCarry);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.listBoxMemoryStack);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 298);
            this.panel1.TabIndex = 13;
            // 
            // textBoxCommandCounter
            // 
            this.textBoxCommandCounter.Location = new System.Drawing.Point(207, 245);
            this.textBoxCommandCounter.Name = "textBoxCommandCounter";
            this.textBoxCommandCounter.ReadOnly = true;
            this.textBoxCommandCounter.Size = new System.Drawing.Size(198, 22);
            this.textBoxCommandCounter.TabIndex = 23;
            this.textBoxCommandCounter.TabStop = false;
            this.textBoxCommandCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelCommandCounter
            // 
            this.labelCommandCounter.AutoSize = true;
            this.labelCommandCounter.Location = new System.Drawing.Point(207, 225);
            this.labelCommandCounter.Name = "labelCommandCounter";
            this.labelCommandCounter.Size = new System.Drawing.Size(87, 17);
            this.labelCommandCounter.TabIndex = 22;
            this.labelCommandCounter.Text = "Befehlzähler";
            // 
            // textBoxRegCommand
            // 
            this.textBoxRegCommand.Location = new System.Drawing.Point(207, 200);
            this.textBoxRegCommand.Name = "textBoxRegCommand";
            this.textBoxRegCommand.ReadOnly = true;
            this.textBoxRegCommand.Size = new System.Drawing.Size(198, 22);
            this.textBoxRegCommand.TabIndex = 21;
            this.textBoxRegCommand.TabStop = false;
            this.textBoxRegCommand.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelRegCommand
            // 
            this.labelRegCommand.AutoSize = true;
            this.labelRegCommand.Location = new System.Drawing.Point(207, 180);
            this.labelRegCommand.Name = "labelRegCommand";
            this.labelRegCommand.Size = new System.Drawing.Size(103, 17);
            this.labelRegCommand.TabIndex = 20;
            this.labelRegCommand.Text = "Befehlsregister";
            // 
            // textBoxReg3
            // 
            this.textBoxReg3.Location = new System.Drawing.Point(207, 155);
            this.textBoxReg3.Name = "textBoxReg3";
            this.textBoxReg3.ReadOnly = true;
            this.textBoxReg3.Size = new System.Drawing.Size(198, 22);
            this.textBoxReg3.TabIndex = 19;
            this.textBoxReg3.TabStop = false;
            this.textBoxReg3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelReg3
            // 
            this.labelReg3.AutoSize = true;
            this.labelReg3.Location = new System.Drawing.Point(207, 135);
            this.labelReg3.Name = "labelReg3";
            this.labelReg3.Size = new System.Drawing.Size(73, 17);
            this.labelReg3.TabIndex = 18;
            this.labelReg3.Text = "Register 3";
            // 
            // textBoxReg2
            // 
            this.textBoxReg2.Location = new System.Drawing.Point(207, 110);
            this.textBoxReg2.Name = "textBoxReg2";
            this.textBoxReg2.ReadOnly = true;
            this.textBoxReg2.Size = new System.Drawing.Size(198, 22);
            this.textBoxReg2.TabIndex = 17;
            this.textBoxReg2.TabStop = false;
            this.textBoxReg2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelReg2
            // 
            this.labelReg2.AutoSize = true;
            this.labelReg2.Location = new System.Drawing.Point(207, 90);
            this.labelReg2.Name = "labelReg2";
            this.labelReg2.Size = new System.Drawing.Size(73, 17);
            this.labelReg2.TabIndex = 16;
            this.labelReg2.Text = "Register 2";
            // 
            // textBoxReg1
            // 
            this.textBoxReg1.Location = new System.Drawing.Point(207, 65);
            this.textBoxReg1.Name = "textBoxReg1";
            this.textBoxReg1.ReadOnly = true;
            this.textBoxReg1.Size = new System.Drawing.Size(198, 22);
            this.textBoxReg1.TabIndex = 15;
            this.textBoxReg1.TabStop = false;
            this.textBoxReg1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelReg1
            // 
            this.labelReg1.AutoSize = true;
            this.labelReg1.Location = new System.Drawing.Point(207, 45);
            this.labelReg1.Name = "labelReg1";
            this.labelReg1.Size = new System.Drawing.Size(73, 17);
            this.labelReg1.TabIndex = 14;
            this.labelReg1.Text = "Register 1";
            // 
            // textBoxReg0
            // 
            this.textBoxReg0.Location = new System.Drawing.Point(207, 20);
            this.textBoxReg0.Name = "textBoxReg0";
            this.textBoxReg0.ReadOnly = true;
            this.textBoxReg0.Size = new System.Drawing.Size(198, 22);
            this.textBoxReg0.TabIndex = 13;
            this.textBoxReg0.TabStop = false;
            this.textBoxReg0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelReg0
            // 
            this.labelReg0.AutoSize = true;
            this.labelReg0.Location = new System.Drawing.Point(207, 0);
            this.labelReg0.Name = "labelReg0";
            this.labelReg0.Size = new System.Drawing.Size(86, 17);
            this.labelReg0.TabIndex = 12;
            this.labelReg0.Text = "Akkumulator";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.modeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(614, 28);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.startToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.startToolStripMenuItem.Text = "&Start/Stop";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startStopToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.resetToolStripMenuItem.Text = "&Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.quitToolStripMenuItem.Text = "&Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slowToolStripMenuItem,
            this.stepToolStripMenuItem,
            this.fastToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.modeToolStripMenuItem.Text = "&Mode";
            // 
            // slowToolStripMenuItem
            // 
            this.slowToolStripMenuItem.Checked = true;
            this.slowToolStripMenuItem.CheckOnClick = true;
            this.slowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.slowToolStripMenuItem.Name = "slowToolStripMenuItem";
            this.slowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.slowToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.slowToolStripMenuItem.Text = "Slow";
            this.slowToolStripMenuItem.Click += new System.EventHandler(this.stepMode_Click);
            // 
            // stepToolStripMenuItem
            // 
            this.stepToolStripMenuItem.CheckOnClick = true;
            this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
            this.stepToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.stepToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.stepToolStripMenuItem.Text = "Step";
            this.stepToolStripMenuItem.Click += new System.EventHandler(this.stepMode_Click);
            // 
            // fastToolStripMenuItem
            // 
            this.fastToolStripMenuItem.CheckOnClick = true;
            this.fastToolStripMenuItem.Name = "fastToolStripMenuItem";
            this.fastToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.fastToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.fastToolStripMenuItem.Text = "Fast";
            this.fastToolStripMenuItem.Click += new System.EventHandler(this.stepMode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 351);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mini-Power-PC - Emulator";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxCommandStack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxMemoryStack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxCarry;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fastToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TextBox textBoxReg0;
        private System.Windows.Forms.Label labelReg0;
        private System.Windows.Forms.Label labelReg1;
        private System.Windows.Forms.TextBox textBoxReg1;
        private System.Windows.Forms.TextBox textBoxReg2;
        private System.Windows.Forms.Label labelReg2;
        private System.Windows.Forms.TextBox textBoxReg3;
        private System.Windows.Forms.Label labelReg3;
        private System.Windows.Forms.TextBox textBoxRegCommand;
        private System.Windows.Forms.Label labelRegCommand;
        private System.Windows.Forms.TextBox textBoxCommandCounter;
        private System.Windows.Forms.Label labelCommandCounter;

    }
}

