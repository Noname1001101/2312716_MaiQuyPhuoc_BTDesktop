using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitap2
{
    public partial class frmBai3 : Form
    {
        public frmBai3()
        {
            InitializeComponent();
        }

        private void bntXemKetQua_Click(object sender, EventArgs e)
        {
            string ho = txtHo.Text; 
            string ten = txtTen.Text;
            int n = int.Parse(txtGiaiThuaN.Text);
            string kqHoTen = " ";
            long kqGiaiThua = 0;
            if (rdInHoTen.Checked)
            {
                TinhToan.NoiChuoi(ho, ten, ref kqHoTen);
                lblKetQua.Text =  kqHoTen;
            }
            else if (rdGiaiThuaN.Checked)
            {
                kqGiaiThua = TinhToan.GiaiThua(n);
                lblKetQua.Text = kqGiaiThua.ToString();
            }


        }

        private void lblKetQua_Click(object sender, EventArgs e)
        {

        }
    }
}
