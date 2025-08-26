namespace _2312716_MaiQuyPhuoc_BTTKForm
{
    partial class FrmBai2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.bntChonHang = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bntBoHang = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bntTinhTien = new System.Windows.Forms.Button();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.bntChonHang);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(27, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 300);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách hàng hóa";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "Chuột",
            "Bàn phím ",
            "Máy in",
            "USB Kingmax"});
            this.listBox1.Location = new System.Drawing.Point(24, 79);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(181, 180);
            this.listBox1.TabIndex = 1;
            // 
            // bntChonHang
            // 
            this.bntChonHang.Location = new System.Drawing.Point(222, 133);
            this.bntChonHang.Name = "bntChonHang";
            this.bntChonHang.Size = new System.Drawing.Size(125, 38);
            this.bntChonHang.TabIndex = 2;
            this.bntChonHang.Text = "Chọn hàng >";
            this.bntChonHang.UseVisualStyleBackColor = true;
            this.bntChonHang.Click += new System.EventHandler(this.bntChonHang_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.bntBoHang);
            this.panel2.Controls.Add(this.listBox2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(417, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(371, 300);
            this.panel2.TabIndex = 1;
            // 
            // bntBoHang
            // 
            this.bntBoHang.Location = new System.Drawing.Point(18, 133);
            this.bntBoHang.Name = "bntBoHang";
            this.bntBoHang.Size = new System.Drawing.Size(125, 38);
            this.bntBoHang.TabIndex = 2;
            this.bntBoHang.Text = " < Bỏ hàng ";
            this.bntBoHang.UseVisualStyleBackColor = true;
            this.bntBoHang.Click += new System.EventHandler(this.bntBoHang_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(149, 79);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(181, 180);
            this.listBox2.TabIndex = 1;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Các mặt hàng khách đã mua";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // bntTinhTien
            // 
            this.bntTinhTien.Location = new System.Drawing.Point(520, 349);
            this.bntTinhTien.Name = "bntTinhTien";
            this.bntTinhTien.Size = new System.Drawing.Size(110, 42);
            this.bntTinhTien.TabIndex = 2;
            this.bntTinhTien.Text = "Tính tiền";
            this.bntTinhTien.UseVisualStyleBackColor = true;
            this.bntTinhTien.Click += new System.EventHandler(this.bntTinhTien_Click);
            // 
            // lblSoTien
            // 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTien.ForeColor = System.Drawing.Color.Blue;
            this.lblSoTien.Location = new System.Drawing.Point(590, 394);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(24, 25);
            this.lblSoTien.TabIndex = 12;
            this.lblSoTien.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(348, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tổng tiền thanh toán:";
            // 
            // FrmBai2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSoTien);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bntTinhTien);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBai2";
            this.Text = "Bán hàng ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bntChonHang;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bntBoHang;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bntTinhTien;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.Label label3;
    }
}