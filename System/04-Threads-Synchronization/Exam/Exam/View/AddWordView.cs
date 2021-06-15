using System;
using System.Windows.Forms;

namespace Exam
{
    public partial class AddWordView : Form
    {
        public event EventHandler Save;
        public event EventHandler Cancel;

        public TextBox TextBox { get; set; }

        public AddWordView()
        {
            InitializeComponent();
            TextBox = this.textBox;
        }

        private void btnSave_Click(object sender, EventArgs e) =>
            Save?.Invoke(this, EventArgs.Empty);

        private void btnCancel_Click(object sender, EventArgs e) =>
            Cancel?.Invoke(this, EventArgs.Empty);
    }
}
