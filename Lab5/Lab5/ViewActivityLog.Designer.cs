namespace Lab5
{
    partial class ViewActivityLog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstBillDates;
        private System.Windows.Forms.DataGridView dgvBills;
        private System.Windows.Forms.DataGridView dgvBillDetails;
        private System.Windows.Forms.Label lblSummary;


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
            this.dgvBillDetails = new System.Windows.Forms.DataGridView();
            this.lblSummary = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillDetails)).BeginInit();
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
            // dgvBillDetails
            // 
            this.dgvBillDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBillDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvBillDetails.ColumnHeadersHeight = 29;
            this.dgvBillDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBillDetails.Location = new System.Drawing.Point(191, 533);
            this.dgvBillDetails.Name = "dgvBillDetails";
            this.dgvBillDetails.ReadOnly = true;
            this.dgvBillDetails.RowHeadersWidth = 51;
            this.dgvBillDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBillDetails.Size = new System.Drawing.Size(838, 0);
            this.dgvBillDetails.TabIndex = 0;
            // 
            // lblSummary
            // 
            this.lblSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSummary.Location = new System.Drawing.Point(191, 493);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(838, 40);
            this.lblSummary.TabIndex = 1;
            this.lblSummary.Text = "Tổng kết hóa đơn";
            this.lblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ViewActivityLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 533);
            this.Controls.Add(this.dgvBillDetails);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.dgvBills);
            this.Controls.Add(this.lstBillDates);
            this.Name = "ViewActivityLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục hóa đơn theo ngày";
            this.Load += new System.EventHandler(this.BillsByDateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillDetails)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
