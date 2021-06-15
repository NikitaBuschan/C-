using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Users.View;

namespace Users
{
    public partial class UsersView : Form, IUsersView
    {
        public IAddUserView AddUserView { get; set; }
        public IEditUserView EditUserView { get; set; }
        public UsersLibrary UsersLibrary { get; set; }
        public List<User> Users { get; set; }

        public event EventHandler DeleteUser;


        public UsersView()
        {
            InitializeComponent();
            AddUserView = new AddUserView();
            EditUserView = new EditUserView();
        }

        private void btnAdd_Click(object sender, EventArgs e) =>
            AddUserView.ShowForm();

        public void UpdateList()
        {
            lbUsers.Items.Clear();
            foreach (var user in Users)
                if (user.Admin == cbAdmin.Checked)
                    lbUsers.Items.Add(user.Login);

            lbUsers.Update();
        }

        public User GetSelectedUser() =>
            Users[lbUsers.SelectedIndex];

        public int GetSelectedUserIndex() =>
            lbUsers.SelectedIndex;

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedIndex != -1 && MessageBox.Show("Are you sure?", "Delete user", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                DeleteUser?.Invoke(this, EventArgs.Empty);
        }

        private void lbUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbUsers.SelectedIndex >= 0 && lbUsers.SelectedIndex < Users.Count)
                EditUserView.ShowForm();
        }

        private void cbAdmin_CheckedChanged(object sender, EventArgs e) =>
            UpdateList();
    }
}
