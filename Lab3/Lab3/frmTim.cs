using Lab3;
using System;
using System.Windows.Forms;

namespace MyForm
{

    public partial class frmTim : Form
    {

        public event Action<string, KieuTim> YeuCauTimKiem;

        public frmTim()
        {
            InitializeComponent();

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTuKhoa.Text.Trim();
            KieuTim kieu;

            if (rdMSSV.Checked)
                kieu = KieuTim.TheoMSSV;
            else if (rdTen.Checked)
                kieu = KieuTim.TheoTen;
            else
                kieu = KieuTim.TheoLop;

            // Gọi sự kiện gửi yêu cầu tìm kiếm cho Form1
            if (YeuCauTimKiem != null)
            {
                YeuCauTimKiem(tuKhoa, kieu);
            }
            this.Close();
        }
    }

}
