using System;
using System.Windows.Forms;

namespace _03_Editor
{
    public partial class Edit : Form
    {
        FormMain mainForm;

        public Edit()
        {
            InitializeComponent();
        }

        public Edit(FormMain mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            textBox.Text = mainForm.textBox.Text;
        }

        private void buttonSave_Click(object sender, EventArgs e) =>
            mainForm.textBox.Text = textBox.Text;

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Close", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }
    }
}