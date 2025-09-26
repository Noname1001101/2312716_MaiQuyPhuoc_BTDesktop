namespace Lab3
{
    partial class frmThemMon
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
            this.txtThemMon = new System.Windows.Forms.TextBox();
            this.bntThem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập tên môn học mới:";
            // 
            // txtThemMon
            // 
            this.txtThemMon.Location = new System.Drawing.Point(218, 54);
            this.txtThemMon.Name = "txtThemMon";
            this.txtThemMon.Size = new System.Drawing.Size(309, 22);
            this.txtThemMon.TabIndex = 1;
            // 
            // bntThem
            // 
            this.bntThem.AutoSize = true;
            this.bntThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntThem.Location = new System.Drawing.Point(533, 50);
            this.bntThem.Name = "bntThem";
            this.bntThem.Size = new System.Drawing.Size(78, 30);
            this.bntThem.TabIndex = 2;
            this.bntThem.Text = "Thêm";
            this.bntThem.UseVisualStyleBackColor = true;
            this.bntThem.Click += new System.EventHandler(this.bntThem_Click);
            // 
            // frmThemMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 161);
            this.Controls.Add(this.bntThem);
            this.Controls.Add(this.txtThemMon);
            this.Controls.Add(this.label1);
            this.Name = "frmThemMon";
            this.Text = "frmThemMon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtThemMon;
        private System.Windows.Forms.Button bntThem;
    }
}