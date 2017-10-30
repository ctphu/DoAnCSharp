namespace ExchangeManagement
{
    partial class frmUserList
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
            this.dgvUserList = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btUpdate = new System.Windows.Forms.Button();
            this.btAddUser = new System.Windows.Forms.Button();
            this.btDeleteUser = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbIsDisable = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUserList
            // 
            this.dgvUserList.AllowUserToAddRows = false;
            this.dgvUserList.AllowUserToDeleteRows = false;
            this.dgvUserList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserList.Location = new System.Drawing.Point(12, 63);
            this.dgvUserList.Name = "dgvUserList";
            this.dgvUserList.Size = new System.Drawing.Size(674, 253);
            this.dgvUserList.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbUsername);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 45);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Username";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbPassword);
            this.groupBox2.Location = new System.Drawing.Point(183, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(167, 45);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Password";
            // 
            // tbUsername
            // 
            this.tbUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUsername.Location = new System.Drawing.Point(6, 19);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(153, 20);
            this.tbUsername.TabIndex = 0;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(6, 19);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(155, 20);
            this.tbPassword.TabIndex = 0;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // btUpdate
            // 
            this.btUpdate.Location = new System.Drawing.Point(448, 29);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(75, 23);
            this.btUpdate.TabIndex = 3;
            this.btUpdate.Text = "Update";
            this.btUpdate.UseVisualStyleBackColor = true;
            // 
            // btAddUser
            // 
            this.btAddUser.Location = new System.Drawing.Point(529, 29);
            this.btAddUser.Name = "btAddUser";
            this.btAddUser.Size = new System.Drawing.Size(75, 23);
            this.btAddUser.TabIndex = 4;
            this.btAddUser.Text = "Add User";
            this.btAddUser.UseVisualStyleBackColor = true;
            // 
            // btDeleteUser
            // 
            this.btDeleteUser.Location = new System.Drawing.Point(610, 29);
            this.btDeleteUser.Name = "btDeleteUser";
            this.btDeleteUser.Size = new System.Drawing.Size(75, 23);
            this.btDeleteUser.TabIndex = 5;
            this.btDeleteUser.Text = "Delete User";
            this.btDeleteUser.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbIsDisable);
            this.groupBox3.Location = new System.Drawing.Point(356, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(72, 45);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Is Disable";
            // 
            // cbIsDisable
            // 
            this.cbIsDisable.AutoSize = true;
            this.cbIsDisable.Location = new System.Drawing.Point(24, 19);
            this.cbIsDisable.Name = "cbIsDisable";
            this.cbIsDisable.Size = new System.Drawing.Size(15, 14);
            this.cbIsDisable.TabIndex = 0;
            this.cbIsDisable.UseVisualStyleBackColor = true;
            // 
            // frmUserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 328);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btDeleteUser);
            this.Controls.Add(this.btAddUser);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvUserList);
            this.Name = "frmUserList";
            this.Text = "frmUserList";
            this.Load += new System.EventHandler(this.frmUserList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUserList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.Button btAddUser;
        private System.Windows.Forms.Button btDeleteUser;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbIsDisable;
    }
}