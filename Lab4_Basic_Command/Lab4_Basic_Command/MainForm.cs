#region code cũ
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Drawing;
//using System.Linq;
//using System.Windows.Forms;

//namespace Lab4_Basic_Command
//{
//    public partial class MainForm : Form
//    {
//        private readonly string connectionString =
//            "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";



//        public MainForm()
//        {
//            InitializeComponent();
//            LoadTableList(); // Hiển thị danh sách bàn khi mở form


//        }
//        public void LoadTableList()
//        {
//            flpBan.Controls.Clear(); // Xóa các bàn cũ trước khi load lại

//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                string query = "SELECT * FROM [Table]";

//                SqlCommand cmd = new SqlCommand(query, conn);

//                conn.Open();
//                SqlDataReader reader = cmd.ExecuteReader();

//                while (reader.Read())
//                {
//                    Button btn = new Button();
//                    btn.Width = 100;
//                    btn.Height = 60;

//                    string tableName = reader["Name"].ToString();   // ✅ đọc tên bàn
//                    string statusValue = reader["Status"].ToString();
//                    string statusText = (statusValue == "0") ? "Trống" : "Có khách";

//                    btn.Text = tableName + Environment.NewLine + statusText; // ✅ sửa ở đây

//                    if (statusValue == "0")
//                        btn.BackColor = System.Drawing.Color.Honeydew;
//                    else
//                        btn.BackColor = System.Drawing.Color.MediumSeaGreen;

//                    btn.ForeColor = System.Drawing.Color.Black;
//                    btn.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
//                    btn.FlatStyle = FlatStyle.Flat;
//                    btn.FlatAppearance.BorderSize = 0;

//                    // ✅ lưu ID bàn để dùng khi xem hóa đơn
//                    btn.Tag = reader["ID"];
//                    btn.Click += BtnBan_Click;
//                    btn.MouseDown += btn_MouseDown;
//                    flpBan.Controls.Add(btn);
//                }


//                conn.Close();
//            }
//        }


//        private void ShowBill(int tableID)
//        {
//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                string query = @"
//            SELECT f.Name AS FoodName, f.Unit, bd.Quantity, f.Price, 
//                   (bd.Quantity * f.Price) AS Total
//            FROM BillDetails bd
//            JOIN Bills b ON bd.InvoiceID = b.ID
//            JOIN Food f ON bd.FoodID = f.ID
//            WHERE b.TableID = @tableID AND b.Status = @status";

//                SqlCommand cmd = new SqlCommand(query, conn);
//                cmd.Parameters.AddWithValue("@tableID", tableID);
//                cmd.Parameters.Add("@status", SqlDbType.Bit).Value = false;  // false = chưa thanh toán

//                conn.Open();
//                SqlDataReader reader = cmd.ExecuteReader();

//                string billText = "";
//                decimal totalAmount = 0;

//                while (reader.Read())
//                {
//                    string foodName = reader["FoodName"].ToString();
//                    string unit = reader["Unit"].ToString();
//                    int quantity = Convert.ToInt32(reader["Quantity"]);
//                    decimal price = Convert.ToDecimal(reader["Price"]);
//                    decimal total = Convert.ToDecimal(reader["Total"]);

//                    billText += $"{foodName} ({unit}) - SL: {quantity}, Giá: {price:N0}, Thành tiền: {total:N0}\n";
//                    totalAmount += total;
//                }

//                reader.Close();

//                if (string.IsNullOrEmpty(billText))
//                {
//                    MessageBox.Show("Bàn này hiện chưa có hóa đơn chưa thanh toán.", "Thông báo");
//                }
//                else
//                {
//                    MessageBox.Show(billText + $"\n--------------------\nTổng cộng: {totalAmount:N0} VNĐ",
//                                    $"Hóa đơn hiện tại của bàn {tableID}");
//                }

//                conn.Close();
//            }
//        }



//        private Button selectedButton = null;

//        private void BtnBan_Click(object sender, EventArgs e)
//        {
//            Button clickedButton = sender as Button;

//            // Nếu nhấn Ctrl → chọn/bỏ chọn nhiều bàn
//            if ((ModifierKeys & Keys.Control) == Keys.Control)
//            {
//                if (selectedButtons.Contains(clickedButton))
//                {
//                    // Bỏ chọn
//                    clickedButton.FlatAppearance.BorderSize = 0;
//                    selectedButtons.Remove(clickedButton);
//                }
//                else
//                {
//                    // Chọn thêm
//                    clickedButton.FlatStyle = FlatStyle.Flat;
//                    clickedButton.FlatAppearance.BorderSize = 3;
//                    clickedButton.FlatAppearance.BorderColor = Color.Black;
//                    selectedButtons.Add(clickedButton);
//                }
//            }
//            else
//            {
//                // Nếu không nhấn Ctrl → chọn 1 bàn duy nhất
//                foreach (Button btn in selectedButtons)
//                    btn.FlatAppearance.BorderSize = 0;
//                selectedButtons.Clear();

//                clickedButton.FlatStyle = FlatStyle.Flat;
//                clickedButton.FlatAppearance.BorderSize = 3;
//                clickedButton.FlatAppearance.BorderColor = Color.Black;
//                selectedButtons.Add(clickedButton);
//            }
//            selectedButton = clickedButton;
//        }


//        private void flpBan_Click(object sender, EventArgs e)
//        {
//            if (selectedButton != null)
//            {
//                selectedButton.FlatAppearance.BorderSize = 0;
//                selectedButton = null;
//            }
//        }

//        private void MainForm_Click(object sender, EventArgs e)
//        {
//            if (selectedButton != null)
//            {
//                selectedButton.FlatAppearance.BorderSize = 0;
//                selectedButton = null;
//            }

//            // Bỏ viền tất cả bàn
//            foreach (Button btn in flpBan.Controls)
//                btn.FlatAppearance.BorderSize = 0;

//        }

//        private void btnThemBan_Click(object sender, EventArgs e)
//        {
//            TableAddUpdate form = new TableAddUpdate(this);
//            form.isEditMode = false;
//            form.ShowDialog();
//        }

//        private void btnSuaBan_Click(object sender, EventArgs e)
//        {
//            if (selectedButton == null)
//            {
//                MessageBox.Show("Vui lòng chọn bàn để sửa!", "Thông báo");
//                return;
//            }

//            int id = Convert.ToInt32(selectedButton.Tag);

//            TableAddUpdate form = new TableAddUpdate(this, id);
//            form.isEditMode = true;
//            form.ShowDialog();
//        }

//        private void tsmiXemHD_Click(object sender, EventArgs e)
//        {
//            // Chỉ cho xem hóa đơn nếu có bàn đang được chọn (bôi đen)
//            if (selectedButtons.Count == 0)
//            {
//                MessageBox.Show("Vui lòng chọn bàn trước khi xem hóa đơn!", "Thông báo",
//                                MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }

//            // Nếu có nhiều bàn được chọn thì lấy bàn đầu tiên
//            Button selected = selectedButtons[0];
//            int tableID = Convert.ToInt32(selected.Tag);

//            BillsForm billForm = new BillsForm(tableID);
//            billForm.ShowDialog();
//        }



//        private List<Button> selectedButtons = new List<Button>();

//        private void bntXoa_Click(object sender, EventArgs e)
//        {
//            if (selectedButtons.Count == 0)
//            {
//                MessageBox.Show("Vui lòng chọn ít nhất một bàn để xóa!", "Thông báo",
//                                MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }

//            if (MessageBox.Show($"Bạn có chắc muốn xóa {selectedButtons.Count} bàn đã chọn?",
//                                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
//            {
//                using (SqlConnection conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();
//                    foreach (Button btn in selectedButtons)
//                    {
//                        int id = Convert.ToInt32(btn.Tag);
//                        string query = "DELETE FROM [Table] WHERE ID = @id";
//                        using (SqlCommand cmd = new SqlCommand(query, conn))
//                        {
//                            cmd.Parameters.AddWithValue("@id", id);
//                            cmd.ExecuteNonQuery();
//                        }
//                    }
//                    conn.Close();
//                }

//                MessageBox.Show("Đã xóa các bàn được chọn.", "Thông báo",
//                                MessageBoxButtons.OK, MessageBoxIcon.Information);

//                LoadTableList();
//                selectedButtons.Clear();
//            }
//        }

//        private Button rightClickedButton = null;

//        private void btn_MouseDown(object sender, MouseEventArgs e)
//        {
//            if (e.Button == MouseButtons.Right)
//            {
//                rightClickedButton = sender as Button;
//                cmsBan.Show(Cursor.Position); // hiển thị menu tại vị trí chuột
//            }
//        }


//        private void tsmiXoa1Ban_Click(object sender, EventArgs e)
//        {
//            if (rightClickedButton == null) return;

//            int id = Convert.ToInt32(rightClickedButton.Tag);

//            if (MessageBox.Show($"Bạn có chắc muốn xóa bàn {rightClickedButton.Text}?",
//                                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
//            {
//                using (SqlConnection conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();
//                    string query = "DELETE FROM [Table] WHERE ID = @id";
//                    SqlCommand cmd = new SqlCommand(query, conn);
//                    cmd.Parameters.AddWithValue("@id", id);
//                    cmd.ExecuteNonQuery();
//                    conn.Close();
//                }

//                MessageBox.Show("Đã xóa bàn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                LoadTableList();
//            }
//        }

//        private void tsmiXemDMHD_Click(object sender, EventArgs e)
//        {
//            BillsByDateForm frm = new BillsByDateForm();
//            frm.ShowDialog();
//        }

//        private void tsmiXemNKHD_Click(object sender, EventArgs e)
//        {

//            PurchaseLogForm frm = new PurchaseLogForm();
//            frm.ShowDialog();
//        }

//        private void btnCategory_Click(object sender, EventArgs e)
//        {
//            CategoryForm f1 = new CategoryForm();
//            f1.ShowDialog();
//        }

//        private void btnAccount_Click(object sender, EventArgs e)
//        {
//            AccountManagerForm f2 = new AccountManagerForm();  
//            f2.ShowDialog();
//        }
//    }
//}
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class MainForm : Form
    {
        private readonly string connectionString =
            "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";

        private readonly List<Button> selectedButtons = new List<Button>();
        private Button selectedButton = null;
        private Button rightClickedButton = null;

        public MainForm()
        {
            InitializeComponent();
            LoadTableList();
        }

        // ================== HIỂN THỊ DANH SÁCH BÀN ==================
        public void LoadTableList()
        {
            flpBan.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Table]", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var btn = CreateTableButton(
                        (int)reader["ID"],
                        reader["Name"].ToString(),
                        reader["Status"].ToString()
                    );
                    flpBan.Controls.Add(btn);
                }
            }
        }

        private Button CreateTableButton(int id, string name, string status)
        {
            string statusText = (status == "0") ? "Trống" : "Có khách";
            Color backColor = (status == "0") ? Color.Honeydew : Color.MediumSeaGreen;

            Button btn = new Button
            {
                Width = 100,
                Height = 60,
                Text = $"{name}\n{statusText}",
                BackColor = backColor,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Tag = id
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += BtnBan_Click;
            btn.MouseDown += Btn_MouseDown;

            return btn;
        }

        //// ================== HIỂN THỊ HÓA ĐƠN ==================
        //private void ShowBill(int tableID)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        string query = @"
        //            SELECT f.Name AS FoodName, f.Unit, bd.Quantity, f.Price, 
        //                   (bd.Quantity * f.Price) AS Total
        //            FROM BillDetails bd
        //            JOIN Bills b ON bd.InvoiceID = b.ID
        //            JOIN Food f ON bd.FoodID = f.ID
        //            WHERE b.TableID = @tableID AND b.Status = @status";

        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@tableID", tableID);
        //        cmd.Parameters.Add("@status", SqlDbType.Bit).Value = false;

        //        conn.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        string billText = "";
        //        decimal total = 0;

        //        while (reader.Read())
        //        {
        //            decimal lineTotal = Convert.ToDecimal(reader["Total"]);
        //            billText += $"{reader["FoodName"]} ({reader["Unit"]}) - SL: {reader["Quantity"]}, " +
        //                        $"Giá: {reader["Price"]:N0}, Thành tiền: {lineTotal:N0}\n";
        //            total += lineTotal;
        //        }

        //        MessageBox.Show(
        //            string.IsNullOrEmpty(billText)
        //                ? "Bàn này hiện chưa có hóa đơn chưa thanh toán."
        //                : billText + $"\n--------------------\nTổng cộng: {total:N0} VNĐ",
        //            $"Hóa đơn bàn {tableID}"
        //        );
        //    }
        //}

        // ================== CHỌN / BỎ CHỌN BÀN ==================
        private void BtnBan_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            bool isCtrl = (ModifierKeys & Keys.Control) == Keys.Control;

            if (!isCtrl)
            {
                foreach (var b in selectedButtons) b.FlatAppearance.BorderSize = 0;
                selectedButtons.Clear();
            }

            if (selectedButtons.Contains(btn))
            {
                btn.FlatAppearance.BorderSize = 0;
                selectedButtons.Remove(btn);
            }
            else
            {
                btn.FlatAppearance.BorderSize = 3;
                btn.FlatAppearance.BorderColor = Color.Black;
                selectedButtons.Add(btn);
            }

            selectedButton = btn;
        }

        private void UnselectAll()
        {
            foreach (Button btn in selectedButtons)
                btn.FlatAppearance.BorderSize = 0;
            selectedButtons.Clear();
            selectedButton = null;
        }

        private void flpBan_Click(object sender, EventArgs e) => UnselectAll();
        private void MainForm_Click(object sender, EventArgs e) => UnselectAll();

        // ================== MENU CHUỘT PHẢI ==================
        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rightClickedButton = sender as Button;
                cmsBan.Show(Cursor.Position);
            }
        }

        private void tsmiXoa1Ban_Click(object sender, EventArgs e)
        {
            if (rightClickedButton == null) return;

            int id = (int)rightClickedButton.Tag;

            if (MessageBox.Show($"Xóa bàn {rightClickedButton.Text}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM [Table] WHERE ID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                LoadTableList();
            }
        }

        // ================== NÚT THÊM / SỬA / XÓA ==================
        private void btnThemBan_Click(object sender, EventArgs e)
        {
            new TableAddUpdate(this) { isEditMode = false }.ShowDialog();
        }

        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            if (selectedButton == null)
            {
                MessageBox.Show("Vui lòng chọn bàn để sửa!");
                return;
            }

            int id = (int)selectedButton.Tag;
            new TableAddUpdate(this, id) { isEditMode = true }.ShowDialog();
        }

        private void bntXoa_Click(object sender, EventArgs e)
        {
            if (!selectedButtons.Any())
            {
                MessageBox.Show("Vui lòng chọn bàn để xóa!");
                return;
            }

            if (MessageBox.Show($"Xóa {selectedButtons.Count} bàn đã chọn?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var btn in selectedButtons)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM [Table] WHERE ID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", btn.Tag);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadTableList();
            selectedButtons.Clear();
        }

        // ================== MỞ FORM KHÁC ==================
        private void tsmiXemDMHD_Click(object sender, EventArgs e)
            => new BillsByDateForm().ShowDialog();

        private void tsmiXemNKHD_Click(object sender, EventArgs e)
            => new PurchaseHistoryForm().ShowDialog();

        private void btnCategory_Click(object sender, EventArgs e)
            => new CategoryForm().ShowDialog();

        private void btnAccount_Click(object sender, EventArgs e)
            => new AccountManagerForm().ShowDialog();

        // ================== XEM HÓA ĐƠN HIỆN TẠI ==================
        private void tsmiXemHD_Click(object sender, EventArgs e)
        {
            // Chỉ cho xem hóa đơn nếu có bàn đang được chọn (bôi đen)
            if (selectedButtons.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi xem hóa đơn!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Nếu có nhiều bàn được chọn thì lấy bàn đầu tiên
            Button selected = selectedButtons[0];
            int tableID = Convert.ToInt32(selected.Tag);

            BillsForm billForm = new BillsForm(tableID);
            billForm.ShowDialog();
        }

      

    }
}



