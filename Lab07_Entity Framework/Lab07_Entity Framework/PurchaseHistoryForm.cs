using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Lab07_Entity_Framework.Models; // ⬅️ THÊM
using System.Data.Entity;           // ⬅️ THÊM

namespace Lab07_Entity_Framework // ⬅️ Đổi namespace (nếu file cũ là Lab4)
{
    public partial class PurchaseHistoryForm : Form
    {
        // 1. Dùng Context, bỏ ConnectionString
        private RestaurantContext _context;

        public PurchaseHistoryForm()
        {
            InitializeComponent();
            _context = new RestaurantContext(); // Khởi tạo
        }

        private void PurchaseLogForm_Load(object sender, EventArgs e)
        {
            // Chúng ta gộp 2 hàm Load cũ thành 1 hàm
            LoadHistory();
        }

        // 2. Hàm Load gộp (Refactored)
        private void LoadHistory()
        {
            try
            {
                // Lấy TẤT CẢ hóa đơn ĐÃ THANH TOÁN (Giả sử Status = 1)
                // Dùng Include() để tải kèm tên Nhân viên
                var paidBills = _context.Bills
                    // Sửa lỗi: b.Status == 1  thành  b.Status == true
                    // (Hoặc có thể viết là b.Status)
                    .Where(b => b.Status == true)
                    .Include(b => b.AccountInfo) // Tải tên nhân viên
                    .OrderByDescending(b => b.CheckoutDate)
                    .ToList();

                // 3. TÍNH TOÁN TỔNG HỢP
                int totalBills = paidBills.Count;

                // b.Amount là 'int', Sum() trả về 'int', gán cho 'decimal' là OK
                decimal totalAmount = paidBills.Sum(b => b.Amount);

                // Sửa lỗi ép kiểu: b.Tax và b.Discount là 'double?'
                // Sum() sẽ trả về 'double'. Phải ép kiểu (decimal)
                decimal totalTax = (decimal)paidBills.Sum(b => b.Tax ?? 0);
                decimal totalDiscount = (decimal)paidBills.Sum(b => b.Discount ?? 0);

                // Gán vào Label
                lblSummary.Text = string.Format(
                    "Tổng số hóa đơn: {0}\n" +
                    "Tổng tiền (Amount): {1:N0} VNĐ\n" +
                    "Tổng thuế (Tax): {2:N0} VNĐ\n" +
                    "Tổng giảm giá (Discount): {3:N0} VNĐ",
                    totalBills, totalAmount, totalTax, totalDiscount);

                // 4. HIỂN THỊ DANH SÁCH HÓA ĐƠN
                var historyList = paidBills.Select(b => new
                {
                    MaHD = b.ID,
                    TenHoaDon = b.Name,
                    NhanVien = b.AccountInfo != null ? b.AccountInfo.FullName : b.Account,
                    NgayThanhToan = b.CheckoutDate,
                    TongTien = b.Amount,
                    Thue = b.Tax,
                    GiamGia = b.Discount
                }).ToList();

                dgvPurchaseLog.DataSource = historyList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải nhật ký bán hàng: " + ex.Message);
            }
        }

        // 5. Nhớ Dispose Context
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                _context.Dispose(); // ⬅️ Thêm dòng này
            }
            base.Dispose(disposing);
        }


    }
}