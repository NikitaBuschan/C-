using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DiagramBuild
{
    public partial class DiagramBuild : Form
    {
        public DiagramBuild()
        {
            InitializeComponent();

            //for (int i = 0; i < 35; i++)
            //    Menu.DropDownItems.Add(Enum.Parse(typeof(SeriesChartType), Convert.ToString(i)).ToString());

            chart.Titles.Add("Диаграммы");
            chart.Titles[0].Font = new Font("Utopia", 12);

            chart.Series.Add(new Series("ColumnSeries")
            {
                ChartType = SeriesChartType.Pie
            });

            double[] yValues = { 2222, 2724, 2720, 3263, 2445 };
            string[] xValues = { "France", "Canada", "Germany", "USA", "Italy" };
            chart.Series["ColumnSeries"].Points.DataBindXY(xValues, yValues);

            chart.ChartAreas[0].Area3DStyle.WallWidth = 10;
            chart.ChartAreas[0].BackColor = Color.Wheat;
        }
    }
}
