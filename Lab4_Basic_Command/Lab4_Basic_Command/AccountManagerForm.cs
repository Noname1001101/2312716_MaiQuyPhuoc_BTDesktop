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
            LoadAccountGroups();   // nạp dữ liệu nhóm tài khoản vào combobox
            LoadAccounts();         // nạp danh sách tài khoản
        }

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
                cboNhomTK.SelectedIndex = -1; // ban đầu chưa chọn nhóm
            }

            // Gắn sự kiện để mỗi lần chọn thay đổi sẽ reload danh sách
            cboNhomTK.SelectedIndexChanged += (s, e) => LoadAccounts();
            chkActive.CheckedChanged += (s, e) => LoadAccounts();
        }

        private void LoadAccounts()
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

                // lọc theo nhóm nếu có chọn
                if (cboNhomTK.SelectedIndex >= 0)
                    query += " AND a.GroupID = @GroupID";

                // lọc theo trạng thái nếu có tick Active
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
    }
}
