using System.Collections.Generic;

namespace PhoneBook.Model
{
    public class PhoneBookModel : IPhoneBookModel
    {
        public List<User> Users { get; set; }

        public PhoneBookModel()
        {
            Users = new List<User>();
        }
    }
}
