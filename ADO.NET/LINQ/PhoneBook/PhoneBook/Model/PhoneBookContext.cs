using System.Data.Entity;

namespace PhoneBook.Model
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext() : base("PhoneBook") { }

        public DbSet<User> Users { get; set; }
    }
}
