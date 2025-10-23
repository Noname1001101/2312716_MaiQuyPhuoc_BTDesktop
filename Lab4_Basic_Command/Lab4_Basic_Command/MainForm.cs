using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class MainForm : Form
    {
        private readonly string connectionString =
            "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";


        public MainForm()
        {
            InitializeComponent();
            LoadTableList(); // Hiển thị danh sách bàn khi mở form

        }
        private void LoadTableList()
        {
            flpBan.Controls.Clear(); // Xóa các bàn cũ trước khi load lại

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM [Table]";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Button btn = new Button();
                    btn.Width = 100;
                    btn.Height = 60;

                    string tableName = reader["Name"].ToString();   // ✅ đọc tên bàn
                    string statusValue = reader["Status"].ToString();
                    string statusText = (statusValue == "0") ? "Trống" : "Có khách";

                    btn.Text = tableName + Environment.NewLine + statusText; // ✅ sửa ở đây

                    if (statusValue == "0")
                        btn.BackColor = System.Drawing.Color.Honeydew;
                    else
                        btn.BackColor = System.Drawing.Color.MediumSeaGreen;

                    btn.ForeColor = System.Drawing.Color.Black;
                    btn.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;

                    // ✅ lưu ID bàn để dùng khi xem hóa đơn
                    btn.Tag = reader["ID"];

                    btn.Click += Btn_Click;
                    flpBan.Controls.Add(btn);
                }


                conn.Close();
            }
        }


        private void ShowBill(int tableID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT f.Name AS FoodName, f.Unit, bd.Quantity, f.Price, 
                   (bd.Quantity * f.Price) AS Total
            FROM BillDetails bd
            JOIN Bills b ON bd.InvoiceID = b.ID
            JOIN Food f ON bd.FoodID = f.ID
            WHERE b.TableID = @tableID AND b.Status = @status";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tableID", tableID);
                cmd.Parameters.Add("@status", SqlDbType.Bit).Value = false;  // false = chưa thanh toán

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                string billText = "";
                decimal totalAmount = 0;

                while (reader.Read())
                {
                    string foodName = reader["FoodName"].ToString();
                    string unit = reader["Unit"].ToString();
                    int quantity = Convert.ToInt32(reader["Quantity"]);
                    decimal price = Convert.ToDecimal(reader["Price"]);
                    decimal total = Convert.ToDecimal(reader["Total"]);

                    billText += $"{foodName} ({unit}) - SL: {quantity}, Giá: {price:N0}, Thành tiền: {total:N0}\n";
                    totalAmount += total;
                }

                reader.Close();

                if (string.IsNullOrEmpty(billText))
                {
                    MessageBox.Show("Bàn này hiện chưa có hóa đơn chưa thanh toán.", "Thông báo");
                }
                else
                {
                    MessageBox.Show(billText + $"\n--------------------\nTổng cộng: {totalAmount:N0} VNĐ",
                                    $"Hóa đơn hiện tại của bàn {tableID}");
                }

                conn.Close();
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int tableID = Convert.ToInt32(clickedButton.Tag);

            BillsForm billForm = new BillsForm(tableID);
            billForm.ShowDialog(); // ✅ hiển thị form BillForm
          

        }




    }
}
