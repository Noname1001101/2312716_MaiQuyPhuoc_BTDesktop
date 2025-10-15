using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class BillDetailsForm : Form
    {
        private int billID;
        private string connectionString = "server=DESKTOP-LSEMTND\\SQLEXPRESS; database=QuanLyNhaHang; Integrated Security=true;";

        public BillDetailsForm(int billID)
        {
            InitializeComponent();
            this.billID = billID;
        }

        private void BillDetailsForm_Load(object sender, EventArgs e)
        {
            LoadBillDetails();
        }

        private void LoadBillDetails()
        {
            string query = @"
        SELECT 
            f.Food AS [Tên món],
            f.Unitofmeasure AS [Đơn vị tính],
            bd.Quantity AS [Số lượng],
            f.UntilPrice AS [Đơn giá],
            (bd.Quantity * f.UntilPrice) AS [Thành tiền],
            f.Note AS [Ghi chú],
            c.Name AS [Nhóm món]
        FROM BillDetails bd
        JOIN Food f ON bd.FoodID = f.FoodID
        JOIN Category c ON f.CategoryID = c.CategoryID
        WHERE bd.BillID = @BillID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@BillID", billID);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvBillDetails.DataSource = dt;

                if (dt.Rows.Count > 0)
                {
                    string categoryName = dt.Rows[0]["Nhóm món"].ToString();
                    this.Text = "Danh sách các món ăn thuộc nhóm: " + categoryName;
                }
                else
                {
                    this.Text = "Hóa đơn không có món ăn nào.";
                }

                // Ẩn cột “Nhóm món” khỏi DataGridView
                if (dgvBillDetails.Columns.Contains("Nhóm món"))
                    dgvBillDetails.Columns["Nhóm món"].Visible = false;

                dgvBillDetails.Columns["Đơn giá"].DefaultCellStyle.Format = "N0";
                dgvBillDetails.Columns["Thành tiền"].DefaultCellStyle.Format = "N0";
                dgvBillDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

    }
}

