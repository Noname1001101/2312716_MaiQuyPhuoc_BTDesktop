﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MyForm
{
    public partial class frmTBGiangVien : Form
    {
        public frmTBGiangVien()
        {
            InitializeComponent();
            
        }

        //Gán chuỗi s cho thuộc text của lblThongBao
        public void SetText(string s)
        {

            this.lblThongBao.Text = s;
            this.lblThongBao.ForeColor = System.Drawing.Color.Purple;
        }


        
    }
}
