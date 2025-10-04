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
            string conectionString = "server=.; database = RestaurantManagement; Integrated Security = true; ";

            SqlConnection sqlConnection = new SqlConnection(conectionString);

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
            }
        }

        private void bntAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "server=.; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "INSERT INTO Category(Name, [Type])" +
                "VALUES (N'" + txtName.Text + "', " + txtType.Text + ")";
            //Cho txtName co the thay bang txtCategoryName.Text nhung hien tai ko co bien nhu vay

            sqlConnection.Open();

            int numOfRowEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if (numOfRowEffected == 1)
            {
                MessageBox.Show("Thêm nhóm món ăn thành công");



                bntLoad.PerformClick();

                txtName.Text = "";//cho nay cung co the thay bang txtCategoryName
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
            txtType.Text = item.SubItems[1].Text == "0" ? "Thức uống" : "Đồ ăn";

            bntUpdate.Enabled = true;
            bntDelete.Enabled = true;
        }

        private void bntUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = "server=.; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "UPDATE Category SET Name = N'" + txtName.Text +
                                     "', [Type] = " + txtType.Text +
                                     " WHERE ID = " + txtID.Text;
        }
    }
}
