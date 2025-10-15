namespace Lab4_Basic_Command
{
    partial class AccountManagerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboNhomTK = new System.Windows.Forms.ComboBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.bntThem = new System.Windows.Forms.Button();
            this.bntCapNhap = new System.Windows.Forms.Button();
            this.bntResetMK = new System.Windows.Forms.Button();
            this.dgvAccount = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTongTK = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).BeginInit();
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
            this.bntThem.Location = new System.Drawing.Point(44, 92);
            this.bntThem.Name = "bntThem";
            this.bntThem.Size = new System.Drawing.Size(108, 40);
            this.bntThem.TabIndex = 3;
            this.bntThem.Text = "Thêm";
            this.bntThem.UseVisualStyleBackColor = true;
            // 
            // bntCapNhap
            // 
            this.bntCapNhap.AutoSize = true;
            this.bntCapNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntCapNhap.Location = new System.Drawing.Point(209, 92);
            this.bntCapNhap.Name = "bntCapNhap";
            this.bntCapNhap.Size = new System.Drawing.Size(105, 40);
            this.bntCapNhap.TabIndex = 4;
            this.bntCapNhap.Text = "Cập nhật";
            this.bntCapNhap.UseVisualStyleBackColor = true;
            // 
            // bntResetMK
            // 
            this.bntResetMK.AutoSize = true;
            this.bntResetMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntResetMK.Location = new System.Drawing.Point(375, 92);
            this.bntResetMK.Name = "bntResetMK";
            this.bntResetMK.Size = new System.Drawing.Size(140, 40);
            this.bntResetMK.TabIndex = 5;
            this.bntResetMK.Text = "Reset mật khẩu";
            this.bntResetMK.UseVisualStyleBackColor = true;
            // 
            // dgvAccount
            // 
            this.dgvAccount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccount.Location = new System.Drawing.Point(12, 214);
            this.dgvAccount.Name = "dgvAccount";
            this.dgvAccount.RowHeadersWidth = 51;
            this.dgvAccount.RowTemplate.Height = 24;
            this.dgvAccount.Size = new System.Drawing.Size(776, 284);
            this.dgvAccount.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bntResetMK);
            this.groupBox1.Controls.Add(this.bntCapNhap);
            this.groupBox1.Controls.Add(this.chkActive);
            this.groupBox1.Controls.Add(this.bntThem);
            this.groupBox1.Controls.Add(this.cboNhomTK);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 196);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
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
            this.ClientSize = new System.Drawing.Size(800, 534);
            this.Controls.Add(this.lblTongTK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvAccount);
            this.Name = "AccountManagerForm";
            this.Text = "AccountManager";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).EndInit();
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
        private System.Windows.Forms.Button bntCapNhap;
        private System.Windows.Forms.Button bntResetMK;
        private System.Windows.Forms.DataGridView dgvAccount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTongTK;
    }
}