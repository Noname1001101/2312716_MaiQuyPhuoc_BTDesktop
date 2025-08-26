using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2312716_MaiQuyPhuoc_BTTKForm
{
    public partial class FrmBai2 : Form
    {
        public FrmBai2()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bntChonHang_Click(object sender, EventArgs e)
        {
            var item = listBox1.SelectedItem;
            listBox2.Items.Add(item);
        }

        private void bntBoHang_Click(object sender, EventArgs e)
        {
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void bntTinhTien_Click(object sender, EventArgs e)
        {
            int soTien = 0;
            foreach (string hang in listBox2.Items)
            {
                switch (hang)
                {
                    case "Chuột":
                        soTien += 100000;
                        break;

                    case "Bàn phím":
                        soTien += 150000;
                        break;
                    case "Máy in":
                        soTien += 200000;
                        break;
                    case "USB Kingmax":
                        soTien += 20000;
                        break;
                    default: 
                        break;
                }
                lblSoTien.Text = soTien + " đồng";
            }
        }
    }
}
