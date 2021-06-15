using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace PhoneBook.Model
{
    public class FileLib
    {
        private static string fileName = "Users.dat";

        public static void SaveToFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                using (var db = new PhoneBookContext())
                {
                    var users = from a in db.Users
                                select new
                                {
                                    ID = a.ID,
                                    Name = a.Name,
                                    Phone = a.Phone
                                };

                    List<User> saveUsers = new List<User>();

                    foreach (var user in users)
                        saveUsers.Add(new User() { ID = user.ID, Name = user.Name, Phone = user.Phone });

                    formatter.Serialize(fs, saveUsers);
                }
            }
        }

        public static List<User> ReadFromFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
                return (List<User>)formatter.Deserialize(fs);
        }
    }
}
