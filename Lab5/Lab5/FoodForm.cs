using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class FoodForm : Form
    {
        private DataTable foodTable;
        public FoodForm()
        {
            InitializeComponent();
        }

        private void FoodForm_Load(object sender, EventArgs e)
        {
            LoadCategory();
        }

        private void LoadCategory()
        {
            string connectionString = "server=.\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Category";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            conn.Open();

            adapter.Fill(dt);

            conn.Close();
            conn.Dispose();

            cbbCategory.DataSource = dt;
            cbbCategory.DisplayMember = "Name";
            cbbCategory.ValueMember = "ID";
        }

        public void RefreshCategoryList()
        {
            LoadCategory(); // Gọi lại hàm có sẵn để nạp Category mới nhất
        }


        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCategory.SelectedIndex == -1)
                return;

            string connectionString = "server=.\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT * FROM Food WHERE FoodCategoryID = @categoryID";

            cmd.Parameters.Add("@categoryID", SqlDbType.Int);

            if (cbbCategory.SelectedValue is DataRowView)
            {
                DataRowView rowView = cbbCategory.SelectedValue as DataRowView;
                cmd.Parameters["@categoryID"].Value = rowView["ID"];
            }
            else
            {
                cmd.Parameters["@categoryID"].Value = cbbCategory.SelectedValue;

            }

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            foodTable = new DataTable();

            conn.Open();
            adapter.Fill(foodTable);
            conn.Close();
            conn.Dispose();
            dgvFoodList.DataSource = foodTable;
            lblQuantity.Text = foodTable.Rows.Count.ToString();
            lblCatName.Text = cbbCategory.Text;
        }

        private void tsmiCalculateQuantity_Click(object sender, EventArgs e)
        {
            string connectionString = "server=.\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT @numSaleFood = sum(Quantity) FROM BillDetails where FoodID IN (SELECT ID FROM Food WHERE FoodID = @foodId)";
            if (dgvFoodList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];

                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

                cmd.Parameters.Add("@foodId", SqlDbType.Int).Value = rowView["ID"];

                cmd.Parameters.Add("@numSaleFood", SqlDbType.Int).Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                string result = cmd.Parameters["@numSaleFood"].Value.ToString();
                MessageBox.Show("Tổng số lượng món " + rowView["Name"] + " đã bán là:" + result + " " + rowView["Unit"]);
                conn.Close();

            }
            cmd.Dispose();
            conn.Dispose();
        }

        void foodForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            int index = cbbCategory.SelectedIndex;
            cbbCategory.SelectedIndex = -1;
            cbbCategory.SelectedIndex = index;
        }

        private void tsmiAddFood_Click(object sender, EventArgs e)
        {
            FoodInfoForm foodForm = new FoodInfoForm();
            foodForm.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);
            foodForm.Show(this);
        }

        private void tsmiUpdateFood_Click(object sender, EventArgs e)
        {
            if (dgvFoodList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];
                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;
                FoodInfoForm foodForm = new FoodInfoForm();
                foodForm.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);
                foodForm.Show(this);
                foodForm.DisplayFoodInfo(rowView);
            }
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            if (foodTable == null) return;
            {
                //string filterExpression = string.Format("Name LIKE '%{0}%'", txtSearchByName.Text.Replace("'", "''"));
                string filterExpression = "Name like '%" + txtSearchByName.Text + "%'";
                string sortExpression = "Price DESC";
                DataViewRowState rowStateFilter = DataViewRowState.OriginalRows;

                DataView foodView = new DataView(foodTable, filterExpression, sortExpression, rowStateFilter);
                dgvFoodList.DataSource = foodView;
            }
        }


    }
}
