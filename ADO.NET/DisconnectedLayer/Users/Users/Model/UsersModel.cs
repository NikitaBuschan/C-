using System.Collections.Generic;

namespace Users.Model
{
    public class UsersModel : IUsersModel
    {
        public List<User> Users { get; set; }
        public UsersLibrary UsersLibrary { get; set; }

        public UsersModel()
        {
            Users = new List<User>();
            UsersLibrary = new UsersLibrary();
        }
    }
}
