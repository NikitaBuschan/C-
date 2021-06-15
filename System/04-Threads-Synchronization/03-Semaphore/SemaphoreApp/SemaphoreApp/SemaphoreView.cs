using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace SemaphoreApp
{
    public partial class SemaphoreView : Form
    {
        public System.Threading.Timer Timer { get; set; }
        public Semaphore Semaphore { get; set; }
        public List<Thread> Threads { get; set; }
        public int Counter = 0;

        public SemaphoreView()
        {
            InitializeComponent();

            Threads = new List<Thread>();
        }

        public void StartThread()
        {
            listBoxWorking.BeginInvoke(
                (MethodInvoker)(() => listBoxWorking.Items.Add(listBoxAwaiting.Items[0])));
            listBoxAwaiting.BeginInvoke(
                (MethodInvoker)(() => listBoxAwaiting.Items.RemoveAt(0)));
            listBoxWorking.BeginInvoke(
                (MethodInvoker)(() =>
                {
                    var index = listBoxWorking.Items[listBoxWorking.Items.Count - 1].ToString().IndexOf(">");
                    var substring = listBoxWorking.Items[listBoxWorking.Items.Count - 1].ToString().Substring(index + 2);
                    listBoxWorking.Items[listBoxWorking.Items.Count - 1] = listBoxWorking.Items[listBoxWorking.Items.Count - 1].ToString().Replace(substring, "0");
                }));
        }

        private void ChangeTime(object state)
        {
            listBoxWorking.BeginInvoke((MethodInvoker)(() =>
            {
                for (int i = 0; i < listBoxWorking.Items.Count; i++)
                {
                    var index = listBoxWorking.Items[i].ToString().IndexOf(">");
                    var substring = listBoxWorking.Items[i].ToString().Substring(index + 2);
                    listBoxWorking.Items[i] = listBoxWorking.Items[i].ToString().Remove(index + 2, substring.Length).Insert(index + 2, (Convert.ToInt32(substring) + 1).ToString());
                }
            }));
        }

        private void btnCreateThread_Click(object sender, EventArgs e) =>
            listBoxCreating.Items.Add($"Thread #{++Counter} -> created");

        private void listBoxCreating_DoubleClick(object sender, EventArgs e)
        {
            if ((int)numericUpDown.Value > listBoxWorking.Items.Count)
            {
                listBoxAwaiting.Items.Add(listBoxCreating.SelectedItem);
                listBoxCreating.Items.RemoveAt(listBoxCreating.SelectedIndex);
                CreateThread();
                return;
            }

            listBoxAwaiting.Items.Add(listBoxCreating.SelectedItem);
            listBoxCreating.Items.RemoveAt(listBoxCreating.SelectedIndex);
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {

            if ((int)numericUpDown.Value < listBoxWorking.Items.Count)
            {
                listBoxWorking.Items.RemoveAt(0);
                Threads[listBoxWorking.Items.Count].Abort();
                return;
            }
            else if (listBoxAwaiting.Items.Count == 0)
            {
                return;
            }

            CreateThread();
        }

        private void CreateThread()
        {
            using (Semaphore = new Semaphore(listBoxWorking.Items.Count, (int)numericUpDown.Value))
            {
                Threads.Add(new Thread(StartThread) { Name = listBoxAwaiting.Items[0].ToString() });
                Threads[Threads.Count - 1].Start();
                Threads[Threads.Count - 1].Join();
            }
        }

        private void listBoxWorking_DoubleClick(object sender, EventArgs e)
        {
            listBoxWorking.BeginInvoke(
               (MethodInvoker)(() =>
               {
                   Threads[listBoxWorking.SelectedIndex].Abort();
                   Threads.RemoveAt(listBoxWorking.SelectedIndex);
                   listBoxWorking.Items.RemoveAt(listBoxWorking.SelectedIndex);

                   if ((int)numericUpDown.Value > listBoxWorking.Items.Count && listBoxAwaiting.Items.Count > 0)
                       CreateThread();
               }));
        }

        private void SemaphoreView_Load(object sender, EventArgs e) =>
           Timer = new System.Threading.Timer(new TimerCallback(ChangeTime), null, 0, 1000);
    }
}
