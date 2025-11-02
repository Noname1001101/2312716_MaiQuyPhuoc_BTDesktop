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

                    dgvBillDetails.AutoGenerateColumns = true;
                    dgvBillDetails.DataSource = dt;
                    UpdateTotalLabel();

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

                    // 1️⃣ Tính tổng tiền trước giảm
                    string sqlTotal = @"
            SELECT SUM(f.Price * bd.Quantity)
            FROM BillDetails bd
            INNER JOIN Food f ON f.ID = bd.FoodID
            WHERE bd.InvoiceID = @BillID";

                    SqlCommand cmdTotal = new SqlCommand(sqlTotal, conn);
                    cmdTotal.Parameters.AddWithValue("@BillID", billID);

                    object result = cmdTotal.ExecuteScalar();
                    decimal totalBeforeDiscount = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;

                    // 2️⃣ Tính tỷ lệ giảm
                    decimal discountRate = 0m;
                    if (totalBeforeDiscount >= 1_000_000)
                        discountRate = 0.15m;
                    else if (totalBeforeDiscount >= 500_000)
                        discountRate = 0.10m;
                    else if (totalBeforeDiscount >= 300_000)
                        discountRate = 0.05m;

                    // 3️⃣ Tính tiền giảm
                    decimal discountAmount = totalBeforeDiscount * discountRate;
                    decimal amountAfterDiscount = totalBeforeDiscount - discountAmount;

                    // 4️⃣ Tính thuế VAT 10% sau giảm
                    decimal taxRate = 0.10m;
                    decimal taxAmount = amountAfterDiscount * taxRate;

                    // Tổng phải thu
                    decimal finalTotal = amountAfterDiscount + taxAmount;

                    // 5️⃣ Update bảng Bills
                    string sqlUpdate = @"
            UPDATE Bills
            SET 
                Amount = @Amount,           
                Discount = @Discount,       
                Tax = @TaxAmount,           
                FinalTotal = @FinalTotal,   
                Status = 1,
                CheckoutDate = GETDATE()
            WHERE ID = @BillID";

                    SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn);
                    cmdUpdate.Parameters.AddWithValue("@Amount", totalBeforeDiscount);
                    cmdUpdate.Parameters.AddWithValue("@Discount", discountAmount);
                    cmdUpdate.Parameters.AddWithValue("@TaxAmount", taxAmount);
                    cmdUpdate.Parameters.AddWithValue("@FinalTotal", finalTotal);
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



        private void UpdateTotalLabel()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvBillDetails.Rows)
            {
                if (row.Cells["colTotal"].Value != null)
                    total += Convert.ToDecimal(row.Cells["colTotal"].Value);

            }
            lblTotalAmount.Text = $"Tổng thành tiền: {total:N0} VND";
        }


    }


}

