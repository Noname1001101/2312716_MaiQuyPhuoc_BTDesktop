using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Lab4_Basic_Command
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void bntLoad_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=QuanLyNhaHang; Integrated Security=true;";


            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            string query = "SELECT ID, Name, Type FROM Category";

            sqlCommand.CommandText = query;

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            this.DisplayCategory(sqlDataReader);

            sqlConnection.Close();
        }

        private void DisplayCategory(SqlDataReader reader)
        {
            lvCategory.Items.Clear();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["ID"].ToString());

                lvCategory.Items.Add(item);

                item.SubItems.Add(reader["Name"].ToString());
                item.SubItems.Add(reader["Type"].ToString());

                // Đầu tiên giãn theo header
                lvCategory.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);



            }
        }

        private void bntAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=QuanLyNhaHang; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "INSERT INTO Category(Name, [Type])" +
                "VALUES (N'" + txtName.Text + "', " + txtType.Text + ")";



            sqlConnection.Open();

            int numOfRowEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if (numOfRowEffected == 1)
            {
                MessageBox.Show("Thêm nhóm món ăn thành công");


                bntLoad.PerformClick();

                txtName.Text = "";
                txtType.Text = "";
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại");
            }

        }

        private void lvCategory_Click(object sender, EventArgs e)
        {
            ListViewItem item = lvCategory.SelectedItems[0];

            txtID.Text = item.SubItems[0].Text;
            txtName.Text = item.SubItems[1].Text;
            txtType.Text = item.SubItems[2].Text == "0" ? "Thức uống" : "Đồ ăn";

            bntUpdate.Enabled = true;
            bntDelete.Enabled = true;
        }

        //private void bntUpdate_Click(object sender, EventArgs e)
        //{
        //    string connectionString = "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=QuanLyNhaHang; Integrated Security=true;";
        //    SqlConnection sqlConnection = new SqlConnection(connectionString);

        //    SqlCommand sqlCommand = sqlConnection.CreateCommand();

        //    sqlCommand.CommandText = "UPDATE Category SET Name = N'" + txtName.Text +
        //                             "', [Type] = " + txtType.Text +
        //                             " WHERE ID = " + txtID.Text;
        //    sqlConnection.Open();

        //    int numOfRowEffected = sqlCommand.ExecuteNonQuery();

        //    sqlConnection.Close();

        //    if (numOfRowEffected == 1)
        //    {
        //        ListViewItem item = lvCategory.SelectedItems[0];

        //        item.SubItems[1].Text = txtName.Text.Trim() + " - Cập nhật";

        //        item.SubItems[2].Text = txtType.Text;

        //        txtID.Text = "";
        //        txtName.Text = "";
        //        txtType.Text = "";

        //        bntUpdate.Enabled = false;
        //        bntDelete.Enabled = false;

        //        MessageBox.Show("Cập nhật nhóm món ăn thành công");
        //    }

        //    else
        //    {
        //        MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại");
        //    }
        //}


        private void bntUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=QuanLyNhaHang; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // Loại bỏ " - cập nhật" nếu có trong tên để lưu dữ liệu sạch vào DB
            string cleanName = txtName.Text.Replace(" - cập nhật", "").Trim();

            sqlCommand.CommandText = "UPDATE Category SET Name = N'" + cleanName +
                                     "', [Type] = " + txtType.Text +
                                     " WHERE ID = " + txtID.Text;


            sqlConnection.Open();

            int numOfRowEffected = sqlCommand.ExecuteNonQuery();

            if (numOfRowEffected == 1)
            {
                ListViewItem item = lvCategory.SelectedItems[0];

                // Cập nhật lại tên và loại trong ListView, thêm chữ "- cập nhật" chỉ để hiển thị tạm thời
                item.SubItems[1].Text = cleanName + " - cập nhật";
                item.SubItems[2].Text = txtType.Text;

                // Xóa textbox và disable nút
                txtID.Text = "";
                txtName.Text = "";
                txtType.Text = "";

                bntUpdate.Enabled = false;
                bntDelete.Enabled = false;

                MessageBox.Show("Cập nhật nhóm món ăn thành công");
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại");
            }
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=QuanLyNhaHang; Integrated Security=true;";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "DELETE FROM Category WHERE ID = " + txtID.Text;

            sqlConnection.Open();

            int numOfRowEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if (numOfRowEffected == 1)
            {
                ListViewItem item = lvCategory.SelectedItems[0];
                lvCategory.Items.Remove(item);

                txtID.Text = "";
                txtName.Text = "";
                txtType.Text = "";

                bntUpdate.Enabled = false;
                bntDelete.Enabled = false;
                MessageBox.Show("Xóa nhóm món ăn thành công");
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại");
            }
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (lvCategory.SelectedItems.Count > 0)
            {
                bntDelete.PerformClick();
            }
        }

        private void tsmViewFood_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                FoodForm foodForm = new FoodForm();
                foodForm.Show(this);
                foodForm.LoadFood(Convert.ToInt32(txtID.Text));
            }    
        }
    }
}
