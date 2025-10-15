using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab4_Basic_Command
{
    public partial class FoodForm : Form
    {
        private string connectionString = "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=QuanLyNhaHang; Integrated Security=true;";
        public FoodForm()
        {
            InitializeComponent();
        }

        public void LoadFood(int categoryID)
        {
            //string connectionString = "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=QuanLyNhaHang; Integrated Security=true;";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "SELECT Name FROM Category WHERE CategoryID = " + categoryID;

            sqlConnection.Open();

            string catName = sqlCommand.ExecuteScalar().ToString();

            this.Text = "Danh sách các món ăn thuộc nhóm: " + catName;

            sqlCommand.CommandText = "SELECT * FROM Food WHERE CategoryID = " + categoryID;    

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);

            DataTable dt = new DataTable("Food");

            da.Fill(dt);

            dgvFood.DataSource = dt;

            sqlConnection.Close();
            sqlConnection.Dispose();
            da.Dispose();

        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            // Lấy DataTable gốc từ DataGridView
            DataTable dt = (DataTable)dgvFood.DataSource;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Adapter để cập nhật dữ liệu
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Food", conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);

                // Tự động tạo các lệnh Insert/Update/Delete
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
                int foodID = Convert.ToInt32(dgvFood.CurrentRow.Cells["FoodID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM Food WHERE FoodID = @id";
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

