namespace MyForm
{
    partial class frmGiangVien
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
            this.lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMaSo = new System.Windows.Forms.ComboBox();
            this.rdNam = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rdNu = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mtxtSoDT = new System.Windows.Forms.MaskedTextBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chklbNgoaiNgu = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbDanhSachHP = new System.Windows.Forms.ListBox();
            this.lbHocPhanDay = new System.Windows.Forms.ListBox();
            this.btnChon = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThongBao = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.linklbLienHe = new System.Windows.Forms.LinkLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.bntThem = new System.Windows.Forms.Button();
            this.bntTim = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.MediumOrchid;
            this.lbl.Location = new System.Drawing.Point(49, 9);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(465, 29);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "THÔNG TIN GIẢNG VIÊN KHOA CNTT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Số";
            // 
            // cboMaSo
            // 
            this.cboMaSo.FormattingEnabled = true;
            this.cboMaSo.Items.AddRange(new object[] {
            "001",
            "002",
            "003",
            "004"});
            this.cboMaSo.Location = new System.Drawing.Point(109, 55);
            this.cboMaSo.Name = "cboMaSo";
            this.cboMaSo.Size = new System.Drawing.Size(121, 24);
            this.cboMaSo.TabIndex = 2;
            // 
            // rdNam
            // 
            this.rdNam.AutoSize = true;
            this.rdNam.Checked = true;
            this.rdNam.Location = new System.Drawing.Point(397, 61);
            this.rdNam.Name = "rdNam";
            this.rdNam.Size = new System.Drawing.Size(57, 20);
            this.rdNam.TabIndex = 3;
            this.rdNam.TabStop = true;
            this.rdNam.Text = "Nam";
            this.rdNam.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(304, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Giới Tính";
            // 
            // rdNu
            // 
            this.rdNu.AutoSize = true;
            this.rdNu.Location = new System.Drawing.Point(460, 61);
            this.rdNu.Name = "rdNu";
            this.rdNu.Size = new System.Drawing.Size(45, 20);
            this.rdNu.TabIndex = 5;
            this.rdNu.Text = "Nữ";
            this.rdNu.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Họ Tên";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(109, 92);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(173, 22);
            this.txtHoTen.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(304, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Số ĐT";
            // 
            // mtxtSoDT
            // 
            this.mtxtSoDT.Location = new System.Drawing.Point(397, 95);
            this.mtxtSoDT.Mask = "(\\0633).000.0000";
            this.mtxtSoDT.Name = "mtxtSoDT";
            this.mtxtSoDT.Size = new System.Drawing.Size(108, 22);
            this.mtxtSoDT.TabIndex = 9;
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Location = new System.Drawing.Point(109, 131);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(190, 22);
            this.dtpNgaySinh.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ngày Sinh";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(305, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Địa chỉ mail";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(397, 133);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(108, 22);
            this.txtMail.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Ngoại Ngữ";
            // 
            // chklbNgoaiNgu
            // 
            this.chklbNgoaiNgu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chklbNgoaiNgu.FormattingEnabled = true;
            this.chklbNgoaiNgu.Items.AddRange(new object[] {
            "Tiếng Anh",
            "Tiếng Pháp",
            "Tiếng Nhật",
            "Tiếng Nga"});
            this.chklbNgoaiNgu.Location = new System.Drawing.Point(109, 170);
            this.chklbNgoaiNgu.Name = "chklbNgoaiNgu";
            this.chklbNgoaiNgu.Size = new System.Drawing.Size(120, 80);
            this.chklbNgoaiNgu.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(373, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Môn học giáo viên dạy";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(106, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Danh sách môn học";
            // 
            // lbDanhSachHP
            // 
            this.lbDanhSachHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDanhSachHP.FormattingEnabled = true;
            this.lbDanhSachHP.ItemHeight = 16;
            this.lbDanhSachHP.Items.AddRange(new object[] {
            "Tin học cơ sở",
            "Lập trình cấu trúc C/C++",
            "Cơ sở dữ liệu\'",
            "Tiếng Anh B1",
            "Tiếng Anh B2",
            "Lập trình hướng đối tượng",
            "Mạng máy tính",
            "Công nghệ phần mềm",
            "Phân tích TKHDT"});
            this.lbDanhSachHP.Location = new System.Drawing.Point(109, 272);
            this.lbDanhSachHP.Name = "lbDanhSachHP";
            this.lbDanhSachHP.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbDanhSachHP.Size = new System.Drawing.Size(173, 148);
            this.lbDanhSachHP.TabIndex = 18;
            // 
            // lbHocPhanDay
            // 
            this.lbHocPhanDay.FormattingEnabled = true;
            this.lbHocPhanDay.ItemHeight = 16;
            this.lbHocPhanDay.Location = new System.Drawing.Point(376, 272);
            this.lbHocPhanDay.Name = "lbHocPhanDay";
            this.lbHocPhanDay.Size = new System.Drawing.Size(173, 148);
            this.lbHocPhanDay.TabIndex = 19;
            // 
            // btnChon
            // 
            this.btnChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChon.Location = new System.Drawing.Point(295, 291);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(63, 43);
            this.btnChon.TabIndex = 20;
            this.btnChon.Text = ">>";
            this.btnChon.UseVisualStyleBackColor = true;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(298, 353);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(60, 44);
            this.btnXoa.TabIndex = 21;
            this.btnXoa.Text = "<<";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThongBao
            // 
            this.btnThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongBao.ForeColor = System.Drawing.Color.Blue;
            this.btnThongBao.Location = new System.Drawing.Point(249, 438);
            this.btnThongBao.Name = "btnThongBao";
            this.btnThongBao.Size = new System.Drawing.Size(105, 37);
            this.btnThongBao.TabIndex = 22;
            this.btnThongBao.Text = "Thông Báo";
            this.btnThongBao.UseVisualStyleBackColor = true;
            this.btnThongBao.Click += new System.EventHandler(this.btnThongBao_Click);

            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Blue;
            this.btnExit.Location = new System.Drawing.Point(488, 438);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(85, 37);
            this.btnExit.TabIndex = 24;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // linklbLienHe
            // 
            this.linklbLienHe.AutoSize = true;
            this.linklbLienHe.Location = new System.Drawing.Point(557, 495);
            this.linklbLienHe.Name = "linklbLienHe";
            this.linklbLienHe.Size = new System.Drawing.Size(50, 16);
            this.linklbLienHe.TabIndex = 25;
            this.linklbLienHe.TabStop = true;
            this.linklbLienHe.Text = "Liên hệ";
            this.linklbLienHe.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklbLienHe_LinkClicked);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(485, 495);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 26;
            this.label10.Text = "Website";
            // 
            // bntThem
            // 
            this.bntThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntThem.ForeColor = System.Drawing.Color.Blue;
            this.bntThem.Location = new System.Drawing.Point(137, 438);
            this.bntThem.Name = "bntThem";
            this.bntThem.Size = new System.Drawing.Size(92, 37);
            this.bntThem.TabIndex = 27;
            this.bntThem.Text = "Thêm";
            this.bntThem.UseVisualStyleBackColor = true;
            this.bntThem.Click += new System.EventHandler(this.bntThem_Click);
            // 
            // bntTim
            // 
            this.bntTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntTim.ForeColor = System.Drawing.Color.Blue;
            this.bntTim.Location = new System.Drawing.Point(12, 438);
            this.bntTim.Name = "bntTim";
            this.bntTim.Size = new System.Drawing.Size(92, 37);
            this.bntTim.TabIndex = 28;
            this.bntTim.Text = "Tìm";
            this.bntTim.UseVisualStyleBackColor = true;
            this.bntTim.Click += new System.EventHandler(this.bntTim_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Image = global::MyForm.Properties.Resources.Cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(367, 438);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 37);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmGiangVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 520);
            this.Controls.Add(this.bntTim);
            this.Controls.Add(this.bntThem);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.linklbLienHe);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnThongBao);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.lbHocPhanDay);
            this.Controls.Add(this.lbDanhSachHP);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chklbNgoaiNgu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.mtxtSoDT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rdNu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdNam);
            this.Controls.Add(this.cboMaSo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl);
            this.Name = "frmGiangVien";
            this.Text = "Thông tin giảng viên";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMaSo;
        private System.Windows.Forms.RadioButton rdNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdNu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mtxtSoDT;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox chklbNgoaiNgu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox lbDanhSachHP;
        private System.Windows.Forms.ListBox lbHocPhanDay;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThongBao;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.LinkLabel linklbLienHe;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button bntThem;
        private System.Windows.Forms.Button bntTim;
    }
}