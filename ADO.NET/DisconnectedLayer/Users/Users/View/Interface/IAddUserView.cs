using System;
using System.Windows.Forms;

namespace Users.View
{
    public interface IAddUserView
    {
        event EventHandler AddNewUser;
        event EventHandler CheckLogin;
        event EventHandler CheckPassword;
        event EventHandler Cancel;
        bool LoginExists { get; set; }
        TextBox Login { get; }
        TextBox Password { get; }
        TextBox Address { get; }
        TextBox Phone { get; }
        CheckBox Admin { get; }

        void ShowForm();
        void CloseForm();
        void CancelForm();
        bool CheckAllFields();
        bool CheckPasswordCorrect();
        void LoginAlreadyExists();
        void LoginClear();
        void PasswordBar();
    }
}
