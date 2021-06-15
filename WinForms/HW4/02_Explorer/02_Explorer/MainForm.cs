using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace _02_Explorer
{
    public partial class MainForm : Form
    {
        private List<DriveInfo> drives = new List<DriveInfo>();

        public MainForm()
        {
            InitializeComponent();
            foreach (var disk in DriveInfo.GetDrives())
                if (disk.DriveType != DriveType.CDRom)
                    listBox.Items.Add($"Local Disk ({disk.ToString().Substring(0, 1)}:)");
            buttonBack.Enabled = false;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonBack.Enabled = false;
            listView.Items.Clear();
            string url = $@"{listBox.SelectedItem.ToString().Substring(12, 1)}:\";
            textBoxUrl.Text = url;

            foreach (var folder in new DirectoryInfo(url).GetDirectories())
                listView.Items.Add(folder.Name);
            foreach (var file in Directory.GetFiles(url))
                listView.Items.Add(file.Substring(file.LastIndexOf("\\") + 1, file.Length - file.LastIndexOf("\\") - 1));

            labelItems.Text = $"{listView.Items.Count.ToString()} items";
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                labelSelectedItems.Text = "";
                return;
            }
            else
            {
                labelSelectedItems.Text = $"{listView.SelectedItems.Count.ToString()} item selected";
            }
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                buttonBack.Enabled = true;
                textBoxUrl.Text += $@"{listView.SelectedItems[0].Text}\";
                listView.Items.Clear();

                try
                {
                    foreach (var folder in new DirectoryInfo(textBoxUrl.Text).GetDirectories())
                        listView.Items.Add(folder.Name);
                    foreach (var file in Directory.GetFiles(textBoxUrl.Text))
                        listView.Items.Add(file.Substring(file.LastIndexOf("\\") + 1, file.Length - file.LastIndexOf("\\") - 1));
                }
                catch (Exception)
                {
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            textBoxUrl.Text = textBoxUrl.Text.Substring(0, textBoxUrl.Text.Length - (textBoxUrl.Text.Length - textBoxUrl.Text.LastIndexOf("\\")));
            textBoxUrl.Text = textBoxUrl.Text.Substring(0, textBoxUrl.Text.Length - (textBoxUrl.Text.Length - textBoxUrl.Text.LastIndexOf("\\")) + 1);
            listView.Items.Clear();

            try
            {
                foreach (var folder in new DirectoryInfo(textBoxUrl.Text).GetDirectories())
                    listView.Items.Add(folder.Name);
                foreach (var file in Directory.GetFiles(textBoxUrl.Text))
                    listView.Items.Add(file.Substring(file.LastIndexOf("\\") + 1, file.Length - file.LastIndexOf("\\") - 1));
            }
            catch (Exception)
            {
            }

            if (textBoxUrl.Text.Length == 3)
                buttonBack.Enabled = false;
        }
    }
}