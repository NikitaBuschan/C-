using System;
using System.Windows.Forms;

namespace _06_DayOfWeek
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            dayLabel.Text = dateTimePicker.Value.DayOfWeek.ToString();
        }
    }
}
