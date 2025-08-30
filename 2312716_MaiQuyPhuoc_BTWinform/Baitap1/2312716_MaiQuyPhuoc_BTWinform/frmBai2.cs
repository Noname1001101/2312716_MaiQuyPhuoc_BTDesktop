using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312716_MaiQuyPhuoc_BTWinform
{
    public partial class frmBai2 : Form
    {
        public frmBai2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbbTenHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var stt = cbbTenHang.SelectedIndex;
            switch (stt)
            {
               case 0:
                    txtDonGia.Text = "100000";
                    break;
               case 1:
                    txtDonGia.Text = "200000";
                    break;
               case 2:
                    txtDonGia.Text = "150000";
                    break;
            }

        }

        private void bntTinhTien_Click(object sender, EventArgs e)
        {
            int donGia = int.Parse(txtDonGia.Text);
            int soLuong = int.Parse(txtSoLuong.Text);
            double thanhTien = donGia * soLuong;

            if (rdChuyenkhoan.Checked)
            {
                thanhTien = donGia * soLuong * 0.95;

            }
            lblSoTien.Text = thanhTien.ToString();
            

        }

        private void frmBai2_Load(object sender, EventArgs e)
        {

        }
    }
}
