using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class AccountManagerForm : Form
    {
        private string connectionString =
            "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=QuanLyNhaHang; Integrated Security=true;";

        public AccountManagerForm()
        {
            InitializeComponent();
            LoadAccountGroups();
            LoadAccounts();
        }

        // 🔹 Nạp danh sách nhóm tài khoản vào combobox
        private void LoadAccountGroups()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT GroupID, GroupName FROM AccountGroup";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboNhomTK.DataSource = dt;
                cboNhomTK.DisplayMember = "GroupName";
                cboNhomTK.ValueMember = "GroupID";
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
                        a.AccountID AS [Mã tài khoản],
                        a.Username AS [Tên đăng nhập],
                        a.FullName AS [Họ tên],
                        g.GroupName AS [Nhóm tài khoản],
                        CASE WHEN a.IsActive = 1 THEN N'Đang hoạt động' ELSE N'Ngừng' END AS [Trạng thái]
                    FROM Account a
                    JOIN AccountGroup g ON a.GroupID = g.GroupID
                    WHERE (1=1)";

                if (cboNhomTK.SelectedIndex >= 0)
                    query += " AND a.GroupID = @GroupID";
                if (chkActive.Checked)
                    query += " AND a.IsActive = 1";

                SqlCommand cmd = new SqlCommand(query, conn);

                if (cboNhomTK.SelectedIndex >= 0)
                    cmd.Parameters.AddWithValue("@GroupID", cboNhomTK.SelectedValue);

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
            f.isEditMode = false; // thêm mới
            f.ShowDialog();
        }


        // 🔹 Nút Sửa
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dgvAccount.CurrentRow != null)
            {
                string username = dgvAccount.CurrentRow.Cells["Tên đăng nhập"].Value.ToString();

                AccountAddUpdateForm f = new AccountAddUpdateForm(this);
                f.isEditMode = true; // chế độ sửa
                f.LoadAccountInfo(username);
                f.ShowDialog();
            }
        }

        private void bntResetMK_Click(object sender, EventArgs e)
        {
            if (dgvAccount.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần reset!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = dgvAccount.CurrentRow.Cells["Tên đăng nhập"].Value.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 🔹 Kiểm tra mật khẩu hiện tại
                string checkQuery = "SELECT Password FROM Account WHERE Username = @Username";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@Username", username);

                object resultPass = checkCmd.ExecuteScalar();

                if (resultPass != null && resultPass.ToString() == "1")
                {
                    MessageBox.Show("Tài khoản này đã được reset mật khẩu trước đó!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 🔹 Hỏi xác nhận reset
                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc muốn reset mật khẩu cho tài khoản '{username}' không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // 🔹 Cập nhật lại mật khẩu về 1
                    string updateQuery = "UPDATE Account SET Password = @Password WHERE Username = @Username";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@Password", "1");
                    updateCmd.Parameters.AddWithValue("@Username", username);
                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Đã reset mật khẩu thành công!\nMật khẩu mới là: 1",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tsmiXoaTK_Click(object sender, EventArgs e)
        {
           
            if (dgvAccount.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = dgvAccount.CurrentRow.Cells["Tên đăng nhập"].Value.ToString();

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa tài khoản '{username}' không?\n(Tất cả vai trò của tài khoản này sẽ bị hủy kích hoạt.)",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE ar
                                    SET ar.IsActive = 0
                                    FROM AccountRole ar
                                    INNER JOIN Account a ON ar.AccountID = a.AccountID
                                    WHERE a.Username = @Username;
                                    ";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    int rows = cmd.ExecuteNonQuery();

                    MessageBox.Show($"Đã xóa tài khoản và hủy kích hoạt {rows} vai trò.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadAccounts();
            }
        }

    }
}


