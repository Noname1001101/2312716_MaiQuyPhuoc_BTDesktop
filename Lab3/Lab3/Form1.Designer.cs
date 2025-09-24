namespace Lab3
{
    partial class Form1
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.label1 = new System.Windows.Forms.Label();
            this.mtxtMSSV = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHoVaTenLot = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.mtxtSoCMND = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.rdNam = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.rdNu = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.mtxtSDT = new System.Windows.Forms.MaskedTextBox();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.clbMHDK = new System.Windows.Forms.CheckedListBox();
            this.bntTimKiem = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.bntCapNhat = new System.Windows.Forms.Button();
            this.bntThoat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvSinhVien = new System.Windows.Forms.ListView();
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "MSSV:";
            // 
            // mtxtMSSV
            // 
            this.mtxtMSSV.Location = new System.Drawing.Point(153, 46);
            this.mtxtMSSV.Mask = "0000000";
            this.mtxtMSSV.Name = "mtxtMSSV";
            this.mtxtMSSV.Size = new System.Drawing.Size(216, 22);
            this.mtxtMSSV.TabIndex = 1;
            this.mtxtMSSV.ValidatingType = typeof(int);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ và tên lót:";
            // 
            // txtHoVaTenLot
            // 
            this.txtHoVaTenLot.Location = new System.Drawing.Point(153, 84);
            this.txtHoVaTenLot.Name = "txtHoVaTenLot";
            this.txtHoVaTenLot.Size = new System.Drawing.Size(216, 22);
            this.txtHoVaTenLot.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày sinh:";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(153, 128);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(216, 22);
            this.dtpNgaySinh.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Số CMND:";
            // 
            // mtxtSoCMND
            // 
            this.mtxtSoCMND.Location = new System.Drawing.Point(153, 175);
            this.mtxtSoCMND.Mask = "000000000";
            this.mtxtSoCMND.Name = "mtxtSoCMND";
            this.mtxtSoCMND.Size = new System.Drawing.Size(216, 22);
            this.mtxtSoCMND.TabIndex = 7;
            this.mtxtSoCMND.ValidatingType = typeof(int);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Địa chỉ liên lạc:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(153, 222);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(542, 22);
            this.txtDiaChi.TabIndex = 9;
            // 
            // rdNam
            // 
            this.rdNam.AutoSize = true;
            this.rdNam.Location = new System.Drawing.Point(512, 42);
            this.rdNam.Name = "rdNam";
            this.rdNam.Size = new System.Drawing.Size(57, 20);
            this.rdNam.TabIndex = 10;
            this.rdNam.TabStop = true;
            this.rdNam.Text = "Nam";
            this.rdNam.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(392, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Giới tính:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(401, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tên:";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(512, 81);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(183, 22);
            this.txtTen.TabIndex = 13;
            // 
            // rdNu
            // 
            this.rdNu.AutoSize = true;
            this.rdNu.Location = new System.Drawing.Point(602, 42);
            this.rdNu.Name = "rdNu";
            this.rdNu.Size = new System.Drawing.Size(45, 20);
            this.rdNu.TabIndex = 14;
            this.rdNu.TabStop = true;
            this.rdNu.Text = "Nữ";
            this.rdNu.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(402, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Lớp:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(401, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Số ĐT:";
            // 
            // mtxtSDT
            // 
            this.mtxtSDT.Location = new System.Drawing.Point(512, 175);
            this.mtxtSDT.Mask = "0000.000.000";
            this.mtxtSDT.Name = "mtxtSDT";
            this.mtxtSDT.Size = new System.Drawing.Size(183, 22);
            this.mtxtSDT.TabIndex = 17;
            // 
            // cboLop
            // 
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(512, 125);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(183, 24);
            this.cboLop.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(34, 304);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Môn học đăng ký:";
            // 
            // clbMHDK
            // 
            this.clbMHDK.FormattingEnabled = true;
            this.clbMHDK.Items.AddRange(new object[] {
            "Mạng máy tính",
            "Hệ điều hành",
            "Lập trình CSDL",
            "Lập trình mạng",
            "Đồ án cơ sở",
            "Phương pháp NCKH",
            "Lập trình trên thiết bị di động",
            "An toàn và bảo mật hệ thống"});
            this.clbMHDK.Location = new System.Drawing.Point(152, 273);
            this.clbMHDK.MultiColumn = true;
            this.clbMHDK.Name = "clbMHDK";
            this.clbMHDK.Size = new System.Drawing.Size(543, 72);
            this.clbMHDK.TabIndex = 20;
            // 
            // bntTimKiem
            // 
            this.bntTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntTimKiem.Location = new System.Drawing.Point(291, 367);
            this.bntTimKiem.Name = "bntTimKiem";
            this.bntTimKiem.Size = new System.Drawing.Size(95, 30);
            this.bntTimKiem.TabIndex = 21;
            this.bntTimKiem.Text = "Tìm kiếm";
            this.bntTimKiem.UseVisualStyleBackColor = true;
            this.bntTimKiem.Click += new System.EventHandler(this.bntTimKiem_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(404, 367);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(95, 30);
            this.btnThem.TabIndex = 22;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // bntCapNhat
            // 
            this.bntCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntCapNhat.Location = new System.Drawing.Point(530, 367);
            this.bntCapNhat.Name = "bntCapNhat";
            this.bntCapNhat.Size = new System.Drawing.Size(95, 30);
            this.bntCapNhat.TabIndex = 23;
            this.bntCapNhat.Text = "Cập nhật";
            this.bntCapNhat.UseVisualStyleBackColor = true;
            this.bntCapNhat.Click += new System.EventHandler(this.bntCapNhat_Click);
            // 
            // bntThoat
            // 
            this.bntThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntThoat.Location = new System.Drawing.Point(653, 367);
            this.bntThoat.Name = "bntThoat";
            this.bntThoat.Size = new System.Drawing.Size(95, 30);
            this.bntThoat.TabIndex = 24;
            this.bntThoat.Text = "Thoát";
            this.bntThoat.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvSinhVien);
            this.groupBox1.Location = new System.Drawing.Point(12, 430);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 354);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách sinh viên";
            // 
            // lvSinhVien
            // 
            this.lvSinhVien.CheckBoxes = true;
            this.lvSinhVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader0,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvSinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSinhVien.GridLines = true;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "MSSV";
            this.lvSinhVien.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.lvSinhVien.HideSelection = false;
            this.lvSinhVien.Location = new System.Drawing.Point(3, 18);
            this.lvSinhVien.Name = "lvSinhVien";
            this.lvSinhVien.Size = new System.Drawing.Size(770, 333);
            this.lvSinhVien.TabIndex = 0;
            this.lvSinhVien.UseCompatibleStateImageBehavior = false;
            this.lvSinhVien.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = "MSSV";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Họ và tên lót";
            this.columnHeader1.Width = 148;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên";
            this.columnHeader2.Width = 71;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ngày sinh";
            this.columnHeader3.Width = 93;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Lớp";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Số CMND";
            this.columnHeader5.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Số điện thoại";
            this.columnHeader6.Width = 93;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Địa chỉ liên lạc";
            this.columnHeader7.Width = 147;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 796);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bntThoat);
            this.Controls.Add(this.bntCapNhat);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.bntTimKiem);
            this.Controls.Add(this.clbMHDK);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.mtxtSDT);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rdNu);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rdNam);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mtxtSoCMND);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHoVaTenLot);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mtxtMSSV);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Nhập thông tin sinh viên";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtxtMSSV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHoVaTenLot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mtxtSoCMND;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.RadioButton rdNam;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.RadioButton rdNu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox mtxtSDT;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckedListBox clbMHDK;
        private System.Windows.Forms.Button bntTimKiem;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button bntCapNhat;
        private System.Windows.Forms.Button bntThoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvSinhVien;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}

