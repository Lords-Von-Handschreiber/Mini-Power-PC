using Compiler.Util;
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

namespace Compiler
{
    public partial class Form1 : Form
    {
        private const string FORM_TITLE = "Mini-Power-PC - Editor/Compiler - ";

        public Form1(string[] args)
        {
            InitializeComponent();
            if (args.Length > 0)
            {
                FileTracker.ActiveFile = new FileInfo(args[0]);
                richTextBox.Text = FileTracker.OpenFile(FileTracker.ActiveFile);
                FileTracker.IsSaved = true;
                saveToolStripMenuItem.Enabled = false;
                updateFormText();
            }

            updateFormText();
        }

        private void updateFormText()
        {
            Text = FORM_TITLE + FileTracker.ActiveFile.Name;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileTracker.IsSaved || MessageBox.Show("Quit anyway?", "File is not saved", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            FileTracker.ActiveFile = new FileInfo(openFileDialog.FileName);
            richTextBox.Text = FileTracker.OpenFile(FileTracker.ActiveFile);
            FileTracker.IsSaved = true;
            saveToolStripMenuItem.Enabled = false;
            updateFormText();
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            FileTracker.ActiveFile = new FileInfo(saveFileDialog.FileName);
            FileTracker.SaveFile(richTextBox.Text);
            updateFormText();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileTracker.SaveFile(richTextBox.Text);
            updateFormText();
            saveToolStripMenuItem.Enabled = false;
        }

        private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
            saveToolStripMenuItem.Enabled = false;
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FileTracker.IsSaved)
            {
                updateFormText();
                Text += "*";
                FileTracker.IsSaved = false;
                saveToolStripMenuItem.Enabled = true;
            }
        }

        private void compileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveCompiledFileDialog.ShowDialog();
        }

        private void saveCombiledFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            FileTracker.SaveFile(richTextBox.Text);
            Util.Compiler.Compile(richTextBox.Text, new FileInfo(saveCompiledFileDialog.FileName));
        }
    }
}
