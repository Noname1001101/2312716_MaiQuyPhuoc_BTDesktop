using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class AccountAddUpdateForm : Form
    {
        private string connectionString =
            "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";

        private AccountManagerForm parentForm;
        public bool isEditMode = false;
        private string editingUsername = "";

        public AccountAddUpdateForm(AccountManagerForm parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void AccountAddUpdateForm_Load(object sender, EventArgs e)
        {
            // 🔹 Nạp danh sách vai trò
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ID, RoleName FROM Role";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboNhom.DataSource = dt;
                cboNhom.DisplayMember = "RoleName";
                cboNhom.ValueMember = "ID";
            }

            if (isEditMode)
            {
                this.Text = "Cập nhật tài khoản";
                txtTenDN.Enabled = false;
            }
            else
            {
                this.Text = "Thêm tài khoản mới";
                txtTenDN.Enabled = true;
            }
        }

        public void LoadAccountInfo(string username)
        {
            editingUsername = username;

            // Bước 1: đảm bảo ComboBox đã load dữ liệu Role
            if (cboNhom.DataSource == null)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string roleQuery = "SELECT ID, RoleName FROM Role";
                    SqlDataAdapter da = new SqlDataAdapter(roleQuery, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cboNhom.DataSource = dt;
                    cboNhom.DisplayMember = "RoleName";
                    cboNhom.ValueMember = "ID";
                }
            }

            // Bước 2: Load thông tin tài khoản và vai trò
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT TOP 1
                a.AccountName,
                a.Password,
                a.FullName,
                ra.RoleID,
                ra.Actived AS RoleActive
            FROM Account a
            LEFT JOIN RoleAccount ra ON a.AccountName = ra.AccountName
            WHERE a.AccountName = @Username";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtTenDN.Text = reader["AccountName"].ToString();
                    txtMK.Text = reader["Password"].ToString();
                    txtHoTen.Text = reader["FullName"].ToString();

                    if (reader["RoleID"] != DBNull.Value)
                        cboNhom.SelectedValue = (int)reader["RoleID"];
                    else
                        cboNhom.SelectedIndex = -1;

                    chkActive.Checked = reader["RoleActive"] != DBNull.Value &&
                                        Convert.ToBoolean(reader["RoleActive"]);
                }
                else
                {
                    chkActive.Checked = false;
                }
            }
        }



        private bool AccountExists(SqlConnection conn, string username)
        {
            string query = "SELECT COUNT(*) FROM Account WHERE AccountName = @AccountName";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@AccountName", username);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private void InsertAccount(SqlConnection conn, string username, string password, string fullname)
        {
            string query = @"INSERT INTO Account(AccountName, Password, FullName, Email, Tell, DateCreated)
                     VALUES(@AccountName, @Password, @FullName, NULL, NULL, GETDATE())";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@AccountName", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@FullName", fullname);
                cmd.ExecuteNonQuery();
            }
        }

        private void UpdateAccount(SqlConnection conn, string username, string password, string fullname)
        {
            string query = @"UPDATE Account 
                     SET Password = @Password, FullName = @FullName 
                     WHERE AccountName = @AccountName";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@AccountName", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@FullName", fullname);
                cmd.ExecuteNonQuery();
            }
        }

        private bool RoleAssigned(SqlConnection conn, string username, int roleId)
        {
            string query = "SELECT COUNT(*) FROM RoleAccount WHERE AccountName = @AccountName AND RoleID = @RoleID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@AccountName", username);
                cmd.Parameters.AddWithValue("@RoleID", roleId);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private void InsertRole(SqlConnection conn, string username, int roleId, bool active)
        {
            string query = @"INSERT INTO RoleAccount(RoleID, AccountName, Actived)
                     VALUES(@RoleID, @AccountName, @Actived)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@RoleID", roleId);
                cmd.Parameters.AddWithValue("@AccountName", username);
                cmd.Parameters.AddWithValue("@Actived", active ? 1 : 0);
                cmd.ExecuteNonQuery();
            }
        }

        private void UpdateRole(SqlConnection conn, string username, int roleId, bool active)
        {
            string query = @"UPDATE RoleAccount 
                     SET Actived = @Actived 
                     WHERE AccountName = @AccountName AND RoleID = @RoleID";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@AccountName", username);
                cmd.Parameters.AddWithValue("@RoleID", roleId);
                cmd.Parameters.AddWithValue("@Actived", active ? 1 : 0);
                cmd.ExecuteNonQuery();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1️⃣ Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtTenDN.Text) ||
                string.IsNullOrWhiteSpace(txtMK.Text) ||
                string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string username = isEditMode ? editingUsername : txtTenDN.Text.Trim();
                string password = txtMK.Text.Trim();
                string fullname = txtHoTen.Text.Trim();
                int roleId = Convert.ToInt32(cboNhom.SelectedValue);
                bool isActive = chkActive.Checked;

                // 2️⃣ Nếu tài khoản chưa có → thêm mới
                if (!AccountExists(conn, username))
                    InsertAccount(conn, username, password, fullname);
                else if (isEditMode)
                    UpdateAccount(conn, username, password, fullname);

                // 3️⃣ Gán vai trò (role)
                if (!RoleAssigned(conn, username, roleId))
                    InsertRole(conn, username, roleId, isActive);
                else
                    UpdateRole(conn, username, roleId, isActive);

                // 4️⃣ Thông báo và reload
                MessageBox.Show("Lưu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                parentForm.LoadAccounts();
                this.Close();
            }
        }


        // Hàm liền mạch
        //private void btnLuu_Click(object sender, EventArgs e)
        //{
        //    // 1️⃣ Kiểm tra dữ liệu đầu vào
        //    if (string.IsNullOrWhiteSpace(txtTenDN.Text) ||
        //        string.IsNullOrWhiteSpace(txtMK.Text) ||
        //        string.IsNullOrWhiteSpace(txtHoTen.Text))
        //    {
        //        MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    string username = isEditMode ? editingUsername : txtTenDN.Text;
        //    string fullname = txtHoTen.Text;
        //    string password = txtMK.Text;
        //    int roleId = Convert.ToInt32(cboNhom.SelectedValue);
        //    bool isActive = chkActive.Checked;

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        // 2️⃣ Kiểm tra tài khoản
        //        bool accountExists = false;
        //        using (SqlCommand cmd = new SqlCommand(
        //            "SELECT COUNT(*) FROM Account WHERE AccountName=@u", conn))
        //        {
        //            cmd.Parameters.AddWithValue("@u", username);
        //            accountExists = (int)cmd.ExecuteScalar() > 0;
        //        }

        //        // 3️⃣ Thêm mới hoặc cập nhật thông tin tài khoản
        //        string sqlAccount = accountExists
        //            ? "UPDATE Account SET Password=@p, FullName=@f WHERE AccountName=@u"
        //            : "INSERT INTO Account(AccountName, Password, FullName, Email, Tell, DateCreated) VALUES(@u, @p, @f, NULL, NULL, GETDATE())";

        //        using (SqlCommand cmd = new SqlCommand(sqlAccount, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@u", username);
        //            cmd.Parameters.AddWithValue("@p", password);
        //            cmd.Parameters.AddWithValue("@f", fullname);
        //            cmd.ExecuteNonQuery();
        //        }

        //        // 4️⃣ Kiểm tra vai trò
        //        bool roleExists = false;
        //        using (SqlCommand cmd = new SqlCommand(
        //            "SELECT COUNT(*) FROM RoleAccount WHERE AccountName=@u AND RoleID=@r", conn))
        //        {
        //            cmd.Parameters.AddWithValue("@u", username);
        //            cmd.Parameters.AddWithValue("@r", roleId);
        //            roleExists = (int)cmd.ExecuteScalar() > 0;
        //        }

        //        // 5️⃣ Thêm mới hoặc cập nhật vai trò
        //        string sqlRole = roleExists
        //            ? "UPDATE RoleAccount SET Actived=@a WHERE AccountName=@u AND RoleID=@r"
        //            : "INSERT INTO RoleAccount(RoleID, AccountName, Actived) VALUES(@r, @u, @a)";

        //        using (SqlCommand cmd = new SqlCommand(sqlRole, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@u", username);
        //            cmd.Parameters.AddWithValue("@r", roleId);
        //            cmd.Parameters.AddWithValue("@a", isActive ? 1 : 0);
        //            cmd.ExecuteNonQuery();
        //        }

        //        // 6️⃣ Thông báo và làm mới danh sách
        //        MessageBox.Show("Lưu thành công!", "Thông báo",
        //            MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        parentForm.LoadAccounts();
        //        this.Close();
        //    }
        //}



    }
}

