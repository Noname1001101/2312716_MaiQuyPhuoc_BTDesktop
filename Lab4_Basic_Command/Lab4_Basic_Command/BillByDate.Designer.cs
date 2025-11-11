namespace Lab4_Basic_Command
{
    partial class BillsByDateForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstBillDates;
        private System.Windows.Forms.DataGridView dgvBills;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lstBillDates = new System.Windows.Forms.ListBox();
            this.dgvBills = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            this.SuspendLayout();
            // 
            // lstBillDates
            // 
            this.lstBillDates.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstBillDates.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstBillDates.ItemHeight = 23;
            this.lstBillDates.Location = new System.Drawing.Point(0, 0);
            this.lstBillDates.Name = "lstBillDates";
            this.lstBillDates.Size = new System.Drawing.Size(191, 533);
            this.lstBillDates.TabIndex = 1;
            this.lstBillDates.SelectedIndexChanged += new System.EventHandler(this.lstBillDates_SelectedIndexChanged);
            // 
            // dgvBills
            // 
            this.dgvBills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBills.BackgroundColor = System.Drawing.Color.White;
            this.dgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBills.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvBills.Location = new System.Drawing.Point(191, 0);
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.ReadOnly = true;
            this.dgvBills.RowHeadersWidth = 51;
            this.dgvBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBills.Size = new System.Drawing.Size(838, 533);
            this.dgvBills.TabIndex = 0;
            this.dgvBills.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBills_CellDoubleClick);
            // 
            // BillsByDateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 533);
            this.Controls.Add(this.dgvBills);
            this.Controls.Add(this.lstBillDates);
            this.Name = "BillsByDateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục hóa đơn theo ngày";
            this.Load += new System.EventHandler(this.BillsByDateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
