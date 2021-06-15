using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WindowWithButton.View
{
    public partial class NonModalWindowView : Form
    {
        private Thread thread { get; set; }

        public NonModalWindowView()
        {
            InitializeComponent();
            this.Load += (e, o) => thread = new Thread(new ThreadStart(StartCounter)) { IsBackground = false };
            this.Load += (e, o) => thread.Start();
            this.FormClosed += (e, o) => thread.Abort();
            this.Show();
        }

        public void StartCounter()
        {
            int counter = 0;
            while (counter <= 20)
            {
                if (counter == 10)
                    lblCounter.Invoke((MethodInvoker)(() => lblCounter.Location = new Point(lblCounter.Location.X - 1, lblCounter.Location.Y - 1)));

                lblCounter.Invoke((MethodInvoker)(() => lblCounter.Text = counter.ToString()));
                Thread.Sleep(500);
                counter++;
            }
        }
    }
}
