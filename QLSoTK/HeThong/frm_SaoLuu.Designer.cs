namespace QLSoTK.DanhMuc
{
    partial class frm_SaoLuu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SaoLuu));
            this.textEdit_duongdan = new DevExpress.XtraEditors.TextEdit();
            this.progressBarControl_back = new DevExpress.XtraEditors.ProgressBarControl();
            this.textEdit_tentaptin = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simplebtn_close = new DevExpress.XtraEditors.SimpleButton();
            this.simplebtn_save = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_duongdan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl_back.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_tentaptin.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit_duongdan
            // 
            this.textEdit_duongdan.EditValue = "Chọn thư mục bạn muốn lưu";
            this.textEdit_duongdan.Location = new System.Drawing.Point(110, 168);
            this.textEdit_duongdan.Name = "textEdit_duongdan";
            this.textEdit_duongdan.Size = new System.Drawing.Size(358, 20);
            this.textEdit_duongdan.TabIndex = 17;
            this.textEdit_duongdan.Click += new System.EventHandler(this.textEdit_duongdan_Click);
            // 
            // progressBarControl_back
            // 
            this.progressBarControl_back.Location = new System.Drawing.Point(110, 84);
            this.progressBarControl_back.Name = "progressBarControl_back";
            this.progressBarControl_back.Properties.ShowTitle = true;
            this.progressBarControl_back.Size = new System.Drawing.Size(358, 25);
            this.progressBarControl_back.TabIndex = 16;
            // 
            // textEdit_tentaptin
            // 
            this.textEdit_tentaptin.EditValue = "";
            this.textEdit_tentaptin.Location = new System.Drawing.Point(110, 126);
            this.textEdit_tentaptin.Name = "textEdit_tentaptin";
            this.textEdit_tentaptin.Size = new System.Drawing.Size(358, 20);
            this.textEdit_tentaptin.TabIndex = 13;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(36, 171);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(54, 13);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "Đường dẫn";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(36, 133);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 13);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Tên tập tin";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(36, 96);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 13);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Tiến trình";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(168, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(261, 25);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Sao lưu dự phòng dữ liệu";
            // 
            // simplebtn_close
            // 
            this.simplebtn_close.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simplebtn_close.ImageOptions.Image")));
            this.simplebtn_close.Location = new System.Drawing.Point(368, 208);
            this.simplebtn_close.Name = "simplebtn_close";
            this.simplebtn_close.Size = new System.Drawing.Size(75, 23);
            this.simplebtn_close.TabIndex = 15;
            this.simplebtn_close.Text = "Đóng";
            this.simplebtn_close.Click += new System.EventHandler(this.simplebtn_close_Click);
            // 
            // simplebtn_save
            // 
            this.simplebtn_save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simplebtn_save.ImageOptions.Image")));
            this.simplebtn_save.Location = new System.Drawing.Point(270, 208);
            this.simplebtn_save.Name = "simplebtn_save";
            this.simplebtn_save.Size = new System.Drawing.Size(75, 23);
            this.simplebtn_save.TabIndex = 14;
            this.simplebtn_save.Text = "Đồng ý";
            this.simplebtn_save.Click += new System.EventHandler(this.simplebtn_save_Click);
            // 
            // frm_SaoLuu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 252);
            this.Controls.Add(this.textEdit_duongdan);
            this.Controls.Add(this.progressBarControl_back);
            this.Controls.Add(this.simplebtn_close);
            this.Controls.Add(this.simplebtn_save);
            this.Controls.Add(this.textEdit_tentaptin);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frm_SaoLuu";
            this.Text = "Sao lưu dữ liệu";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_duongdan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl_back.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_tentaptin.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit_duongdan;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl_back;
        private DevExpress.XtraEditors.SimpleButton simplebtn_close;
        private DevExpress.XtraEditors.SimpleButton simplebtn_save;
        private DevExpress.XtraEditors.TextEdit textEdit_tentaptin;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}