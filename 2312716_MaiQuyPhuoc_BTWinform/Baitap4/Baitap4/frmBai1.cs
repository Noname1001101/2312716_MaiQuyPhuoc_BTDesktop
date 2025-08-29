using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitap4
{
    public partial class frmBai1 : Form
    {
        public frmBai1()
        {
            InitializeComponent();
        }

        private void frmBai1_Load(object sender, EventArgs e)
        {
            SanPham sp = new SanPham();
            sp.MaSanPham = "HH01";
            sp.TenSanPham = "Máy tính bỏ túi";
            sp.LoaiSanPham = "Đồ điện tử";
            sp.NgaySanXuat = DateTime.Parse("2024-04-14");


           lblThongBao.Text= sp.HienThi();
        }
    }
}
