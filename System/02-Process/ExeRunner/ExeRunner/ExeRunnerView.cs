using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ExeRunner
{
    public partial class ExeRunnerView : Form
    {
        public ExeRunnerView()
        {
            InitializeComponent();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = ".exe files |*.exe";
                fileDialog.FilterIndex = 0;
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Process.Start(fileDialog.FileName);
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
