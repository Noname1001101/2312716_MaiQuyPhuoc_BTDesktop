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
    public partial class FrmChinh : Form
    {
        public FrmChinh()
        {
            InitializeComponent();
        }

        private void frmBai1_Click(object sender, EventArgs e)
        {
            var form = new frmTrungTam();
            form.ShowDialog();
        }

        private void frmBai2_Click(object sender, EventArgs e)
        {
            var form = new frmGiangVien();
            form.ShowDialog();
        }

        private void frmBai3_Click(object sender, EventArgs e)
        {
            var form = new FrmSinhVien();
            form.ShowDialog();
        }

        private void FrmChinh_Load(object sender, EventArgs e)
        {

        }
    }
}
