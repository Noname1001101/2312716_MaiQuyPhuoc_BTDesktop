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
    public partial class FrmBai2 : Form
    {
        public FrmBai2()
        {
            InitializeComponent();
        }

        private void bntXemKetQua_Click(object sender, EventArgs e)
        {
            int soThuNhat = int.Parse(txtSoThuNhat.Text);
            int soThuHai = int.Parse(txtSoThuHai.Text);
            int kq;
            if (rdCong.Checked)
            {
                kq = soThuNhat + soThuHai;
            }
            else if (rdTru.Checked)
            {
                kq = soThuNhat - soThuHai;
            }
            else if (rdNhan.Checked)
            {
                kq = soThuNhat * soThuHai;
            }
            else
            {
                kq = soThuNhat / soThuHai;
            }
           
            lblKetQua.Text = kq.ToString();
        }
    }
}
