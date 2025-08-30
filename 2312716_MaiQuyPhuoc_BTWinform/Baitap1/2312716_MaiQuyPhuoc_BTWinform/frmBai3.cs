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
    public partial class frmBai3 : Form
    {
        public frmBai3()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnXemKQ_Click(object sender, EventArgs e)
        {
            int a = int.Parse(txtSoA.Text);
            int b = int.Parse(txtSoB.Text);
            int n = int.Parse(txtSoN.Text);
            int kq = 0;

            if (rdTongAB.Checked)
            {
                TinhToan.CongHaiSo(a, b, ref kq);
            }
            else
            {
                kq = TinhToan.TongDaySo(n);
            }

            lblKetQua.Text = kq.ToString();
        }

        private void lblKetQua_Click(object sender, EventArgs e)
        {

        }
    }
}
