using System;
using System.Drawing;
using System.Windows.Forms;
using Chess.Properties;
using Chess.View;

namespace Chess
{
    public partial class CheesView : Form, ICheesView
    {
        public event EventHandler FillDesk;

        public CheesView()
        {
            InitializeComponent();
        }

        private void CheesView_Load(object sender, EventArgs e) =>
            FillDesk?.Invoke(this, EventArgs.Empty);
            

        public void PaintDesk()
        {
            this.BackgroundImage = Resources.Desk;
        }

        public void PutFigureOnDesk()
        {
            // White Pawn
            Point startPos = new Point(37, 84);
            for (int i = 1; i < 9; i++)
            {
                PaintFigure(new Point(startPos.X, startPos.Y), new Size(45, 45), Resources.WhitePawn, "Я пешка", (i % 2 == 0) ? true : false);
                startPos.X += 47;
            }
            // Black Pawn
            startPos = new Point(37, 318);
            for (int i = 0; i < 8; i++)
            {
                PaintFigure(new Point(startPos.X, startPos.Y), new Size(45, 45), Resources.BlackPawn, "Я пешка", (i % 2 == 0) ? true : false);
                startPos.X += 47;
            }

            // White Rook
            PaintFigure(new Point(37, 37), new Size(45, 45), Resources.WhiteRook, "Я ладья", true);
            PaintFigure(new Point(365, 37), new Size(45, 45), Resources.WhiteRook, "Я ладья", false);

            // Black Rook
            PaintFigure(new Point(37, 365), new Size(45, 45), Resources.BlackRook, "Я ладья", false);
            PaintFigure(new Point(365, 365), new Size(45, 45), Resources.BlackRook, "Я ладья", true);

            // White Horse
            PaintFigure(new Point(84, 37), new Size(45, 45), Resources.WhiteHorse, "Я конь", false);
            PaintFigure(new Point(318, 37), new Size(45, 45), Resources.WhiteHorse, "Я конь", true);

            // Black Horse
            PaintFigure(new Point(84, 365), new Size(45, 45), Resources.BlackHorse, "Я конь", true);
            PaintFigure(new Point(318, 365), new Size(45, 45), Resources.BlackHorse, "Я конь", false);

            // White Elefant
            PaintFigure(new Point(131, 37), new Size(45, 45), Resources.WhiteElefant, "Я слон", true);
            PaintFigure(new Point(271, 37), new Size(45, 45), Resources.WhiteElefant, "Я слон", false);

            // Black Elefant
            PaintFigure(new Point(131, 365), new Size(45, 45), Resources.BlackElefant, "Я слон", false);
            PaintFigure(new Point(271, 365), new Size(45, 45), Resources.BlackElefant, "Я слон", true);

            // White Queen
            PaintFigure(new Point(178, 37), new Size(45, 45), Resources.WhiteQueen, "Я королева", false);

            // Black Queen
            PaintFigure(new Point(178, 365), new Size(45, 45), Resources.BlackQueen, "Я королева", true);

            // White King
            PaintFigure(new Point(225, 37), new Size(45, 45), Resources.WhiteKing, "Я король", true);

            // White King
            PaintFigure(new Point(225, 365), new Size(45, 45), Resources.BlackKing, "Я король", false);

        }

        private void PaintFigure(Point point, Size size, Image image, string contextMessge, bool onWhite)
        {
            PictureBox picture = new PictureBox();
            picture.Location = point;
            picture.Size = size;
            if (onWhite)
                picture.BackColor = Color.FromArgb(255, 251, 219);
            else
                picture.BackColor = Color.FromArgb(142, 36, 38);
            picture.Image = image;
            ContextMenuStrip context = new ContextMenuStrip();
            context.Items.Add(contextMessge);
            picture.ContextMenuStrip = context;
            this.Controls.Add(picture);
        }
    }
}
