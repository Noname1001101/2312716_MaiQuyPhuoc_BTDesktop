using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class PurchaseHistoryForm : Form
    {
        private readonly string connectionString =
            "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";

        public PurchaseHistoryForm()
        {
            InitializeComponent();
        }

        private void PurchaseLogForm_Load(object sender, EventArgs e)
        {
            LoadPurchaseLog();
            LoadSummary();
        }

        private void LoadPurchaseLog()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        ID,
                        Name AS [Tên hóa đơn],
                        Account AS [Nhân viên],
                        CheckoutDate AS [Ngày lập],
                        Amount AS [Tổng tiền],
                        Tax AS [Thuế],
                        Discount AS [Giảm giá]
                    FROM Bills
                    WHERE CheckoutDate IS NOT NULL
                    ORDER BY ID ASC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPurchaseLog.DataSource = dt;
            }
        }

        private void LoadSummary()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        COUNT(*) AS TotalBills,
                        SUM(Amount) AS TotalAmount,
                        SUM(Tax * Amount) AS TotalTax,
                        SUM(Discount * Amount) AS TotalDiscount
                    FROM Bills
                    WHERE CheckoutDate IS NOT NULL";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblSummary.Text = string.Format(
                        "Tổng số hóa đơn: {0}\nTổng tiền: {1:N0} VNĐ",
                        reader["TotalBills"], reader["TotalAmount"]);
                }

                reader.Close();
                conn.Close();
            }
        }
    }
}
