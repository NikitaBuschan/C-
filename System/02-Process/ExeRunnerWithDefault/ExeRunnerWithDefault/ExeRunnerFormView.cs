using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ExeRunnerWithDefault
{
    public partial class ExeRunnerForm : Form
    {
        public ExeRunnerForm()
        {
            InitializeComponent();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = ".txt files |*.txt";
                fileDialog.FilterIndex = 0;
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var processStartInfo = new ProcessStartInfo
                        {
                            FileName = fileDialog.FileName,
                            UseShellExecute = true
                        };
                        Process.Start(processStartInfo);
                    }
                    catch
                    {
                        MessageBox.Show("Couldn't open file", "Fail with run", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
