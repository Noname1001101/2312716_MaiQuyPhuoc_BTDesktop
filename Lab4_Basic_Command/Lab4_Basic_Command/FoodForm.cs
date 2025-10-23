using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class FoodForm : Form
    {
        // ✅ Đổi tên database thành RestaurantManagement
        private string connectionString = "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";

        public FoodForm()
        {
            InitializeComponent();
        }

        public void LoadFood(int categoryID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                // ✅ Lấy tên nhóm món ăn (Category)
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT Name FROM Category WHERE ID = @catID";
                sqlCommand.Parameters.AddWithValue("@catID", categoryID);

                object result = sqlCommand.ExecuteScalar();
                string catName = (result != null) ? result.ToString() : "Không xác định";

                this.Text = "Danh sách các món ăn thuộc nhóm: " + catName;

                // ✅ Lấy danh sách món ăn trong nhóm
                sqlCommand.CommandText = "SELECT ID, Name, Unit, FoodCategoryID, Price, Notes FROM Food WHERE FoodCategoryID = @catID";
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);

                DataTable dt = new DataTable("Food");
                da.Fill(dt);

                dgvFood.DataSource = dt;
            }
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            // Lấy DataTable gốc từ DataGridView
            DataTable dt = (DataTable)dgvFood.DataSource;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Adapter để cập nhật dữ liệu
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID, Name, Unit, FoodCategoryID, Price, Notes FROM Food", conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);

                da.InsertCommand = builder.GetInsertCommand();
                da.UpdateCommand = builder.GetUpdateCommand();
                da.DeleteCommand = builder.GetDeleteCommand();

                try
                {
                    int updated = da.Update(dt);
                    MessageBox.Show($"Đã lưu {updated} thay đổi vào cơ sở dữ liệu.", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu: " + ex.Message);
                }
            }
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {
            if (dgvFood.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa món này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int foodID = Convert.ToInt32(dgvFood.CurrentRow.Cells["IDFood"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM Food WHERE ID = @id";
                    cmd.Parameters.AddWithValue("@id", foodID);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        dgvFood.Rows.Remove(dgvFood.CurrentRow);
                        MessageBox.Show("Đã xóa món ăn thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa. Món không tồn tại hoặc đã bị lỗi!");
                    }
                }
            }
        }
    }
}
