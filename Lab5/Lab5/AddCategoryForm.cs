using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab5
{
    public partial class AddCategoryForm : Form
    {
        public int NewCategoryID { get; private set; } = -1; // để trả về ID nhóm mới

        public AddCategoryForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCatName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm món ăn!");
                return;
            }

            try
            {
                string connectionString = "server=.\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "AddNewCategory"; // thủ tục bạn sẽ tạo trong SQL
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = txtCatName.Text;

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        NewCategoryID = (int)cmd.Parameters["@id"].Value;
                        MessageBox.Show("Đã thêm nhóm món ăn mới!", "Thông báo");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm nhóm món ăn.");
                    }

                    

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
