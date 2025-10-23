namespace Lab4_Basic_Command
{
    partial class ViewListRoleForm
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
            this.lblVaiTroTK = new System.Windows.Forms.Label();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.colRoleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vai trò của tài khoản:";
            // 
            // lblVaiTroTK
            // 
            this.lblVaiTroTK.AutoSize = true;
            this.lblVaiTroTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVaiTroTK.Location = new System.Drawing.Point(239, 46);
            this.lblVaiTroTK.Name = "lblVaiTroTK";
            this.lblVaiTroTK.Size = new System.Drawing.Size(13, 20);
            this.lblVaiTroTK.TabIndex = 1;
            this.lblVaiTroTK.Text = ".";
            // 
            // dgvRoles
            // 
            this.dgvRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRoleID,
            this.colRoleName,
            this.colActived,
            this.colNotes});
            this.dgvRoles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvRoles.Location = new System.Drawing.Point(0, 97);
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.RowHeadersWidth = 51;
            this.dgvRoles.RowTemplate.Height = 24;
            this.dgvRoles.Size = new System.Drawing.Size(800, 270);
            this.dgvRoles.TabIndex = 2;
            // 
            // colRoleID
            // 
            this.colRoleID.DataPropertyName = "RoleID";
            this.colRoleID.HeaderText = "Mã vai trò";
            this.colRoleID.MinimumWidth = 6;
            this.colRoleID.Name = "colRoleID";
            // 
            // colRoleName
            // 
            this.colRoleName.DataPropertyName = "RoleName";
            this.colRoleName.HeaderText = "Tên vai trò";
            this.colRoleName.MinimumWidth = 6;
            this.colRoleName.Name = "colRoleName";
            // 
            // colActived
            // 
            this.colActived.DataPropertyName = "Actived";
            this.colActived.HeaderText = "Trạng thái";
            this.colActived.MinimumWidth = 6;
            this.colActived.Name = "colActived";
            // 
            // colNotes
            // 
            this.colNotes.DataPropertyName = "Notes";
            this.colNotes.HeaderText = "Ghi chú";
            this.colNotes.MinimumWidth = 6;
            this.colNotes.Name = "colNotes";
            // 
            // ViewListRoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 367);
            this.Controls.Add(this.dgvRoles);
            this.Controls.Add(this.lblVaiTroTK);
            this.Controls.Add(this.label1);
            this.Name = "ViewListRoleForm";
            this.Text = "ViewListRoles";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVaiTroTK;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActived;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotes;
    }
}