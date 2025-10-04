namespace Lab4_Basic_Command
{
    partial class CategoryForm
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
            this.bntLoad = new System.Windows.Forms.Button();
            this.lvCategory = new System.Windows.Forms.ListView();
            this.chID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.bntAdd = new System.Windows.Forms.Button();
            this.bntUpdate = new System.Windows.Forms.Button();
            this.bntDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bntLoad
            // 
            this.bntLoad.AutoSize = true;
            this.bntLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntLoad.Location = new System.Drawing.Point(12, 117);
            this.bntLoad.Name = "bntLoad";
            this.bntLoad.Size = new System.Drawing.Size(128, 34);
            this.bntLoad.TabIndex = 0;
            this.bntLoad.Text = "Lấy danh sách";
            this.bntLoad.UseVisualStyleBackColor = true;
            this.bntLoad.Click += new System.EventHandler(this.bntLoad_Click);
            // 
            // lvCategory
            // 
            this.lvCategory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chName,
            this.chType});
            this.lvCategory.FullRowSelect = true;
            this.lvCategory.HideSelection = false;
            this.lvCategory.Location = new System.Drawing.Point(0, 170);
            this.lvCategory.MultiSelect = false;
            this.lvCategory.Name = "lvCategory";
            this.lvCategory.Size = new System.Drawing.Size(608, 333);
            this.lvCategory.TabIndex = 1;
            this.lvCategory.UseCompatibleStateImageBehavior = false;
            this.lvCategory.View = System.Windows.Forms.View.Details;
            this.lvCategory.Click += new System.EventHandler(this.lvCategory_Click);
            // 
            // chID
            // 
            this.chID.Text = "Mã Loại";
            // 
            // chName
            // 
            this.chName.Text = "Tên loại món ăn";
            // 
            // chType
            // 
            this.chType.Text = "Loại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã nhóm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên nhóm thức ăn:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(180, 13);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(233, 22);
            this.txtID.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(180, 46);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(233, 22);
            this.txtName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Loại:";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(180, 81);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(233, 22);
            this.txtType.TabIndex = 7;
            // 
            // bntAdd
            // 
            this.bntAdd.AutoSize = true;
            this.bntAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntAdd.Location = new System.Drawing.Point(304, 117);
            this.bntAdd.Name = "bntAdd";
            this.bntAdd.Size = new System.Drawing.Size(76, 34);
            this.bntAdd.TabIndex = 8;
            this.bntAdd.Text = "Thêm";
            this.bntAdd.UseVisualStyleBackColor = true;
            this.bntAdd.Click += new System.EventHandler(this.bntAdd_Click);
            // 
            // bntUpdate
            // 
            this.bntUpdate.AutoSize = true;
            this.bntUpdate.Enabled = false;
            this.bntUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntUpdate.Location = new System.Drawing.Point(407, 117);
            this.bntUpdate.Name = "bntUpdate";
            this.bntUpdate.Size = new System.Drawing.Size(86, 34);
            this.bntUpdate.TabIndex = 9;
            this.bntUpdate.Text = "Cập nhật";
            this.bntUpdate.UseVisualStyleBackColor = true;
            this.bntUpdate.Click += new System.EventHandler(this.bntUpdate_Click);
            // 
            // bntDelete
            // 
            this.bntDelete.AutoSize = true;
            this.bntDelete.Enabled = false;
            this.bntDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntDelete.Location = new System.Drawing.Point(520, 117);
            this.bntDelete.Name = "bntDelete";
            this.bntDelete.Size = new System.Drawing.Size(76, 34);
            this.bntDelete.TabIndex = 10;
            this.bntDelete.Text = "Xóa";
            this.bntDelete.UseVisualStyleBackColor = true;
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 503);
            this.Controls.Add(this.bntDelete);
            this.Controls.Add(this.bntUpdate);
            this.Controls.Add(this.bntAdd);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvCategory);
            this.Controls.Add(this.bntLoad);
            this.Name = "CategoryForm";
            this.Text = "Quản lý nhóm món ăn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntLoad;
        private System.Windows.Forms.ListView lvCategory;
        private System.Windows.Forms.ColumnHeader chID;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Button bntAdd;
        private System.Windows.Forms.Button bntUpdate;
        private System.Windows.Forms.Button bntDelete;
    }
}

