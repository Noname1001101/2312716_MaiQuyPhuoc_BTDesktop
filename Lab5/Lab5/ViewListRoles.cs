using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab5
{
    public partial class ViewListRoleForm : Form
    {
        private string connectionString =
            "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";

        private string username;

        public ViewListRoleForm(string username)
        {
            InitializeComponent();
            this.username = username;
            lblVaiTroTK.Text = username;
            LoadRoles();
        }

        private void LoadRoles()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        r.ID AS RoleID,
                        r.RoleName,
                        CASE WHEN ra.Actived = 1 THEN 1 ELSE 0 END AS Assigned,
                        r.Notes
                    FROM Role r
                    LEFT JOIN RoleAccount ra 
                        ON r.ID = ra.RoleID AND ra.AccountName = @Username";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvRoles.AutoGenerateColumns = false;
                dgvRoles.DataSource = dt;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (DataGridViewRow row in dgvRoles.Rows)
                {
                    bool assigned = Convert.ToBoolean(row.Cells["colAssigned"].Value);
                    int roleId = Convert.ToInt32(row.Cells["colRoleID"].Value);

                    if (assigned)
                    {
                        // Nếu có check thì thêm hoặc kích hoạt vai trò
                        string insert = @"
                            IF EXISTS (SELECT * FROM RoleAccount WHERE AccountName = @Username AND RoleID = @RoleID)
                                UPDATE RoleAccount SET Actived = 1 WHERE AccountName = @Username AND RoleID = @RoleID
                            ELSE
                                INSERT INTO RoleAccount(AccountName, RoleID, Actived)
                                VALUES(@Username, @RoleID, 1)";
                        SqlCommand cmd = new SqlCommand(insert, conn);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@RoleID", roleId);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // Nếu bỏ check thì xóa vai trò
                        string delete = "DELETE FROM RoleAccount WHERE AccountName = @Username AND RoleID = @RoleID";
                        SqlCommand cmd = new SqlCommand(delete, conn);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@RoleID", roleId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cập nhật vai trò thành công!", "Thông báo");
                LoadRoles();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            // Lấy dòng hiện tại người dùng đang chọn
            DataGridViewRow newRow = dgvRoles.CurrentRow;

            // Kiểm tra nếu đó là dòng trống (dòng tạo mới của DataGridView)
            if (newRow == null || newRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng nhập thông tin vai trò vào dòng trống trước khi thêm!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string roleName = newRow.Cells["colRoleName"].Value?.ToString().Trim();
            string notes = newRow.Cells["colNotes"].Value?.ToString().Trim();

            if (string.IsNullOrEmpty(roleName))
            {
                MessageBox.Show("Tên vai trò không được để trống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Kiểm tra trùng tên vai trò
                string checkQuery = "SELECT COUNT(*) FROM Role WHERE RoleName = @RoleName";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@RoleName", roleName);

                int exists = (int)checkCmd.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("Vai trò đã tồn tại! Vui lòng bấm Update để gán vai trò.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thêm vai trò mới
                string insertQuery = "INSERT INTO Role(RoleName, Notes) VALUES (@RoleName, @Notes)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@RoleName", roleName);
                insertCmd.Parameters.AddWithValue("@Notes", notes);
                insertCmd.ExecuteNonQuery();
            }

            MessageBox.Show("Thêm vai trò mới thành công!", "Thông báo");
            LoadRoles();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
