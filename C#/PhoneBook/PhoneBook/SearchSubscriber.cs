using System.Collections.Generic;
using System.Linq;

namespace PhoneBook
{
    class SearchSubscriber
    {
        public static Subscriber ByName(List<Subscriber> subscribers, string name)
        {
            foreach (var item in subscribers.Where(item => item.Name == name))
                return item;
            return null;
        }
        public static Subscriber BySurname(List<Subscriber> subscribers, string surname)
        {
            foreach (var item in subscribers.Where(item => item.Surname == surname))
                return item;
            return null;
        }
        public static Subscriber ByPhone(List<Subscriber> subscribers, string phone)
        {
            foreach (var item in subscribers.Where(item => item.Phone == phone))
                return item;
            return null;
        }
        public static Subscriber ByEmail(List<Subscriber> subscribers, string email)
        {
            foreach (var item in subscribers.Where(item => item.Email == email))
                return item;
            return null;
        }
    }
}