using System;
using System.Windows.Forms;

namespace ConnectedLayer_01
{
    public interface IMagazineView
    {
        ListViewItem Item { get; set; }
        event EventHandler ShowList;
        void MainForm_Load();
    }
}
