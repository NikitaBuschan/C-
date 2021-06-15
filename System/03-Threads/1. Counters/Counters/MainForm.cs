using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Counters
{
    public class MyThread
    {
        public Thread Thrd { get; set; }
        public int Counter { get; set; }
        public int Pause { get; set; }
        public Label Label { get; set; }

        public MyThread(int pause, Label lbl)
        {
            Counter = 0;
            Pause = pause;
            Label = lbl;
            Thrd = new Thread(this.Run);
            Thrd.Name = lbl.Name;
            Thrd.IsBackground = true;
            Thrd.Start();
        }

        public void Run()
        {
            while (true)
            {
                Label.Text = Counter++.ToString();
                Thread.Sleep(Pause);
            }
        }
    }

    public partial class MainForm : Form
    {
        public List<MyThread> Threads { get; set; } = new List<MyThread>();

        public MainForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            buttonClear.Enabled = false;
            buttonStop.Enabled = false;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Threads?.Clear();

            Threads.Add(new MyThread(500, label1));
            Threads.Add(new MyThread(1000, label2));
            Threads.Add(new MyThread(1500, label3));

            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            buttonClear.Enabled = false;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            foreach (var thread in Threads)
                thread.Thrd.Abort();

            buttonStart.Enabled = true;
            buttonClear.Enabled = true;
            buttonStop.Enabled = false;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            label2.Text = "0";
            label3.Text = "0";

            buttonStart.Enabled = true;
            buttonClear.Enabled = false;
        }
    }
}
