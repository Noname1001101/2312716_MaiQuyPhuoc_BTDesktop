// ChangePasswordForm.cs
using Lab07_Entity_Framework.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Lab07_Entity_Framework
{
    public partial class ChangePasswordForm : Form
    {
        private RestaurantContext _context;
        private string _username;

        public ChangePasswordForm(string username)
        {
            InitializeComponent();
            _context = new RestaurantContext();
            _username = username;
            txtUserName.Text = username;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.");
                return;
            }

            var account = _context.Accounts.Find(_username);
            if (account != null)
            {
                // Bạn nên mã hóa (hash) mật khẩu này
                account.Password = txtNewPassword.Text;
                _context.SaveChanges();

                MessageBox.Show("Đổi mật khẩu thành công.");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Nhớ Dispose context
        private void ChangePasswordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Dispose();
        }
    }
}