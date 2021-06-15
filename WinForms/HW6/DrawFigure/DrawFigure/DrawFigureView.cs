using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace DrawFigure
{
    [Serializable]
    struct Figure
    {
        public Point down { get; set; }
        public Point up { get; set; }
        public string figure { get; set; }

        public Figure(Point down, Point up, string figure)
        {
            this.down = down;
            this.up = up;
            this.figure = figure;
        }
    }
    public partial class DrawFigure : Form
    {
        private BinaryFormatter formatter = new BinaryFormatter();
        private string figurePath = "figure.dat";
        private bool drawComposition = false;
        List<Figure> figures = new List<Figure>();
        public Point down { get; set; }
        public Point up { get; set; }
        public string figure { get; set; }

        public DrawFigure()
        {
            InitializeComponent();
        }

        private void DrawFigure_MouseDown(object sender, MouseEventArgs e)
        {
            down = e.Location;
        }

        private void DrawFigure_MouseUp(object sender, MouseEventArgs e)
        {
            up = e.Location;
            if (figure != null)
                figures.Add(new Figure(down, up, figure));
            Invalidate();
        }

        private void DrawFigure_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (drawComposition == true)
            {
                foreach (var f in figures)
                {
                    down = f.down;
                    up = f.up;
                    figure = f.figure;

                    if (f.figure == "square")
                        g.DrawRectangle(new Pen(Color.Red, 2), CreateRectangle());
                    else if (f.figure == "circle")
                        g.DrawEllipse(new Pen(Color.Red, 2), CreateRectangle());
                }
                drawComposition = false;
            }

            if (figure == "square")
                g.DrawRectangle(new Pen(Color.Red, 2), CreateRectangle());
            else if (figure == "circle")
                g.DrawEllipse(new Pen(Color.Red, 2), CreateRectangle());
        }

        public Rectangle CreateRectangle()
        {
            if (down.X < up.X && down.Y < up.Y)
                return GetRectangle(up.X - down.X, up.Y - down.Y, down.X, down.Y);
            else if (down.X > up.X && down.Y > up.Y)
                return GetRectangle(down.X - up.X, down.Y - up.Y, up.X, up.Y);
            else if (down.X > up.X && down.Y < up.Y)
                return GetRectangle(down.X - up.X, up.Y - down.Y, down.X - (down.X - up.X), up.Y - (up.Y - down.Y));
            else if (down.X < up.X && down.Y > up.Y)
                return GetRectangle(up.X - down.X, down.Y - up.Y, down.X, up.Y);

            return Rectangle.Empty;
        }

        private Rectangle GetRectangle(int x, int y, int xLocation, int yLocation) =>
            new Rectangle(xLocation, yLocation, x, y);

        private void квадратToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figure = "square";
        }

        private void кругToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figure = "circle";
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fileStream = new FileStream(figurePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                formatter.Serialize(fileStream, figures);
        }

        private void скачатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var fileStream = new FileStream(figurePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
                    figures = (List<Figure>)formatter.Deserialize(fileStream);
            }
            catch (System.Exception)
            {
            }
        }

        private void нарисоватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (figures.Count == 0)
            {
                MessageBox.Show("Скачайте композицию перед использованием", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                drawComposition = true;
                Invalidate();
            }
        }
    }
}
