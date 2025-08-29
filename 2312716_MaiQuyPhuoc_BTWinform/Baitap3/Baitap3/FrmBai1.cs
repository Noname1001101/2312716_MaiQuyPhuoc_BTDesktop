using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitap3
{
    public partial class FrmBai1 : Form
    {
        public FrmBai1()
        {
            InitializeComponent();
        }


        private void FrmBai1_Load(object sender, EventArgs e)
        {
            
            NhanVien nv = new NhanVien("2312716", "Mai Quý Phước", "23/08/2005", 2.34, 0.2);
            lblThongBao.Text = nv.HienThi();
        }
    }
}
