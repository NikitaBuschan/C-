using System;
using System.Drawing;
using System.Windows.Forms;

namespace FunctionChart
{
    public partial class FunctionChartView : Form
    {
        public FunctionChartView()
        {
            InitializeComponent();
        }

        private void FunctionChartView_Paint(object sender, PaintEventArgs e) =>
            PaintFunction();

        private void buttonFillFunction_Click(object sender, EventArgs e) =>
            PaintGraphic();

        private void PaintFunction()
        {
            Graphics e = gbFuntion.CreateGraphics();
            e.DrawLine(new Pen(Color.Black, 1.2F), new Point(gbFuntion.Width / 2, 20), new Point(gbFuntion.Width / 2, gbFuntion.Height - 20));
            e.DrawLine(new Pen(Color.Black, 1.2F), new Point(10, gbFuntion.Height / 2), new Point(gbFuntion.Width - 10, gbFuntion.Height / 2));
        }

        public void PaintGraphic()
        {
            Graphics e = gbFuntion.CreateGraphics();
            const double pi = 3.14159265;
            double step = 0.1;
            double heigh = 30;
            int fillHeight = 350;
            int indentation = 18;
            int n = Convert.ToInt32(4 * pi / step);
            Point[] pointSin = new Point[n];

            for (double i = 0, p = 0; i < 4 * pi; i += step, p++)
                pointSin[Convert.ToInt32(p)] = new Point(Convert.ToInt32(i * heigh + indentation), Convert.ToInt32(Math.Sin(i) * heigh + fillHeight / 2 + indentation));

            e.DrawCurve(new Pen(Color.Red, 1.2F), pointSin);
        }
    }
}
