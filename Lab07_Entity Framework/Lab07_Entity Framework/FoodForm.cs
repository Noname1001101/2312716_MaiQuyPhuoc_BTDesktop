using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Lab07_Entity_Framework.Models;
using System.Data.Entity; // 🔹 Nhớ thêm

namespace Lab07_Entity_Framework
{
    public partial class FoodForm : Form
    {
        private RestaurantContext _context;

        public FoodForm()
        {
            InitializeComponent();
            _context = new RestaurantContext();
        }

        private void FoodForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadFoods();

        }

        // 🔹 Nạp danh sách Nhóm món ăn vào ComboBox
        private void LoadCategories()
        {
            var categories = _context.Categories.ToList();
            categories.Insert(0, new Category { Id = 0, Name = "Tất cả" });

            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
        }

        // 🔹 Nạp danh sách Món ăn (Yêu cầu 1 và 2)
        private void LoadFoods()
        {
            // Bắt đầu truy vấn, dùng Include để lấy CategoryName
            var query = _context.Foods
                                .Include(f => f.Category)
                                .AsQueryable();

            // Lọc theo Nhóm (Category)
            if (cboCategory.SelectedIndex > 0)
            {
                var categoryId = (int)cboCategory.SelectedValue;
                query = query.Where(f => f.FoodCategoryId == categoryId);
            }

            // Lọc theo Tên (Search)
            string searchName = txtSearchName.Text.Trim();
            if (!string.IsNullOrEmpty(searchName))
            {
                query = query.Where(f => f.Name.Contains(searchName));
            }

            // 🔹 Dùng FoodModel (ViewModel) mà giảng viên của bạn đã cung cấp
            var foodsForDisplay = query
                .OrderBy(f => f.Name)
                .Select(food => new FoodModel // Chuyển từ Food (Entity) sang FoodModel (ViewModel)
                {
                    Id = food.Id,
                    Name = food.Name,
                    Unit = food.Unit,
                    Price = food.Price,
                    Notes = food.Notes,
                    CategoryName = food.Category.Name // Đây là lý do cần ViewModel
                })
                .ToList();

            dgvFoods.DataSource = foodsForDisplay;
        }

        // 🔹 Thêm món ăn (Yêu cầu 3)
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            // Mở form UpdateFoodForm (bạn đã có) ở chế độ "Thêm"
            // Gọi constructor không tham số (foodId = null)
            UpdateFoodForm form = new UpdateFoodForm();
            var result = form.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                LoadFoods(); // Tải lại danh sách nếu thêm thành công
            }
        }

        // 🔹 Sửa món ăn (Yêu cầu 3)
        private void btnEditFood_Click(object sender, EventArgs e)
        {
            if (dgvFoods.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần sửa.");
                return;
            }

            // Lấy ID của món ăn từ DataGridView
            // Dùng DataBoundItem sẽ an toàn hơn
            var selectedFood = dgvFoods.SelectedRows[0].DataBoundItem as FoodModel;
            if (selectedFood == null) return;

            int foodId = selectedFood.Id;

            // Mở form UpdateFoodForm (bạn đã có) ở chế độ "Sửa"
            UpdateFoodForm form = new UpdateFoodForm(foodId); // ⬅️ Truyền ID vào
            var result = form.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                LoadFoods(); // Tải lại danh sách nếu sửa thành công
            }
        }

        // 🔹 Xóa món ăn (Yêu cầu 4)
        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            if (dgvFoods.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một món ăn để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa các món ăn đã chọn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                var idsToDelete = new List<int>();
                foreach (DataGridViewRow row in dgvFoods.SelectedRows)
                {
                    var food = row.DataBoundItem as FoodModel;
                    if (food != null)
                    {
                        idsToDelete.Add(food.Id);
                    }
                }

                // Xóa nhiều dòng hiệu quả
                var foodsToDelete = _context.Foods
                    .Where(f => idsToDelete.Contains(f.Id))
                    .ToList();

                _context.Foods.RemoveRange(foodsToDelete);
                _context.SaveChanges();

                LoadFoods(); // Tải lại danh sách
            }
            catch (Exception ex)
            {
                // Có thể lỗi do khóa ngoại (nếu món ăn đã được bán)
                MessageBox.Show("Lỗi khi xóa món ăn. Có thể món ăn đã nằm trong hóa đơn? \n" + ex.Message);
            }
        }

        // 🔹 Thêm nhóm món ăn (Yêu cầu 5)
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            // Mở form UpdateCategoryForm (bạn đã có)
            // Gọi constructor không tham số (categoryId = null)
            UpdateCategoryForm form = new UpdateCategoryForm();
            var result = form.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                LoadCategories(); // Tải lại ComboBox nhóm
            }
        }

        // 🔹 Nhớ Dispose Context
        private void FoodForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Dispose();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFoods();
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            LoadFoods();
        }
    }
}