namespace Baitap3
{
    partial class frmChinh
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
            this.bntBai2 = new System.Windows.Forms.Button();
            this.bntBai3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // frmBai1
            // 
            this.frmBai1.Location = new System.Drawing.Point(31, 65);
            this.frmBai1.Name = "frmBai1";
            this.frmBai1.Size = new System.Drawing.Size(110, 53);
            this.frmBai1.TabIndex = 0;
            this.frmBai1.Text = "Bài 1";
            this.frmBai1.UseVisualStyleBackColor = true;
            this.frmBai1.Click += new System.EventHandler(this.frmBai1_Click);
            // 
            // bntBai2
            // 
            this.bntBai2.Location = new System.Drawing.Point(193, 65);
            this.bntBai2.Name = "bntBai2";
            this.bntBai2.Size = new System.Drawing.Size(110, 53);
            this.bntBai2.TabIndex = 1;
            this.bntBai2.Text = "Bài 2";
            this.bntBai2.UseVisualStyleBackColor = true;
            this.bntBai2.Click += new System.EventHandler(this.bntBai2_Click);
            // 
            // bntBai3
            // 
            this.bntBai3.Location = new System.Drawing.Point(355, 65);
            this.bntBai3.Name = "bntBai3";
            this.bntBai3.Size = new System.Drawing.Size(110, 53);
            this.bntBai3.TabIndex = 2;
            this.bntBai3.Text = "Bài 3";
            this.bntBai3.UseVisualStyleBackColor = true;
            this.bntBai3.Click += new System.EventHandler(this.bntBai3_Click);
            // 
            // frmChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 148);
            this.Controls.Add(this.bntBai3);
            this.Controls.Add(this.bntBai2);
            this.Controls.Add(this.frmBai1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmChinh";
            this.Text = "Chương trình chính";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button frmBai1;
        private System.Windows.Forms.Button bntBai2;
        private System.Windows.Forms.Button bntBai3;
    }
}

