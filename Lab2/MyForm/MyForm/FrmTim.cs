using System;
using System.Windows.Forms;

namespace MyForm
{
    public partial class frmTim : Form
    {
        private QuanLyGiangVien qlgv;

        public frmTim(QuanLyGiangVien qlgv)
        {
            InitializeComponent();
            this.qlgv = qlgv;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTuKhoa.Text.Trim();
            KieuTim kieu;

            if (rdMaGV.Checked)
                kieu = KieuTim.TheoMa;
            else if (rdHoTen.Checked)
                kieu = KieuTim.TheoHoTen;
            else
                kieu = KieuTim.TheoSDT;


            GiangVien gv = qlgv.Tim(tuKhoa, kieu);

            if (gv == null)
            {
                MessageBox.Show("Không tìm thấy giảng viên trong danh sách!");
                return;
            }
            else
            {
                MessageBox.Show("Đã tìm thấy: " + gv.HoTen); // debug
            }

            // Chuẩn bị nội dung hiển thị
            string thongTin = $"Mã số: {gv.MaSo}\n" +
                              $"Họ tên: {gv.HoTen}\n" +
                              $"Ngày sinh: {gv.NgaySinh}\n" +
                              $"Giới tính: {gv.GioiTinh}\n" +
                              $"SĐT: {gv.SoDT}\n" +
                              $"Email: {gv.Mail}\n" +
                              $"Ngoại ngữ: {string.Join(", ", gv.NgoaiNgu)}\n" +
                              $"Danh sách môn dạy: {string.Join(", ", gv.dsHocPhan)}";

            frmTBGiangVien frm = new frmTBGiangVien();
            frm.SetText(thongTin);
            frm.ShowDialog();
        }

        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmTim_Load(object sender, EventArgs e)
        {

        }
    }

}
