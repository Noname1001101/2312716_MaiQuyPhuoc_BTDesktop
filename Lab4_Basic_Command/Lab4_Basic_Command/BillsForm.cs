
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class BillsForm : Form
    {
        private string connectionString = "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=QuanLyNhaHang; Integrated Security=true;";

        public BillsForm()
        {
            InitializeComponent();
        }

        private void BillsForm_Load(object sender, EventArgs e)
        {
            // Khi form mở, hiển thị toàn bộ dữ liệu Bills
            LoadBills();
        }

        //private void LoadBills(DateTime? fromDate = null, DateTime? toDate = null)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        string sql = @"
        //    SELECT 
        //        BillID AS [Mã hóa đơn],
        //        [Date] AS [Ngày],
        //        TotalBeforeDiscount AS [Tổng tiền trước giảm],
        //        TotalDiscount AS [Tổng giảm giá],
        //        TotalPaid AS [Thực thu]
        //    FROM Bills";

        //        // nếu có truyền khoảng ngày thì thêm điều kiện
        //        if (fromDate.HasValue && toDate.HasValue)
        //        {
        //            sql += " WHERE CAST([Date] AS DATE) BETWEEN @fromDate AND @toDate";
        //        }

        //        sql += " ORDER BY BillID ASC";

        //        SqlCommand cmd = new SqlCommand(sql, conn);
        //        if (fromDate.HasValue && toDate.HasValue)
        //        {
        //            cmd.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate.Value;
        //            cmd.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate.Value;
        //        }

        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);

        //        dgvBills.Columns.Clear();
        //        dgvBills.DataSource = dt;
        //        dgvBills.AllowUserToAddRows = false;
        //        dgvBills.Columns["Ngày"].DefaultCellStyle.Format = "dd/MM/yyyy";
        //        dgvBills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



        //        // cập nhật tiêu đề form
        //        if (fromDate.HasValue && toDate.HasValue)
        //            this.Text = $"Danh sách hóa đơn từ {fromDate:dd/MM/yyyy} đến {toDate:dd/MM/yyyy}";
        //        else
        //            this.Text = "Danh sách tất cả hóa đơn";
        //    }
        //}

        private void LoadBills(DateTime? fromDate = null, DateTime? toDate = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
        SELECT 
            b.BillID AS [Mã hóa đơn],
            b.[Date] AS [Ngày],
            ISNULL(SUM(bd.Quantity * f.UntilPrice), 0) AS [Tổng tiền trước giảm],
            b.TotalDiscount AS [Tổng giảm giá],
            ISNULL(SUM(bd.Quantity * f.UntilPrice), 0) - b.TotalDiscount AS [Thực thu]
        FROM Bills b
        LEFT JOIN BillDetails bd ON b.BillID = bd.BillID
        LEFT JOIN Food f ON bd.FoodID = f.FoodID
        WHERE 1 = 1";

                if (fromDate.HasValue && toDate.HasValue)
                    sql += " AND CAST(b.[Date] AS DATE) BETWEEN @fromDate AND @toDate";

                sql += " GROUP BY b.BillID, b.[Date], b.TotalDiscount ORDER BY b.BillID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                if (fromDate.HasValue && toDate.HasValue)
                {
                    cmd.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate.Value;
                    cmd.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate.Value;
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvBills.Columns.Clear();
                dgvBills.DataSource = dt;
                dgvBills.AllowUserToAddRows = false;
                dgvBills.Columns["Ngày"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvBills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvBills.Columns["Tổng tiền trước giảm"].DefaultCellStyle.Format = "N0";
                dgvBills.Columns["Tổng giảm giá"].DefaultCellStyle.Format = "N0";
                dgvBills.Columns["Thực thu"].DefaultCellStyle.Format = "N0";

                if (fromDate.HasValue && toDate.HasValue)
                    this.Text = $"Danh sách hóa đơn từ {fromDate:dd/MM/yyyy} đến {toDate:dd/MM/yyyy}";
                else
                    this.Text = "Danh sách tất cả hóa đơn";
            }
        }



        // Khi thay đổi Từ ngày
        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value.Date <= dtpDenNgay.Value.Date)
                LoadBills(dtpTuNgay.Value.Date, dtpDenNgay.Value.Date);
            else
                MessageBox.Show("Từ ngày phải nhỏ hơn hoặc bằng Đến ngày.", "Lỗi ngày", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Khi thay đổi Đến ngày
        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value.Date <= dtpDenNgay.Value.Date)
                LoadBills(dtpTuNgay.Value.Date, dtpDenNgay.Value.Date);
            else
                MessageBox.Show("Từ ngày phải nhỏ hơn hoặc bằng Đến ngày.", "Lỗi ngày", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            // Gọi lại hàm load toàn bộ dữ liệu
            LoadBills();

            // Cập nhật lại khoảng ngày hiển thị nếu cần
            this.Text = "Danh sách tất cả hóa đơn";
        }

        private void dgvBills_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // kiểm tra dòng hợp lệ
            {
                // Lấy BillID của dòng được double-click
                int billID = Convert.ToInt32(dgvBills.Rows[e.RowIndex].Cells["Mã hóa đơn"].Value);

                // Mở form chi tiết hóa đơn
                BillDetailsForm detailsForm = new BillDetailsForm(billID);
                detailsForm.ShowDialog();
            }
        }
    }
}
