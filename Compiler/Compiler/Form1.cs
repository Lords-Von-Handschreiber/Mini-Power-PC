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

        private FileInfo activeFileInfo;
        private bool isSaved = true;

        private const string FORM_TITLE = "Mini-Power-PC - Editor/Compiler - ";

        public Form1()
        {
            InitializeComponent();
        }

        private void saveFile()
        {
            using (var fs = activeFileInfo.CreateText())
            {
                fs.Write(richTextBox.Text);
                Text = FORM_TITLE + activeFileInfo.Name;
            }
            isSaved = true;
            Text = Text.PadLeft(Text.Length - 1);
        }

        private void openFile()
        {
            using (var fs = activeFileInfo.OpenText())
            {
                richTextBox.Text = fs.ReadToEnd();
                Text = FORM_TITLE + activeFileInfo.Name;
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            activeFileInfo = new FileInfo(openFileDialog.FileName);
            saveToolStripMenuItem.Enabled = true;
            openFile();
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            activeFileInfo = new FileInfo(saveFileDialog.FileName);
            saveFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isSaved)
            {
                Text += "*";
                isSaved = false;
            }
        }
    }
}
