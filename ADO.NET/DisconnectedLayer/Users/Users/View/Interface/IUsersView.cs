using System;
using System.Collections.Generic;

namespace Users.View
{
    public interface IUsersView
    {
        IAddUserView AddUserView { get; set; }
        IEditUserView EditUserView { get; set; }
        List<User> Users { get; set; }
        UsersLibrary UsersLibrary { get; set; }

        event EventHandler DeleteUser;

        User GetSelectedUser();
        int GetSelectedUserIndex();
        void UpdateList();
    }
}
