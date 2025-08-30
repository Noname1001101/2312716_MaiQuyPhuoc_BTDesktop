namespace Baitap3
{
    partial class FrmBai3
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
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSoNguyen1 = new System.Windows.Forms.TextBox();
            this.txtSoNguyen2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdSoNguyenLT = new System.Windows.Forms.RadioButton();
            this.rdTachChuoi = new System.Windows.Forms.RadioButton();
            this.lbl = new System.Windows.Forms.Label();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.bntXemKetQua = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(161, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ và tên:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(253, 30);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(169, 22);
            this.txtHoTen.TabIndex = 1;
            this.txtHoTen.TextChanged += new System.EventHandler(this.txtHoTen_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nhập số nguyên thứ nhất:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nhập số nguyên thứ hai:";
            // 
            // txtSoNguyen1
            // 
            this.txtSoNguyen1.Location = new System.Drawing.Point(253, 68);
            this.txtSoNguyen1.Name = "txtSoNguyen1";
            this.txtSoNguyen1.Size = new System.Drawing.Size(169, 22);
            this.txtSoNguyen1.TabIndex = 4;
            // 
            // txtSoNguyen2
            // 
            this.txtSoNguyen2.Location = new System.Drawing.Point(253, 102);
            this.txtSoNguyen2.Name = "txtSoNguyen2";
            this.txtSoNguyen2.Size = new System.Drawing.Size(169, 22);
            this.txtSoNguyen2.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.rdSoNguyenLT);
            this.groupBox1.Controls.Add(this.rdTachChuoi);
            this.groupBox1.Location = new System.Drawing.Point(193, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 106);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn chức năng:";
            // 
            // rdSoNguyenLT
            // 
            this.rdSoNguyenLT.AutoSize = true;
            this.rdSoNguyenLT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdSoNguyenLT.Location = new System.Drawing.Point(6, 61);
            this.rdSoNguyenLT.Name = "rdSoNguyenLT";
            this.rdSoNguyenLT.Size = new System.Drawing.Size(185, 24);
            this.rdSoNguyenLT.TabIndex = 1;
            this.rdSoNguyenLT.TabStop = true;
            this.rdSoNguyenLT.Text = "Số Nguyên Liên Tiếp";
            this.rdSoNguyenLT.UseVisualStyleBackColor = true;
            // 
            // rdTachChuoi
            // 
            this.rdTachChuoi.AutoSize = true;
            this.rdTachChuoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTachChuoi.Location = new System.Drawing.Point(7, 22);
            this.rdTachChuoi.Name = "rdTachChuoi";
            this.rdTachChuoi.Size = new System.Drawing.Size(112, 24);
            this.rdTachChuoi.TabIndex = 0;
            this.rdTachChuoi.TabStop = true;
            this.rdTachChuoi.Text = "Tách chuỗi";
            this.rdTachChuoi.UseVisualStyleBackColor = true;
            // 
            // lbl
            // 
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(160, 312);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(107, 23);
            this.lbl.TabIndex = 8;
            this.lbl.Text = "Kết quả là:";
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKetQua.Location = new System.Drawing.Point(277, 312);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(0, 25);
            this.lblKetQua.TabIndex = 9;
            // 
            // bntXemKetQua
            // 
            this.bntXemKetQua.AutoSize = true;
            this.bntXemKetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntXemKetQua.Location = new System.Drawing.Point(273, 255);
            this.bntXemKetQua.Name = "bntXemKetQua";
            this.bntXemKetQua.Size = new System.Drawing.Size(120, 37);
            this.bntXemKetQua.TabIndex = 10;
            this.bntXemKetQua.Text = "Xem kết quả";
            this.bntXemKetQua.UseVisualStyleBackColor = true;
            this.bntXemKetQua.Click += new System.EventHandler(this.bntXemKetQua_Click);
            // 
            // FrmBai3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bntXemKetQua);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSoNguyen2);
            this.Controls.Add(this.txtSoNguyen1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label1);
            this.Name = "FrmBai3";
            this.Text = "FrmBai3";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoNguyen1;
        private System.Windows.Forms.TextBox txtSoNguyen2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdSoNguyenLT;
        private System.Windows.Forms.RadioButton rdTachChuoi;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.Button bntXemKetQua;
    }
}