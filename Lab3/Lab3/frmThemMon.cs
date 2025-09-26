using System;
using System.Windows.Forms;

namespace Lab3
{
    public partial class frmThemMon : Form
    {
        public string MonMoi { get; private set; } = "";
        public frmThemMon()
        {
            InitializeComponent();
        }

        private void bntThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtThemMon.Text))
            {
                MonMoi = txtThemMon.Text.Trim();
                this.DialogResult = DialogResult.OK; // báo lại form chính biết là OK
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên môn học không được để trống!");
            }
        }
    }
}
