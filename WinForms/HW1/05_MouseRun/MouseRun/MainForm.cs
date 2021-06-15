using System.Drawing;
using System.Windows.Forms;

namespace MouseRun
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private bool RangeWidth(int location, int width, int pos)
        {
            for (int i = location; i < width; i++)
                if (pos == i)
                    return true;
            return false;
        }

        private bool RangeHeight(int location, int height, int pos)
        {
            for (int i = location; i < height; i++)
                if (pos == i)
                    return true;
            return false;
        }

        private bool CheckBoard(int x, int y)
        {
            return (button.Location.Y + button.Height == this.Height - 50 && y < button.Location.Y ||
                button.Location.Y == 10 && y > 10 || button.Location.X == 10 && x > 10 ||
                button.Location.X + button.Width == this.Width - 30 && x < button.Location.X + button.Width);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (CheckBoard(e.X, e.Y))
                return;
            if (RangeHeight(button.Location.Y - (button.Height / 2), button.Location.Y, e.Y) &&
                RangeWidth(button.Location.X, button.Location.X + button.Width, e.X))
                button.Location = new Point(button.Location.X, button.Location.Y + 2);
            else if (RangeHeight(button.Location.Y + button.Height, button.Location.Y + button.Height + button.Height / 2, e.Y) &&
                RangeWidth(button.Location.X, button.Location.X + button.Width, e.X))
                button.Location = new Point(button.Location.X, button.Location.Y - 2);
            else if (RangeWidth(button.Location.X - button.Width / 3, button.Location.X, e.X) &&
                RangeHeight(button.Location.Y, button.Location.Y + button.Height, e.Y))
                button.Location = new Point(button.Location.X + 2, button.Location.Y);
            else if (RangeWidth(button.Location.X + button.Width, button.Location.X + button.Width + button.Width / 3, e.X) &&
                RangeHeight(button.Location.Y, button.Location.Y + button.Height, e.Y))
                button.Location = new Point(button.Location.X - 2, button.Location.Y);
        }
    }
}
