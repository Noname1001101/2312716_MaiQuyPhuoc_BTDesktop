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
            UpdateBillAmount();
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
            UpdateBillAmount();
        }

        /// <summary>
        /// Tự động tính lại Amount và giảm giá cho hóa đơn hiện tại.
        /// </summary>
        private void UpdateBillAmount()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 🔹 Bước 1: Tính tổng tiền gốc
                    string sqlTotal = @"
                SELECT SUM(f.Price * bd.Quantity)
                FROM BillDetails bd
                INNER JOIN Food f ON f.ID = bd.FoodID
                WHERE bd.InvoiceID = @BillID";

                    SqlCommand cmdTotal = new SqlCommand(sqlTotal, conn);
                    cmdTotal.Parameters.AddWithValue("@BillID", billID);

                    object result = cmdTotal.ExecuteScalar();
                    decimal totalBeforeDiscount = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;

                    // 🔹 Bước 2: Áp dụng giảm 10% nếu tổng >= 300000
                    decimal tax = (totalBeforeDiscount >= 300000) ? 0.9m : 1m;
                    decimal totalAfterDiscount = totalBeforeDiscount * tax;

                    // 🔹 Bước 3: Cập nhật vào Bills
                    string sqlUpdate = @"
                UPDATE Bills
                SET 
                    Discount = @TotalBefore,
                    Tax = @Tax,
                    Amount = @TotalAfter
                WHERE ID = @BillID";

                    SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn);
                    cmdUpdate.Parameters.AddWithValue("@TotalBefore", totalBeforeDiscount);
                    cmdUpdate.Parameters.AddWithValue("@Tax", tax);
                    cmdUpdate.Parameters.AddWithValue("@TotalAfter", totalAfterDiscount);
                    cmdUpdate.Parameters.AddWithValue("@BillID", billID);

                    cmdUpdate.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật tổng tiền hóa đơn: " + ex.Message,
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
