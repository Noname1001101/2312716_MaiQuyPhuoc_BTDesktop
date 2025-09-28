namespace MyForm
{
    partial class frmTim
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSDT = new System.Windows.Forms.MaskedTextBox();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.txtSoCMND = new System.Windows.Forms.MaskedTextBox();
            this.txtMSSV = new System.Windows.Forms.MaskedTextBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtHoVaTenLot = new System.Windows.Forms.TextBox();
            this.cbSoDT = new System.Windows.Forms.CheckBox();
            this.cbSoCMND = new System.Windows.Forms.CheckBox();
            this.cbNgaySinh = new System.Windows.Forms.CheckBox();
            this.cbHoVaTenLot = new System.Windows.Forms.CheckBox();
            this.cbDiaChi = new System.Windows.Forms.CheckBox();
            this.cbLop = new System.Windows.Forms.CheckBox();
            this.cbTen = new System.Windows.Forms.CheckBox();
            this.cbMSSV = new System.Windows.Forms.CheckBox();
            this.bntTim = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSDT);
            this.groupBox1.Controls.Add(this.cboLop);
            this.groupBox1.Controls.Add(this.txtSoCMND);
            this.groupBox1.Controls.Add(this.txtMSSV);
            this.groupBox1.Controls.Add(this.dtpNgaySinh);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.txtTen);
            this.groupBox1.Controls.Add(this.txtHoVaTenLot);
            this.groupBox1.Controls.Add(this.cbSoDT);
            this.groupBox1.Controls.Add(this.cbSoCMND);
            this.groupBox1.Controls.Add(this.cbNgaySinh);
            this.groupBox1.Controls.Add(this.cbHoVaTenLot);
            this.groupBox1.Controls.Add(this.cbDiaChi);
            this.groupBox1.Controls.Add(this.cbLop);
            this.groupBox1.Controls.Add(this.cbTen);
            this.groupBox1.Controls.Add(this.cbMSSV);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 236);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm theo";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(461, 139);
            this.txtSDT.Mask = "0000.000.000";
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(173, 26);
            this.txtSDT.TabIndex = 24;
            // 
            // cboLop
            // 
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Items.AddRange(new object[] {
            "CTK47",
            "TNK46",
            "THK45",
            "KLK44",
            "DKK43",
            "HDK42",
            "HHK41",
            "VLK40"});
            this.cboLop.Location = new System.Drawing.Point(461, 50);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(173, 28);
            this.cboLop.TabIndex = 23;
            this.cboLop.SelectedIndexChanged += new System.EventHandler(this.cboLop_SelectedIndexChanged);
            // 
            // txtSoCMND
            // 
            this.txtSoCMND.Location = new System.Drawing.Point(145, 180);
            this.txtSoCMND.Mask = "000000000";
            this.txtSoCMND.Name = "txtSoCMND";
            this.txtSoCMND.Size = new System.Drawing.Size(173, 26);
            this.txtSoCMND.TabIndex = 22;
            this.txtSoCMND.ValidatingType = typeof(int);
            // 
            // txtMSSV
            // 
            this.txtMSSV.Location = new System.Drawing.Point(145, 48);
            this.txtMSSV.Mask = "0000000";
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(173, 26);
            this.txtMSSV.TabIndex = 21;
            this.txtMSSV.ValidatingType = typeof(int);
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(145, 141);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(173, 26);
            this.dtpNgaySinh.TabIndex = 20;
            this.dtpNgaySinh.ValueChanged += new System.EventHandler(this.dtpNgaySinh_ValueChanged);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(461, 178);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(173, 26);
            this.txtDiaChi.TabIndex = 18;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(461, 92);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(173, 26);
            this.txtTen.TabIndex = 16;
            // 
            // txtHoVaTenLot
            // 
            this.txtHoVaTenLot.Location = new System.Drawing.Point(145, 94);
            this.txtHoVaTenLot.Name = "txtHoVaTenLot";
            this.txtHoVaTenLot.Size = new System.Drawing.Size(173, 26);
            this.txtHoVaTenLot.TabIndex = 12;
            // 
            // cbSoDT
            // 
            this.cbSoDT.AutoSize = true;
            this.cbSoDT.Location = new System.Drawing.Point(361, 141);
            this.cbSoDT.Name = "cbSoDT";
            this.cbSoDT.Size = new System.Drawing.Size(83, 24);
            this.cbSoDT.TabIndex = 10;
            this.cbSoDT.Text = "Số ĐT:";
            this.cbSoDT.UseVisualStyleBackColor = true;
            // 
            // cbSoCMND
            // 
            this.cbSoCMND.AutoSize = true;
            this.cbSoCMND.Location = new System.Drawing.Point(6, 180);
            this.cbSoCMND.Name = "cbSoCMND";
            this.cbSoCMND.Size = new System.Drawing.Size(112, 24);
            this.cbSoCMND.TabIndex = 9;
            this.cbSoCMND.Text = "Số CMND:";
            this.cbSoCMND.UseVisualStyleBackColor = true;
            // 
            // cbNgaySinh
            // 
            this.cbNgaySinh.AutoSize = true;
            this.cbNgaySinh.Location = new System.Drawing.Point(6, 141);
            this.cbNgaySinh.Name = "cbNgaySinh";
            this.cbNgaySinh.Size = new System.Drawing.Size(112, 24);
            this.cbNgaySinh.TabIndex = 8;
            this.cbNgaySinh.Text = "Ngày Sinh:";
            this.cbNgaySinh.UseVisualStyleBackColor = true;
            // 
            // cbHoVaTenLot
            // 
            this.cbHoVaTenLot.AutoSize = true;
            this.cbHoVaTenLot.Location = new System.Drawing.Point(6, 94);
            this.cbHoVaTenLot.Name = "cbHoVaTenLot";
            this.cbHoVaTenLot.Size = new System.Drawing.Size(131, 24);
            this.cbHoVaTenLot.TabIndex = 7;
            this.cbHoVaTenLot.Text = "Họ và tên lót:";
            this.cbHoVaTenLot.UseVisualStyleBackColor = true;
            // 
            // cbDiaChi
            // 
            this.cbDiaChi.AutoSize = true;
            this.cbDiaChi.Location = new System.Drawing.Point(361, 178);
            this.cbDiaChi.Name = "cbDiaChi";
            this.cbDiaChi.Size = new System.Drawing.Size(88, 24);
            this.cbDiaChi.TabIndex = 6;
            this.cbDiaChi.Text = "Địa chỉ:";
            this.cbDiaChi.UseVisualStyleBackColor = true;
            // 
            // cbLop
            // 
            this.cbLop.AutoSize = true;
            this.cbLop.Location = new System.Drawing.Point(361, 50);
            this.cbLop.Name = "cbLop";
            this.cbLop.Size = new System.Drawing.Size(64, 24);
            this.cbLop.TabIndex = 5;
            this.cbLop.Text = "Lớp:";
            this.cbLop.UseVisualStyleBackColor = true;
            // 
            // cbTen
            // 
            this.cbTen.AutoSize = true;
            this.cbTen.Location = new System.Drawing.Point(361, 94);
            this.cbTen.Name = "cbTen";
            this.cbTen.Size = new System.Drawing.Size(64, 24);
            this.cbTen.TabIndex = 4;
            this.cbTen.Text = "Tên:";
            this.cbTen.UseVisualStyleBackColor = true;
            // 
            // cbMSSV
            // 
            this.cbMSSV.AutoSize = true;
            this.cbMSSV.Location = new System.Drawing.Point(6, 50);
            this.cbMSSV.Name = "cbMSSV";
            this.cbMSSV.Size = new System.Drawing.Size(83, 24);
            this.cbMSSV.TabIndex = 3;
            this.cbMSSV.Text = "MSSV:";
            this.cbMSSV.UseVisualStyleBackColor = true;
            // 
            // bntTim
            // 
            this.bntTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntTim.ForeColor = System.Drawing.Color.Blue;
            this.bntTim.Location = new System.Drawing.Point(264, 254);
            this.bntTim.Name = "bntTim";
            this.bntTim.Size = new System.Drawing.Size(154, 38);
            this.bntTim.TabIndex = 29;
            this.bntTim.Text = "Tìm";
            this.bntTim.UseVisualStyleBackColor = true;
            this.bntTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // frmTim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 304);
            this.Controls.Add(this.bntTim);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTim";
            this.Text = "Tìm sinh viên";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bntTim;
        private System.Windows.Forms.CheckBox cbTen;
        private System.Windows.Forms.CheckBox cbMSSV;
        private System.Windows.Forms.CheckBox cbDiaChi;
        private System.Windows.Forms.CheckBox cbLop;
        private System.Windows.Forms.CheckBox cbSoDT;
        private System.Windows.Forms.CheckBox cbSoCMND;
        private System.Windows.Forms.CheckBox cbNgaySinh;
        private System.Windows.Forms.CheckBox cbHoVaTenLot;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtHoVaTenLot;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.MaskedTextBox txtMSSV;
        private System.Windows.Forms.MaskedTextBox txtSoCMND;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.MaskedTextBox txtSDT;
    }
}