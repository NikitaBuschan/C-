using System.Drawing;
using System.Windows.Forms;

namespace _04_Forms
{
    public partial class MainForm : Form
    {
        private Point down;
        private Point up;
        private int count = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            down = e.Location;
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            up = e.Location;

            if (down.X < up.X && down.Y < up.Y)
                CreateStatic(up.X - down.X, up.Y - down.Y, down.X, down.Y);
            else if (down.X > up.X && down.Y > up.Y)
                CreateStatic(down.X - up.X, down.Y - up.Y, up.X, up.Y);
            else if (down.X > up.X && down.Y < up.Y)
                CreateStatic(down.X - up.X, up.Y - down.Y, down.X - (down.X - up.X), up.Y - (up.Y - down.Y));
            else if (down.X < up.X && down.Y > up.Y)
                CreateStatic(up.X - down.X, down.Y - up.Y, down.X, up.Y);
        }

        private void CreateStatic(int x, int y, int xLocation, int yLocation)
        {
            if (x < 10 || y < 10)
            {
                MessageBox.Show("Static smaller then 10 x 10 size", "Small window!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            count++;
            var groupBox = new GroupBox()
            {
                Location = new Point(xLocation, yLocation),
                Size = new Size(x, y),
                Text = $"Number #{count}",
                Tag = count,
                Parent = this.Parent
            };
            Controls.Add(groupBox);
            groupBox.BringToFront();
        }

        private void MainForm_ControlAdded(object sender, ControlEventArgs e)
        {
            Text = $"Down: {down}, Up: {up}";
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        { 
            if (e.Button == MouseButtons.Right)
            {
                foreach (var item in this.Controls)
                {
                    GroupBox groupBox = item as GroupBox;
                    if (groupBox.Location.Y - e.Y > 10 || e.Y - groupBox.Location.Y > 10)
                    {
                        Controls.Remove(groupBox);
                        return;
                    }
                }
            }
        }
    }
}
