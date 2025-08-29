using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitap3
{
    public partial class FrmBai3 : Form
    {
        public FrmBai3()
        {
            InitializeComponent();
        }

       

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void bntXemKetQua_Click(object sender, EventArgs e)
        {
            string hoVaTen = txtHoTen.Text;
           
        
            if (rdTachChuoi.Checked)
            {
                string s1 = "", s2 = "";
                TinhToan.TachChuoi(hoVaTen, ref s1, ref s2);
                lblKetQua.Text = "Họ: " + s1 + " - Tên: " + s2;
            }
            else 
            {
                int soNguyen1 = int.Parse(txtSoNguyen1.Text);
                int soNguyen2 = int.Parse(txtSoNguyen2.Text);
                bool kq = TinhToan.ThuTu(ref soNguyen1, ref soNguyen2);
                if (kq)
                    lblKetQua.Text = $"{soNguyen1} và {soNguyen2} là hai số liên tiếp.";
                else
                    lblKetQua.Text = $"{soNguyen1} và {soNguyen2} không phải là hai số liên tiếp.";
            }
        }
    }
}
