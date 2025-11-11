using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Lab07_Entity_Framework.Models; // 🔹 Thêm
using System.Data.Entity;           // 🔹 Thêm

namespace Lab07_Entity_Framework
{
    public partial class AccountForm : Form
    {
        private RestaurantContext _context; // 🔹 Dùng Context

        public AccountForm()
        {
            InitializeComponent();
            _context = new RestaurantContext();
            LoadRoleList();
            LoadAccounts();
        }

        // 🔹 Nạp danh sách vai trò (Role) - Dùng EF
        private void LoadRoleList()
        {
            var roles = _context.Roles.ToList();
            roles.Insert(0, new Role { Id = 0, RoleName = "Tất cả" }); // Thêm mục "Tất cả"

            cboNhomTK.DataSource = roles;
            cboNhomTK.DisplayMember = "RoleName";
            cboNhomTK.ValueMember = "ID";
            cboNhomTK.SelectedIndex = 0;

            // Gắn sự kiện (đảm bảo code cũ của bạn đã gỡ sự kiện cũ)
            cboNhomTK.SelectedIndexChanged += (s, e) => LoadAccounts();
            chkActive.CheckedChanged += (s, e) => LoadAccounts();
        }

        // 🔹 Nạp danh sách tài khoản - Dùng EF và AccountViewModel
        public void LoadAccounts()
        {
            var query = _context.RoleAccounts
                                .Include(ra => ra.Account)
                                .Include(ra => ra.Role)
                                .AsQueryable();

            // Lọc theo nhóm (Role)
            if (cboNhomTK.SelectedIndex > 0)
            {
                var roleId = (int)cboNhomTK.SelectedValue;
                query = query.Where(ra => ra.RoleID == roleId);
            }

            // Lọc theo trạng thái
            if (chkActive.Checked)
            {
                query = query.Where(ra => ra.Actived == true);
            }


            // ===== BỔ SUNG TÌM THEO TÊN (YÊU CẦU 1) =====
            // (Bạn phải chắc chắn rằng TextBox tìm kiếm của bạn có tên (Name) là txtTimTheoTen)
            string searchName = txtTimTheoTen.Text.Trim(); // Lấy text từ ô tìm kiếm
            if (!string.IsNullOrEmpty(searchName))
            {
                query = query.Where(ra => ra.Account.AccountName.Contains(searchName)
                                      || ra.Account.FullName.Contains(searchName));
            }
            // =============================================


            // 🔹 Chuyển đổi sang ViewModel
            var data = query.Select(ra => new AccountViewModel
            {
                AccountName = ra.Account.AccountName,
                FullName = ra.Account.FullName,
                Email = ra.Account.Email,
                Tell = ra.Account.Tell,
                DateCreated = ra.Account.DateCreated,
                RoleName = ra.Role.RoleName,
                TrangThai = ra.Actived == true ? "Đang hoạt động" : "Ngừng"
            })
            .ToList();

            dgvAccount.DataSource = data;
            lblTongTK.Text = $"Tổng số tài khoản: {data.Count}";
        }

        // 🔹 Nút Thêm / Cập nhật
        // (Giữ nguyên logic mở Form AccountAddUpdateForm của bạn)
        // Bạn cần đảm bảo Form "AccountAddUpdateForm" cũng phải được refactor
        // để dùng EF khi Thêm/Cập nhật Account và RoleAccount.
        private void btnThem_Click(object sender, EventArgs e)
        {
            AccountAddUpdateForm f = new AccountAddUpdateForm(this);
            f.isEditMode = false;
            f.ShowDialog();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dgvAccount.CurrentRow == null) return;
            string username = dgvAccount.CurrentRow.Cells["colAccountName"].Value.ToString();

            AccountAddUpdateForm f = new AccountAddUpdateForm(this);
            f.isEditMode = true;
            f.LoadAccountInfo(username); // 🔹 Hàm này trong form f cần dùng EF
            f.ShowDialog();
        }

        // 🔹 Nút Reset mật khẩu - Dùng EF
        private void bntResetMK_Click(object sender, EventArgs e)
        {
            if (dgvAccount.SelectedRows.Count == 0) return;

            var selectedUsernames = dgvAccount.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(r => r.Cells["colAccountName"].Value.ToString())
                .Distinct()
                .ToList();

            if (MessageBox.Show($"Reset mật khẩu về '1' cho {selectedUsernames.Count} tài khoản?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            foreach (string username in selectedUsernames)
            {
                var account = _context.Accounts.Find(username);
                if (account != null)
                {
                    account.Password = "1"; // 🔹 Nên mã hóa
                }
            }
            _context.SaveChanges();
            MessageBox.Show("Reset mật khẩu thành công.");
            LoadAccounts();
        }

        // 🔹 Xóa tài khoản (Vô hiệu hóa) - Dùng EF (Theo đúng yêu cầu đề)
        private void tsmiXoaTK_Click(object sender, EventArgs e)
        {
            if (dgvAccount.CurrentRow == null) return;
            string username = dgvAccount.CurrentRow.Cells["colAccountName"].Value.ToString();

            if (MessageBox.Show($"Thực hiện 'Xóa tài khoản' (vô hiệu hóa) cho '{username}'?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            var account = _context.Accounts.Find(username);
            if (account != null)
            {
                // Yêu cầu: Xóa Password, gán về null
                account.Password = null;

                // Yêu cầu: Tài khoản ở trạng thái Inactive
                var userRoles = _context.RoleAccounts.Where(ra => ra.AccountName == username);
                foreach (var roleAccount in userRoles)
                {
                    roleAccount.Actived = false; // Set Inactive
                }

                _context.SaveChanges();
                MessageBox.Show("Đã vô hiệu hóa tài khoản.");
                LoadAccounts();
            }
        }

        // 🔹 Xem danh sách vai trò
        private void tsmiXemDSVT_Click(object sender, EventArgs e)
        {
            if (dgvAccount.CurrentRow == null) return;
            string username = dgvAccount.CurrentRow.Cells["colAccountName"].Value.ToString();

            // Mở form xem vai trò (đã được refactor)
            ViewListRoleForm frm = new ViewListRoleForm(username);
            frm.ShowDialog();

            // Load lại, phòng trường hợp bên form kia có cập nhật
            LoadAccounts();
        }

        // 🔹 Các hàm còn lại (SelectionChanged, MouseDown, Refresh...)
        // Giữ nguyên như code của bạn.

        // 🔹 Nhớ Dispose Context khi đóng Form
        private void AccountForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_context != null)
                _context.Dispose();
        }

    

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if (dgvAccount.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để đổi mật khẩu.");
                return;
            }

            if (dgvAccount.SelectedRows.Count > 1)
            {
                MessageBox.Show("Chỉ có thể đổi mật khẩu cho 1 tài khoản mỗi lần.");
                return;
            }

            // Lấy username từ dòng đang chọn
            string username = dgvAccount.SelectedRows[0].Cells["colAccountName"].Value.ToString();

            // Mở Form popup mới
            ChangePasswordForm changePassForm = new ChangePasswordForm(username);
            changePassForm.ShowDialog();

            // Không cần LoadAccounts() vì mật khẩu đã được ẩn
        }

        private void txtTimTheoTen_TextChanged(object sender, EventArgs e)
        {
            LoadAccounts();
        }
    }
}