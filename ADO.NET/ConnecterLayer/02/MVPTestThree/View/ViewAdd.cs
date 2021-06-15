using EmployeeAccounting.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MVPTestThree.View
{
    public partial class ViewAdd : Form, IView
    {
        public Person person { get; set; }
        public List<string> gender = new List<string>() { "Male", "Female" };

        public ViewAdd()
        {
            InitializeComponent();
            foreach (var item in gender)
                cbGender.Items.Add(item);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox.Image = new Bitmap(ofdImage.FileName);
                }
                catch (Exception)
                {

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length == 0 ||
                txtSurname.Text.Length == 0 ||
                txtAge.Text.Length == 0 ||
                pictureBox.Image == null)
            {
                MessageBox.Show("Field all lines", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateWindow();
            DialogResult = DialogResult.OK;
        }

        public void UpdateWindow()
        {
            person = new Person(
                txtName.Text,
                txtSurname.Text,
                Convert.ToInt32(txtAge.Text),
                (cbGender.SelectedItem.ToString() == "Male") ? true : false,
                new Bitmap(pictureBox.Image));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtSurname.Clear();
            txtAge.Clear();
            cbGender.SelectedItem = null;
            pictureBox.Image = null;
        }
    }
}
