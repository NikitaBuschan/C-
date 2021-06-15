using System;
using System.Windows.Forms;

namespace Users.View
{
    public interface IEditUserView
    {
        event EventHandler FillFields;
        event EventHandler SaveUser;
        event EventHandler CheckLogin;
        event EventHandler CheckPassword;
        event EventHandler Cancel;
        bool LoginExists { get; set; }
        TextBox Login { get; }
        TextBox Password { get; }
        TextBox ConfirmPassword { get; }
        TextBox Address { get; }
        TextBox Phone { get; }
        CheckBox Admin { get; }

        void ShowForm();
        void CloseForm();
        void CancelForm();
        bool CheckAllFields();
        void LoginAlreadyExists();
        void LoginClear();
        void PasswordBar();
    }
}
