using System.Collections.Generic;

namespace Users.Model
{
    public interface IUsersModel
    {
        List<User> Users { get; set; }
        UsersLibrary UsersLibrary { get; set; }
    }
}
