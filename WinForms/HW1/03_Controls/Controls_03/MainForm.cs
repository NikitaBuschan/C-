using System.Drawing;
using System.Windows.Forms;

namespace Controls_03
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            MouseMove += MouseMove_Controls;
            Size = new Size(600, 400);
        }

        private void MouseMove_Controls(object sender, MouseEventArgs e)
        {
            Text = $"X: {e.X}, Y: {e.Y}";
        }
    }
}