using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyForm
{
    public enum TuyChon
    {
        MaSV,
        HoTen,
        NgaySinh
    }
    public partial class frmTuyChon : Form
    {
        public event Action<TuyChon> YeuCauSapXep;
       
        public event Action<string, TuyChon> YeuCauTimKiem;

        public frmTuyChon()
        {
            InitializeComponent();
        }


        public TuyChon KieuSapXep { get; private set; }

        Button btnSapXep;
        string ChuoiTim;
        GroupBox groupBoxTim;
        TuyChon Kieu;
        private void bntSapXep_Click(object sender, EventArgs e)
        {
            TuyChon kieu = TuyChon.MaSV;
            if (rdMaSV.Checked) kieu = TuyChon.MaSV;
            else if (rdHoTen.Checked) kieu = TuyChon.HoTen;
            else if (rdNgaySinh.Checked) kieu = TuyChon.NgaySinh;

            // Gọi event gửi thông báo cho frmSinhVien
            YeuCauSapXep?.Invoke(kieu);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

            string chuoiTim = txtNhapThongTin.Text.Trim();
        

            if (string.IsNullOrEmpty(chuoiTim))
            {
                MessageBox.Show("Hãy nhập thông tin tìm!", "Lỗi nhập thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TuyChon kieu = TuyChon.MaSV;
            if (rdMaSV.Checked) kieu = TuyChon.MaSV;
            else if (rdHoTen.Checked) kieu = TuyChon.HoTen;
            else if (rdNgaySinh.Checked) kieu = TuyChon.NgaySinh;

            // Gọi event gửi thông báo cho frmSinhVien
            YeuCauTimKiem?.Invoke(chuoiTim, kieu);

       
        }

    }
}
