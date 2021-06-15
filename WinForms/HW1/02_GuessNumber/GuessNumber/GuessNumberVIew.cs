using System;
using System.Windows.Forms;

namespace GuessNumber
{
    public partial class MainForm : Form
    {
        Random Random = new Random();

        public MainForm()
        {
            InitializeComponent();
            this.Shown += Game;
        }

        private void Game(object sender, EventArgs e)
        {
            int number;
            int count = 0;
            while (true)
            {
                number = Random.Next(0, 2000);
                count++;
                var dialogResult = MessageBox.Show($"Your number {Convert.ToString(number)}", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show($"Number of attempts: {count}", "");
                    dialogResult = MessageBox.Show("Play again?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                        this.Close();
                    count = 0;
                }                
            }
        }
    }
}
