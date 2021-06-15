using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace _01_SearchFile
{
    public partial class FormMain : Form
    {
        private string path = string.Empty;
        static DirectoryInfo dir;
        private Path load = new Path();

        static List<string> filterArr = new List<string>
        {
            "All",
            "*.txt",
            "*.cs"
        };

        public FormMain()
        {
            InitializeComponent();

            foreach (var item in filterArr)
                comboBox.Items.Add(item);
            comboBox.SelectedIndex = 0;
            comboBox.Update();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure?",
                "Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                ) == DialogResult.Yes)

                Close();
        }

        private void buttonPath_Click(object sender, EventArgs e) => load.Show();

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (load.DialogResult == DialogResult.OK)
            {
                path = load.PathStr;
                dir = new DirectoryInfo(path);
                AddFiles(string.Empty);
                listBox.Update();
            }
        }

        private void AddFiles(string str)
        {
            if (listBox.Items.Count > 0)
                listBox.Items.Clear();

            if (str == string.Empty)
                foreach (var info in dir.GetFiles())
                    listBox.Items.Add(info);
            else
                foreach (var info in dir.GetFiles(str))
                    listBox.Items.Add(info);
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (path == string.Empty)
                return;
            if (comboBox.SelectedIndex != 0)
                AddFiles(comboBox.SelectedItem.ToString());
            if (comboBox.SelectedIndex == 0 && load.DialogResult == DialogResult.OK)
                AddFiles(string.Empty);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var add = new AddFilter();

            add.ShowDialog();

            filterArr.Add("*." + add.Filter);
            comboBox.Items.Add("*." + add.Filter);
            comboBox.Update();
        }

        private void buttonDeleteFilter_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex != 0 &&
                MessageBox.Show("Realy?", $"Are you sure tahat you delete {comboBox.SelectedItem.ToString()}", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int a = comboBox.SelectedIndex;
                comboBox.Items.Remove(comboBox.SelectedItem);
                comboBox.SelectedIndex = 0;
            }
        }
    }
}