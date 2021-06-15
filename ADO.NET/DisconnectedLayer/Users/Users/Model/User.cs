
namespace Users
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool Admin { get; set; }

        public User(string login, string password, string address, string phone, bool admin)
        {
            Login = login;
            Password = password;
            Address = address;
            Phone = phone;
            Admin = admin;
        }
    }
}
