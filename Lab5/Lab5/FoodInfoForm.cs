using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab5
{
    public partial class FoodInfoForm : Form
    {
        public FoodInfoForm()
        {
            InitializeComponent();
        }

        private void FoodInfoForm_Load(object sender, EventArgs e)
        {
            InitValues();
        }

        private void InitValues()
        {
            string connectionString = "server=.\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT ID, Name FROM Category";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            conn.Open();
            adapter.Fill(ds, "Category");

            cbbCatName.DataSource = ds.Tables["Category"];
            cbbCatName.DisplayMember = "Name";
            cbbCatName.ValueMember = "ID";

            conn.Close();
            conn.Dispose();
        }

       


        public void DisplayFoodInfo(DataRowView rowView)
        {
            try
            {
                txtFoodID.Text = rowView["ID"].ToString();
                txtName.Text = rowView["name"].ToString();
                txtUnit.Text = rowView["unit"].ToString();
                nudPrice.Value = Convert.ToDecimal(rowView["Price"]);
                txtNotes.Text = rowView["Notes"].ToString();

                cbbCatName.SelectedIndex = -1;

                for (int i = 0; i < cbbCatName.Items.Count; i++)
                {
                    DataRowView cat = cbbCatName.Items[i] as DataRowView;
                    if (cat["ID"].ToString() == rowView["FoodCategoryID"].ToString())
                    {
                        cbbCatName.SelectedIndex = i;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                Close();

            }
          
        }

        private void ResetText()
        {
            txtFoodID.ResetText();
            txtName.ResetText();
            txtUnit.ResetText();
            cbbCatName.ResetText();
            nudPrice.ResetText();
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=.\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "EXECUTE InsertFood @id OUTPUT, @name, @unit, @foodCategoryID, @price, @notes";

                cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 1000).Value = txtName.Text;
                cmd.Parameters.Add("@unit", SqlDbType.NVarChar, 100).Value = txtUnit.Text;
                cmd.Parameters.Add("@foodCategoryID", SqlDbType.Int).Value = cbbCatName.SelectedValue;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = nudPrice.Value;
                cmd.Parameters.Add("@notes", SqlDbType.NVarChar, 3000).Value = txtNotes.Text;

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    string foodID = cmd.Parameters["@id"].Value.ToString();

                    MessageBox.Show("Successfully adding new food, Food ID = " + foodID, "Message");
                    ResetText();
                }
                else
                {
                    MessageBox.Show("Addting food failes");
                }
                conn.Close();
                conn.Dispose();

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

        private void btnUpdateFood_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=.\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true;";
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE UpdateFood @id, @name, @unit, @foodCategoryID, @price, @notes";

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(txtFoodID.Text);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 1000).Value = txtName.Text;
                cmd.Parameters.Add("@unit", SqlDbType.NVarChar, 100).Value = txtUnit.Text;
                cmd.Parameters.Add("@foodCategoryID", SqlDbType.Int).Value = cbbCatName.SelectedValue;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = nudPrice.Value;
                cmd.Parameters.Add("@notes", SqlDbType.NVarChar, 3000).Value = txtNotes.Text;

                conn.Open();

                int numberOfRowsAffected = cmd.ExecuteNonQuery();

                if (numberOfRowsAffected > 0)
                {
                    MessageBox.Show("Successfully updating food", "Message");
                }
                else
                {
                    MessageBox.Show("Updating food failed");
                }

                conn.Close();
                conn.Dispose();

            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message, " SQL Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            using (AddCategoryForm f = new AddCategoryForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    // Cập nhật lại combobox trong FoodInfoForm
                    InitValues();

                    if (f.NewCategoryID > 0)
                        cbbCatName.SelectedValue = f.NewCategoryID;

                    // ✅ Cập nhật lại combobox bên FoodForm (nếu có)
                    if (this.Owner is FoodForm parentForm)
                    {
                        parentForm.RefreshCategoryList();
                    }
                }
            }
        }


    }
}
