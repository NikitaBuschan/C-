using Catalog.View;
using System;
using System.Windows.Forms;

namespace Catalog
{
    public partial class CatalogView : Form, ICatalogView
    {
        public event EventHandler CreateNewWindow;

        public CatalogView()
        {
            InitializeComponent();
        }

        private void btnShowInfo_Click(object sender, EventArgs e) =>
             CreateNewWindow?.Invoke(this, EventArgs.Empty);

        public string GetPath() => 
            textBoxPath?.Text;
    }
}
