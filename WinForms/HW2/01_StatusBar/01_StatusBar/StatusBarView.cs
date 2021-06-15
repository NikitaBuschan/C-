using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace _01_StatusBar
{
    public partial class FormMain : Form
    {
        private List<string> list;

        public FormMain()
        {
            InitializeComponent();
            list = new List<string>();
        }

        private void buttonReadFromFile_Click(object sender, EventArgs e)
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
                    textBox.Text = openFileDialog.FileName;
                    textBox.Update();
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string line = string.Empty;
                        while ((line = reader.ReadLine()) != null)
                        {
                            list.Add(line);
                        }
                    }
                }
            }
            progressBar.Maximum = list.Count;

            Start();
        }

        private void Start()
        {
            int i = 0;
            buttonReadFromFile.Enabled = false;

            foreach (var item in list)
            {
                Thread.Sleep(10);
                i++;
                label.Text = item.ToString();
                label.Refresh();
                progressBar.Value = i;
            }
            buttonReadFromFile.Enabled = true;
        }
    }
}