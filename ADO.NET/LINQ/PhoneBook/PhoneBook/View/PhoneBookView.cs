using PhoneBook.Model;
using PhoneBook.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class PhoneBookView : Form, IPhoneBookView
    {
        public event EventHandler AddUser;
        public event EventHandler EditUser;
        public AddView Add { get; set; }
        public EditView Edit { get; set; }
        public DataGridView DataGridView { get; set; }

        public PhoneBookView()
        {
            InitializeComponent();
            DataGridView = this.dataGridView;
            CreateDB();
            FillDataGridView();
            FileLib.SaveToFile();
        }

        public User GetSelectedUser() =>
           new User() 
           { 
               ID = 1, 
               Name = dataGridView?.Rows[dataGridView.SelectedCells[0].RowIndex].Cells[0].Value.ToString(), 
               Phone = dataGridView?.Rows[dataGridView.SelectedCells[0].RowIndex].Cells[1].Value.ToString() 
           };             

        public void CreateDB()
        {
            using (var db = new PhoneBookContext())
            {
                db.Users.AddRange(new List<User>()
                {
                    new User() { ID = 1, Name = "Nikita", Phone = "01" },
                    new User() { ID = 2, Name = "Kolia", Phone = "06" },
                    new User() { ID = 3, Name = "Hanna", Phone = "13" },
                    new User() { ID = 4, Name = "Artem", Phone = "46" },
                    new User() { ID = 5, Name = "Vova", Phone = "10" },
                    new User() { ID = 6, Name = "Olia", Phone = "02" },
                });
                db.SaveChanges();
            }
        }

        public void FillDataGridView()
        {
            using (var db = new PhoneBookContext())
            {
                var users = from a in db.Users.ToList()
                            select new
                            {
                                Name = a.Name,
                                Phone = a.Phone
                            };

                dataGridView.Columns.Add("Name", "Name");
                dataGridView.Columns.Add("Phone", "Phone");

                int temp = 0;
                foreach (var user in users)
                {
                    dataGridView.Rows.Add();
                    dataGridView.Rows[temp].Cells["Name"].Value = user.Name;
                    dataGridView.Rows[temp].Cells["Phone"].Value = user.Phone;
                    temp++;
                }

                for (int i = 0; i < dataGridView.Columns.Count; i++)
                    dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) =>
            AddUser?.Invoke(this, EventArgs.Empty);

        private void btnEdit_Click(object sender, EventArgs e) =>
            EditUser?.Invoke(this, EventArgs.Empty);
    }
}
