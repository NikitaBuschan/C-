using System;
using System.IO;
using System.Windows.Forms;

namespace _03_Editor
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            textBox.ReadOnly = true;
            buttonEdit.Enabled = false;
        }

        private void button_Click(object sender, EventArgs e)
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
            buttonEdit.Enabled = true;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Close", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var edit = new Edit(this);
            edit.Show();
        }
    }
}