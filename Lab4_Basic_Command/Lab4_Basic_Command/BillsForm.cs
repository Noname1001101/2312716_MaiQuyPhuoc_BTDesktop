using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class BillsForm : Form
    {
        // Chuỗi kết nối đến SQL Server
        private readonly string connectionString =
            "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";

        private int currentTableID; // ✅ lưu mã bàn được chọn
        public BillsForm(int tableID)
        {
            InitializeComponent();
            currentTableID = tableID;
        }

        // Khi form mở lên, tự động nạp khoảng ngày và danh sách hóa đơn
        private void BillsForm_Load(object sender, EventArgs e)
        {
            LoadBillsByTable(currentTableID); // ✅ hiển thị hóa đơn theo bàn
            //LoadDateRange();
            //LoadBills();
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

        private void LoadBills()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string sql = @"
                        SELECT *
                        FROM Bills
                        WHERE CheckoutDate BETWEEN @fromDate AND @toDate
                        ORDER BY ID ASC";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@fromDate", dtpTuNgay.Value.Date);
                    cmd.Parameters.AddWithValue("@toDate", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvBills.DataSource = dt; // Cho phép tự sinh cột
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //private void LoadBills(int tableID)
        //{
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            con.Open();

        //            string sql = @"
        //        SELECT 
        //            b.ID ,
        //            t.Name ,
        //            b.CheckoutDate ,
        //            b.Amount ,
        //            b.Discount ,
        //            b.Tax AS ,
        //            b.Status ,
        //            b.Account
        //        FROM Bills b
        //        JOIN [Table] t ON b.TableID = t.ID
        //        WHERE b.TableID = @tableID 
        //          AND b.CheckoutDate BETWEEN @fromDate AND @toDate
        //        ORDER BY b.ID DESC";

        //            SqlCommand cmd = new SqlCommand(sql, con);
        //            cmd.Parameters.AddWithValue("@tableID", tableID);
        //            cmd.Parameters.AddWithValue("@fromDate", dtpTuNgay.Value.Date);
        //            cmd.Parameters.AddWithValue("@toDate", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1));

        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);
        //            dgvBills.DataSource = dt;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message,
        //                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        private void LoadBillsByTable(int tableID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string sql = @"
                    SELECT 
                        b.ID,
                        t.ID AS TableID,
                        b.CheckoutDate,
                        b.Name AS BillName,
                        b.Amount,
                        b.Discount,
                        b.Tax,
                        b.Status,
                        b.Account
                    FROM Bills b
                    JOIN [Table] t ON b.TableID = t.ID
                    WHERE b.TableID = @tableID
                    ORDER BY b.ID DESC";


                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@tableID", tableID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    
                    dgvBills.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message,
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        // Khi người dùng đổi ngày, tự động tải lại hóa đơn
        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value <= dtpDenNgay.Value)
                //LoadBills(currentTableID); // lọc theo ngày + bàn
                LoadBills();
            else
                MessageBox.Show("Từ ngày phải nhỏ hơn hoặc bằng Đến ngày.", "Lỗi ngày",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value <= dtpDenNgay.Value)
                //LoadBills(currentTableID); // lọc theo ngày + bàn
                LoadBills();
            else
                MessageBox.Show("Từ ngày phải nhỏ hơn hoặc bằng Đến ngày.", "Lỗi ngày",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    dgvBills.DataSource = dt;
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
        private void dgvBills_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvBills.Rows[e.RowIndex].Cells["colID"] != null)
            {
                int billID = Convert.ToInt32(dgvBills.Rows[e.RowIndex].Cells["colID"].Value);
                BillDetailsForm detailsForm = new BillDetailsForm(billID);
                detailsForm.ShowDialog();
            }
        }
    }
}
