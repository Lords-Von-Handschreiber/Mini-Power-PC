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

namespace Compiler
{
    public partial class Form1 : Form
    {
        private const string FORM_TITLE = "Mini-Power-PC - Editor/Compiler - ";
        private const string PARAM_SEPERATOR = "~~params~~";

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1" /> class.
        /// </summary>
        /// <param name="args">The args.</param>
        public Form1(string[] args)
        {
            InitializeComponent();
            if (args.Length > 0)
            {
                FileTracker.ActiveFile = new FileInfo(args[0]);
                var content = FileTracker.OpenFile(FileTracker.ActiveFile).Split(PARAM_SEPERATOR.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                richTextBox.Text = content[0];
                if (content.Length > 1)
                    richTextBox1.Text = content[1].Trim();
                FileTracker.IsSaved = true;
                saveToolStripMenuItem.Enabled = false;
                updateFormText();
            }

            updateFormText();
        }

        /// <summary>
        /// Updates the form text.
        /// </summary>
        private void updateFormText()
        {
            Text = FORM_TITLE + FileTracker.ActiveFile.Name;
        }

        /// <summary>
        /// Handles the Click event of the quitToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileTracker.IsSaved || MessageBox.Show("Quit anyway?", "File is not saved", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Handles the Click event of the openToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        /// <summary>
        /// Handles the FileOk event of the openFileDialog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs" /> instance containing the event data.</param>
        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            FileTracker.ActiveFile = new FileInfo(openFileDialog.FileName);
            richTextBox.Text = FileTracker.OpenFile(FileTracker.ActiveFile);
            FileTracker.IsSaved = true;
            saveToolStripMenuItem.Enabled = false;
            updateFormText();
        }

        /// <summary>
        /// Handles the FileOk event of the saveFileDialog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs" /> instance containing the event data.</param>
        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            FileTracker.ActiveFile = new FileInfo(saveFileDialog.FileName);
            FileTracker.SaveFile(getFileContentString());
            updateFormText();
        }

        /// <summary>
        /// Handles the Click event of the saveToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileTracker.SaveFile(getFileContentString());
            updateFormText();
            saveToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Handles the Click event of the saveasToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
            saveToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Handles the TextChanged event of the richTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the compileToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void compileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Text = richTextBox.Text.Replace("\t", " ").Trim();
            FileTracker.SaveFile(getFileContentString());
            updateFormText();
            saveToolStripMenuItem.Enabled = false;
            Utils.Compiler.Compile(richTextBox.Text, richTextBox1.Text, FileTracker.ActiveCompileFile);
        }

        /// <summary>
        /// Handles the FileOk event of the saveCombiledFileDialog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs" /> instance containing the event data.</param>
        private void saveCombiledFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            FileTracker.SaveFile(getFileContentString());
            Utils.Compiler.Compile(richTextBox.Text, richTextBox1.Text, FileTracker.ActiveCompileFile);
        }

        /// <summary>
        /// Gets the file content string.
        /// </summary>
        /// <returns></returns>
        private string getFileContentString()
        {
            return richTextBox.Text.Trim() + Environment.NewLine + PARAM_SEPERATOR + Environment.NewLine + richTextBox1.Text.Trim();
        }
    }
}
