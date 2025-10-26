namespace Lab4_Basic_Command
{
    partial class MainForm
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
            this.bntThemBan = new System.Windows.Forms.Button();
            this.flpBan = new System.Windows.Forms.FlowLayoutPanel();
            this.cmsBan = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiXoa1Ban = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiXemDMHD = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiXemNKHD = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsiXemHD = new System.Windows.Forms.ToolStripMenuItem();
            this.bntSuaBan = new System.Windows.Forms.Button();
            this.bntXoa = new System.Windows.Forms.Button();
            this.xemHóaĐơnHiệnTạiCủa1BànToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnAccount = new System.Windows.Forms.Button();
            this.cmsBan.SuspendLayout();
            this.SuspendLayout();
            // 
            // bntThemBan
            // 
            this.bntThemBan.AutoSize = true;
            this.bntThemBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntThemBan.Location = new System.Drawing.Point(409, 24);
            this.bntThemBan.Name = "bntThemBan";
            this.bntThemBan.Size = new System.Drawing.Size(84, 47);
            this.bntThemBan.TabIndex = 1;
            this.bntThemBan.Text = "Thêm";
            this.bntThemBan.UseVisualStyleBackColor = true;
            this.bntThemBan.Click += new System.EventHandler(this.btnThemBan_Click);
            // 
            // flpBan
            // 
            this.flpBan.ContextMenuStrip = this.cmsBan;
            this.flpBan.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpBan.Location = new System.Drawing.Point(0, 0);
            this.flpBan.Name = "flpBan";
            this.flpBan.Size = new System.Drawing.Size(403, 450);
            this.flpBan.TabIndex = 2;
            this.flpBan.Click += new System.EventHandler(this.flpBan_Click);
            // 
            // cmsBan
            // 
            this.cmsBan.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsBan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiXoa1Ban,
            this.tsmiXemDMHD,
            this.tsmiXemNKHD,
            this.tmsiXemHD});
            this.cmsBan.Name = "contextMenuStrip1";
            this.cmsBan.Size = new System.Drawing.Size(289, 116);
            // 
            // tsmiXoa1Ban
            // 
            this.tsmiXoa1Ban.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsmiXoa1Ban.Name = "tsmiXoa1Ban";
            this.tsmiXoa1Ban.Size = new System.Drawing.Size(288, 28);
            this.tsmiXoa1Ban.Text = "Xóa bàn";
            this.tsmiXoa1Ban.Click += new System.EventHandler(this.tsmiXoa1Ban_Click);
            // 
            // tsmiXemDMHD
            // 
            this.tsmiXemDMHD.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsmiXemDMHD.Name = "tsmiXemDMHD";
            this.tsmiXemDMHD.Size = new System.Drawing.Size(288, 28);
            this.tsmiXemDMHD.Text = "Xem danh mục hóa đơn";
            this.tsmiXemDMHD.Click += new System.EventHandler(this.tsmiXemDMHD_Click);
            // 
            // tsmiXemNKHD
            // 
            this.tsmiXemNKHD.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsmiXemNKHD.Name = "tsmiXemNKHD";
            this.tsmiXemNKHD.Size = new System.Drawing.Size(288, 28);
            this.tsmiXemNKHD.Text = "Xem nhật ký hoá đơn";
            this.tsmiXemNKHD.Click += new System.EventHandler(this.tsmiXemNKHD_Click);
            // 
            // tmsiXemHD
            // 
            this.tmsiXemHD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tmsiXemHD.Name = "tmsiXemHD";
            this.tmsiXemHD.Size = new System.Drawing.Size(288, 28);
            this.tmsiXemHD.Text = "Xem hóa đơn hiện tại của 1 bàn";
            this.tmsiXemHD.Click += new System.EventHandler(this.tsmiXemHD_Click);
            // 
            // bntSuaBan
            // 
            this.bntSuaBan.AutoSize = true;
            this.bntSuaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntSuaBan.Location = new System.Drawing.Point(527, 24);
            this.bntSuaBan.Name = "bntSuaBan";
            this.bntSuaBan.Size = new System.Drawing.Size(84, 47);
            this.bntSuaBan.TabIndex = 3;
            this.bntSuaBan.Text = "Sửa";
            this.bntSuaBan.UseVisualStyleBackColor = true;
            this.bntSuaBan.Click += new System.EventHandler(this.btnSuaBan_Click);
            // 
            // bntXoa
            // 
            this.bntXoa.AutoSize = true;
            this.bntXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntXoa.Location = new System.Drawing.Point(654, 24);
            this.bntXoa.Name = "bntXoa";
            this.bntXoa.Size = new System.Drawing.Size(85, 47);
            this.bntXoa.TabIndex = 4;
            this.bntXoa.Text = "Xóa";
            this.bntXoa.UseVisualStyleBackColor = true;
            this.bntXoa.Click += new System.EventHandler(this.bntXoa_Click);
            // 
            // xemHóaĐơnHiệnTạiCủa1BànToolStripMenuItem
            // 
            this.xemHóaĐơnHiệnTạiCủa1BànToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.xemHóaĐơnHiệnTạiCủa1BànToolStripMenuItem.Name = "xemHóaĐơnHiệnTạiCủa1BànToolStripMenuItem";
            this.xemHóaĐơnHiệnTạiCủa1BànToolStripMenuItem.Size = new System.Drawing.Size(324, 28);
            this.xemHóaĐơnHiệnTạiCủa1BànToolStripMenuItem.Text = "Xem hóa đơn hiện tại của 1 bàn";
            // 
            // btnCategory
            // 
            this.btnCategory.AutoSize = true;
            this.btnCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategory.Location = new System.Drawing.Point(409, 112);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(86, 47);
            this.btnCategory.TabIndex = 5;
            this.btnCategory.Text = "Category";
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.AutoSize = true;
            this.btnAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccount.Location = new System.Drawing.Point(527, 112);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(84, 47);
            this.btnAccount.TabIndex = 6;
            this.btnAccount.Text = "Account";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAccount);
            this.Controls.Add(this.btnCategory);
            this.Controls.Add(this.bntXoa);
            this.Controls.Add(this.bntSuaBan);
            this.Controls.Add(this.flpBan);
            this.Controls.Add(this.bntThemBan);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.cmsBan.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bntThemBan;
        private System.Windows.Forms.FlowLayoutPanel flpBan;
        private System.Windows.Forms.Button bntSuaBan;
        private System.Windows.Forms.Button bntXoa;
        private System.Windows.Forms.ToolStripMenuItem xemHóaĐơnHiệnTạiCủa1BànToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiXoa1Ban;
        private System.Windows.Forms.ToolStripMenuItem tsmiXemDMHD;
        private System.Windows.Forms.ToolStripMenuItem tsmiXemNKHD;
        private System.Windows.Forms.ContextMenuStrip cmsBan;
        private System.Windows.Forms.ToolStripMenuItem tmsiXemHD;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnAccount;
    }
}