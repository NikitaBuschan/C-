using System;

namespace PhoneBook.Model
{
    [Serializable]
    public class User
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
