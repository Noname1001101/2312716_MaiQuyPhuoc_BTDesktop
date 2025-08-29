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
    public partial class FrmBai2 : Form
    {
        public FrmBai2()
        {
            InitializeComponent();
        }

        

        private void bntXemKQ_Click(object sender, EventArgs e)
        {
            int n = int.Parse(txtSoND.Text);
            long kq = 0;
            if (rdTinhTong.Checked)
            {

                //for (int i = 0; i <= n; i++)
                //{
                //    kq += i;
                //}

                kq = (long)n * (n + 1) / 2;
            }
            else
            {
                kq = 1;
                for (int i = 2; i <= n; i++)
                {
                        kq *= i;
                }

            }
            lblKetQua.Text = kq.ToString();
        }

       
    }
}
