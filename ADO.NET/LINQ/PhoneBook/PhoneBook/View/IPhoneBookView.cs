using PhoneBook.Model;
using System;
using System.Windows.Forms;

namespace PhoneBook.View
{
    public interface IPhoneBookView
    {
        event EventHandler AddUser;
        event EventHandler EditUser;
        AddView Add { get; set; }
        EditView Edit { get; set; }
        DataGridView DataGridView { get; set; }

        User GetSelectedUser();
    }
}
