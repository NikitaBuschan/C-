using EmployeeAccounting.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MVPTestThree.View
{
    public partial class ViewEditForm : Form, IView
    {
        public Person person { get; set; }
        public List<string> gender = new List<string>() { "Male", "Female" };

        public ViewEditForm()
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
            if (textName.Text.Length == 0 ||
                textSurname.Text.Length == 0 ||
                textAge.Text.Length == 0 ||
                pictureBox.Image == null)
            {
                MessageBox.Show("Field all lines", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            EditPerson();

            DialogResult = DialogResult.OK;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textName.Clear();
            textSurname.Clear();
            textAge.Clear();
            cbGender.SelectedItem = null;
            pictureBox.Image = null;
        }

        public void EditPerson()
        {
            person = new Person(
                textName.Text,
                textSurname.Text,
                Convert.ToInt32(textAge.Text),
                (cbGender.SelectedItem.ToString() == "Male") ? true : false,
                new Bitmap(pictureBox.Image));
        }

        public void UpdateWindow()
        {
            textName.Text = person.Name;
            textSurname.Text = person.Surname;
            textAge.Text = person.Age.ToString();
            cbGender.Text = (person.Gender) ? "Male" : "Female";
            pictureBox.Image = person.Image;
        }
    }
}
