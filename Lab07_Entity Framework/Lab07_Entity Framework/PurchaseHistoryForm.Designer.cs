namespace Lab07_Entity_Framework
{
    partial class PurchaseHistoryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvPurchaseLog;
        private System.Windows.Forms.Label lblSummary;



        private void InitializeComponent()
        {
            this.dgvPurchaseLog = new System.Windows.Forms.DataGridView();
            this.lblSummary = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseLog)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPurchaseLog
            // 
            this.dgvPurchaseLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPurchaseLog.BackgroundColor = System.Drawing.Color.White;
            this.dgvPurchaseLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPurchaseLog.Location = new System.Drawing.Point(0, 0);
            this.dgvPurchaseLog.Name = "dgvPurchaseLog";
            this.dgvPurchaseLog.RowHeadersWidth = 51;
            this.dgvPurchaseLog.Size = new System.Drawing.Size(929, 416);
            this.dgvPurchaseLog.TabIndex = 0;
            // 
            // lblSummary
            // 
            this.lblSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSummary.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblSummary.Location = new System.Drawing.Point(0, 416);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Padding = new System.Windows.Forms.Padding(10);
            this.lblSummary.Size = new System.Drawing.Size(929, 134);
            this.lblSummary.TabIndex = 1;
            this.lblSummary.Text = "Tổng kết:";
            // 
            // PurchaseHistoryForm
            // 
            this.ClientSize = new System.Drawing.Size(929, 550);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.dgvPurchaseLog);
            this.Name = "PurchaseHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhật ký mua hàng";
            this.Load += new System.EventHandler(this.PurchaseLogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseLog)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
