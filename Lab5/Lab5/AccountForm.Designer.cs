namespace Lab4_Basic_Command
{
    partial class AccountForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboNhomTK = new System.Windows.Forms.ComboBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.bntThem = new System.Windows.Forms.Button();
            this.bntCapNhat = new System.Windows.Forms.Button();
            this.bntResetMK = new System.Windows.Forms.Button();
            this.dgvAccount = new System.Windows.Forms.DataGridView();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiXoaTK = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiXemDSVT = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTongTK = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhóm tài khoản:";
            // 
            // cboNhomTK
            // 
            this.cboNhomTK.FormattingEnabled = true;
            this.cboNhomTK.Items.AddRange(new object[] {
            "Admin",
            "Thu Ngân",
            "Nhân Viên"});
            this.cboNhomTK.Location = new System.Drawing.Point(209, 28);
            this.cboNhomTK.Name = "cboNhomTK";
            this.cboNhomTK.Size = new System.Drawing.Size(178, 24);
            this.cboNhomTK.TabIndex = 1;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActive.Location = new System.Drawing.Point(445, 28);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(194, 24);
            this.chkActive.TabIndex = 2;
            this.chkActive.Text = "Theo trạng thái Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // bntThem
            // 
            this.bntThem.AutoSize = true;
            this.bntThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntThem.Location = new System.Drawing.Point(44, 86);
            this.bntThem.Name = "bntThem";
            this.bntThem.Size = new System.Drawing.Size(108, 40);
            this.bntThem.TabIndex = 3;
            this.bntThem.Text = "Thêm";
            this.bntThem.UseVisualStyleBackColor = true;
            this.bntThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // bntCapNhat
            // 
            this.bntCapNhat.AutoSize = true;
            this.bntCapNhat.Enabled = false;
            this.bntCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntCapNhat.Location = new System.Drawing.Point(237, 86);
            this.bntCapNhat.Name = "bntCapNhat";
            this.bntCapNhat.Size = new System.Drawing.Size(114, 40);
            this.bntCapNhat.TabIndex = 4;
            this.bntCapNhat.Text = "Cập nhật";
            this.bntCapNhat.UseVisualStyleBackColor = true;
            this.bntCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // bntResetMK
            // 
            this.bntResetMK.AutoSize = true;
            this.bntResetMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntResetMK.Location = new System.Drawing.Point(445, 86);
            this.bntResetMK.Name = "bntResetMK";
            this.bntResetMK.Size = new System.Drawing.Size(140, 40);
            this.bntResetMK.TabIndex = 5;
            this.bntResetMK.Text = "Reset mật khẩu";
            this.bntResetMK.UseVisualStyleBackColor = true;
            this.bntResetMK.Click += new System.EventHandler(this.bntResetMK_Click);
            // 
            // dgvAccount
            // 
            this.dgvAccount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountName,
            this.colFullName,
            this.colPassword,
            this.colEmail,
            this.colTell,
            this.colDateCreated});
            this.dgvAccount.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAccount.Location = new System.Drawing.Point(12, 161);
            this.dgvAccount.Name = "dgvAccount";
            this.dgvAccount.ReadOnly = true;
            this.dgvAccount.RowHeadersWidth = 51;
            this.dgvAccount.RowTemplate.Height = 24;
            this.dgvAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccount.Size = new System.Drawing.Size(845, 337);
            this.dgvAccount.TabIndex = 6;
            this.dgvAccount.SelectionChanged += new System.EventHandler(this.dgvAccount_SelectionChanged);
            // 
            // colAccountName
            // 
            this.colAccountName.DataPropertyName = "AccountName";
            this.colAccountName.HeaderText = "Tên đăng nhập";
            this.colAccountName.MinimumWidth = 6;
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.ReadOnly = true;
            // 
            // colFullName
            // 
            this.colFullName.DataPropertyName = "FullName";
            this.colFullName.HeaderText = "Họ tên";
            this.colFullName.MinimumWidth = 6;
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            // 
            // colPassword
            // 
            this.colPassword.DataPropertyName = "Password";
            this.colPassword.HeaderText = "Mật khẩu";
            this.colPassword.MinimumWidth = 6;
            this.colPassword.Name = "colPassword";
            this.colPassword.ReadOnly = true;
            this.colPassword.Visible = false;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.HeaderText = "Email";
            this.colEmail.MinimumWidth = 6;
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colTell
            // 
            this.colTell.DataPropertyName = "Tell";
            this.colTell.HeaderText = "SĐT";
            this.colTell.MinimumWidth = 6;
            this.colTell.Name = "colTell";
            this.colTell.ReadOnly = true;
            // 
            // colDateCreated
            // 
            this.colDateCreated.DataPropertyName = "DateCreated";
            this.colDateCreated.HeaderText = "Ngày tạo";
            this.colDateCreated.MinimumWidth = 6;
            this.colDateCreated.Name = "colDateCreated";
            this.colDateCreated.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRefresh,
            this.tsmiXoaTK,
            this.tsmiXemDSVT});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(225, 76);
            // 
            // tsmiRefresh
            // 
            this.tsmiRefresh.Name = "tsmiRefresh";
            this.tsmiRefresh.Size = new System.Drawing.Size(224, 24);
            this.tsmiRefresh.Text = "Refresh";
            this.tsmiRefresh.Click += new System.EventHandler(this.tsmiRefresh_Click);
            // 
            // tsmiXoaTK
            // 
            this.tsmiXoaTK.Name = "tsmiXoaTK";
            this.tsmiXoaTK.Size = new System.Drawing.Size(224, 24);
            this.tsmiXoaTK.Text = "Xóa tài khoản";
            this.tsmiXoaTK.Click += new System.EventHandler(this.tsmiXoaTK_Click);
            // 
            // tsmiXemDSVT
            // 
            this.tsmiXemDSVT.Name = "tsmiXemDSVT";
            this.tsmiXemDSVT.Size = new System.Drawing.Size(224, 24);
            this.tsmiXemDSVT.Text = "Xem danh sách vai trò";
            this.tsmiXemDSVT.Click += new System.EventHandler(this.tsmiXemDSVT_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bntResetMK);
            this.groupBox1.Controls.Add(this.bntCapNhat);
            this.groupBox1.Controls.Add(this.chkActive);
            this.groupBox1.Controls.Add(this.bntThem);
            this.groupBox1.Controls.Add(this.cboNhomTK);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(845, 143);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // lblTongTK
            // 
            this.lblTongTK.AutoSize = true;
            this.lblTongTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTK.Location = new System.Drawing.Point(12, 505);
            this.lblTongTK.Name = "lblTongTK";
            this.lblTongTK.Size = new System.Drawing.Size(146, 20);
            this.lblTongTK.TabIndex = 8;
            this.lblTongTK.Text = "Tổng số tài khoản:";
            // 
            // AccountManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 532);
            this.Controls.Add(this.lblTongTK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvAccount);
            this.Name = "AccountManagerForm";
            this.Text = "AccountManager";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AccountManagerForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboNhomTK;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button bntThem;
        private System.Windows.Forms.Button bntCapNhat;
        private System.Windows.Forms.Button bntResetMK;
        private System.Windows.Forms.DataGridView dgvAccount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTongTK;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiXoaTK;
        private System.Windows.Forms.ToolStripMenuItem tsmiXemDSVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTell;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateCreated;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefresh;
    }
}