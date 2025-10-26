using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class AccountManagerForm : Form
    {
        private string connectionString =
            "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";

        public AccountManagerForm()
        {
            InitializeComponent();
            LoadRoleList();
            LoadAccounts();
        }

        // 🔹 Nạp danh sách vai trò (Role)
        private void LoadRoleList()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ID, RoleName FROM Role";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboNhomTK.DataSource = dt;
                cboNhomTK.DisplayMember = "RoleName";
                cboNhomTK.ValueMember = "ID";
                cboNhomTK.SelectedIndex = -1;
            }

            cboNhomTK.SelectedIndexChanged += (s, e) => LoadAccounts();
            chkActive.CheckedChanged += (s, e) => LoadAccounts();
        }

        // 🔹 Nạp danh sách tài khoản
        public void LoadAccounts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
        SELECT 
            a.AccountName,
            a.FullName,
            a.Password,
            a.Email,
            a.Tell,
            a.DateCreated,
            CASE WHEN ra.Actived = 1 THEN N'Đang hoạt động' ELSE N'Ngừng' END AS [TrangThai]
        FROM Account a
        LEFT JOIN RoleAccount ra ON a.AccountName = ra.AccountName
        LEFT JOIN Role r ON ra.RoleID = r.ID
        WHERE (1=1)";

                // 🔹 Lọc theo nhóm (Role)
                if (cboNhomTK.SelectedIndex >= 0)
                    query += " AND r.ID = @RoleID";

                // 🔹 Lọc chỉ hiển thị vai trò đang kích hoạt
                if (chkActive.Checked)
                    query += " AND ra.Actived = 1";

                SqlCommand cmd = new SqlCommand(query, conn);
                if (cboNhomTK.SelectedIndex >= 0)
                    cmd.Parameters.AddWithValue("@RoleID", cboNhomTK.SelectedValue);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvAccount.DataSource = dt;
                lblTongTK.Text = $"Tổng số tài khoản: {dt.Rows.Count}";
            }
        }


        // 🔹 Nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            AccountAddUpdateForm f = new AccountAddUpdateForm(this);
            f.isEditMode = false;
            f.ShowDialog();
        }

        // 🔹 Nút Cập nhật
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dgvAccount.CurrentRow != null)
            {
                string username = dgvAccount.CurrentRow.Cells["colAccountName"].Value.ToString();

                AccountAddUpdateForm f = new AccountAddUpdateForm(this);
                f.isEditMode = true;
                f.LoadAccountInfo(username);
                f.ShowDialog();
            }
        }

        // 🔹 Nút Reset mật khẩu
        private void bntResetMK_Click(object sender, EventArgs e)
        {
            // Kiểm tra có chọn ít nhất 1 dòng không
            if (dgvAccount.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một tài khoản để reset mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gom danh sách tên tài khoản được chọn
            var selectedUsernames = dgvAccount.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(r => r.Cells["colAccountName"].Value.ToString())
                .ToList();

            // Xác nhận người dùng
            string listNames = string.Join(", ", selectedUsernames);
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn reset mật khẩu về '1' cho các tài khoản sau:  {listNames}",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (string username in selectedUsernames)
                {
                    string query = "UPDATE Account SET Password = @Password WHERE AccountName = @Username";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Password", "1");
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.ExecuteNonQuery();
                }
            }

            // Hiển thị danh sách đã reset
            string resetList = string.Join("\n• ", selectedUsernames);
            MessageBox.Show($"Đã reset mật khẩu về '1' cho các tài khoản:\n\n• {resetList}",
                "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cập nhật lại bảng
            LoadAccounts();
        }


        // 🔹 Vô hiệu hóa tài khoản
        private void tsmiXoaTK_Click(object sender, EventArgs e)
        {
            if (dgvAccount.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần vô hiệu hóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = dgvAccount.CurrentRow.Cells["colAccountName"].Value.ToString();

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn vô hiệu hóa toàn bộ vai trò của tài khoản '{username}' không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 🔹 Chỉ cập nhật bảng RoleAccount — đúng yêu cầu đề
                string disableRoles = "UPDATE RoleAccount SET Actived = 0 WHERE AccountName = @Username";
                SqlCommand cmd = new SqlCommand(disableRoles, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Đã vô hiệu hóa toàn bộ vai trò của tài khoản này.", "Thông báo");
            }

            LoadAccounts();
        }


        private void tsmiXemDSVT_Click(object sender, EventArgs e)
        {
            // Kiểm tra có chọn dòng nào chưa
            if (dgvAccount.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xem vai trò!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy tên tài khoản từ cột DataPropertyName = "AccountName"
            string username = dgvAccount.CurrentRow.Cells["colAccountName"].Value.ToString();

            // Mở form xem vai trò
            ViewListRoleForm frm = new ViewListRoleForm(username);
            frm.ShowDialog();
        }

        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            // 🔹 Xóa chọn trong combobox và bỏ tick checkbox
            cboNhomTK.SelectedIndex = -1;
            chkActive.Checked = false;

            // 🔹 Gọi lại hàm load toàn bộ tài khoản
            LoadAccounts();
        }

        private void dgvAccount_SelectionChanged(object sender, EventArgs e)
        {
            bntCapNhat.Enabled = dgvAccount.SelectedRows.Count > 0;

        }

        private void AccountManagerForm_MouseDown(object sender, MouseEventArgs e)
        {
            // Nếu click ra ngoài DataGridView
            if (!dgvAccount.Bounds.Contains(e.Location))
            {
                dgvAccount.ClearSelection();
            }
        }
    }
}
