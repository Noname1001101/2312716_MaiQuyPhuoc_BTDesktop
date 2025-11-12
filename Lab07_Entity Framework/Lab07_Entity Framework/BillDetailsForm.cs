using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Lab07_Entity_Framework.Models; // ⬅️ THÊM
using System.Data.Entity;           // ⬅️ THÊM

namespace Lab07_Entity_Framework // ⬅️ Đổi namespace
{
    public partial class BillDetailsForm : Form
    {
        private RestaurantContext _context;
        private int _billId;

        public BillDetailsForm(int billId)
        {
            InitializeComponent();
            _context = new RestaurantContext();
            this._billId = billId;
        }

        private void BillDetailsForm_Load(object sender, EventArgs e)
        {
            LoadBillDetails();
        }

        private void LoadBillDetails()
        {
            try
            {
                // === SỬA LỖI 2: Tắt tính năng tự động tạo cột ===
                // Điều này sẽ ngăn các cột colName, colUnit... tự động xuất hiện
                dgvBillDetails.AutoGenerateColumns = false;

                // Dùng EF và LINQ thay cho SQL query
                var billDetails = _context.BillDetails
                    .Where(bd => bd.BillID == _billId)
                    .Include(bd => bd.Food.Category) // Tải kèm Food và Category
                    .Select(bd => new
                    {
                        // Giữ nguyên các tên này, chúng ta sẽ dùng ở Bước 2
                        Name = bd.Food.Name,
                        Unit = bd.Food.Unit,
                        Quantity = bd.Quantity,
                        Price = bd.Food.Price,
                        Total = bd.Quantity * bd.Food.Price,
                        Notes = bd.Food.Notes,
                        CategoryName = bd.Food.Category.Name
                    })
                    .ToList();

                // Gán DataSource như bình thường
                dgvBillDetails.DataSource = billDetails;

                // === SỬA LỖI 1: Tính tổng từ danh sách (list) ===
                // KHÔNG dùng vòng lặp DataGridView vì nó không an toàn
                // Thay vào đó, tính tổng trực tiếp từ 'billDetails' list
                decimal total = 0;
                if (billDetails != null)
                {
                    total = billDetails.Sum(item => item.Total);
                }

                // Cập nhật nhãn (label) tổng tiền
                lblTotalAmount.Text = $"Tổng thành tiền: {total:N0} VND";

                // Chúng ta không cần hàm UpdateTotalLabel() nữa
                // UpdateTotalLabel(); // ⬅️ Xóa hoặc vô hiệu hóa dòng này
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết hóa đơn: " + ex.Message, "Lỗi",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm này giữ nguyên logic cũ của bạn (tính tổng trên grid)
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

        // Nhớ Dispose Context
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