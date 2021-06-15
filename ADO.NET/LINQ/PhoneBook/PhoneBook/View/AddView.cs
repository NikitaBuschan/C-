using System;
using System.Windows.Forms;

namespace PhoneBook.View
{
    public partial class AddView : Form
    {
        public event EventHandler Save;
        public event EventHandler Cancel;
        public TextBox tbName { get; set; } 
        public TextBox tbPhone { get; set; }

        public AddView()
        {
            InitializeComponent();

            tbName = textBoxName;
            tbPhone = textBoxPhone;
        }

        private void btnSave_Click(object sender, EventArgs e) =>
            Save?.Invoke(this, EventArgs.Empty);

        private void btnCancel_Click(object sender, EventArgs e) =>
            Cancel?.Invoke(this, EventArgs.Empty);
    }
}
