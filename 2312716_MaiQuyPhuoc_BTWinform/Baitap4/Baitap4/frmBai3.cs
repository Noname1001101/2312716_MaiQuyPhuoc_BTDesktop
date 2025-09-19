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
    public partial class frmBai3 : Form
    {
        public frmBai3()
        {
            InitializeComponent();
        }

        private void bntXemKetQua_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text;
            string kqChaoHoi = "";
            bool gioiTinh = rdNam.Checked;
            if (rdNam.Checked || rdNu.Checked)
            {
                
                TinhToan.ChaoHoi(ref hoTen, gioiTinh,ref kqChaoHoi);
                lblKetQua.Text = kqChaoHoi;
            }
            
            else
            {
                int soNguyen1 = int.Parse(txtSoNguyen1.Text);
                int soNguyen2 = int.Parse(txtSoNguyen2.Text);
                int kq = TinhToan.USCLN(ref soNguyen1, ref soNguyen2);
                lblKetQua.Text = kq.ToString();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
