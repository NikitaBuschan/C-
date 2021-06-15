using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Catalog.Properties
{
    public partial class InfoView : Form
    {
        private Thread thread { get; set; }
        private string Path { get; set; }

        public InfoView(string path)
        {
            InitializeComponent();

            try
            {
                Directory.GetDirectories(path);
            }
            catch
            {
                MessageBox.Show("Please enter valid path", "Wrong path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Path = path;
            this.Load += (e, o) => thread = new Thread(new ThreadStart(SetLabels)) { IsBackground = false };
            this.Load += (e, o) => thread.Start();
            this.FormClosing += (e, o) => thread.Abort();
            this.Show();
        }

        private void SetLabels()
        {
            while (true)
            {
                lblShowPath.Invoke((MethodInvoker)(() => lblShowPath.Text = Path));
                lblShowFolderCount.Invoke((MethodInvoker)(() => lblShowFolderCount.Text = Directory.GetDirectories(Path).Length.ToString()));
                lblShowFileCount.Invoke((MethodInvoker)(() => lblShowFileCount.Text = Directory.GetFiles(Path).Length.ToString()));
                lblShowFileSize.Invoke((MethodInvoker)(() => lblShowFileSize.Text = $"{Convert.ToDouble(Directory.GetFiles(Path).ToArray().Sum(n => new FileInfo(n).Length)) / 1000} KB"));
                Thread.Sleep(2000);
            }
        }
    }
}
