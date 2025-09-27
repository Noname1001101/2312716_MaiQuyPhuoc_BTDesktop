using Lab3;
using System;
using System.Collections.Generic;
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
    }
}
