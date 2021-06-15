using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace CopyFile
{
    public partial class CopyFile : Form
    {
        public CopyFile()
        {
            InitializeComponent();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            tbFrom.Text = openFileDialog.FileName;
        }

        private void btnFile2_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            tbWhere.Text = openFileDialog.FileName;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync(Tuple.Create(tbFrom.Text, tbWhere.Text));
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var data = (Tuple<string, string>)e.Argument;

            using (var input = new FileStream(data.Item1, FileMode.Open, FileAccess.Read))
            using (var output = new FileStream(data.Item2, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[4096];
                int read;

                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (backgroundWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    output.Write(buffer, 0, read);

                    float pct = (1.0f * input.Position) / input.Length * 100.0f;
                }
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show("Copy canceled");
            else if (e.Error != null)
                MessageBox.Show("Copy Error: " + e.Error.Message);
            else
                MessageBox.Show("Copy finish");
        }
    }
}
