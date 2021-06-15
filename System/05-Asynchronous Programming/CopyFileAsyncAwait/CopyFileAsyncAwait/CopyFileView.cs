using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyFileAsyncAwait
{
    public partial class CopyFileAsyncAwait : Form
    {
        public CopyFileAsyncAwait()
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

        private async void btnCopy_Click(object sender, EventArgs e)
        {
            if (tbFrom.Text.Length == 0)
            {
                MessageBox.Show("Select the file to copy from", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (tbWhere.Text.Length == 0)
            {
                MessageBox.Show("Select the file to copy to", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IProgress<Tuple<long>> progress = new Progress<Tuple<long>>(t => 
            {
                progressBar.Value = (int)t.Item1;
            });

            await Task.Factory.StartNew(() => 
            {
                var data = Tuple.Create(tbFrom.Text, tbWhere.Text);

                using (var input = new FileStream(data.Item1, FileMode.Open, FileAccess.Read))
                using (var output = new FileStream(data.Item2, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[4096];
                    int read;

                    while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        output.Write(buffer, 0, read);

                        progress.Report(new Tuple<long>(input.Position / input.Length * 100));
                    }

                    MessageBox.Show("Copy finish");
                }
            });
        }
    }
}
