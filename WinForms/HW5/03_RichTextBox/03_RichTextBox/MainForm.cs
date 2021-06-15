using System.IO;
using System.Windows.Forms;

namespace _03_RichTextBox
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            richTextBox.AllowDrop = true;
            richTextBox.DragDrop += RichTextBox_DragDrop;
            richTextBox.DragEnter += RichTextBox_DragEnter;
            //richTextBox.Enabled = false;
        }

        private void RichTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void RichTextBox_DragDrop(object sender, DragEventArgs e)
        {

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (var item in files)
            {
                using (StreamReader sr = new StreamReader(item, System.Text.Encoding.Default))
                {
                    richTextBox.Text = sr.ReadToEnd();
                }
            }
            //richTextBox.Update();
        }
    }
}
