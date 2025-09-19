namespace MyForm
{
    partial class FrmChinh
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
            this.frmBai1 = new System.Windows.Forms.Button();
            this.frmBai2 = new System.Windows.Forms.Button();
            this.frmBai3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // frmBai1
            // 
            this.frmBai1.Location = new System.Drawing.Point(93, 164);
            this.frmBai1.Name = "frmBai1";
            this.frmBai1.Size = new System.Drawing.Size(130, 57);
            this.frmBai1.TabIndex = 0;
            this.frmBai1.Text = "Trung Tâm";
            this.frmBai1.UseVisualStyleBackColor = true;
            this.frmBai1.Click += new System.EventHandler(this.frmBai1_Click);
            // 
            // frmBai2
            // 
            this.frmBai2.Location = new System.Drawing.Point(332, 161);
            this.frmBai2.Name = "frmBai2";
            this.frmBai2.Size = new System.Drawing.Size(130, 60);
            this.frmBai2.TabIndex = 1;
            this.frmBai2.Text = "TB Giảng Viên";
            this.frmBai2.UseVisualStyleBackColor = true;
            this.frmBai2.Click += new System.EventHandler(this.frmBai2_Click);
            // 
            // frmBai3
            // 
            this.frmBai3.Location = new System.Drawing.Point(569, 161);
            this.frmBai3.Name = "frmBai3";
            this.frmBai3.Size = new System.Drawing.Size(109, 60);
            this.frmBai3.TabIndex = 2;
            this.frmBai3.Text = "Sinh Viên";
            this.frmBai3.UseVisualStyleBackColor = true;
            this.frmBai3.Click += new System.EventHandler(this.frmBai3_Click);
            // 
            // FrmChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.frmBai3);
            this.Controls.Add(this.frmBai2);
            this.Controls.Add(this.frmBai1);
            this.Name = "FrmChinh";
            this.Text = "FrmChinh";
            this.Load += new System.EventHandler(this.FrmChinh_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button frmBai1;
        private System.Windows.Forms.Button frmBai2;
        private System.Windows.Forms.Button frmBai3;
    }
}