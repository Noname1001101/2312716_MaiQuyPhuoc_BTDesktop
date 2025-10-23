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
            this.cmsBan = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaBànToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemDanhMụcHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemNhậtKýHoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.flpBan = new System.Windows.Forms.FlowLayoutPanel();
            this.cmsBan.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsBan
            // 
            this.cmsBan.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsBan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaBànToolStripMenuItem,
            this.xemDanhMụcHóaĐơnToolStripMenuItem,
            this.xemNhậtKýHoaToolStripMenuItem});
            this.cmsBan.Name = "contextMenuStrip1";
            this.cmsBan.Size = new System.Drawing.Size(265, 88);
            // 
            // xóaBànToolStripMenuItem
            // 
            this.xóaBànToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.xóaBànToolStripMenuItem.Name = "xóaBànToolStripMenuItem";
            this.xóaBànToolStripMenuItem.Size = new System.Drawing.Size(264, 28);
            this.xóaBànToolStripMenuItem.Text = "Xóa bàn";
            // 
            // xemDanhMụcHóaĐơnToolStripMenuItem
            // 
            this.xemDanhMụcHóaĐơnToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.xemDanhMụcHóaĐơnToolStripMenuItem.Name = "xemDanhMụcHóaĐơnToolStripMenuItem";
            this.xemDanhMụcHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(264, 28);
            this.xemDanhMụcHóaĐơnToolStripMenuItem.Text = "Xem danh mục hóa đơn";
            // 
            // xemNhậtKýHoaToolStripMenuItem
            // 
            this.xemNhậtKýHoaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.xemNhậtKýHoaToolStripMenuItem.Name = "xemNhậtKýHoaToolStripMenuItem";
            this.xemNhậtKýHoaToolStripMenuItem.Size = new System.Drawing.Size(264, 28);
            this.xemNhậtKýHoaToolStripMenuItem.Text = "Xem nhật ký hoá đơn";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(554, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // flpBan
            // 
            this.flpBan.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpBan.Location = new System.Drawing.Point(0, 0);
            this.flpBan.Name = "flpBan";
            this.flpBan.Size = new System.Drawing.Size(354, 450);
            this.flpBan.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flpBan);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.cmsBan.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmsBan;
        private System.Windows.Forms.ToolStripMenuItem xóaBànToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemDanhMụcHóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemNhậtKýHoaToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flpBan;
    }
}