using Lab3;
using System;
using System.Windows.Forms;

namespace MyForm
{

    public partial class frmTim : Form
    {
        QuanLySinhVien qlsv;
        public event Action<string, KieuTim> YeuCauTimKiem;

        public frmTim()
        {
            InitializeComponent();

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTuKhoa.Text.Trim();
            KieuTim kieu;
            if (rdMSSV.Checked) kieu = KieuTim.TheoMSSV;
            else if (rdTen.Checked) kieu = KieuTim.TheoTen;
            else kieu = KieuTim.TheoLop;

            YeuCauTimKiem?.Invoke(tuKhoa, kieu);
            this.Close();
        }
    }

}
