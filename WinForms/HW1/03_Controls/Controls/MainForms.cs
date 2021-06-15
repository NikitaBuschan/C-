using System.Drawing;
using System.Windows.Forms;

namespace Controls
{
    public partial class MainForms : Form
    {
        public MainForms()
        {
            InitializeComponent();
            Size = new Size(400, 400);
            panel.Location = new Point(10, 10);
            panel.Size = new Size(Width - 40, Height - 60);
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        { 
            if (e.X < panel.Location.X || e.Y < panel.Location.Y ||
                e.X > panel.Width + panel.Location.X || e.Y > panel.Height + panel.Location.Y)
                Text = "Mouse click on Main Form";
            else if (e.X == panel.Location.X || e.Y == panel.Location.Y ||
                e.X == panel.Width + panel.Location.X || e.Y == panel.Height + panel.Location.Y)
                Text = "Mouse click on Border";
            else
                Text = "Mouse click on Panel";
        }
    }
}