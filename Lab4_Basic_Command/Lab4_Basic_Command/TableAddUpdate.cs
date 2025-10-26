using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class TableAddUpdate : Form
    {
        private readonly string connectionString =
            "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";

        private MainForm parentForm;
        private int? tableId = null;
        public bool isEditMode = false;

        public TableAddUpdate(MainForm parent, int? id = null)
        {
            InitializeComponent();
            parentForm = parent;
            tableId = id;
        }

        private void TableAddUpdate_Load(object sender, EventArgs e)
        {
            cbStatus.SelectedIndex = 0; // Mặc định “Trống”

            if (isEditMode && tableId != null)
            {
                this.Text = "Cập nhật bàn";
                LoadTableInfo((int)tableId);
            }
            else
            {
                this.Text = "Thêm bàn mới";
            }
        }

        private void LoadTableInfo(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM [Table] WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtName.Text = reader["Name"].ToString();
                    cbStatus.SelectedIndex = Convert.ToInt32(reader["Status"]);
                    numCapacity.Value = Convert.ToInt32(reader["Capacity"]);
                }
                conn.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            int status = cbStatus.SelectedIndex;
            int capacity = (int)numCapacity.Value;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên bàn.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 🔍 Kiểm tra trùng tên (trừ chính bàn đang sửa)
                string checkQuery = isEditMode
                    ? "SELECT COUNT(*) FROM [Table] WHERE Name = @name AND ID <> @id"
                    : "SELECT COUNT(*) FROM [Table] WHERE Name = @name";

                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@name", name);
                if (isEditMode)
                    checkCmd.Parameters.AddWithValue("@id", tableId);

                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Tên bàn này đã tồn tại. Vui lòng nhập tên khác!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ✅ Nếu không trùng, mới thực thi lệnh thêm/sửa
                string query = !isEditMode
                    ? "INSERT INTO [Table](Name, Status, Capacity) VALUES (@name, @status, @capacity)"
                    : "UPDATE [Table] SET Name=@name, Status=@status, Capacity=@capacity WHERE ID=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@capacity", capacity);
                if (isEditMode)
                    cmd.Parameters.AddWithValue("@id", tableId);

                cmd.ExecuteNonQuery();
                conn.Close();
            }

            MessageBox.Show("Lưu thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            parentForm.LoadTableList();
            this.Close();
        }


       
    }
}
