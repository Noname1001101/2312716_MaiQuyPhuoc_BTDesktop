using Lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MyForm // giữ namespace của bạn (nếu khác thì đổi cho đúng)
{
    public partial class frmTim : Form
    {
        // tham chiếu tới danh sách gốc (được gán từ frmSinhVien trước khi ShowDialog)
        public Lab3.QuanLySinhVien qlsv;

        // sau khi tìm xong sẽ gán vào đây để form cha lấy
        public List<Lab3.SinhVien> KetQua { get; private set; }

        public frmTim()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string mssv = cbMSSV.Checked ? txtMSSV.Text.Trim() : null;
            string hoVaTenLot = cbHoVaTenLot.Checked ? txtHoVaTenLot.Text.Trim() : null;
            string ngaySinh = cbNgaySinh.Checked ? dtpNgaySinh.Text.Trim() : null;
            string soCMND = cbSoCMND.Checked ? txtSoCMND.Text.Trim() : null;
            string lop = cbLop.Checked ? cbLop.Text.Trim() : null;
            string ten = cbTen.Checked ? txtTen.Text.Trim() : null;
            string soDT = cbSoDT.Checked ? txtSDT.Text.Trim() : null;
            string diaChi = cbDiaChi.Checked ? txtDiaChi.Text.Trim() : null;

            // gọi hàm tìm nhiều điều kiện từ qlsv gốc
            var ketQua = qlsv.TimKiemNhieuDieuKien(
                mssv, ten, lop, diaChi,
                hoVaTenLot, ngaySinh, soCMND, soDT
            );

            frmSinhVien frm = (frmSinhVien)this.Owner;
            frm.HienKetQuaTimKiem(ketQua);
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Lấy lớp đang chọn
            string lopChon = cboLop.Text.Trim();

            // Lọc danh sách sinh viên theo lớp
            var ketQua = qlsv.dsSinhVien
                             .Where(sv => sv.Lop.Equals(lopChon, StringComparison.OrdinalIgnoreCase))
                             .ToList();

            // Gọi hàm hiển thị lại ListView (giống lúc tìm kiếm)
            frmSinhVien frm = (frmSinhVien)this.Owner;
            frm.HienKetQuaTimKiem(ketQua);
        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            // Lấy ngày được chọn trong DateTimePicker
            DateTime ngayChon = dtpNgaySinh.Value.Date; // .Date để bỏ phần giờ phút giây

            // Lọc danh sách sinh viên theo ngày sinh
            var ketQua = qlsv.dsSinhVien
                             .Where(sv => sv.NgaySinh.Date == ngayChon)
                             .ToList();

            // Gọi hàm hiển thị lại ListView
            frmSinhVien frm = (frmSinhVien)this.Owner;
            frm.HienKetQuaTimKiem(ketQua);
        }
    }
}
