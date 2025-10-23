using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class CategoryForm : Form
    {
        // 🔹 Khai báo sẵn chuỗi kết nối, tránh lặp đi lặp lại
        private readonly string connectionString =
            "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";

        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            cboLoai.Items.Clear();
            cboLoai.Items.Add("Thức uống"); // index 0
            cboLoai.Items.Add("Đồ ăn");     // index 1
        }

        private void bntLoad_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandText = "SELECT ID, MaMonAn, Name, Type FROM Category";
                sqlConnection.Open();

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    DisplayCategory(reader);
                }
            }
        }

        private void DisplayCategory(SqlDataReader reader)
        {
            lvCategory.Items.Clear();

            while (reader.Read())
            {
                var item = new ListViewItem(reader["MaMonAn"].ToString())
                {
                    Tag = reader["ID"] // ✅ lưu ID thật ở đây
                };

                item.SubItems.Add(reader["Name"].ToString());
                item.SubItems.Add(reader["Type"].ToString());
                lvCategory.Items.Add(item);
            }

            lvCategory.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void bntAdd_Click(object sender, EventArgs e)
        {
            if (cboLoai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại (Thức uống hoặc Đồ ăn).",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtName.Text.Trim();
            int typeValue = cboLoai.SelectedIndex;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm món ăn!");
                return;
            }

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                // 🔹 Lấy ID tiếp theo
                int nextId;
                using (SqlCommand getMaxCmd = new SqlCommand("SELECT ISNULL(MAX(ID), 0) + 1 FROM Category", sqlConnection))
                {
                    nextId = (int)getMaxCmd.ExecuteScalar();
                }

                string newCode = "M" + nextId.ToString("00");

                // 🔹 Dùng tham số để tránh lỗi SQL injection
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "INSERT INTO Category(MaMonAn, Name, [Type]) VALUES (@code, @name, @type)";
                    sqlCommand.Parameters.AddWithValue("@code", newCode);
                    sqlCommand.Parameters.AddWithValue("@name", name);
                    sqlCommand.Parameters.AddWithValue("@type", typeValue);

                    int rows = sqlCommand.ExecuteNonQuery();

                    if (rows == 1)
                    {
                        MessageBox.Show($"Thêm nhóm món ăn thành công (Mã: {newCode})");
                        bntLoad.PerformClick();
                        txtName.Clear();
                        cboLoai.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại");
                    }
                }
            }
        }

        private void bntUpdate_Click(object sender, EventArgs e)
        {
            if (lvCategory.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhóm món ăn cần cập nhật!");
                return;
            }

            if (cboLoai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại (Thức uống hoặc Đồ ăn).",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(lvCategory.SelectedItems[0].Tag);
            int typeValue = cboLoai.SelectedIndex;
            string cleanName = txtName.Text.Replace(" - cập nhật", "").Trim();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandText = "UPDATE Category SET Name = @name, [Type] = @type WHERE ID = @id";
                sqlCommand.Parameters.AddWithValue("@name", cleanName);
                sqlCommand.Parameters.AddWithValue("@type", typeValue);
                sqlCommand.Parameters.AddWithValue("@id", id);

                sqlConnection.Open();
                int rows = sqlCommand.ExecuteNonQuery();

                if (rows == 1)
                {
                    ListViewItem item = lvCategory.SelectedItems[0];
                    item.SubItems[1].Text = cleanName + " - cập nhật";
                    item.SubItems[2].Text = typeValue.ToString();

                    txtMaMonAn.Clear();
                    txtName.Clear();
                    cboLoai.SelectedIndex = -1;

                    bntUpdate.Enabled = bntDelete.Enabled = false;

                    MessageBox.Show("Cập nhật nhóm món ăn thành công!");
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại.");
                }
            }
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {
            if (lvCategory.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhóm món ăn cần xóa!");
                return;
            }

            int id = Convert.ToInt32(lvCategory.SelectedItems[0].Tag);
            string name = lvCategory.SelectedItems[0].SubItems[1].Text;

            // 🔹 Hiện thông báo xác nhận
            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa nhóm món ăn '{name}' và toàn bộ các món thuộc nhóm này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.No)
                return; // Người dùng chọn "Không", dừng lại

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                // 🔹 Bắt đầu transaction để đảm bảo an toàn
                SqlTransaction transaction = sqlConnection.BeginTransaction();

                try
                {
                    // 1️ Xóa toàn bộ món ăn trong nhóm trước
                    SqlCommand deleteFoodCmd = new SqlCommand("DELETE FROM Food WHERE FoodCategoryID = @id", sqlConnection, transaction);
                    deleteFoodCmd.Parameters.AddWithValue("@id", id);
                    deleteFoodCmd.ExecuteNonQuery();

                    // 2️ Sau đó xóa nhóm món ăn
                    SqlCommand deleteCategoryCmd = new SqlCommand("DELETE FROM Category WHERE ID = @id", sqlConnection, transaction);
                    deleteCategoryCmd.Parameters.AddWithValue("@id", id);
                    int numOfRowDeleted = deleteCategoryCmd.ExecuteNonQuery();

                    transaction.Commit();

                    if (numOfRowDeleted == 1)
                    {
                        MessageBox.Show($"Đã xóa nhóm '{name}' và các món ăn thuộc nhóm thành công!");
                        bntLoad.PerformClick();
                        txtMaMonAn.Clear();
                        txtName.Clear();
                        cboLoai.SelectedIndex = -1;
                        bntUpdate.Enabled = false;
                        bntDelete.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhóm món ăn để xóa!");
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Đã xảy ra lỗi khi xóa: " + ex.Message);
                }
            }
        }


        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (lvCategory.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhóm món ăn để xóa các món thuộc nhóm đó!");
                return;
            }

            int categoryId = Convert.ToInt32(lvCategory.SelectedItems[0].Tag);
            string categoryName = lvCategory.SelectedItems[0].SubItems[1].Text;

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa tất cả món ăn trong nhóm '{categoryName}' không?\n(Nhóm món ăn vẫn được giữ lại)",
                "Xác nhận xóa món ăn trong nhóm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "DELETE FROM Food WHERE FoodCategoryID = @catId";
                    sqlCommand.Parameters.AddWithValue("@catId", categoryId);

                    sqlConnection.Open();
                    int rowsDeleted = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    MessageBox.Show(
                        $"Đã xóa {rowsDeleted} món ăn thuộc nhóm '{categoryName}'.",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        }


        private void tsmViewFood_Click(object sender, EventArgs e)
        {
            if (lvCategory.SelectedItems.Count == 0) return;

            int id = Convert.ToInt32(lvCategory.SelectedItems[0].Tag);
            FoodForm foodForm = new FoodForm();
            foodForm.Show(this);
            foodForm.LoadFood(id);
        }
    }
}
