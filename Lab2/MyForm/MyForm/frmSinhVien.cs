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
    public partial class FrmSinhVien : Form
    {
        QuanLySinhVien qlsv = new QuanLySinhVien();
        public FrmSinhVien()
        {
            InitializeComponent();
        }

        private void ThemSV(SinhVien sv)
        {
            ListViewItem lvItem = new ListViewItem(sv.MaSo);
            lvItem.SubItems.Add(sv.HoTen);
            lvItem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvItem.SubItems.Add(sv.DiaChi);
            lvItem.SubItems.Add(sv.Lop);
            string gt = "Nữ";
            if (sv.GioiTinh)
            {
                gt = "Nam";   
            }
            lvItem.SubItems.Add(gt);
            string cn = "";
            foreach (string s in sv.ChuyenNganh)
            {
                cn += s + ",";
            }
            cn = cn.Substring(0, cn.Length - 1);
            lvItem.SubItems.Add(cn);
            lvItem.SubItems.Add(sv.Hinh);
            this.lvSinhVien.Items.Add(lvItem);
        }

        private void LoadListView()
        {
            this.lvSinhVien.Items.Clear();
            foreach (SinhVien sv in qlsv.dsSinhVien)
            {
                ThemSV(sv);
            }

            this.sslTongSV.Text = "Tổng Sinh Viên: " + qlsv.dsSinhVien.Count.ToString();
        }

        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            bool gt = true;
            List<string> cn = new List<string>();
            sv.MaSo = this.mtxtMaSo.Text;
            sv.HoTen = this.txtHoTen.Text;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            sv.DiaChi = this.txtDiaChi.Text;
            sv.Lop = this.cboLop.Text;
            sv.Hinh = this.txtHinh.Text;
            if (rdNu.Checked)
                gt = false;
            sv.GioiTinh = gt;
            for (int i = 0; i < this.clbChuyenNganh.Items.Count; i++)
                if (clbChuyenNganh.GetItemChecked(i))
                    cn.Add(clbChuyenNganh.Items[i].ToString());
            sv.ChuyenNganh = cn;
            return sv;

        }
        private SinhVien GetSinhVienLV(ListViewItem lvItem)
        {
            SinhVien sv = new SinhVien();
            sv.MaSo = lvItem.SubItems[0].Text;
            sv.HoTen = lvItem.SubItems[1].Text;
            sv.NgaySinh = DateTime.Parse(lvItem.SubItems[2].Text);
            sv.DiaChi = lvItem.SubItems[3].Text;
            sv.Lop = lvItem.SubItems[4].Text;
            sv.GioiTinh = false;
            if (lvItem.SubItems[5].Text == "Nam")
                sv.GioiTinh = true;
            List<string> cn = new List<string>();
            string[] s = lvItem.SubItems[6].Text.Split(',');
            foreach (string t in s)
                cn.Add(t);
            sv.ChuyenNganh = cn;
            sv.Hinh = lvItem.SubItems[7].Text;
            return sv;
        }

        private void ThietLapThongTin(SinhVien sv)
        {
            this.mtxtMaSo.Text = sv.MaSo;
            this.txtHoTen.Text = sv.HoTen;
            this.dtpNgaySinh.Value = sv.NgaySinh;
            this.txtDiaChi.Text = sv.DiaChi;
            this.cboLop.Text = sv.Lop;
            this.txtHinh.Text = sv.Hinh;
            this.pbHinh.ImageLocation = sv.Hinh;
            if (sv.GioiTinh)
            {
                this.rdNam.Checked = true;

            }
            else
            {
                this.rdNu.Checked = true;

            }
            for (int i = 0; i < this.clbChuyenNganh.Items.Count; i++)
            {
                this.clbChuyenNganh.SetItemChecked(i, false);
            }
            foreach (string s in sv.ChuyenNganh)
            {
                for (int i = 0; i < this.clbChuyenNganh.Items.Count; i++)
                {
                    if (s.CompareTo(this.clbChuyenNganh.Items[i]) == 0)
                    {
                        this.clbChuyenNganh.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            qlsv = new QuanLySinhVien();
            qlsv.DocTuFile("DanhSachSV.txt");
            LoadListView();
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            this.mtxtMaSo.Text = "";
            this.txtHoTen.Text = "";
            this.dtpNgaySinh.Value = DateTime.Now;
            this.txtDiaChi.Text = "";
            this.cboLop.Text = this.cboLop.Items[0].ToString();
            this.txtHinh.Text = "";
            this.pbHinh.ImageLocation = "";
            this.rdNam.Checked = true;
            for (int i = 0; i < this.clbChuyenNganh.Items.Count - 1 ; i++)
            {
                this.clbChuyenNganh.SetItemChecked(i, false);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private int SoSanhTheoMa(object sv1,object sv2)
        {
            SinhVien sv = sv2 as SinhVien;
            return sv.MaSo.CompareTo(sv1);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int count, i;
            ListViewItem lvItem;
            count = this.lvSinhVien.Items.Count - 1;
            for (i = count; i >= 0; i--)
            {
                lvItem = this.lvSinhVien.Items[i];
                if (lvItem.Checked)
                {
                    qlsv.Xoa(lvItem.SubItems[0].Text, SoSanhTheoMa);
                }
            }
            this.LoadListView();
            this.btnMacDinh.PerformClick();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            bool kqsua;
            kqsua = qlsv.Sua(sv, sv.MaSo, SoSanhTheoMa);
            if (kqsua)
            {
                this.LoadListView();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open File Image";
            ofd.Filter = "Image Files|*.bmp;*.jpg;*.png|All files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Gán đường dẫn vào TextBox
                this.txtHinh.Text = ofd.FileName;

                // Hiển thị ảnh lên PictureBox
                this.pbHinh.Image = Image.FromFile(ofd.FileName);
              
            }

        }

      
    }
}
