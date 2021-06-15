using EmployeeAccounting.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MVPTestThree
{
    public partial class ViewMainForm : Form, IView
    {
        public Person person { get; set; }
        public List<Person> people { get; set; }

        public delegate void SelectedPerson(int person);
        public event SelectedPerson UpdatePerson;
        public event SelectedPerson EditPerson;
        public event SelectedPerson DeletePerson;
        public event EventHandler AddPerson;

        public ViewMainForm()
        {
            InitializeComponent();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e) =>
            UpdatePerson?.Invoke(comboBox.SelectedIndex);

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddPerson?.Invoke(sender, e);
            UpdateComboBox();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedItem == null)
                return;
            EditPerson?.Invoke(comboBox.SelectedIndex);
            int temp = comboBox.SelectedIndex;
            UpdateComboBox();
            comboBox.SelectedIndex = temp;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (comboBox.Items.Count == 0)
                return;
            if (MessageBox.Show(
                "Are you sure you want to delete this person?",
                "Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                DeletePerson?.Invoke(comboBox.SelectedIndex);
            {
                if (people.Count == 0)
                {
                    ClearAllWindow();
                    return;
                }
                int temp = (people.Count > 1) ? comboBox.SelectedIndex : 0;
                UpdateComboBox();
                comboBox.SelectedIndex = temp;
            }
        }

        public void UpdateWindow()
        {
            txtName.Text = person.Name;
            txtSurname.Text = person.Surname;
            txtAge.Text = person.Age.ToString();
            txtGender.Text = (person.Gender) ? "Male" : "Female";
            pictureBox.Image = person.Image;
        }

        public void UpdateComboBox()
        {
            comboBox.Items.Clear();
            foreach (var person in people)
                comboBox.Items.Add($"{person.Name} {person.Surname}");
        }

        public void SetFirstValueInComboBox()
        {
            if (comboBox.Items.Count > 0)
                comboBox.SelectedItem = comboBox.Items[0];
        }

        private void ClearAllWindow()
        {
            txtName.Clear();
            txtSurname.Clear();
            txtAge.Clear();
            txtGender.Clear();
            pictureBox.Image = null;
            comboBox.Items.Clear();
        }
    }
}