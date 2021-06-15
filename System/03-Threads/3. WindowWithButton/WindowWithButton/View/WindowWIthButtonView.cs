using System;
using System.Windows.Forms;
using WindowWithButton.View;

namespace WindowWithButton
{
    public partial class WindowWithButtonView : Form, IWindowWithButtonView
    {
        public event EventHandler CreateNewWindow;

        public WindowWithButtonView()
        {
            InitializeComponent();
        }

        private void btnButton_Click(object sender, EventArgs e) =>
            CreateNewWindow?.Invoke(this, EventArgs.Empty);
    }
}
