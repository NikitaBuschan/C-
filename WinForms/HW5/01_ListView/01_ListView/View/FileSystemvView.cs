using System;
using System.IO;
using System.Windows.Forms;

namespace _01_ListView
{
    public partial class FileSystemvView : Form, IFileSystemView
    {
        public FileSystemvView()
        {
            InitializeComponent();
        }

        public void FillTreeView(DriveInfo[] drive)
        {
            foreach (var disk in drive)
                if (disk.DriveType != DriveType.CDRom)
                    treeView.Nodes.Add(GetCollection(disk.Name));
        }

        private TreeNode GetCollection(string dir)
        {
            TreeNode treeNode = new TreeNode(dir);
            try
            {
                foreach (var folder in Directory.GetDirectories(dir))
                    treeNode.Nodes.Add(GetCollection(folder));

                foreach (var file in Directory.GetFiles(dir))
                    treeNode.Nodes.Add(file);
            }
            catch (Exception)
            {
            }

            return treeNode;
        }
    }
}
