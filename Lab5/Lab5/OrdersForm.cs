using Lab4_Basic_Command;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab5
{
    public partial class OrdersForm : Form
    {
        // Chuỗi kết nối đến SQL Server
        private readonly string connectionString =
            "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";

        private int currentTableID; // ✅ lưu mã bàn được chọn
        private DateTime prevFromDate;
        private DateTime prevToDate;


        public OrdersForm()
        {
            InitializeComponent();
      

        }

        // Khi form mở lên, tự động nạp khoảng ngày và danh sách hóa đơn
        private void OrdersForm_Load(object sender, EventArgs e)
        {
         
            LoadDateRange();
            LoadOrders();
            prevFromDate = dtpTuNgay.Value;
            prevToDate = dtpDenNgay.Value;
        }

   
        /// Lấy ngày nhỏ nhất và lớn nhất trong bảng Bills để hiển thị lên DateTimePicker
       
        private void LoadDateRange()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT MIN(CheckoutDate), MAX(CheckoutDate) FROM Bills WHERE CheckoutDate IS NOT NULL";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read() && !reader.IsDBNull(0) && !reader.IsDBNull(1))
                    {
                        dtpTuNgay.Value = reader.GetDateTime(0).Date;
                        dtpDenNgay.Value = reader.GetDateTime(1).Date;
                    }
                    else
                    {
                        // Nếu bảng Bills chưa có dữ liệu, đặt mặc định 1 tháng gần nhất
                        dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
                        dtpDenNgay.Value = DateTime.Now;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải ngày: " + ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /// Tải danh sách hóa đơn theo khoảng ngày

        private void LoadOrders()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string sql = @"
                        SELECT 
                        b.ID,
                        b.CheckoutDate,
                        b.Name,
                        b.Amount,
                        b.Discount,
                        b.Tax,
                        b.Status,
                        b.Account
                        FROM Bills b
                        WHERE CheckoutDate BETWEEN @fromDate AND @toDate
                        ORDER BY ID ASC";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@fromDate", dtpTuNgay.Value.Date);
                    cmd.Parameters.AddWithValue("@toDate", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvOrders.DataSource = dt; // Cho phép tự sinh cột
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Khi người dùng đổi ngày, tự động tải lại hóa đơn
        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value <= dtpDenNgay.Value)
            {
                LoadOrders();
                prevFromDate = dtpTuNgay.Value; // ✅ lưu giá trị hợp lệ mới
            }
            else
            {
                dtpTuNgay.ValueChanged -= dtpTuNgay_ValueChanged;
                MessageBox.Show("❌ 'Từ ngày' phải nhỏ hơn hoặc bằng 'Đến ngày'.", "Lỗi ngày",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpTuNgay.Value = prevFromDate; // ✅ khôi phục giá trị cũ
                dtpTuNgay.ValueChanged += dtpTuNgay_ValueChanged;
            }
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value <= dtpDenNgay.Value)
            {
                LoadOrders();
                prevToDate = dtpDenNgay.Value; // ✅ lưu giá trị hợp lệ mới
            }
            else
            {
                
                dtpDenNgay.Value = prevToDate;
                dtpDenNgay.ValueChanged += dtpDenNgay_ValueChanged;
            }
        }



        // Nút Refresh – tải lại toàn bộ hóa đơn, không lọc theo ngày
        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string sql = "SELECT * FROM Bills ORDER BY ID ASC";

                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvOrders.DataSource = dt;
                }

                Console.WriteLine("Đã tải lại toàn bộ hóa đơn.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lại dữ liệu: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Khi double-click vào hóa đơn, mở form chi tiết
        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOrders.Rows[e.RowIndex].Cells["colID"] != null)
            {
                int billID = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["colID"].Value);
                OrderDetailsForm detailsForm = new OrderDetailsForm(billID);
                detailsForm.ShowDialog();
            }
        }
    }
}
