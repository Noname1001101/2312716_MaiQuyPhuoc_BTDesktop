using MyForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        QuanLySinhVien qlsv = new QuanLySinhVien();
        public Form1()
        {
            InitializeComponent();
        }

        //private void btnThem_Click(object sender, EventArgs e)
        //{
        //    SinhVien sv = GetSinhVien(); // lấy dữ liệu từ form
        //    qlsv.Them(sv);               // thêm vào danh sách
        //    qlsv.GhiVaoFile("DanhSachSV.txt"); // lưu ra file
        //    LoadListView();               // load lại listview
        //}

        private void ThemSV(SinhVien sv)
        {
            ListViewItem lvItem = new ListViewItem(sv.MSSV);
            lvItem.SubItems.Add(sv.HoVaTenLot);
            lvItem.SubItems.Add(sv.Ten);
            lvItem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvItem.SubItems.Add(sv.Lop);
            lvItem.SubItems.Add(sv.SoCMND);
            lvItem.SubItems.Add(sv.SDT);
            lvItem.SubItems.Add(sv.DiaChi);
            this.lvSinhVien.Items.Add(lvItem);
        }

        private void LoadListView()
        {
            this.lvSinhVien.Items.Clear();
            foreach (SinhVien sv in qlsv.dsSinhVien)
            {
                ThemSV(sv);
            }

        }

        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            List<string> cn = new List<string>();
            sv.MSSV = this.mtxtMSSV.Text;
            sv.HoVaTenLot = this.txtHoVaTenLot.Text;
            sv.Ten = this.txtTen.Text;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            sv.Lop = this.cboLop.Text;
            sv.SoCMND = this.mtxtSoCMND.Text;
            sv.SDT = this.mtxtSDT.Text;
            sv.DiaChi = this.txtDiaChi.Text;
            return sv;

        }

        private SinhVien GetSinhVienLV(ListViewItem lvItem)
        {
            SinhVien sv = new SinhVien();
            sv.MSSV = lvItem.SubItems[0].Text;
            sv.HoVaTenLot = lvItem.SubItems[1].Text;
            sv.Ten = lvItem.SubItems[2].Text;
            sv.NgaySinh = DateTime.Parse(lvItem.SubItems[3].Text);
            sv.Lop = lvItem.SubItems[4].Text;
            sv.SoCMND = lvItem.SubItems[5].Text;
            sv.SDT = lvItem.SubItems[6].Text;
            sv.DiaChi = lvItem.SubItems[7].Text;
            return sv;
        }

        private void ThietLapThongTin(SinhVien sv)
        {
            this.mtxtMSSV.Text = sv.MSSV;
            this.txtHoVaTenLot.Text = sv.HoVaTenLot;
            this.txtTen.Text = sv.Ten;
            this.dtpNgaySinh.Value = sv.NgaySinh;
            this.cboLop.Text = sv.Lop;
            this.mtxtSoCMND.Text = sv.SoCMND;
            this.mtxtSDT.Text = sv.SDT;


            this.txtDiaChi.Text = sv.DiaChi;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            qlsv = new QuanLySinhVien();
            qlsv.DocTuFile("DanhSachSV.txt");
            LoadListView();
        }



        // Khi bấm nút Thêm mới
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Cho phép nhập MSSV khi thêm mới
            mtxtMSSV.Enabled = true;

            SinhVien sv = GetSinhVien();
            qlsv.Them(sv);
            qlsv.GhiVaoFile("DanhSachSV.txt");
            LoadListView();
        }

        // Khi chọn 1 sinh viên trên ListView để hiển thị vào form
        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count == 0) return;

            SinhVien sv = GetSinhVienLV(lvSinhVien.SelectedItems[0]);
            ThietLapThongTin(sv);

            // Khi sửa thì MSSV là khóa duy nhất → khóa lại không cho sửa
            mtxtMSSV.Enabled = false;
        }

        // Khi bấm nút Cập nhật
        private void bntCapNhat_Click(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Chọn 1 sinh viên để cập nhật");
                return;
            }

            string oldMssv = lvSinhVien.SelectedItems[0].SubItems[0].Text.Trim();
            SinhVien svMoi = GetSinhVien();

            // Nếu người dùng cố tình sửa MSSV thì không cho cập nhật
            if (svMoi.MSSV != oldMssv)
            {
                MessageBox.Show("Không được phép thay đổi MSSV (MSSV là duy nhất).");
                return;
            }

            SoSanh ss = delegate (object obj, object sv)
            {
                return ((SinhVien)sv).MSSV.CompareTo(obj.ToString());
            };

            bool ok = qlsv.CapNhat(svMoi, oldMssv, ss);
            if (ok)
            {
                qlsv.GhiVaoFile("DanhSachSV.txt");
                LoadListView();
                MessageBox.Show("Cập nhật thành công.");
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên cần cập nhật.");
            }
        }

        private void bntTimKiem_Click(object sender, EventArgs e)
        {
            var form = new frmTim();
            form.YeuCauTimKiem += (chuoiTim, kieu) =>
            {
                var ketQua = qlsv.TimKiem(chuoiTim, kieu).ToList();

                lvSinhVien.Items.Clear();
                foreach (var sv in ketQua)
                    ThemSV(sv);

                if (!ketQua.Any())
                    MessageBox.Show("Không tìm thấy sinh viên thỏa điều kiện.");
            };

            form.Show(this); // không modal, hoặc dùng ShowDialog(this) nếu muốn khóa
        }

    }

}

