using System.Drawing;
using System.Windows.Forms;

namespace Controls_02
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Size = new Size(600, 400);
        }
        private void MainForm_Paint(object sender, System.EventArgs e)
        {
            Text = $"Width: {Width}, Height: {Height}";
        }
    }
}