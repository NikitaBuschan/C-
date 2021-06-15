using System;
using System.Windows.Forms;

namespace HW_07
{
    public partial class MainForm : Form
    {
        private DateTime dateTime { get; set; }

        public MainForm()
        {
            InitializeComponent();
            dateTime = new DateTime();
            yearRadioButton.Checked = true;
        }

        private void maskedTextBox_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox.Text.Length == 10)
                WriteResult();
        }

        private void yearsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (maskedTextBox.Text == "  /  /")
                return;

            WriteResult();
        }

        private void WriteResult()
        {
            string str = maskedTextBox.Text;

            if (str.Length == 10 &&
                Convert.ToInt32(str.Substring(0, 2)) < 12 &&
                Convert.ToInt32(str.Substring(3, 2)) < 31)
            {
                dateTime = Convert.ToDateTime(maskedTextBox.Text);

                DateTime first;
                DateTime second;

                if (DateTime.Now > dateTime)
                {
                    first = DateTime.Now;
                    second = dateTime;
                }
                else
                {
                    first = dateTime;
                    second = DateTime.Now;
                }

                if (yearRadioButton.Checked)
                    answerLabel.Text = Convert.ToString(first.Year - second.Year);
                else if (monthRadioButton.Checked)
                    answerLabel.Text = Convert.ToString((first.Year - second.Year) * 12 + first.Month - second.Month);
                else if (dayRadioButton.Checked)
                    answerLabel.Text = Convert.ToString(Convert.ToInt32(first.Subtract(second).TotalDays));
                else if (minuteRadioButton.Checked)
                    answerLabel.Text = Convert.ToString(Convert.ToInt32(first.Subtract(second).TotalMinutes));
                else if (secondRadioButton.Checked)
                    answerLabel.Text = Convert.ToString(Convert.ToInt32(first.Subtract(second).TotalSeconds));
            }
            else
            {
                MessageBox.Show("Неверно введена дата", "Дата", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}