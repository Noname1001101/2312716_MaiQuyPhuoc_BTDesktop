using MyForm;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // Thêm 1 SV vào ListView
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
        // Load toàn bộ SV vào ListView
        private void LoadListView()
        {

            this.lvSinhVien.Items.Clear();
            foreach (SinhVien sv in qlsv.dsSinhVien)
            {
                ThemSV(sv);
            }
            // Tự động giãn cột theo nội dung lớn nhất
            lvSinhVien.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        // Lấy SV từ form nhập liệu
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

        // Lấy SV từ 1 dòng trong ListView
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

        // Đổ thông tin SV từ ListView vào form
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

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            //qlsv = new QuanLySinhVien();
            //qlsv.DocTuFile("DanhSachSV.txt");
            //LoadListView();


        }

        // Nút Thêm mới
        private void btnThem_Click(object sender, EventArgs e)
        {

            SinhVien sv = GetSinhVien();

            string thongbao;

            if (!qlsv.KiemTraThongTin(sv, out thongbao))
            {
                MessageBox.Show(thongbao, "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            qlsv.Them(sv);// thêm vào danh sách
            qlsv.GhiVaoFile("DanhSachSV.txt"); // lưu ra file
            qlsv.GhiVaoFileXML("DanhSachSV.xml");
            qlsv.GhiVaoFileJSON("DanhSachSV.json");
            LoadListView();


        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count > 0) // Có chọn SV
            {
                SinhVien sv = GetSinhVienLV(lvSinhVien.SelectedItems[0]);
                ThietLapThongTin(sv);

            }
            else
            {
                // clear form
                txtMSSV.Clear();
                txtHoVaTenLot.Clear();
                txtTen.Clear();
                cboLop.SelectedIndex = -1;
                txtSoCMND.Clear();
                txtSDT.Clear();
            }
        }

        private void frmSinhVien_MouseDown(object sender, MouseEventArgs e)
        {
            // Nếu click mà không phải bên trong ListView
            if (!lvSinhVien.Bounds.Contains(e.Location))
            {
                lvSinhVien.SelectedItems.Clear();
            }
        }

        // Khi bấm nút Cập nhật
        private void bntCapNhat_Click(object sender, EventArgs e)
        {
            // Gom SV cần cập nhật (tick hoặc chọn)
            var itemsToUpdate = lvSinhVien.CheckedItems.Cast<ListViewItem>()
                                .Concat(lvSinhVien.SelectedItems.Cast<ListViewItem>())
                                .Distinct()
                                .ToList();

            if (itemsToUpdate.Count == 0)
            {
                MessageBox.Show("Vui lòng tick hoặc chọn ít nhất 1 sinh viên để cập nhật!");
                return;
            }

            // Lấy thông tin mới từ form
            SinhVien svMoi = GetSinhVien();

            foreach (var item in itemsToUpdate)
            {
                string mssv = item.SubItems[0].Text.Trim(); // MSSV gốc

                SoSanh ss = (obj, sv) => ((SinhVien)sv).MSSV.CompareTo(obj.ToString());

                // Update, dùng MSSV gốc làm khóa
                if (!qlsv.CapNhat(svMoi, mssv, ss))
                    MessageBox.Show($"Không tìm thấy sinh viên {mssv} để cập nhật.");
            }

            // Lưu lại file
            qlsv.GhiVaoFile("DanhSachSV.txt");
            qlsv.GhiVaoFileXML("DanhSachSV.xml");
            qlsv.GhiVaoFileJSON("DanhSachSV.json");

            LoadListView();
            MessageBox.Show("Cập nhật thành công!");
        }




        private void bntTimKiem_Click(object sender, EventArgs e)
        {
            var form = new frmTim();
            form.qlsv = this.qlsv;  // truyền dữ liệu qua form tìm
            form.Show(this);
        }

        // Menu Xóa SV
        private void menuXoa_Click(object sender, EventArgs e)
        {
            // Gom SV được tick hoặc chọn (loại trùng)
            var itemsToDelete = lvSinhVien.CheckedItems.Cast<ListViewItem>()
                                 .Concat(lvSinhVien.SelectedItems.Cast<ListViewItem>())
                                 .Distinct()
                                 .ToList();


            if (itemsToDelete.Count == 0)
            {
                MessageBox.Show("Tick hoặc chọn ít nhất 1 SV để xóa.");
                return;
            }

            // Tạo chuỗi thông tin sinh viên đơn giản
            string svInfo = "";
            int stt = 1;
            foreach (var item in itemsToDelete)
            {
                svInfo += $"{stt}. {item.SubItems[0].Text} - {item.SubItems[1].Text} {item.SubItems[2].Text}\n";
                stt++;
            }

            var result = MessageBox.Show(
                $"Bạn có chắc muốn xóa ({itemsToDelete.Count}) sinh viên:\n\n + {svInfo}",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No) return;

            foreach (ListViewItem item in itemsToDelete)
            {
                string mssv = item.SubItems[0].Text;

                SoSanh ss = delegate (object obj, object sv)
                {
                    return ((SinhVien)sv).MSSV.CompareTo(obj.ToString());
                };

                qlsv.Xoa(mssv, ss);
            }

            qlsv.GhiVaoFile("DanhSachSV.txt");
            qlsv.GhiVaoFileXML("DanhSachSV.xml");
            qlsv.GhiVaoFileJSON("DanhSachSV.json");
            LoadListView();

            MessageBox.Show("Đã xóa thành công!");
        }

        // Thêm môn học vào danh sách
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

        // Xóa môn học
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

        // Nút Thoát
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

        // Khi chọn lớp thì tạo MSSV
        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lop = cboLop.Text.Trim();
            if (!string.IsNullOrEmpty(lop))
            {
                txtMSSV.Text = qlsv.TaoMSSV(lop);
            }
        }


        // Đọc file XML/TXT/JSON từ menu
        private void menuDocXML_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    qlsv.DocTuFileXML(ofd.FileName);
                    LoadListView();
                    MessageBox.Show("Đọc file XML thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc file XML: " + ex.Message);
                }
            }
        }

        private void menuDocTXT_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    qlsv.DocTuFile(ofd.FileName);  // gọi hàm đã có trong QuanLySinhVien
                    LoadListView();                // nạp dữ liệu ra ListView
                    MessageBox.Show("Đọc file TXT thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc file TXT: " + ex.Message);
                }
            }
        }

        private void menuDocJSON_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    qlsv.DocTuFileJSON(ofd.FileName);
                    LoadListView();
                    MessageBox.Show("Đọc file JSON thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc file JSON: " + ex.Message);
                }
            }
        }

        // Hiện kết quả tìm kiếm
        public void HienKetQuaTimKiem(List<SinhVien> ketQua)
        {
            lvSinhVien.Items.Clear();

            foreach (SinhVien sv in ketQua)
            {
                ThemSV(sv);
            }
        }


        // Click vào MSSV thì bắt buộc nhập lớp trước
        private void txtMSSV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboLop.Text))
            {
                MessageBox.Show("Bạn phải nhập thông tin lớp trước khi tạo MSSV!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }

        }
    }

}

