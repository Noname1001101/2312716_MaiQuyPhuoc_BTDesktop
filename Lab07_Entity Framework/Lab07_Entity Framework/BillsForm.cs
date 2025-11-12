using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Lab07_Entity_Framework.Models;
using System.Data.Entity;

namespace Lab07_Entity_Framework
{
    public partial class BillsForm : Form
    {
        private RestaurantContext _context;
        private int _tableId;

        private DateTime _previousFromDate;
        private DateTime _previousToDate;

        public BillsForm(int tableID)
        {
            InitializeComponent();
            _context = new RestaurantContext();
            _tableId = tableID;
        }

        private void BillsForm_Load(object sender, EventArgs e)
        {
            dgvBills.AutoGenerateColumns = false;

            dtpTuNgay.Value = new DateTime(2024, 1, 1);
            dtpDenNgay.Value = new DateTime(2024, 12, 30);

            _previousFromDate = dtpTuNgay.Value;
            _previousToDate = dtpDenNgay.Value;

            

            LoadBillsByDate(); // Tải lần đầu
        }

        private void LoadBillsByDate()
        {
            try
            {
                

                var query = _context.Bills
                    .Where(b => b.TableID == _tableId); // Lọc theo bàn

                DateTime fromDate = dtpTuNgay.Value.Date;
                DateTime toDate = dtpDenNgay.Value.Date.AddDays(1);

                query = query.Where(b => b.CheckoutDate != null &&
                                         b.CheckoutDate >= fromDate &&
                                         b.CheckoutDate < toDate);

                var bills = query
                    .OrderByDescending(b => b.CheckoutDate)
                    .Select(b => new
                    {
                        ID = b.ID,
                        TableID = b.TableID,
                        CheckoutDate = b.CheckoutDate,
                        Name = b.Name,
                        Amount = b.Amount,
                        Tax = b.Tax,
                        Discount = b.Discount,
                        FinalTotal = b.Amount - (b.Discount ?? 0) + (b.Tax ?? 0),
                        Status = b.Status ? "Đã thanh toán" : "Chưa thanh toán",
                        Account = b.Account
                    })
                    .ToList();

               

                dgvBills.DataSource = bills;
            }
            catch (Exception ex)
            {
                string errorMessage = "Lỗi khi tải danh sách hóa đơn.\n\n";
                errorMessage += "Message: " + ex.Message;
                if (ex.InnerException != null)
                {
                    errorMessage += "\n\nInner Exception: " + ex.InnerException.Message;
                }
                MessageBox.Show(errorMessage, "Lỗi Chi Tiết", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ... (các hàm còn lại giữ nguyên) ...

        private void dgvBills_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                var billID = (int)dgvBills.Rows[e.RowIndex].Cells["colID"].Value;
                BillDetailsForm detailsForm = new BillDetailsForm(billID);
                detailsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở chi tiết: " + ex.Message);
            }
        }

        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            LoadBillsByDate();
        }

        private void BillsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Dispose();
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Lỗi Ngày", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpTuNgay.Value = _previousFromDate;
            }
            else
            {
                _previousFromDate = dtpTuNgay.Value;
                LoadBillsByDate();
            }
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDenNgay.Value.Date < dtpTuNgay.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu.", "Lỗi Ngày", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDenNgay.Value = _previousToDate;
            }
            else
            {
                _previousToDate = dtpDenNgay.Value;
                LoadBillsByDate();
            }
        }
    }
}