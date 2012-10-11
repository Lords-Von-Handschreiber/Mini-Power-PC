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
            this.listBoxReg0 = new System.Windows.Forms.ListBox();
            this.listBoxReg1 = new System.Windows.Forms.ListBox();
            this.listBoxReg2 = new System.Windows.Forms.ListBox();
            this.listBoxReg3 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxRegCommand = new System.Windows.Forms.ListBox();
            this.listBoxMemoryStack = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxCarry = new System.Windows.Forms.CheckBox();
            this.listBoxCommandCounter = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxCommandStack
            // 
            this.listBoxCommandStack.Enabled = false;
            this.listBoxCommandStack.FormattingEnabled = true;
            this.listBoxCommandStack.ItemHeight = 16;
            this.listBoxCommandStack.Location = new System.Drawing.Point(12, 29);
            this.listBoxCommandStack.Name = "listBoxCommandStack";
            this.listBoxCommandStack.Size = new System.Drawing.Size(198, 260);
            this.listBoxCommandStack.TabIndex = 0;
            // 
            // listBoxReg0
            // 
            this.listBoxReg0.Enabled = false;
            this.listBoxReg0.FormattingEnabled = true;
            this.listBoxReg0.ItemHeight = 16;
            this.listBoxReg0.Items.AddRange(new object[] {
            "Akkumulator"});
            this.listBoxReg0.Location = new System.Drawing.Point(216, 29);
            this.listBoxReg0.Name = "listBoxReg0";
            this.listBoxReg0.Size = new System.Drawing.Size(198, 36);
            this.listBoxReg0.TabIndex = 1;
            // 
            // listBoxReg1
            // 
            this.listBoxReg1.Enabled = false;
            this.listBoxReg1.FormattingEnabled = true;
            this.listBoxReg1.ItemHeight = 16;
            this.listBoxReg1.Items.AddRange(new object[] {
            "Register 1"});
            this.listBoxReg1.Location = new System.Drawing.Point(216, 71);
            this.listBoxReg1.Name = "listBoxReg1";
            this.listBoxReg1.Size = new System.Drawing.Size(198, 36);
            this.listBoxReg1.TabIndex = 2;
            // 
            // listBoxReg2
            // 
            this.listBoxReg2.Enabled = false;
            this.listBoxReg2.FormattingEnabled = true;
            this.listBoxReg2.ItemHeight = 16;
            this.listBoxReg2.Items.AddRange(new object[] {
            "Register 2"});
            this.listBoxReg2.Location = new System.Drawing.Point(216, 113);
            this.listBoxReg2.Name = "listBoxReg2";
            this.listBoxReg2.Size = new System.Drawing.Size(198, 36);
            this.listBoxReg2.TabIndex = 3;
            // 
            // listBoxReg3
            // 
            this.listBoxReg3.Enabled = false;
            this.listBoxReg3.FormattingEnabled = true;
            this.listBoxReg3.ItemHeight = 16;
            this.listBoxReg3.Items.AddRange(new object[] {
            "Register 3"});
            this.listBoxReg3.Location = new System.Drawing.Point(216, 155);
            this.listBoxReg3.Name = "listBoxReg3";
            this.listBoxReg3.Size = new System.Drawing.Size(198, 36);
            this.listBoxReg3.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Speicher Stack";
            // 
            // listBoxRegCommand
            // 
            this.listBoxRegCommand.Enabled = false;
            this.listBoxRegCommand.FormattingEnabled = true;
            this.listBoxRegCommand.ItemHeight = 16;
            this.listBoxRegCommand.Items.AddRange(new object[] {
            "Befehlsregister"});
            this.listBoxRegCommand.Location = new System.Drawing.Point(216, 197);
            this.listBoxRegCommand.Name = "listBoxRegCommand";
            this.listBoxRegCommand.Size = new System.Drawing.Size(198, 36);
            this.listBoxRegCommand.TabIndex = 6;
            // 
            // listBoxMemoryStack
            // 
            this.listBoxMemoryStack.Enabled = false;
            this.listBoxMemoryStack.FormattingEnabled = true;
            this.listBoxMemoryStack.ItemHeight = 16;
            this.listBoxMemoryStack.Location = new System.Drawing.Point(420, 29);
            this.listBoxMemoryStack.Name = "listBoxMemoryStack";
            this.listBoxMemoryStack.Size = new System.Drawing.Size(198, 244);
            this.listBoxMemoryStack.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(420, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Speicher [500-529] Stack";
            // 
            // checkBoxCarry
            // 
            this.checkBoxCarry.AutoSize = true;
            this.checkBoxCarry.Enabled = false;
            this.checkBoxCarry.Location = new System.Drawing.Point(216, 281);
            this.checkBoxCarry.Name = "checkBoxCarry";
            this.checkBoxCarry.Size = new System.Drawing.Size(96, 21);
            this.checkBoxCarry.TabIndex = 10;
            this.checkBoxCarry.Text = "Carry-Flag";
            this.checkBoxCarry.UseVisualStyleBackColor = true;
            // 
            // listBoxCommandCounter
            // 
            this.listBoxCommandCounter.Enabled = false;
            this.listBoxCommandCounter.FormattingEnabled = true;
            this.listBoxCommandCounter.ItemHeight = 16;
            this.listBoxCommandCounter.Items.AddRange(new object[] {
            "Befehlszähler"});
            this.listBoxCommandCounter.Location = new System.Drawing.Point(216, 239);
            this.listBoxCommandCounter.Name = "listBoxCommandCounter";
            this.listBoxCommandCounter.Size = new System.Drawing.Size(198, 36);
            this.listBoxCommandCounter.TabIndex = 11;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 308);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(634, 25);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 333);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listBoxCommandCounter);
            this.Controls.Add(this.checkBoxCarry);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxMemoryStack);
            this.Controls.Add(this.listBoxRegCommand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxReg3);
            this.Controls.Add(this.listBoxReg2);
            this.Controls.Add(this.listBoxReg1);
            this.Controls.Add(this.listBoxReg0);
            this.Controls.Add(this.listBoxCommandStack);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mini-Power-PC - Emulator";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxCommandStack;
        private System.Windows.Forms.ListBox listBoxReg0;
        private System.Windows.Forms.ListBox listBoxReg1;
        private System.Windows.Forms.ListBox listBoxReg2;
        private System.Windows.Forms.ListBox listBoxReg3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxRegCommand;
        private System.Windows.Forms.ListBox listBoxMemoryStack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxCarry;
        private System.Windows.Forms.ListBox listBoxCommandCounter;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

    }
}

