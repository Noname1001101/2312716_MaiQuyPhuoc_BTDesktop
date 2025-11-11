using Lab07_Entity_Framework.Models; // ⬅️ THÊM

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;           // ⬅️ THÊM
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lab07_Entity_Framework // ⬅️ Đổi namespace thành Lab07 (nếu cần)
{
    public partial class TableForm : Form
    {
        private RestaurantContext _context;
        private List<Button> selectedButtons = new List<Button>();
        private Button selectedButton = null;
        private Button rightClickedButton = null;

        public TableForm()
        {
            InitializeComponent();
            _context = new RestaurantContext(); // Khởi tạo Context
            LoadTableList();
        }

        // ================== HIỂN THỊ DANH SÁCH BÀN (Refactored) ==================
        public void LoadTableList()
        {
            // Tải lại Context để refresh
            _context.Dispose();
            _context = new RestaurantContext();

            flpBan.Controls.Clear();
            selectedButtons.Clear();
            selectedButton = null;
            rightClickedButton = null;

            // Dùng Entity Framework
            var tables = _context.Tables.OrderBy(t => t.Name).ToList();

            foreach (var table in tables)
            {
                var statusText = table.Status == 0 ? "Trống" : "Có khách";
                var btn = CreateTableButton(table.ID, table.Name, statusText);
                flpBan.Controls.Add(btn);
            }
        }

        // (Hàm này giữ nguyên code cũ của bạn)
        private Button CreateTableButton(int id, string name, string status)
        {
            var btn = new Button
            {
                Text = $"{name}\n({status})",
                Width = 100,
                Height = 100,
                Tag = id,
                BackColor = status == "Trống" ? Color.LightGray : Color.LightSalmon,
                ContextMenuStrip = cmsBan
            };
            btn.Click += btn_Click;
            btn.MouseDown += btn_MouseDown;
            return btn;
        }

        // ================== XỬ LÝ CLICK (Giữ nguyên) ==================
        private void btn_Click(object sender, EventArgs e)
        {
            selectedButton = sender as Button;
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (!selectedButtons.Contains(selectedButton))
                {
                    selectedButtons.Add(selectedButton);
                    selectedButton.BackColor = Color.LightSkyBlue;
                }
                else
                {
                    selectedButtons.Remove(selectedButton);
                    var table = _context.Tables.Find((int)selectedButton.Tag);
                    selectedButton.BackColor = table.Status == 0 ? Color.LightGray : Color.LightSalmon;
                }
            }
            else
            {
                ClearSelection();
                selectedButtons.Add(selectedButton);
                selectedButton.BackColor = Color.LightSkyBlue;
            }
        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rightClickedButton = sender as Button;
            }
        }

        private void ClearSelection()
        {
            foreach (var btn in selectedButtons)
            {
                var table = _context.Tables.Find((int)btn.Tag);
                if (table != null)
                    btn.BackColor = table.Status == 0 ? Color.LightGray : Color.LightSalmon;
                else
                    btn.BackColor = Color.LightGray;
            }
            selectedButtons.Clear();
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            ClearSelection();
        }

        // Hàm trợ giúp lấy ID từ nút được chọn
        private int? GetSelectedTableId(Button buttonToCheck)
        {
            if (buttonToCheck == null)
            {
                MessageBox.Show("Vui lòng chọn một bàn.");
                return null;
            }
            return (int)buttonToCheck.Tag;
        }

        // ================== THÊM / SỬA / XÓA (Refactored) ==================

        // Yêu cầu: Thêm bàn
        private void bntThemBan_Click(object sender, EventArgs e)
        {
            // Mở Form TableAddUpdate (bạn đã có)
            TableAddUpdate form = new TableAddUpdate(); // Chế độ Thêm (ID = 0)
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadTableList(); // Tải lại nếu thành công
            }
        }

        // Yêu cầu: Cập nhật bàn
        private void bntCapNhatBan_Click(object sender, EventArgs e)
        {
            var tableId = GetSelectedTableId(selectedButton); // Lấy bàn đang chọn (click trái)
            if (tableId == null) return;

            TableAddUpdate form = new TableAddUpdate(tableId.Value); // Chế độ Sửa
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadTableList(); // Tải lại
            }
        }

        // Yêu cầu: Xóa bàn
        private void bntXoa_Click(object sender, EventArgs e)
        {
            if (selectedButtons.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một bàn để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa các bàn đã chọn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                foreach (var btn in selectedButtons)
                {
                    int tableId = (int)btn.Tag;
                    var table = _context.Tables.Find(tableId);
                    if (table != null)
                    {
                        _context.Tables.Remove(table);
                    }
                }
                _context.SaveChanges();
                LoadTableList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa bàn. Bàn có thể đã có hóa đơn. \n" + ex.Message, "Lỗi khóa ngoại");
            }
        }

        // ================== MENU CHUỘT PHẢI (Refactored) ==================

        // Yêu cầu: Xóa bàn (Menu chuột phải)
        private void tsmiXoa1Ban_Click(object sender, EventArgs e)
        {
            var tableId = GetSelectedTableId(rightClickedButton); // Lấy bàn click phải
            if (tableId == null) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa bàn này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                var table = _context.Tables.Find(tableId.Value);
                if (table != null)
                {
                    _context.Tables.Remove(table);
                    _context.SaveChanges();
                    LoadTableList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa bàn. Bàn có thể đã có hóa đơn. \n" + ex.Message, "Lỗi khóa ngoại");
            }
        }

        // Yêu cầu: Xem hóa đơn hiện tại
        private void xemHóaĐơnHiệnTạiCủa1BànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tableId = GetSelectedTableId(rightClickedButton);
            if (tableId == null) return;

            // Tìm hóa đơn CHƯA THANH TOÁN (Status = 0) của bàn này
            var currentBill = _context.Bills
                .FirstOrDefault(b => b.TableID == tableId.Value && b.Status == false);

            if (currentBill == null)
            {
                MessageBox.Show("Bàn này hiện đang trống, không có hóa đơn.");
                return;
            }

            // Mở form BillDetailsForm (bạn đã có)
            BillDetailsForm detailsForm = new BillDetailsForm(currentBill.ID);
            detailsForm.ShowDialog();
        }

        // Yêu cầu: Xem danh mục hóa đơn
        private void tsmiXemDMHD_Click(object sender, EventArgs e)
        {
            var tableId = GetSelectedTableId(rightClickedButton);
            if (tableId == null) return;

            // Mở form BillsForm (bạn đã có)
            BillsForm billsForm = new BillsForm(tableId.Value);
            billsForm.ShowDialog();
        }

        // Yêu cầu: Xem nhật ký bán hàng
        private void tsmiXemNKHD_Click(object sender, EventArgs e)
        {
            // Mở form PurchaseHistoryForm (bạn đã có)
            PurchaseHistoryForm historyForm = new PurchaseHistoryForm();
            historyForm.ShowDialog();
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