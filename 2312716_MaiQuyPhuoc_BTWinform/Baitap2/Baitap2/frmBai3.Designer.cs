namespace Baitap2
{
    partial class frmBai3
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
            this.lblHo = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtHo = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGiaiThuaN = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdGiaiThuaN = new System.Windows.Forms.RadioButton();
            this.rdInHoTen = new System.Windows.Forms.RadioButton();
            this.bntXemKetQua = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHo
            // 
            this.lblHo.AutoSize = true;
            this.lblHo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHo.Location = new System.Drawing.Point(31, 28);
            this.lblHo.Name = "lblHo";
            this.lblHo.Size = new System.Drawing.Size(76, 20);
            this.lblHo.TabIndex = 0;
            this.lblHo.Text = "Nhập họ:";
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTen.Location = new System.Drawing.Point(31, 72);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(81, 20);
            this.lblTen.TabIndex = 1;
            this.lblTen.Text = "Nhập tên:";
            // 
            // txtHo
            // 
            this.txtHo.Location = new System.Drawing.Point(113, 28);
            this.txtHo.Name = "txtHo";
            this.txtHo.Size = new System.Drawing.Size(100, 22);
            this.txtHo.TabIndex = 2;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(113, 72);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(100, 22);
            this.txtTen.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nhập giai thừa:";
            // 
            // txtGiaiThuaN
            // 
            this.txtGiaiThuaN.Location = new System.Drawing.Point(159, 106);
            this.txtGiaiThuaN.Name = "txtGiaiThuaN";
            this.txtGiaiThuaN.Size = new System.Drawing.Size(100, 22);
            this.txtGiaiThuaN.TabIndex = 5;
            this.txtGiaiThuaN.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdGiaiThuaN);
            this.groupBox1.Controls.Add(this.rdInHoTen);
            this.groupBox1.Location = new System.Drawing.Point(35, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // rdGiaiThuaN
            // 
            this.rdGiaiThuaN.AutoSize = true;
            this.rdGiaiThuaN.Location = new System.Drawing.Point(7, 63);
            this.rdGiaiThuaN.Name = "rdGiaiThuaN";
            this.rdGiaiThuaN.Size = new System.Drawing.Size(101, 20);
            this.rdGiaiThuaN.TabIndex = 1;
            this.rdGiaiThuaN.TabStop = true;
            this.rdGiaiThuaN.Text = "In giai thừa n";
            this.rdGiaiThuaN.UseVisualStyleBackColor = true;
            // 
            // rdInHoTen
            // 
            this.rdInHoTen.AutoSize = true;
            this.rdInHoTen.Location = new System.Drawing.Point(7, 22);
            this.rdInHoTen.Name = "rdInHoTen";
            this.rdInHoTen.Size = new System.Drawing.Size(77, 20);
            this.rdInHoTen.TabIndex = 0;
            this.rdInHoTen.TabStop = true;
            this.rdInHoTen.Text = "In họ tên";
            this.rdInHoTen.UseVisualStyleBackColor = true;
            // 
            // bntXemKetQua
            // 
            this.bntXemKetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntXemKetQua.Location = new System.Drawing.Point(123, 280);
            this.bntXemKetQua.Name = "bntXemKetQua";
            this.bntXemKetQua.Size = new System.Drawing.Size(112, 37);
            this.bntXemKetQua.TabIndex = 7;
            this.bntXemKetQua.Text = "Xem kết quả ";
            this.bntXemKetQua.UseVisualStyleBackColor = true;
            this.bntXemKetQua.Click += new System.EventHandler(this.bntXemKetQua_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Kết quả là:";
            // 
            // lblKetQua
            // 
            this.lblKetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKetQua.Location = new System.Drawing.Point(154, 336);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(296, 60);
            this.lblKetQua.TabIndex = 9;
            this.lblKetQua.Text = ",";
            // 
            // frmBai3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bntXemKetQua);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtGiaiThuaN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtHo);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.lblHo);
            this.Name = "frmBai3";
            this.Text = "frmBai3";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHo;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtHo;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGiaiThuaN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdInHoTen;
        private System.Windows.Forms.RadioButton rdGiaiThuaN;
        private System.Windows.Forms.Button bntXemKetQua;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblKetQua;
    }
}