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

            if (d1 < 5 || d2 < 5)
                return "Yếu";
            if (DTB < 7)
                return "Trung bình";
            if (DTB < 8)
                return "Khá";
            if (DTB < 9)
                return "Giỏi";
            return "Xuất sắc";
        }


        private void bntXepLoai_Click(object sender, EventArgs e)
        {
            int diemLyThuyet = int.Parse(txtDiemLyThuyet.Text);
            int diemThucHanh = int.Parse(txtDiemThucHanh.Text);
            if (diemLyThuyet < 0 || diemLyThuyet > 10 || diemThucHanh < 0 || diemThucHanh > 10)
            {
                MessageBox.Show("Điểm nhập vào phải nằm trong khoảng 0 đến 10!",
                                "Lỗi nhập liệu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return; 
            }
            string kq = XepLoaiHocTap(diemThucHanh, diemLyThuyet);
            lblKetQua.Text = kq.ToString();
            
        }
    }
}
