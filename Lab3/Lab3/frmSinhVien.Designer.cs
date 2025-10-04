namespace Lab3
{
    partial class frmSinhVien
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.label1 = new System.Windows.Forms.Label();
            this.txtMSSV = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHoVaTenLot = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoCMND = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.rdNam = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.rdNu = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.MaskedTextBox();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.clbMHDK = new System.Windows.Forms.CheckedListBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mennuThemMon = new System.Windows.Forms.ToolStripMenuItem();
            this.menuXoaMon = new System.Windows.Forms.ToolStripMenuItem();
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.đọcFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDocTXT = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDocXML = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDocJSON = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "MSSV:";
            // 
            // txtMSSV
            // 
            this.txtMSSV.Location = new System.Drawing.Point(153, 46);
            this.txtMSSV.Mask = "0000000";
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.ReadOnly = true;
            this.txtMSSV.Size = new System.Drawing.Size(261, 22);
            this.txtMSSV.TabIndex = 20;
            this.txtMSSV.ValidatingType = typeof(int);
            this.txtMSSV.Click += new System.EventHandler(this.txtMSSV_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ và tên lót:";
            // 
            // txtHoVaTenLot
            // 
            this.txtHoVaTenLot.Location = new System.Drawing.Point(153, 84);
            this.txtHoVaTenLot.Name = "txtHoVaTenLot";
            this.txtHoVaTenLot.Size = new System.Drawing.Size(261, 22);
            this.txtHoVaTenLot.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày sinh:";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(153, 128);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(261, 22);
            this.dtpNgaySinh.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Số CMND:";
            // 
            // txtSoCMND
            // 
            this.txtSoCMND.Location = new System.Drawing.Point(153, 175);
            this.txtSoCMND.Mask = "000000000";
            this.txtSoCMND.Name = "txtSoCMND";
            this.txtSoCMND.Size = new System.Drawing.Size(261, 22);
            this.txtSoCMND.TabIndex = 3;
            this.txtSoCMND.ValidatingType = typeof(int);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Địa chỉ liên lạc:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(153, 222);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(669, 22);
            this.txtDiaChi.TabIndex = 9;
            // 
            // rdNam
            // 
            this.rdNam.AutoSize = true;
            this.rdNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdNam.Location = new System.Drawing.Point(576, 44);
            this.rdNam.Name = "rdNam";
            this.rdNam.Size = new System.Drawing.Size(65, 24);
            this.rdNam.TabIndex = 4;
            this.rdNam.TabStop = true;
            this.rdNam.Text = "Nam";
            this.rdNam.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(487, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Giới tính:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(487, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tên:";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(576, 84);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(246, 22);
            this.txtTen.TabIndex = 6;
            // 
            // rdNu
            // 
            this.rdNu.AutoSize = true;
            this.rdNu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdNu.Location = new System.Drawing.Point(673, 46);
            this.rdNu.Name = "rdNu";
            this.rdNu.Size = new System.Drawing.Size(51, 24);
            this.rdNu.TabIndex = 5;
            this.rdNu.TabStop = true;
            this.rdNu.Text = "Nữ";
            this.rdNu.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(487, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Lớp:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(487, 172);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Số ĐT:";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(576, 172);
            this.txtSDT.Mask = "0000.000.000";
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(246, 22);
            this.txtSDT.TabIndex = 8;
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
            "VLK40",
            "FFF60"});
            this.cboLop.Location = new System.Drawing.Point(576, 129);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(246, 24);
            this.cboLop.TabIndex = 7;
            this.cboLop.SelectedIndexChanged += new System.EventHandler(this.cboLop_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 298);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(213, 23);
            this.label10.TabIndex = 19;
            this.label10.Text = "Môn học đăng ký:";
            // 
            // clbMHDK
            // 
            this.clbMHDK.ColumnWidth = 240;
            this.clbMHDK.ContextMenuStrip = this.contextMenuStrip2;
            this.clbMHDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.clbMHDK.Location = new System.Drawing.Point(163, 269);
            this.clbMHDK.MultiColumn = true;
            this.clbMHDK.Name = "clbMHDK";
            this.clbMHDK.Size = new System.Drawing.Size(670, 89);
            this.clbMHDK.TabIndex = 10;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mennuThemMon,
            this.menuXoaMon});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(150, 52);
            // 
            // mennuThemMon
            // 
            this.mennuThemMon.Name = "mennuThemMon";
            this.mennuThemMon.Size = new System.Drawing.Size(149, 24);
            this.mennuThemMon.Text = "Thêm môn";
            this.mennuThemMon.Click += new System.EventHandler(this.mennuThemMon_Click);
            // 
            // menuXoaMon
            // 
            this.menuXoaMon.Name = "menuXoaMon";
            this.menuXoaMon.Size = new System.Drawing.Size(149, 24);
            this.menuXoaMon.Text = "Xóa môn";
            this.menuXoaMon.Click += new System.EventHandler(this.menuXoaMon_Click);
            // 
            // bntTimKiem
            // 
            this.bntTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntTimKiem.Location = new System.Drawing.Point(319, 378);
            this.bntTimKiem.Name = "bntTimKiem";
            this.bntTimKiem.Size = new System.Drawing.Size(95, 30);
            this.bntTimKiem.TabIndex = 11;
            this.bntTimKiem.Text = "Tìm kiếm";
            this.bntTimKiem.UseVisualStyleBackColor = true;
            this.bntTimKiem.Click += new System.EventHandler(this.bntTimKiem_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(453, 378);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(95, 30);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // bntCapNhat
            // 
            this.bntCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntCapNhat.Location = new System.Drawing.Point(590, 378);
            this.bntCapNhat.Name = "bntCapNhat";
            this.bntCapNhat.Size = new System.Drawing.Size(114, 30);
            this.bntCapNhat.TabIndex = 13;
            this.bntCapNhat.Text = "Cập nhật";
            this.bntCapNhat.UseVisualStyleBackColor = true;
            this.bntCapNhat.Click += new System.EventHandler(this.bntCapNhat_Click);
            // 
            // bntThoat
            // 
            this.bntThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntThoat.Location = new System.Drawing.Point(727, 378);
            this.bntThoat.Name = "bntThoat";
            this.bntThoat.Size = new System.Drawing.Size(95, 30);
            this.bntThoat.TabIndex = 14;
            this.bntThoat.Text = "Thoát";
            this.bntThoat.UseVisualStyleBackColor = true;
            this.bntThoat.Click += new System.EventHandler(this.bntThoat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvSinhVien);
            this.groupBox1.Location = new System.Drawing.Point(12, 430);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(852, 354);
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
            this.lvSinhVien.ContextMenuStrip = this.contextMenuStrip1;
            this.lvSinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSinhVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvSinhVien.FullRowSelect = true;
            this.lvSinhVien.GridLines = true;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "MSSV";
            this.lvSinhVien.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.lvSinhVien.HideSelection = false;
            this.lvSinhVien.Location = new System.Drawing.Point(3, 18);
            this.lvSinhVien.Name = "lvSinhVien";
            this.lvSinhVien.Size = new System.Drawing.Size(846, 333);
            this.lvSinhVien.TabIndex = 0;
            this.lvSinhVien.UseCompatibleStateImageBehavior = false;
            this.lvSinhVien.View = System.Windows.Forms.View.Details;
            this.lvSinhVien.SelectedIndexChanged += new System.EventHandler(this.lvSinhVien_SelectedIndexChanged);
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
            this.columnHeader6.Width = 121;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Địa chỉ liên lạc";
            this.columnHeader7.Width = 201;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuXoa});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(105, 28);
            // 
            // menuXoa
            // 
            this.menuXoa.Name = "menuXoa";
            this.menuXoa.Size = new System.Drawing.Size(104, 24);
            this.menuXoa.Text = "Xóa";
            this.menuXoa.Click += new System.EventHandler(this.menuXoa_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đọcFileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(864, 28);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // đọcFileToolStripMenuItem
            // 
            this.đọcFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDocTXT,
            this.menuDocXML,
            this.menuDocJSON});
            this.đọcFileToolStripMenuItem.Name = "đọcFileToolStripMenuItem";
            this.đọcFileToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.đọcFileToolStripMenuItem.Text = "Đọc File";
            // 
            // menuDocTXT
            // 
            this.menuDocTXT.Name = "menuDocTXT";
            this.menuDocTXT.Size = new System.Drawing.Size(183, 26);
            this.menuDocTXT.Text = "Đọc file txt";
            this.menuDocTXT.Click += new System.EventHandler(this.menuDocTXT_Click);
            // 
            // menuDocXML
            // 
            this.menuDocXML.Name = "menuDocXML";
            this.menuDocXML.Size = new System.Drawing.Size(183, 26);
            this.menuDocXML.Text = "Đọc file XML";
            this.menuDocXML.Click += new System.EventHandler(this.menuDocXML_Click);
            // 
            // menuDocJSON
            // 
            this.menuDocJSON.Name = "menuDocJSON";
            this.menuDocJSON.Size = new System.Drawing.Size(183, 26);
            this.menuDocJSON.Text = "Đọc file JSON";
            this.menuDocJSON.Click += new System.EventHandler(this.menuDocJSON_Click);
            // 
            // frmSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 796);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bntThoat);
            this.Controls.Add(this.bntCapNhat);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.bntTimKiem);
            this.Controls.Add(this.clbMHDK);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rdNu);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rdNam);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSoCMND);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHoVaTenLot);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMSSV);
            this.Controls.Add(this.label1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmSinhVien";
            this.Text = "Nhập thông tin sinh viên";
            this.Load += new System.EventHandler(this.frmSinhVien_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmSinhVien_MouseDown);
            this.contextMenuStrip2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtMSSV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHoVaTenLot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtSoCMND;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.RadioButton rdNam;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.RadioButton rdNu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtSDT;
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuXoa;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem mennuThemMon;
        private System.Windows.Forms.ToolStripMenuItem menuXoaMon;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem đọcFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuDocTXT;
        private System.Windows.Forms.ToolStripMenuItem menuDocXML;
        private System.Windows.Forms.ToolStripMenuItem menuDocJSON;
    }
}

