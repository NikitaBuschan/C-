using Exam.Model;
using Exam.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Exam.Presenter
{
    public class ForbiddenWordsPresenter
    {
        private IForbiddenWordsModel Model { get; set; }
        private IForbiddenWordsView View { get; set; }

        private Thread mainThread { get; set; }
        private ManualResetEvent mrse = new ManualResetEvent(false);

        public ForbiddenWordsPresenter(IForbiddenWordsModel model, IForbiddenWordsView view)
        {
            Model = model;
            View = view;

            Model.Wrods = new List<string>();

            View.LoadWords += (o, e) =>
            {
                Model.Wrods = FileLib.ReadFromFile();
                
                if (View.ListBoxForbiddenWords.Items.Count != 0 && Model.Wrods.Count != 0)
                {
                    if (MessageBox.Show("You have new word in list, do you want delete list and load from file?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        View.ListBoxForbiddenWords.Items.Clear();
                        View.ListBoxForbiddenWords.Items.AddRange(Model.Wrods.ToArray());
                    }
                }
                else
                {
                    View.ListBoxForbiddenWords.Items.AddRange(Model.Wrods.ToArray());
                }
            };

            View.AddWord += (o, e) =>
            {
                View.AddWordView = new AddWordView();
                View.AddWordView.Save += AddWordView_Save_Click;
                View.AddWordView.Cancel += AddWordView_Cancel_Click;
                View.AddWordView.ShowDialog();
            };

            View.DeleteWord += (o, e) =>
            {
                if (View.ListBoxForbiddenWords.Items.Count == 0)
                    return;

                if (MessageBox.Show("Do you want delete this word?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Model.Wrods.RemoveAt(View.ListBoxForbiddenWords.SelectedIndex);
                    View.ListBoxForbiddenWords.Items.RemoveAt(View.ListBoxForbiddenWords.SelectedIndex);
                }
            };

            View.SaveWords += (o, e) =>
            {
                if (View.ListBoxForbiddenWords.Items.Count != 0)
                    FileLib.SaveToFile(Model.Wrods);
            };

            View.Search += (o, e) =>
            {
                View.SearchView = new SearchView();
                View.SearchView.ButtonCancel.Enabled = false;
                View.SearchView.ButtonPause.Enabled = false;
                View.SearchView.Start += SearchView_Start_Click;
                View.SearchView.Pause += SearchView_Pause_Click;
                View.SearchView.Cancel += SearchView_Cancel_Click;
                View.SearchView.Show();
            };
        }

        // Add view
        private void AddWordView_Save_Click(object sender, EventArgs e)
        {
            if (View.AddWordView.TextBox.Text.Length <= 0)
                return;

            Model.Wrods.Add(View.AddWordView.TextBox.Text);
            View.ListBoxForbiddenWords.Items.Add(View.AddWordView.TextBox.Text);
            View.AddWordView.Close();
        }

        private void AddWordView_Cancel_Click(object sender, EventArgs e)
        {
            if (View.AddWordView.TextBox.Text.Length > 0 &&
                MessageBox.Show("Are you sure?", "Do you want close?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
                View.AddWordView.Close();
            else
                View.AddWordView.Close();
        }

        // Search view
        private void SearchView_Start_Click(object sender, EventArgs e)
        {
            View.SearchView.ButtonStart.Enabled = false;
            View.SearchView.ButtonCancel.Enabled = true;
            View.SearchView.ButtonPause.Enabled = true;
            mainThread = new Thread(MakeSearch);
            mainThread.Start();
        }

        private void MakeSearch()
        {
            mrse.Set();
            Dictionary<string, int> words = new Dictionary<string, int>();

            foreach (var word in Model.Wrods)
                words.Add(word, 0);

            FileLib.NewWord += (e, o) =>
            {
                mrse.WaitOne();
                View.ListBoxFileList.BeginInvoke((MethodInvoker)(() =>
                {
                    words[e.ToString()]++;
                    FileInfo fileInf = new FileInfo(FileLib.File);
                    View.ListBoxFileList.Items.Add($"Word: {e.ToString()} | File name: {fileInf.Name} | Size: {fileInf.Length}KB");
                }));
            };

            FileLib.SearchFiles(Model.Wrods);

            List<string> sortedWords = (List<string>)words.OrderByDescending(x => x.Value);

            MessageBox.Show("Top 10 words",
                $"#1 {sortedWords[0]}\n" +
                $"#2 {sortedWords[1]}\n" +
                $"#3 {sortedWords[2]}\n" +
                $"#4 {sortedWords[3]}\n" +
                $"#5 {sortedWords[4]}\n" +
                $"#6 {sortedWords[5]}\n" +
                $"#7 {sortedWords[6]}\n" +
                $"#8 {sortedWords[7]}\n" +
                $"#9 {sortedWords[8]}\n" +
                $"#10 {sortedWords[9]}\n", MessageBoxButtons.OK);
        }

        private void SearchView_Pause_Click(object sender, EventArgs e)
        {
            if (View.SearchView.ButtonPause.Text == "Pause")
            {
                View.SearchView.ButtonStart.Enabled = false;
                mrse.Reset();
                View.SearchView.ButtonPause.Text = "Unpouse";
            }
            else
            {
                View.SearchView.ButtonPause.Text = "Pause";
                mrse.Set();
            }
        }

        private void SearchView_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Do you want close?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                View.SearchView.Close();
                mainThread.Abort();
            }
        }
    }
}
