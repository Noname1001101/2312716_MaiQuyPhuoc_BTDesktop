using System;
using System.Linq;
using System.Windows.Forms;
using Lab07_Entity_Framework.Models;

namespace Lab07_Entity_Framework
{
    public partial class TableAddUpdate : Form
    {
        private RestaurantContext _context;
        private int _tableId;

        public TableAddUpdate(int tableId = 0)
        {
            InitializeComponent();
            _context = new RestaurantContext();
            _tableId = tableId;
        }

        private void UpdateTableForm_Load(object sender, EventArgs e)
        {
            if (_tableId == 0) // Chế độ Thêm mới
            {
                this.Text = "Thêm bàn mới";
                cboStatus.SelectedIndex = 0; // Mặc định là Trống
            }
            else // Chế độ Cập nhật
            {
                this.Text = "Cập nhật thông tin bàn";
                var table = _context.Tables.Find(_tableId);
                if (table != null)
                {
                    txtTableID.Text = table.ID.ToString();
                    txtTableName.Text = table.Name;
                    nudCapacity.Value = table.Capacity;
                    cboStatus.SelectedIndex = table.Status;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTableName.Text))
            {
                MessageBox.Show("Tên bàn không được để trống.", "Lỗi");
                return;
            }

            try
            {
                if (_tableId == 0) // Thêm mới
                {
                    var newTable = new DiningTable
                    {
                        Name = txtTableName.Text.Trim(),
                        Capacity = (int)nudCapacity.Value,
                        Status = cboStatus.SelectedIndex // 0 = Trống, 1 = Có khách
                    };
                    _context.Tables.Add(newTable);
                }
                else // Cập nhật
                {
                    var table = _context.Tables.Find(_tableId);
                    if (table != null)
                    {
                        table.Name = txtTableName.Text.Trim();
                        table.Capacity = (int)nudCapacity.Value;
                        table.Status = cboStatus.SelectedIndex;
                    }
                }

                _context.SaveChanges();
                this.DialogResult = DialogResult.OK; // Báo thành công
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
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