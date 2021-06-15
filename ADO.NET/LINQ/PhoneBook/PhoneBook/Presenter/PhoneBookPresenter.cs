using PhoneBook.Model;
using PhoneBook.View;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PhoneBook.Presenter
{
    public class PhoneBookPresenter
    {
        private IPhoneBookView View { get; set; }
        private IPhoneBookModel Model { get; set; }

        public PhoneBookPresenter(IPhoneBookView view, IPhoneBookModel model)
        {
            View = view;
            Model = model;

            View.AddUser += (e, o) =>
            {
                View.Add = new AddView();
                View.Add.Save += Add_Save;
                View.Add.Cancel += Add_Cancel;
                View.Add.ShowDialog();
            };

            View.EditUser += (e, o) =>
            {
                View.Edit = new EditView();
                View.Edit.tbName.Text = View.GetSelectedUser().Name;
                View.Edit.tbPhone.Text = View.GetSelectedUser().Phone;
                View.Edit.Save += Edit_Save;
                View.Edit.Cancel += Edit_Cancel;
                View.Edit.ShowDialog();
            };
        }

        private void Add_Cancel(object sender, EventArgs e)
        {
            if (MessageBox.Show("You sure?", "Do you want to exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                View.Add.Close();
        }

        private void Add_Save(object sender, EventArgs e)
        {
            if (View.Add.tbName.Text.Length > 0 && View.Add.tbPhone.Text.Length > 0)
            {
                using (var db = new PhoneBookContext())
                {
                    var id = db.Users.Max(u => u.ID);
                    var user = new User()
                    {
                        ID = id + 1,
                        Name = View.Add.tbName.Text,
                        Phone = View.Add.tbPhone.Text
                    };

                    db.Users.Add(user);
                    db.SaveChanges();

                    Model.Users.Add(user);

                    View.DataGridView.Rows.Add();
                    View.DataGridView.Rows[(int)id].Cells["Name"].Value = user.Name;
                    View.DataGridView.Rows[(int)id].Cells["Phone"].Value = user.Phone;
                }

                View.Add.Close();
            }
        }

        private void Edit_Save(object sender, EventArgs e)
        {
            if (View.Edit.tbName.Text.Length > 0 && View.Edit.tbPhone.Text.Length > 0)
            {
                using (var db = new PhoneBookContext())
                {
                    int id = View.DataGridView.SelectedRows[0].Index;
                    User user = db.Users.Find(id);

                    user.Name = View.Edit.tbName.Text;
                    user.Phone = View.Edit.tbPhone.Text;
                    db.SaveChanges();

                    View.DataGridView.Rows[id].Cells["Name"].Value = user.Name;
                    View.DataGridView.Rows[id].Cells["Phone"].Value = user.Phone;
                }

                View.Edit.Close();
            }
        }

        private void Edit_Cancel(object sender, EventArgs e)
        {
            if (MessageBox.Show("You sure?", "Do you want to exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                View.Edit.Close();
        }
    }
}
