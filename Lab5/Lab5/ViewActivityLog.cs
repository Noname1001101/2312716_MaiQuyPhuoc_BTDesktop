using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab5
{
    public partial class ViewActivityLog : Form
    {
        private readonly string connectionString =
            "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";

        public ViewActivityLog()
        {
            InitializeComponent();
        }

        private void BillsByDateForm_Load(object sender, EventArgs e)
        {
            LoadBillDates();
        }

        // ==========================================================
        // 1️⃣ TẢI DANH SÁCH NGÀY LẬP HÓA ĐƠN
        // ==========================================================
        private void LoadBillDates()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT DISTINCT CONVERT(date, CheckoutDate) AS BillDate
                    FROM Bills
                    WHERE CheckoutDate IS NOT NULL
                    ORDER BY BillDate DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                lstBillDates.DisplayMember = "BillDate";
                lstBillDates.ValueMember = "BillDate";
                lstBillDates.DataSource = dt;
            }
        }

        // ==========================================================
        // 2️⃣ KHI NGƯỜI DÙNG NHẤN VÀO NGÀY → HIỂN THỊ CÁC HÓA ĐƠN CỦA NGÀY ĐÓ
        // ==========================================================
        private void lstBillDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBillDates.SelectedValue == null)
                return;

            DateTime selectedDate = Convert.ToDateTime(lstBillDates.SelectedValue);
            LoadBillsByDate(selectedDate);
           
        }

        // ==========================================================
        // 3️⃣ TẢI DANH SÁCH HÓA ĐƠN TRONG NGÀY
        // ==========================================================
        private void LoadBillsByDate(DateTime billDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT ID, Name, CheckoutDate, Amount, Tax, Discount, Account
            FROM Bills
            WHERE CONVERT(date, CheckoutDate) = @date";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@date", billDate.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvBills.DataSource = dt;

                // ✅ Tính tổng số hóa đơn và tổng tiền
                int count = dt.Rows.Count;
                decimal total = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Amount"] != DBNull.Value)
                        total += Convert.ToDecimal(row["Amount"]);
                }

                lblSummary.Text = $"Số hóa đơn: {count} | Tổng tiền: {total:N0} VNĐ";
            }
        }


        // ==========================================================
        // 4️⃣ KHI CHỌN 1 HÓA ĐƠN → HIỂN THỊ DANH MỤC MÓN ĂN
        // ==========================================================
        private void dgvBills_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int billID = Convert.ToInt32(dgvBills.Rows[e.RowIndex].Cells["colID"].Value);
                LoadBillDetails(billID);
            }
        }

        private void LoadBillDetails(int billID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT f.Name AS [Tên món], f.Unit AS [ĐVT], d.Quantity AS [Số lượng], 
                   f.Price AS [Đơn giá], (f.Price * d.Quantity) AS [Thành tiền]
            FROM BillDetails d
            JOIN Food f ON d.FoodID = f.ID
            WHERE d.InvoiceID = @billID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@billID", billID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvBillDetails.DataSource = dt;
            }
        }



    }
}
