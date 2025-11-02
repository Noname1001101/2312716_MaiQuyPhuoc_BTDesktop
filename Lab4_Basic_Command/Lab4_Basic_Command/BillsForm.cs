
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class BillsForm : Form
    {
        private readonly string connectionString =
            "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";

        private int currentTableID;
        private DateTime prevFromDate;
        private DateTime prevToDate;

        public BillsForm(int tableID)
        {
            InitializeComponent();
            currentTableID = tableID;
        }

        private void BillsForm_Load(object sender, EventArgs e)
        {
            LoadBillsByTable(currentTableID);
            prevFromDate = dtpTuNgay.Value;
            prevToDate = dtpDenNgay.Value;
            UpdateGridTotals();
          
        }

        // ----------------- LOAD DỮ LIỆU THEO NGÀY -----------------
        private void LoadBillsByDate()
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
                b.Name,
                b.Amount,
                b.Discount,
                b.Tax,
                (b.Amount - (b.Amount * b.Discount / 100) + (b.Amount * b.Tax / 100)) AS FinalTotal,
                b.Status,
                b.Account
                FROM Bills b
                JOIN [Table] t ON b.TableID = t.ID
                WHERE b.CheckoutDate BETWEEN @fromDate AND @toDate
                ORDER BY b.ID ASC";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@fromDate", dtpTuNgay.Value.Date);
                    cmd.Parameters.AddWithValue("@toDate", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    //dgvBills.AutoGenerateColumns = false;
                    dgvBills.DataSource = dt;

                    UpdateGridTotals();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ----------------- LOAD DỮ LIỆU THEO BÀN -----------------
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
                     b.Name,
                     b.Amount,
                     b.Discount,
                     b.Tax,
                     (b.Amount - (b.Amount * b.Discount / 100) + (b.Amount * b.Tax / 100)) AS FinalTotal,
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

                    UpdateGridTotals();
              
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message,
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        // ----------------- TÍNH CỘNG -----------------

        private void UpdateGridTotals()
        {
            if (dgvBills.DataSource == null) return;

            decimal tongTruocGiam = 0;
            decimal tongGiam = 0;
            decimal tongThue = 0;
            decimal tongThucThu = 0;

            foreach (DataGridViewRow row in dgvBills.Rows)
            {
                if (row.IsNewRow) continue;

                decimal.TryParse(row.Cells["colAmount"].Value?.ToString(), out decimal truocGiam);
                decimal.TryParse(row.Cells["colDiscount"].Value?.ToString(), out decimal giam);
                decimal.TryParse(row.Cells["colTax"].Value?.ToString(), out decimal thue);

                // Tính thực thu
                decimal thucThu = truocGiam - giam + thue;

                tongTruocGiam += truocGiam;
                tongGiam += giam;
                tongThue += thue;
                tongThucThu += thucThu;
            }

           
        }

        //private void UpdateBillTotals(int billID)
        //{
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        con.Open();

        //        string sql = @"
        //    DECLARE @taxRate FLOAT, @discountRate FLOAT;

        //    -- Lấy % thuế và % giảm giá hiện đang lưu trong Bills
        //    SELECT 
        //        @taxRate = ISNULL(Tax, 0),
        //        @discountRate = ISNULL(Discount, 0)
        //    FROM Bills
        //    WHERE ID = @billID;

        //    -- Cập nhật lại các giá trị tính toán
        //    UPDATE Bills
        //    SET 
        //        Amount = ISNULL((
        //            SELECT SUM(fd.Price * bd.Quantity)
        //            FROM BillDetails bd
        //            JOIN Food fd ON bd.FoodID = fd.ID
        //            WHERE bd.InvoiceID = @billID
        //        ), 0),

        //        FinalTotal = ISNULL((
        //            SELECT SUM(fd.Price * bd.Quantity)
        //            FROM BillDetails bd
        //            JOIN Food fd ON bd.FoodID = fd.ID
        //            WHERE bd.InvoiceID = @billID
        //        ), 0)
        //        * (1 - @discountRate / 100 + @taxRate / 100)
        //    WHERE ID = @billID;
        //";

        //        SqlCommand cmd = new SqlCommand(sql, con);
        //        cmd.Parameters.AddWithValue("@billID", billID);
        //        cmd.ExecuteNonQuery();
        //    }
        //}


        private void UpdateBillTotals(int billID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string sql = @"
        DECLARE @taxRate FLOAT = 10;  -- Thuế cố định 10%
        DECLARE @discountRate FLOAT;

        -- Lấy % giảm giá hiện đang lưu trong Bills
        SELECT 
            @discountRate = ISNULL(Discount, 0)
        FROM Bills
        WHERE ID = @billID;

        -- Cập nhật lại các giá trị tính toán
        UPDATE Bills
        SET 
            Tax = @taxRate,  -- Gán luôn thuế 10%
            Amount = ISNULL((
                SELECT SUM(fd.Price * bd.Quantity)
                FROM BillDetails bd
                JOIN Food fd ON bd.FoodID = fd.ID
                WHERE bd.InvoiceID = @billID
            ), 0),

            FinalTotal = ISNULL((
                SELECT SUM(fd.Price * bd.Quantity)
                FROM BillDetails bd
                JOIN Food fd ON bd.FoodID = fd.ID
                WHERE bd.InvoiceID = @billID
            ), 0)
            * (1 - @discountRate / 100 + @taxRate / 100)
        WHERE ID = @billID;
        ";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@billID", billID);
                cmd.ExecuteNonQuery();
            }
        }


        private void dgvBills_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
    // Hiển thị cột Thuế dạng %
    if (dgvBills.Columns[e.ColumnIndex].Name == "colTax" && e.Value != null)
        {
                if (double.TryParse(e.Value.ToString(), out double discount))
                {
                    e.Value = discount.ToString("0") + "%";
                    e.FormattingApplied = true;
                }

            }

            // Hiển thị cột Giảm giá dạng %
            else if (dgvBills.Columns[e.ColumnIndex].Name == "colDiscount" && e.Value != null)
            {
                if (double.TryParse(e.Value.ToString(), out double tax))
                {
                    e.Value = tax.ToString("0") + "%";
                    e.FormattingApplied = true;
                }

            }
        }








        // ----------------- SỰ KIỆN -----------------

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value <= dtpDenNgay.Value)
            {
                LoadBillsByDate();
                prevFromDate = dtpTuNgay.Value;
            }
            else
            {
                dtpTuNgay.ValueChanged -= dtpTuNgay_ValueChanged;
                MessageBox.Show("❌ 'Từ ngày' phải nhỏ hơn hoặc bằng 'Đến ngày'.", "Lỗi ngày",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpTuNgay.Value = prevFromDate;
                dtpTuNgay.ValueChanged += dtpTuNgay_ValueChanged;
            }
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value <= dtpDenNgay.Value)
            {
                LoadBillsByDate();
                prevToDate = dtpDenNgay.Value;
            }
            else
            {
                dtpDenNgay.Value = prevToDate;
                dtpDenNgay.ValueChanged += dtpDenNgay_ValueChanged;
            }
        }

        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy tất cả các bill của bàn hiện tại
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string sql = "SELECT ID FROM Bills WHERE TableID = @tableID";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@tableID", currentTableID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    var billIDs = new List<int>();
                    while (reader.Read())
                    {
                        billIDs.Add(Convert.ToInt32(reader["ID"]));
                    }
                    reader.Close();

                    // Cập nhật lại từng bill trước khi load
                    foreach (int billID in billIDs)
                    {
                        UpdateBillTotals(billID);
                    }
                }

                // Sau khi cập nhật thì load lại dữ liệu
                LoadBillsByTable(currentTableID);

                MessageBox.Show("🔄 Dữ liệu và tổng tiền đã được cập nhật mới nhất!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lại dữ liệu: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvBills_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvBills.Rows[e.RowIndex].Cells["colID"] != null)
            {
                object cellValue = dgvBills.Rows[e.RowIndex].Cells["colID"].Value;

                if (cellValue == null || cellValue == DBNull.Value)
                {
                    MessageBox.Show("⚠️ Không có mã hóa đơn hợp lệ để xem chi tiết!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int billID = Convert.ToInt32(cellValue);
                BillDetailsForm detailsForm = new BillDetailsForm(billID);
                detailsForm.ShowDialog();

            }
        }
    }
}

