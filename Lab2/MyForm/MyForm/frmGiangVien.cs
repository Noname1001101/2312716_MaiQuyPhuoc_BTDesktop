using System;
using System.Diagnostics;
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
    public partial class frmGiangVien : Form
    {
        private QuanLyGiangVien dsGiangVien = new QuanLyGiangVien();
        public frmGiangVien()
        {
            InitializeComponent();
        }

        private void frmGiangVien_Load(object sender, EventArgs e)
        {
            string lienHe = "https://cntt.dlu.edu.vn";
            this.linklbLienHe.Links.Add(0, lienHe.Length, lienHe);
            this.cboMaSo.SelectedItem = this.cboMaSo.Items[0];
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int i = this.lbHocPhanDay.SelectedItems.Count - 1;
            while (i >= 0)
            {
                var item = lbHocPhanDay.SelectedItems[i];
                this.lbDanhSachHP.Items.Add(item);
                this.lbHocPhanDay.Items.Remove(item);
                i--;
            }
        }

   

        private void btnChon_Click(object sender, EventArgs e)
        {
            // duyệt ngược để tránh lỗi khi Remove
            for (int i = lbDanhSachHP.SelectedItems.Count - 1; i >= 0; i--)
            {
                var item = lbDanhSachHP.SelectedItems[i]; // lấy ra item đang chọn
                lbHocPhanDay.Items.Add(item);             // thêm vào listbox khác
                lbDanhSachHP.Items.Remove(item);          // xóa khỏi listbox hiện tại
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Reset();
        }

        public void Reset()
        {
            this.cboMaSo.Text = "";
            this.txtHoTen.Text = "";
            this.txtMail.Text = "";
            this.mtxtSoDT.Text = "";
            this.rdNam.Checked = true;
            for (int i = 0; i < chklbNgoaiNgu.Items.Count - 1; i++)
            {
                chklbNgoaiNgu.SetItemChecked(i, false);

            }
            foreach (object ob in this.lbHocPhanDay.Items)
            {
                this.lbDanhSachHP.Items.Add(ob);

            }
            this.lbHocPhanDay.Items.Clear();
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            if (dsGiangVien.dsGiangVien.Count == 0)
            {
                MessageBox.Show("Chưa có giảng viên nào!", "Thông báo");
                return;
            }

            string info = "";
            foreach (GiangVien gv in dsGiangVien.dsGiangVien)
            {
                info += gv.ToString() + "\n----------------\n";
            }

            frmTBGiangVien frm = new frmTBGiangVien();
            frm.SetText(info);
            frm.ShowDialog();
        }


        //Lấy thông tin của giảng viên được nhập trên form
        public GiangVien GetGiangVien()
        {
            string gt = "Nam";
            if (rdNu.Checked)
            {
                gt = "Nữ";

            }
            GiangVien gv = new GiangVien();
            gv.MaSo = this.cboMaSo.Text;
            gv.GioiTinh = gt;
            gv.HoTen = this.txtHoTen.Text;
            gv.NgaySinh = this.dtpNgaySinh.Value;
            gv.Mail = this.txtMail.Text;
            gv.SoDT = this.mtxtSoDT.Text;
            string ngoaiNgu = "";
            for (int i = 0; i < chklbNgoaiNgu.Items.Count - 1; i++)
            {
                if (chklbNgoaiNgu.GetItemChecked(i))
                {
                    ngoaiNgu += chklbNgoaiNgu.Items[i] + ";";
                }
            }
            gv.NgoaiNgu = ngoaiNgu.Split(';');
            DanhSachHocPhan dshp = new DanhSachHocPhan();

            foreach (object hp in lbHocPhanDay.Items)
            {
                dshp.Them(new HocPhan(hp.ToString()));

            }
            gv.dsHocPhan = dshp;
            return gv;

        }


        private void linklbLienHe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string strlink = e.Link.LinkData.ToString();
            Process.Start(strlink);
        }



        private void bntTim_Click(object sender, EventArgs e)
        {
            frmTim frm = new frmTim(dsGiangVien);
            frm.ShowDialog();
        }


        private void bntThem_Click(object sender, EventArgs e)
        {
            GiangVien gv = GetGiangVien();

            if (dsGiangVien.Them(gv))
            {
                MessageBox.Show("Thêm giảng viên thành công!", "Thông báo");
                Reset();
            }
            else
            {
                MessageBox.Show("Mã giảng viên đã tồn tại!", "Thông báo");
            }
        }


    }
    
}
