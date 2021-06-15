using System;
using System.Threading;
using System.Windows.Forms;

namespace sumOfNumbers.View
{
    public partial class SumOfNumbersView : Form, ISumOfNumberView
    {
        public event EventHandler CreateFirstThreadEvent;
        public event EventHandler CreateSecondThreadEvent;
        private object lockObjOne { get; set; }
        private object lockObjSecond { get; set; }
        public MyThread FirstThread { get; set; }
        public MyThread SecondThread { get; set; }

        public SumOfNumbersView()
        {
            InitializeComponent();
            lockObjOne = new object();
            lockObjSecond = new object();
        }

        private void btnOneStart_Click(object sender, EventArgs e) =>
            CreateFirstThreadEvent?.Invoke(this, EventArgs.Empty);

        private void btnTwoStart_Click(object sender, EventArgs e) =>
            CreateSecondThreadEvent?.Invoke(this, EventArgs.Empty);

        public void CreateFirstThread()
        {
            if (int.TryParse(textBox1?.Text, out int a) == false || textBox1.Text.Length == 0)
            {
                if (MessageBox.Show(this, "Enter correct number", "Wrong number", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    textBox1.Text = "";
                    return;
                }
            }

            FirstThread = new MyThread(
            new Thread(new ThreadStart(FirstThreadTask)) { Name = "First thread", IsBackground = true },
            label1,
            Convert.ToInt32(textBox1.Text),
            500);

            FirstThread.thread.Start();
        }

        public void CreateSecondThread()
        {
            if (int.TryParse(textBox2?.Text, out int a) == false || textBox2.Text.Length == 0)
            {
                if (MessageBox.Show(this, "Enter correct number", "Wrong number", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    textBox2.Text = "";
                    return;
                }
            }

            SecondThread = new MyThread(
            new Thread(new ThreadStart(SecondThreadTask)) { Name = "Second thread", IsBackground = true },
            label2,
            Convert.ToInt32(textBox2.Text),
            500);

            SecondThread.thread.Start();
        }

        public void FirstThreadTask()
        {
            lock (lockObjOne)
                ThreadTask(FirstThread);
        }

        public void SecondThreadTask()
        {
            lock (lockObjSecond)
                ThreadTask(SecondThread);
        }

        public void ThreadTask(MyThread thread)
        {
            int iter = thread.number;
            while (true)
            {
                int temp = 0;
                for (int i = 1; i <= iter; i++)
                    temp += i;

                thread.label.Text = temp.ToString();

                Thread.Sleep(thread.interval);
                if (Convert.ToInt32(thread.label.Text) == 0)
                    thread.thread.Abort();
                iter--;
            }
        }
    }
}
