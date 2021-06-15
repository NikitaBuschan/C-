using System;
using System.IO;
using System.Windows.Forms;

namespace _01_TextEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        textBox.Text = reader.ReadToEnd();
                    }
                }
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
                textBox.Font = fontDialog.Font;
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
                textBox.ForeColor = colorDialog.Color;
        }

        private void backgraundColoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
                textBox.BackColor = colorDialog.Color;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName + ".txt", true, System.Text.Encoding.Default))
                    foreach (var item in textBox.Lines)
                        sw.WriteLine(item);
        }

        private void toolStripButtonCreate_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                File.Create(saveFileDialog.FileName + ".txt");
        }

        private void toolStripButtonCopy_Click(object sender, EventArgs e) => textBox.Copy();

        private void toolStripButtonCut_Click(object sender, EventArgs e) => textBox.Cut();

        private void toolStripButtonPaste_Click(object sender, EventArgs e) => textBox.Paste();

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            if (textBox.SelectionLength > 0)
                textBox.Select(0, 0);
        }
    }
}
