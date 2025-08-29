using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitap4
{
    public partial class frmBai2 : Form
    {
        public frmBai2()
        {
            InitializeComponent();
        }

        
        public static string XepLoaiHocTap(int d1, int d2)
        {
           
            int DTB = (d1 + d2) / 2;
            string ketQua = "";
            if (d1 < 5 || d2 < 5)
            {
                ketQua = "Yếu";
            }
            else if (DTB < 7)
            {
                ketQua = "Trung bình";

            }
            else if (7 <= DTB && DTB < 8)
            {
                ketQua = "Khá";

            }
            else if (8 <= DTB && DTB < 9)
            {
                ketQua = "Giỏi";
            }
            else if (DTB >= 9)
            {
                ketQua = "Xuất sắc";
            }
            return ketQua;
        }

        private void bntXepLoai_Click(object sender, EventArgs e)
        {
            int diemLyThuyet = int.Parse(txtDiemLyThuyet.Text);
            int diemThucHanh = int.Parse(txtDiemThucHanh.Text);
            string kq = XepLoaiHocTap(diemThucHanh, diemLyThuyet);
            lblKetQua.Text = kq.ToString();
            
        }
    }
}
