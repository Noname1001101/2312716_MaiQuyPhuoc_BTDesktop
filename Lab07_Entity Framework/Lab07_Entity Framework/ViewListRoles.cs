using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Lab07_Entity_Framework.Models; // 🔹 Thêm
using System.Data.Entity;           // 🔹 Thêm
using System.ComponentModel;
namespace Lab07_Entity_Framework
{
    public partial class ViewListRoleForm : Form
    {
        private RestaurantContext _context;
        private string _username;

        public ViewListRoleForm(string username)
        {
            InitializeComponent();
            _context = new RestaurantContext();
            _username = username;
            lblVaiTroTK.Text = username;
            LoadRoles();
        }

        // 🔹 Nạp danh sách vai trò - Dùng EF và ViewModel
        private void LoadRoles()
        {
            // Lấy tất cả vai trò
            var allRoles = _context.Roles.ToList();

            // Lấy các vai trò mà tài khoản này đang có
            var userRoles = _context.RoleAccounts
                .Where(ra => ra.AccountName == _username)
                .ToList();

            // 🔹 Dùng ViewModel
            var data = allRoles.Select(role => new RoleAssignmentViewModel
            {
                RoleID = role.Id,
                RoleName = role.RoleName,
                Assigned = userRoles.Any(ur => ur.RoleID == role.Id && ur.Actived == true),
                Notes = role.Notes
            }).ToList(); // ⬅️ Dùng ToList() như ban đầu!

            // 3. Gán DataSource bằng List<T> đơn giản
            dgvRoles.AutoGenerateColumns = false;
            dgvRoles.DataSource = data;
        }

        // 🔹 Cập nhật vai trò - Dùng EF
     
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // 1. Ép DataGridView commit (lưu) bất kỳ ô nào đang sửa
            // (VD: Sửa "Quầy phục vụ" thành "Quầy thanh toán")
            dgvRoles.EndEdit(); // ⬅️ QUAN TRỌNG: Thêm dòng này

            try
            {
                foreach (DataGridViewRow row in dgvRoles.Rows)
                {
                    // Bỏ qua dòng trống (mặc dù bây giờ đã tắt)
                    if (row.IsNewRow) continue;

                    var rowData = row.DataBoundItem as RoleAssignmentViewModel;
                    if (rowData == null) continue;

                    // ===== PHẦN A: CẬP NHẬT "ĐƯỢC GÁN" (code cũ của bạn) =====

                    bool assigned = rowData.Assigned;
                    int roleId = rowData.RoleID;

                    // Bỏ qua nếu là dòng mới (mặc dù đã tắt)
                    if (roleId == 0) continue;

                    var existingLink = _context.RoleAccounts.Find(roleId, _username);

                    if (assigned)
                    {
                        if (existingLink == null) // Nếu chưa có link thì tạo
                        {
                            var newLink = new RoleAccount { RoleID = roleId, AccountName = _username, Actived = true };
                            _context.RoleAccounts.Add(newLink);
                        }
                        else // Nếu có link rồi thì kích hoạt
                        {
                            existingLink.Actived = true;
                        }
                    }
                    else // Nếu bỏ check
                    {
                        if (existingLink != null) // Nếu có link thì xóa
                        {
                            _context.RoleAccounts.Remove(existingLink);
                        }
                    }

                    // ===== PHẦN B: CẬP NHẬT TÊN VAI TRÒ / GHI CHÚ (PHẦN MỚI) =====

                    // Tìm Role gốc trong CSDL
                    var roleInDb = _context.Roles.Find(roleId);
                    if (roleInDb != null)
                    {
                        // Lấy giá trị mới từ ViewModel (đã được dgvRoles.EndEdit() cập nhật)
                        string newName = rowData.RoleName?.Trim();
                        string newNotes = rowData.Notes?.Trim();

                        // So sánh xem có thay đổi không
                        if (roleInDb.RoleName != newName || roleInDb.Notes != newNotes)
                        {
                            if (!string.IsNullOrWhiteSpace(newName))
                            {
                                // Cập nhật Entity gốc
                                roleInDb.RoleName = newName;
                                roleInDb.Notes = newNotes;
                            }
                            else
                            {
                                MessageBox.Show($"Không thể cập nhật RoleID {roleId} vì Tên vai trò bị trống.");
                            }
                        }
                    }
                    // =========================================================
                }

                // Lưu tất cả thay đổi (cả gán vai trò và sửa tên) trong 1 lần
                _context.SaveChanges();
                MessageBox.Show("Cập nhật vai trò thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
            finally
            {
                // Tải lại để thấy thay đổi
                LoadRoles();
            }
        }

        // 🔹 Thêm vai trò mới (vào bảng Role) - Dùng EF

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            // 1. Tạo và mở Form popup
            AddRoleForm form = new AddRoleForm();
            var result = form.ShowDialog(this);

            // 2. Nếu Form kia báo là đã LƯU OK
            if (result == DialogResult.OK)
            {
                // 3. Tải lại danh sách để thấy vai trò mới
                LoadRoles();
            }
        }

        // 🔹 Nhớ Dispose Context
        private void ViewListRoleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_context != null)
                _context.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}