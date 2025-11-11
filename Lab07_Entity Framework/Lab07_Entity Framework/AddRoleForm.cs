using System;
using System.Linq;
using System.Windows.Forms;
using Lab07_Entity_Framework.Models;

namespace Lab07_Entity_Framework
{
    public partial class AddRoleForm : Form
    {
        private RestaurantContext _context;

        public AddRoleForm()
        {
            InitializeComponent();
            _context = new RestaurantContext();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string roleName = txtRoleName.Text.Trim();

            // 1. Kiểm tra (Validate)
            if (string.IsNullOrWhiteSpace(roleName))
            {
                MessageBox.Show("Tên vai trò không được để trống.");
                return;
            }

            if (_context.Roles.Any(r => r.RoleName == roleName))
            {
                MessageBox.Show("Tên vai trò này đã tồn tại.");
                return;
            }

            // 2. Tạo Entity Role mới
            var newRole = new Role
            {
                RoleName = roleName,
                Notes = txtNotes.Text.Trim()
            };

            // 3. Lưu vào CSDL
            _context.Roles.Add(newRole);
            _context.SaveChanges();

            MessageBox.Show("Thêm vai trò mới thành công.");

            // 4. Báo cho Form cha (ViewListRoleForm) biết là đã LƯU OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 5. Nhớ Dispose context
        private void AddRoleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Dispose();
        }
    }
}