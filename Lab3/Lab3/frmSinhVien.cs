using MyForm;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Lab3
{
    public partial class frmSinhVien : Form
    {
        QuanLySinhVien qlsv = new QuanLySinhVien();
        public frmSinhVien()
        {
            InitializeComponent();
        }

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
            bool gt = true;
            SinhVien sv = new SinhVien();
            List<string> cn = new List<string>();
            sv.MSSV = this.txtMSSV.Text;
            sv.HoVaTenLot = this.txtHoVaTenLot.Text;
            sv.Ten = this.txtTen.Text;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            sv.Lop = this.cboLop.Text;
            sv.SoCMND = this.txtSoCMND.Text;
            sv.SDT = this.txtSDT.Text;
            sv.DiaChi = this.txtDiaChi.Text;
            if (rdNam.Checked)
                sv.GioiTinh = true;
            else if (rdNu.Checked)
                sv.GioiTinh = false;
            else
                sv.GioiTinh = null;   // chưa chọn


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
            this.txtMSSV.Text = sv.MSSV;
            this.txtHoVaTenLot.Text = sv.HoVaTenLot;
            this.txtTen.Text = sv.Ten;
            this.dtpNgaySinh.Value = sv.NgaySinh;
            this.cboLop.Text = sv.Lop;
            this.txtSoCMND.Text = sv.SoCMND;
            this.txtSDT.Text = sv.SDT;
            this.txtDiaChi.Text = sv.DiaChi;
            if (sv.GioiTinh == true)
                this.rdNam.Checked = true;
            else if (sv.GioiTinh == false)
                this.rdNu.Checked = true;
            else
            {
                this.rdNam.Checked = false;
                this.rdNu.Checked = false;
            }
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

            //Cho phép nhập MSSV khi thêm mới
            txtMSSV.Enabled = true;

            SinhVien sv = GetSinhVien();

            string thongbao;

            if (!qlsv.KiemTraThongTin(sv, out thongbao))
            {
                MessageBox.Show(thongbao, "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            qlsv.Them(sv);
            qlsv.GhiVaoFile("DanhSachSV.txt");
            LoadListView();


        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count > 0) // Có chọn sinh viên
            {
                SinhVien sv = GetSinhVienLV(lvSinhVien.SelectedItems[0]);
                ThietLapThongTin(sv);

                // Khi sửa thì MSSV là khóa duy nhất → khóa lại không cho sửa
                txtMSSV.ReadOnly = true;
            }
            else // Không chọn sinh viên nào
            {
                // Cho nhập MSSV để thêm mới
                txtMSSV.ReadOnly = false;

                // (nếu muốn thì clear form ở đây luôn)
                txtMSSV.Clear();
                txtHoVaTenLot.Clear();
                txtTen.Clear();
                cboLop.SelectedIndex = -1;
                txtSoCMND.Clear();
                txtSDT.Clear();

            }
        }




        // Khi bấm nút Cập nhật
        private void bntCapNhat_Click(object sender, EventArgs e)
        {
            // Gom tất cả sinh viên được tick hoặc chọn
            List<ListViewItem> itemsToUpdate = new List<ListViewItem>();

            foreach (ListViewItem item in lvSinhVien.CheckedItems)
                itemsToUpdate.Add(item);

            foreach (ListViewItem item in lvSinhVien.SelectedItems)
                if (!itemsToUpdate.Contains(item)) // tránh trùng lặp
                    itemsToUpdate.Add(item);

            if (itemsToUpdate.Count == 0)
            {
                MessageBox.Show("Vui lòng tick hoặc chọn ít nhất 1 sinh viên để cập nhật!");
                return;
            }

            // Lấy thông tin mới từ form
            SinhVien svMoi = GetSinhVien();

            foreach (ListViewItem item in itemsToUpdate)
            {
                string oldMssv = item.SubItems[0].Text.Trim();

                // Không cho đổi MSSV
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
                if (!ok)
                {
                    MessageBox.Show($"Không tìm thấy sinh viên {oldMssv} để cập nhật.");
                }
            }

            // Lưu lại file và load lại ListView
            qlsv.GhiVaoFile("DanhSachSV.txt");
            LoadListView();

            MessageBox.Show("Cập nhật thành công!");
        }

        private void bntTimKiem_Click(object sender, EventArgs e)
        {
            var form = new frmTim();
            form.YeuCauTimKiem += (chuoiTim, kieu) =>
            {
                List<SinhVien> ketQua = qlsv.TimKiem(chuoiTim, kieu);

                lvSinhVien.Items.Clear();
                foreach (SinhVien sv in ketQua)
                {
                    ThemSV(sv);
                }

                if (ketQua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sinh viên thỏa điều kiện.");
                }
            };

            form.Show(this);
        }

        private void menuXoa_Click(object sender, EventArgs e)
        {
            // Lấy danh sách sinh viên được tick
            var checkedItems = lvSinhVien.CheckedItems;
            if (checkedItems.Count == 0)
            {
                MessageBox.Show("Hãy tick vào ít nhất 1 sinh viên để xóa.");
                return;
            }

            var result = MessageBox.Show($"Bạn có chắc muốn xóa {checkedItems.Count} sinh viên đã chọn?",
                                         "Xác nhận xóa",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.No) return;

            foreach (ListViewItem item in checkedItems)
            {
                string mssv = item.SubItems[0].Text;

                SoSanh ss = delegate (object obj, object sv)
                {
                    return ((SinhVien)sv).MSSV.CompareTo(obj.ToString());
                };

                qlsv.Xoa(mssv, ss);
            }

            qlsv.GhiVaoFile("DanhSachSV.txt");
            LoadListView();

            MessageBox.Show("Đã xóa thành công!");
        }

        private void mennuThemMon_Click(object sender, EventArgs e)
        {
            using (frmThemMon frm = new frmThemMon())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    clbMHDK.Items.Add(frm.MonMoi, false);
                }
            }
        }

        private void menuXoaMon_Click(object sender, EventArgs e)
        {
            if (clbMHDK.SelectedItem != null)
            {
                var result = MessageBox.Show(
                    $"Bạn có chắc muốn xóa môn \"{clbMHDK.SelectedItem}\"?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    clbMHDK.Items.Remove(clbMHDK.SelectedItem);
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn 1 môn để xóa.");
            }
        }

        private void bntThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
              "Bạn có chắc muốn thoát chương trình không?",
              "",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // thoát toàn bộ chương trình
            }
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lop = cboLop.Text.Trim();
            if (!string.IsNullOrEmpty(lop))
            {
                txtMSSV.Text = qlsv.TaoMSSV(lop);
            }
        }
    }

}

