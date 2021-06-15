using System.Data;

namespace Users
{
    public class UsersLibrary
    {
        private DataSet UsersLib { get; set; }

        public UsersLibrary()
        {
            UsersLib = new DataSet("UsersLib");
            UsersLib.Tables.Add(new DataTable("Users"));
            CrateColumns();
        }

        public void CrateColumns()
        {
            UsersLib.Tables["Users"].Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Id", typeof(long))
                {
                Caption = "Id",
                ReadOnly = true,
                AllowDBNull = true,
                Unique = true,
                AutoIncrement = true,
                AutoIncrementSeed = 0,
                AutoIncrementStep = 1
                },
                new DataColumn("Login", typeof(string))
                {
                Caption = "Login",
                MaxLength = 30
                },
                new DataColumn("Password", typeof(string))
                {
                Caption = "Password",
                MaxLength = 30
                },
                new DataColumn("Address", typeof(string))
                {
                Caption = "Address",
                MaxLength = 30
                },
                new DataColumn("Phone", typeof(string))
                {
                Caption = "Phone",
                MaxLength = 30
                }
            });
        }

        public void AddUser(User user)
        {
            DataRow userRow = UsersLib.Tables["Users"].NewRow();

            userRow["Login"] = user.Login;
            userRow["Password"] = user.Password;
            userRow["Address"] = user.Address;
            userRow["Phone"] = user.Phone;

            UsersLib.Tables["Users"].Rows.Add(userRow);
        }

        public void ChangeUser(int index, User user)
        {
            UsersLib.Tables["Users"].Rows[index]["Login"] = user.Login;
            UsersLib.Tables["Users"].Rows[index]["Password"] = user.Password;
            UsersLib.Tables["Users"].Rows[index]["Address"] = user.Address;
            UsersLib.Tables["Users"].Rows[index]["Phone"] = user.Phone;
        }

        public void DeleteUser(int index) =>
            UsersLib.Tables["Users"].Rows[index].Delete();
    }
}
