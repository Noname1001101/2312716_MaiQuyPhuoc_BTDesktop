using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
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
            lblVaiTroTK.Text = $"{username}";
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
                    CASE 
                        WHEN ra.Actived = 1 THEN N'Đang hoạt động'
                        ELSE N'Ngừng'
                    END AS Actived,
                    ra.Notes
                FROM RoleAccount ra
                INNER JOIN Role r ON ra.RoleID = r.ID
                INNER JOIN Account a ON ra.AccountName = a.AccountName
                WHERE a.AccountName = @Username";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvRoles.AutoGenerateColumns = false; // chỉ dùng cột bạn đã tạo sẵn trong Designer
                dgvRoles.DataSource = dt;
            }
        }

    }
}
