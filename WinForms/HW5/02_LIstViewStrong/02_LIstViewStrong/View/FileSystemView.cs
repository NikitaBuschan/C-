using _02_LIstViewStrong.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace _02_LIstViewStrong
{
    public partial class FileSystemView : Form, IFileSystemView
    {
        private ListView table { get; set; }
        public FileSystemView()
        {
            InitializeComponent();
            table = new ListView();

            this.Size = new Size(430, 500);
            UpdateView();
            FillComboBoxList();
        }

        public void UpdateView()
        {
            table.Location = new Point(12, 62);
            table.Size = new Size(390, 390);

            foreach (var item in DriveInfo.GetDrives())
            {
                if (item.DriveType == DriveType.CDRom)
                    continue;

                DirectoryInfo[] dir = new DirectoryInfo(item.RootDirectory.FullName).GetDirectories();
                foreach (var folder in dir)
                {
                    table.Items.Add(folder.Name);
                }
            }
            this.ClientSizeChanged += ClientSizeChangedFunction;
            this.Controls.Add(table);
        }

        private void ClientSizeChangedFunction(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(430, 500);
            table.Size = new Size(this.Size.Width - 40, this.Size.Height - table.Location.X - 100);
        }

        public List<string> GetComboBoxList()
        {
            return new List<string>
            {
                System.Windows.Forms.View.LargeIcon.ToString(),
                System.Windows.Forms.View.SmallIcon.ToString(),
                System.Windows.Forms.View.List.ToString(),
                System.Windows.Forms.View.Tile.ToString()
            };
        }

        public void FillComboBoxList()
        {
            foreach (var item in GetComboBoxList())
                comboBox.Items.Add(item);

            comboBox.SelectedIndex = 0;
            comboBox.Update();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex == 0)
                table.View = System.Windows.Forms.View.LargeIcon;
            else if (comboBox.SelectedIndex == 1)
                table.View = System.Windows.Forms.View.SmallIcon;
            else if (comboBox.SelectedIndex == 2)
                table.View = System.Windows.Forms.View.List;
            else if (comboBox.SelectedIndex == 3)
                table.View = System.Windows.Forms.View.Tile;
        }
    }
}
