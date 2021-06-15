using System;
using System.Windows.Forms;
using Users.View;

namespace Users
{
    public partial class EditUserView : Form, IEditUserView
    {
        public event EventHandler FillFields;
        public event EventHandler SaveUser;
        public event EventHandler CheckLogin;
        public event EventHandler CheckPassword;
        public event EventHandler Cancel;
        public bool LoginExists { get; set; }
        public TextBox Login { get; private set; }
        public TextBox Password { get; private set; }
        public TextBox ConfirmPassword { get; private set; }
        public TextBox Address { get; private set; }
        public TextBox Phone { get; private set; }
        public CheckBox Admin { get; private set; }

        public EditUserView()
        {
            InitializeComponent();
            pbPassword.Maximum = 10;
            Login = txtLogin;
            Password = txtPassword;
            ConfirmPassword = txtConfirmPassword;
            Address = txtAddress;
            Phone = txtPhone;
            Admin = cbAdmin;

            this.FormClosing += (o, e) =>
               CancelForm();
        }

        public void ShowForm() =>
            this.Show();

        public void CloseForm() =>
            this.Close();

        public void CancelForm() =>
            Cancel?.Invoke(this, EventArgs.Empty);

        private void EditUserView_Load(object sender, EventArgs e) =>
            FillFields?.Invoke(this, EventArgs.Empty);

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Save user", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                SaveUser?.Invoke(this, EventArgs.Empty);
        }

        public bool CheckAllFields()
        {
            if (txtLogin.Text.Length > 0 &&
                txtPassword.Text.Length > 0 &&
                txtConfirmPassword.Text.Length > 0 &&
                txtAddress.Text.Length > 0 &&
                txtPhone.Text.Length > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Fill in all the fields", "Error filling fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void txtLogin_TextChanged(object sender, EventArgs e) =>
            CheckLogin?.Invoke(this, EventArgs.Empty);

        public void LoginAlreadyExists()
        {
            LoginExists = true;
            lblLoginCheck.Text = "Login already exists";
        }

        public void LoginClear()
        {
            LoginExists = false;
            lblLoginCheck.Text = string.Empty;
        }

        public void PasswordBar()
        {
            if (txtPassword.Text.Length <= 10)
                pbPassword.Value = txtPassword.Text.Length;
        }

        public bool CheckPasswordCorrect()
        {
            if (txtPassword?.Text == txtConfirmPassword?.Text)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Wrong confirm passwod", "Wrong confirm password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e) =>
            CheckPassword?.Invoke(this, EventArgs.Empty);

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Close form", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cancel?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }
    }
}
