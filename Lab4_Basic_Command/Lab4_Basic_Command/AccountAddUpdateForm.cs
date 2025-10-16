using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class AccountAddUpdateForm : Form
    {
        private string connectionString =
            "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=QuanLyNhaHang; Integrated Security=true;";

        private AccountManagerForm parentForm;
        public bool IsAddedOrUpdated = false; // báo lại cho form cha

        public bool isEditMode = false; // false = thêm mới, true = cập nhật
        private string editingUsername = ""; // dùng khi cập nhật

        public AccountAddUpdateForm(AccountManagerForm parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void AccountAddUpdateForm_Load(object sender, EventArgs e)
        {
            // Load danh sách nhóm
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT GroupID, GroupName FROM AccountGroup";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboNhom.DataSource = dt;
                cboNhom.DisplayMember = "GroupName";
                cboNhom.ValueMember = "GroupID";
            }

            if (isEditMode)
            {
                this.Text = "Cập nhật tài khoản"; // thay tiêu đề form
                txtTenDN.Enabled = false; // không cho sửa username
            }
            else
            {
                this.Text = "Thêm tài khoản mới";
                txtTenDN.Enabled = true;
            }
        }

        // Hàm load thông tin tài khoản khi cập nhật
        public void LoadAccountInfo(string username)
        {
            editingUsername = username;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Account WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtTenDN.Text = reader["Username"].ToString();
                    txtMK.Text = reader["Password"].ToString();
                    txtHoTen.Text = reader["FullName"].ToString();
                    cboNhom.SelectedValue = reader["GroupID"];
                    chkActive.Checked = (bool)reader["IsActive"];
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenDN.Text == "" || txtMK.Text == "" || txtHoTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                isEditMode ? "Bạn có chắc muốn cập nhật tài khoản này không?" :
                             "Bạn có chắc muốn thêm tài khoản này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd;

                if (!isEditMode)
                {
                    // 🟢 Thêm mới
                    string query = @"INSERT INTO Account(Username, Password, FullName, GroupID, IsActive, CreatedDate)
                                     VALUES(@Username, @Password, @FullName, @GroupID, @IsActive, GETDATE())";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", txtTenDN.Text);
                }
                else
                {
                    // 🟠 Cập nhật
                    string query = @"UPDATE Account 
                                     SET Password=@Password, FullName=@FullName, GroupID=@GroupID, IsActive=@IsActive
                                     WHERE Username=@Username";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", editingUsername);
                }

                cmd.Parameters.AddWithValue("@Password", txtMK.Text);
                cmd.Parameters.AddWithValue("@FullName", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@GroupID", cboNhom.SelectedValue);
                cmd.Parameters.AddWithValue("@IsActive", chkActive.Checked ? 1 : 0);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show(isEditMode ? "Cập nhật thành công!" : "Thêm tài khoản thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    IsAddedOrUpdated = true;
                    parentForm.LoadAccounts(); // cập nhật lại danh sách

                    if (!isEditMode)
                    {
                        // 🧹 Nếu là thêm mới → xóa trắng form để nhập người tiếp theo
                        txtTenDN.Clear();
                        txtMK.Clear();
                        txtHoTen.Clear();
                        cboNhom.SelectedIndex = 0;
                        chkActive.Checked = false;
                        txtTenDN.Focus();
                    }

                    else
                    {
                        // 🟡 Nếu là cập nhật → chỉ load lại thông tin vừa sửa
                        LoadAccountInfo(editingUsername);
                    }
                }
            }
        }
    }
}
