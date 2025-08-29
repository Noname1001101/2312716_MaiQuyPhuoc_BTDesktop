namespace Baitap4
{
    partial class frmBai2
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiemLyThuyet = new System.Windows.Forms.TextBox();
            this.txtDiemThucHanh = new System.Windows.Forms.TextBox();
            this.bntXepLoai = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập điểm lý thuyết:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhập điểm thực hành:";
            // 
            // txtDiemLyThuyet
            // 
            this.txtDiemLyThuyet.Location = new System.Drawing.Point(311, 48);
            this.txtDiemLyThuyet.Name = "txtDiemLyThuyet";
            this.txtDiemLyThuyet.Size = new System.Drawing.Size(100, 22);
            this.txtDiemLyThuyet.TabIndex = 2;
            // 
            // txtDiemThucHanh
            // 
            this.txtDiemThucHanh.Location = new System.Drawing.Point(311, 84);
            this.txtDiemThucHanh.Name = "txtDiemThucHanh";
            this.txtDiemThucHanh.Size = new System.Drawing.Size(100, 22);
            this.txtDiemThucHanh.TabIndex = 3;
            // 
            // bntXepLoai
            // 
            this.bntXepLoai.AutoSize = true;
            this.bntXepLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntXepLoai.Location = new System.Drawing.Point(268, 125);
            this.bntXepLoai.Name = "bntXepLoai";
            this.bntXepLoai.Size = new System.Drawing.Size(91, 42);
            this.bntXepLoai.TabIndex = 4;
            this.bntXepLoai.Text = "Xếp loại";
            this.bntXepLoai.UseVisualStyleBackColor = true;
            this.bntXepLoai.Click += new System.EventHandler(this.bntXepLoai_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(156, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Kết quả xếp loại:";
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKetQua.ForeColor = System.Drawing.Color.Red;
            this.lblKetQua.Location = new System.Drawing.Point(311, 181);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(0, 25);
            this.lblKetQua.TabIndex = 11;
            // 
            // frmBai2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bntXepLoai);
            this.Controls.Add(this.txtDiemThucHanh);
            this.Controls.Add(this.txtDiemLyThuyet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmBai2";
            this.Text = "Xếp loại";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiemLyThuyet;
        private System.Windows.Forms.TextBox txtDiemThucHanh;
        private System.Windows.Forms.Button bntXepLoai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblKetQua;
    }
}