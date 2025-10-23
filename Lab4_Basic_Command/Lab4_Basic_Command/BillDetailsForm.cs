using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class BillDetailsForm : Form
    {
    
        private string connectionString =
            "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
        private int billID;

        public BillDetailsForm(int billID)
        {
            InitializeComponent();
            this.billID = billID;
        }

        private void BillDetailsForm_Load(object sender, EventArgs e)
        {
            LoadBillDetails();
        }

        private void LoadBillDetails()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                    SELECT 
                    f.Name,
                    f.Unit,
                    bd.Quantity,
                    f.Price,
                    (bd.Quantity * f.Price) AS Total,
                    f.Notes,
                    c.Name AS CategoryName
                    FROM BillDetails bd
                    INNER JOIN Food f ON bd.FoodID = f.ID
                    INNER JOIN Category c ON f.FoodCategoryID = c.ID
                    WHERE bd.InvoiceID = @BillID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BillID", billID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvBillDetails.AutoGenerateColumns = false;
                    dgvBillDetails.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải chi tiết hóa đơn: " + ex.Message,
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
