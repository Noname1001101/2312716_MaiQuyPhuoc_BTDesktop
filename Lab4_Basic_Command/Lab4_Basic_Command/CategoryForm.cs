using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class CategoryForm : Form
    {
        private readonly string connectionString =
            "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";

        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            cboLoai.Items.Clear();
            cboLoai.Items.Add("Thức uống");
            cboLoai.Items.Add("Đồ ăn");
        }

        private void lvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCategory.SelectedItems.Count == 0)
                return;

            ListViewItem item = lvCategory.SelectedItems[0];

            // Gán dữ liệu lên các ô textbox và combobox
            txtMaMonAn.Text = item.SubItems[0].Text;  // hiển thị ID
            txtName.Text = item.SubItems[1].Text;
            int typeValue = int.Parse(item.SubItems[2].Text);
            cboLoai.SelectedIndex = typeValue;

            bntUpdate.Enabled = true;
            bntDelete.Enabled = true;
        }

        private void bntLoad_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandText = "SELECT ID, Name, Type FROM Category";
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
                var item = new ListViewItem(reader["ID"].ToString())
                {
                    Tag = reader["ID"]
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

                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "INSERT INTO Category(Name, [Type]) VALUES (@name, @type)";
                    sqlCommand.Parameters.AddWithValue("@name", name);
                    sqlCommand.Parameters.AddWithValue("@type", typeValue);

                    int rows = sqlCommand.ExecuteNonQuery();

                    if (rows == 1)
                    {
                        MessageBox.Show("Thêm nhóm món ăn thành công!");
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
                MessageBox.Show("Vui lòng chọn ít nhất một nhóm món ăn cần xóa!");
                return;
            }

            string deletedNames = "";

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa {lvCategory.SelectedItems.Count} nhóm món ăn đã chọn cùng toàn bộ món thuộc các nhóm đó không?",
                "Xác nhận xóa nhiều nhóm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.No)
                return;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction transaction = sqlConnection.BeginTransaction();

                try
                {
                    foreach (ListViewItem item in lvCategory.SelectedItems)
                    {
                        int id = Convert.ToInt32(item.Tag);
                        string name = item.SubItems[1].Text;
                        deletedNames += $"- {name}\n";

                        SqlCommand deleteFoodCmd = new SqlCommand(
                            "DELETE FROM Food WHERE FoodCategoryID = @id",
                            sqlConnection, transaction
                        );
                        deleteFoodCmd.Parameters.AddWithValue("@id", id);
                        deleteFoodCmd.ExecuteNonQuery();

                        SqlCommand deleteCategoryCmd = new SqlCommand(
                            "DELETE FROM Category WHERE ID = @id",
                            sqlConnection, transaction
                        );
                        deleteCategoryCmd.Parameters.AddWithValue("@id", id);
                        deleteCategoryCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    bntLoad.PerformClick();

                    txtMaMonAn.Clear();
                    txtName.Clear();
                    cboLoai.SelectedIndex = -1;

                    bntUpdate.Enabled = false;
                    bntDelete.Enabled = false;

                    MessageBox.Show(
                        $"Đã xóa thành công {lvCategory.SelectedItems.Count} nhóm món ăn:\n\n{deletedNames}",
                        "Đã xóa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
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

        private void CategoryForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (!lvCategory.Bounds.Contains(e.Location))
            {
                lvCategory.SelectedItems.Clear();
                txtMaMonAn.Clear();
                txtName.Clear();
                cboLoai.SelectedIndex = -1;
                bntUpdate.Enabled = false;
                bntDelete.Enabled = false;
            }
        }
    }
}

