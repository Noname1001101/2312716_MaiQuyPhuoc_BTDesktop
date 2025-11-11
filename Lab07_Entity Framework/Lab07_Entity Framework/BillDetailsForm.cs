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
                // Dùng EF và LINQ thay cho SQL query
                var billDetails = _context.BillDetails
                    .Where(bd => bd.BillID == _billId)
                    .Include(bd => bd.Food.Category) // Tải kèm Food và Category
                    .Select(bd => new
                    {
                        colName = bd.Food.Name,
                        colUnit = bd.Food.Unit,
                        colQuantity = bd.Quantity,
                        colPrice = bd.Food.Price,
                        colTotal = bd.Quantity * bd.Food.Price,
                        colNotes = bd.Food.Notes,
                        colCategory = bd.Food.Category.Name
                    })
                    .ToList();

                dgvBillDetails.DataSource = billDetails;

                // Cập nhật lại tên cột (nếu tên trong Designer khác)
                dgvBillDetails.Columns["colName"].HeaderText = "Tên món";
                dgvBillDetails.Columns["colUnit"].HeaderText = "Đơn vị";
                dgvBillDetails.Columns["colQuantity"].HeaderText = "Số lượng";
                dgvBillDetails.Columns["colPrice"].HeaderText = "Đơn giá";
                dgvBillDetails.Columns["colTotal"].HeaderText = "Thành tiền";
                dgvBillDetails.Columns["colNotes"].HeaderText = "Ghi chú";
                dgvBillDetails.Columns["colCategory"].HeaderText = "Loại";

                UpdateTotalLabel();
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