namespace Lab5
{
    partial class FoodForm
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
            this.cbbCategory = new System.Windows.Forms.ComboBox();
            this.dgvFoodList = new System.Windows.Forms.DataGridView();
            this.ctmFoodList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCalculateQuantity = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSeperator = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddFood = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdateFood = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblCatName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearchByName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoodList)).BeginInit();
            this.ctmFoodList.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbCategory
            // 
            this.cbbCategory.FormattingEnabled = true;
            this.cbbCategory.ItemHeight = 16;
            this.cbbCategory.Location = new System.Drawing.Point(203, 25);
            this.cbbCategory.Name = "cbbCategory";
            this.cbbCategory.Size = new System.Drawing.Size(146, 24);
            this.cbbCategory.TabIndex = 0;
            this.cbbCategory.SelectedIndexChanged += new System.EventHandler(this.cbbCategory_SelectedIndexChanged);
            // 
            // dgvFoodList
            // 
            this.dgvFoodList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFoodList.ContextMenuStrip = this.ctmFoodList;
            this.dgvFoodList.Location = new System.Drawing.Point(5, 55);
            this.dgvFoodList.Name = "dgvFoodList";
            this.dgvFoodList.ReadOnly = true;
            this.dgvFoodList.RowHeadersWidth = 51;
            this.dgvFoodList.RowTemplate.Height = 24;
            this.dgvFoodList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFoodList.Size = new System.Drawing.Size(832, 364);
            this.dgvFoodList.TabIndex = 1;
            // 
            // ctmFoodList
            // 
            this.ctmFoodList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctmFoodList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCalculateQuantity,
            this.tsmiSeperator,
            this.tsmiAddFood,
            this.tsmiUpdateFood});
            this.ctmFoodList.Name = "ctmFoodList";
            this.ctmFoodList.Size = new System.Drawing.Size(235, 100);
            // 
            // tsmiCalculateQuantity
            // 
            this.tsmiCalculateQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsmiCalculateQuantity.Name = "tsmiCalculateQuantity";
            this.tsmiCalculateQuantity.Size = new System.Drawing.Size(234, 24);
            this.tsmiCalculateQuantity.Text = "Tính số lượng đã bán";
            this.tsmiCalculateQuantity.Click += new System.EventHandler(this.tsmiCalculateQuantity_Click);
            // 
            // tsmiSeperator
            // 
            this.tsmiSeperator.Name = "tsmiSeperator";
            this.tsmiSeperator.Size = new System.Drawing.Size(234, 24);
            this.tsmiSeperator.Text = "--------------------------";
            // 
            // tsmiAddFood
            // 
            this.tsmiAddFood.Name = "tsmiAddFood";
            this.tsmiAddFood.Size = new System.Drawing.Size(234, 24);
            this.tsmiAddFood.Text = "Thêm món ăn mới";
            this.tsmiAddFood.Click += new System.EventHandler(this.tsmiAddFood_Click);
            // 
            // tsmiUpdateFood
            // 
            this.tsmiUpdateFood.Name = "tsmiUpdateFood";
            this.tsmiUpdateFood.Size = new System.Drawing.Size(234, 24);
            this.tsmiUpdateFood.Text = "Cập nhật món ăn";
            this.tsmiUpdateFood.Click += new System.EventHandler(this.tsmiUpdateFood_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Có tất cả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(199, 422);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "món ăn thuộc nhóm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Chọn nhóm món ăn:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(114, 422);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(21, 20);
            this.lblQuantity.TabIndex = 5;
            this.lblQuantity.Text = "...";
            // 
            // lblCatName
            // 
            this.lblCatName.AutoSize = true;
            this.lblCatName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCatName.Location = new System.Drawing.Point(385, 422);
            this.lblCatName.Name = "lblCatName";
            this.lblCatName.Size = new System.Drawing.Size(21, 20);
            this.lblCatName.TabIndex = 6;
            this.lblCatName.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(437, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tìm kiếm theo tên:";
            // 
            // txtSearchByName
            // 
            this.txtSearchByName.Location = new System.Drawing.Point(613, 23);
            this.txtSearchByName.Name = "txtSearchByName";
            this.txtSearchByName.Size = new System.Drawing.Size(214, 22);
            this.txtSearchByName.TabIndex = 8;
            this.txtSearchByName.TextChanged += new System.EventHandler(this.txtSearchByName_TextChanged);
            // 
            // FoodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 450);
            this.Controls.Add(this.txtSearchByName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCatName);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvFoodList);
            this.Controls.Add(this.cbbCategory);
            this.Name = "FoodForm";
            this.Text = "Danh sách món ăn";
            this.Load += new System.EventHandler(this.FoodForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoodList)).EndInit();
            this.ctmFoodList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbCategory;
        private System.Windows.Forms.DataGridView dgvFoodList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblCatName;
        private System.Windows.Forms.ContextMenuStrip ctmFoodList;
        private System.Windows.Forms.ToolStripMenuItem tsmiCalculateQuantity;
        private System.Windows.Forms.ToolStripMenuItem tsmiSeperator;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddFood;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdateFood;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearchByName;
    }
}

