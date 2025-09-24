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
            this.rdLop = new System.Windows.Forms.RadioButton();
            this.rdTen = new System.Windows.Forms.RadioButton();
            this.rdMSSV = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.bntTim = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdLop);
            this.groupBox1.Controls.Add(this.rdTen);
            this.groupBox1.Controls.Add(this.rdMSSV);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 63);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm theo";
            // 
            // rdLop
            // 
            this.rdLop.AutoSize = true;
            this.rdLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdLop.Location = new System.Drawing.Point(303, 30);
            this.rdLop.Name = "rdLop";
            this.rdLop.Size = new System.Drawing.Size(58, 24);
            this.rdLop.TabIndex = 2;
            this.rdLop.TabStop = true;
            this.rdLop.Text = "Lớp";
            this.rdLop.UseVisualStyleBackColor = true;
            // 
            // rdTen
            // 
            this.rdTen.AutoSize = true;
            this.rdTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTen.Location = new System.Drawing.Point(175, 30);
            this.rdTen.Name = "rdTen";
            this.rdTen.Size = new System.Drawing.Size(58, 24);
            this.rdTen.TabIndex = 1;
            this.rdTen.TabStop = true;
            this.rdTen.Text = "Tên";
            this.rdTen.UseVisualStyleBackColor = true;
            // 
            // rdMSSV
            // 
            this.rdMSSV.AutoSize = true;
            this.rdMSSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdMSSV.Location = new System.Drawing.Point(28, 30);
            this.rdMSSV.Name = "rdMSSV";
            this.rdMSSV.Size = new System.Drawing.Size(77, 24);
            this.rdMSSV.TabIndex = 0;
            this.rdMSSV.TabStop = true;
            this.rdMSSV.Text = "MSSV";
            this.rdMSSV.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tìm theo";
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Location = new System.Drawing.Point(93, 90);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(264, 22);
            this.txtTuKhoa.TabIndex = 3;
            // 
            // bntTim
            // 
            this.bntTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntTim.ForeColor = System.Drawing.Color.Blue;
            this.bntTim.Location = new System.Drawing.Point(363, 81);
            this.bntTim.Name = "bntTim";
            this.bntTim.Size = new System.Drawing.Size(85, 29);
            this.bntTim.TabIndex = 29;
            this.bntTim.Text = "Tìm";
            this.bntTim.UseVisualStyleBackColor = true;
            this.bntTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // frmTim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 133);
            this.Controls.Add(this.bntTim);
            this.Controls.Add(this.txtTuKhoa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTim";
            this.Text = "Tìm sinh viên";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdTen;
        private System.Windows.Forms.RadioButton rdMSSV;
        private System.Windows.Forms.RadioButton rdLop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Button bntTim;
    }
}