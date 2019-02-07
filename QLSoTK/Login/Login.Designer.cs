namespace QLSoTK.Login
{
    partial class frmLogin
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
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.but_Login = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.group_FormLogin = new DevExpress.XtraEditors.GroupControl();
            this.but_Exit = new System.Windows.Forms.Button();
            this.chkRememberUser = new System.Windows.Forms.CheckBox();
            this.error_Login = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.group_FormLogin)).BeginInit();
            this.group_FormLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.error_Login)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Password
            // 
            this.txt_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Password.Location = new System.Drawing.Point(160, 50);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(229, 26);
            this.txt_Password.TabIndex = 22;
            this.txt_Password.UseSystemPasswordChar = true;
            // 
            // txt_UserName
            // 
            this.txt_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UserName.Location = new System.Drawing.Point(160, 12);
            this.txt_UserName.Multiline = true;
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(229, 26);
            this.txt_UserName.TabIndex = 21;
            // 
            // but_Login
            // 
            this.but_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but_Login.Location = new System.Drawing.Point(160, 105);
            this.but_Login.Name = "but_Login";
            this.but_Login.Size = new System.Drawing.Size(107, 30);
            this.but_Login.TabIndex = 20;
            this.but_Login.Text = "Đăng Nhập";
            this.but_Login.UseVisualStyleBackColor = true;
            this.but_Login.Click += new System.EventHandler(this.but_Login_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Tên đăng nhập";
            // 
            // group_FormLogin
            // 
            this.group_FormLogin.Controls.Add(this.but_Exit);
            this.group_FormLogin.Controls.Add(this.chkRememberUser);
            this.group_FormLogin.Controls.Add(this.label1);
            this.group_FormLogin.Controls.Add(this.but_Login);
            this.group_FormLogin.Controls.Add(this.txt_Password);
            this.group_FormLogin.Controls.Add(this.txt_UserName);
            this.group_FormLogin.Controls.Add(this.label2);
            this.group_FormLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_FormLogin.Location = new System.Drawing.Point(0, 0);
            this.group_FormLogin.Name = "group_FormLogin";
            this.group_FormLogin.ShowCaption = false;
            this.group_FormLogin.Size = new System.Drawing.Size(401, 152);
            this.group_FormLogin.TabIndex = 23;
            // 
            // but_Exit
            // 
            this.but_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.but_Exit.Location = new System.Drawing.Point(282, 105);
            this.but_Exit.Name = "but_Exit";
            this.but_Exit.Size = new System.Drawing.Size(107, 30);
            this.but_Exit.TabIndex = 24;
            this.but_Exit.Text = "Thoát";
            this.but_Exit.UseVisualStyleBackColor = true;
            this.but_Exit.Click += new System.EventHandler(this.but_Exit_Click);
            // 
            // chkRememberUser
            // 
            this.chkRememberUser.AutoSize = true;
            this.chkRememberUser.Location = new System.Drawing.Point(160, 82);
            this.chkRememberUser.Name = "chkRememberUser";
            this.chkRememberUser.Size = new System.Drawing.Size(116, 17);
            this.chkRememberUser.TabIndex = 23;
            this.chkRememberUser.Text = "Ghi nhớ đăng nhập";
            this.chkRememberUser.UseVisualStyleBackColor = true;
            // 
            // error_Login
            // 
            this.error_Login.ContainerControl = this;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(401, 152);
            this.Controls.Add(this.group_FormLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.group_FormLogin)).EndInit();
            this.group_FormLogin.ResumeLayout(false);
            this.group_FormLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.error_Login)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.Button but_Login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl group_FormLogin;
        private System.Windows.Forms.CheckBox chkRememberUser;
        private System.Windows.Forms.Button but_Exit;
        private System.Windows.Forms.ErrorProvider error_Login;
    }
}