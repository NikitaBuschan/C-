using Users.Model;
using Users.View;

namespace Users.Presenter
{
    public class UsersPresenter
    {
        private IUsersModel Model { get; set; }
        private IUsersView View { get; set; }

        public UsersPresenter(IUsersModel model, IUsersView view)
        {
            Model = model;
            View = view;

            View.Users = Model.Users;
            View.UsersLibrary = Model.UsersLibrary;

            SubscribeOnAddEvents();
            SubscribeOnEditEvents();

            View.DeleteUser += (o, e) =>
            {
                Model.Users.Remove(View.GetSelectedUser());
                Model.UsersLibrary.DeleteUser(View.GetSelectedUserIndex());
                View.Users = Model.Users;
                View.UsersLibrary = Model.UsersLibrary;
                View.UpdateList();
            };
        }

        public void SubscribeOnAddEvents()
        {
            View.AddUserView.AddNewUser += (o, e) =>
            {
                if (View.AddUserView.CheckAllFields() == false)
                    return;

                if (View.AddUserView.LoginExists == false && View.AddUserView.CheckPasswordCorrect())
                {
                    Model.Users.Add(new User(View.AddUserView.Login.Text, 
                        View.AddUserView.Password.Text, 
                        View.AddUserView.Address.Text, 
                        View.AddUserView.Phone.Text,
                        View.AddUserView.Admin.Checked));
                    Model.UsersLibrary.AddUser(Model.Users[Model.Users.Count - 1]);
                    View.Users = Model.Users;
                    View.UsersLibrary = Model.UsersLibrary;
                    View.UpdateList();
                    View.AddUserView.CloseForm();
                    View.AddUserView.CancelForm();
                }
            };

            View.AddUserView.CheckLogin += (o, e) =>
            {
                foreach (var user in Model.Users)
                    if (user.Login == View.AddUserView.Login.Text)
                    {
                        View.AddUserView.LoginAlreadyExists();
                        return;
                    }

                if (View.AddUserView.LoginExists == true)
                {
                    View.AddUserView.LoginClear();
                }
            };

            View.AddUserView.CheckPassword += (o, e) =>
                View.AddUserView.PasswordBar();

            View.AddUserView.Cancel += (o, e) =>
            {
                View.AddUserView = new AddUserView();
                SubscribeOnAddEvents();
            };
        }

        public void SubscribeOnEditEvents()
        {
            View.EditUserView.FillFields += (o, e) =>
            {
                User user = View.GetSelectedUser();
                View.EditUserView.Login.Text = user.Login;
                View.EditUserView.Password.Text = user.Password;
                View.EditUserView.ConfirmPassword.Text = user.Password;
                View.EditUserView.Address.Text = user.Address;
                View.EditUserView.Phone.Text = user.Phone;
                View.EditUserView.Admin.Checked = user.Admin;
            };

            View.EditUserView.SaveUser += (o, e) =>
            {
                Model.Users[View.GetSelectedUserIndex()] = new User(
                    View.EditUserView.Login.Text,
                    View.EditUserView.Password.Text,
                    View.EditUserView.Address.Text,
                    View.EditUserView.Phone.Text,
                    View.EditUserView.Admin.Checked);
                Model.UsersLibrary.ChangeUser(View.GetSelectedUserIndex(), View.Users[View.GetSelectedUserIndex()]);
                View.Users = Model.Users;
                View.UsersLibrary = Model.UsersLibrary;
                View.UpdateList();
                View.EditUserView.CloseForm();
                View.EditUserView.CancelForm();
            };

            View.EditUserView.CheckLogin += (o, e) =>
            {
                foreach (var user in Model.Users)
                    if (user.Login == View.EditUserView.Login.Text && 
                    user.Login != View.GetSelectedUser().Login)
                    {
                        View.EditUserView.LoginAlreadyExists();
                        return;
                    }

                if (View.EditUserView.LoginExists == true)
                {
                    View.EditUserView.LoginClear();
                }
            };

            View.EditUserView.CheckPassword += (o, e) =>
                View.EditUserView.PasswordBar();

            View.EditUserView.Cancel += (o, e) =>
            {
                View.EditUserView = new EditUserView();
                SubscribeOnEditEvents();
            };
        }
    }
}
