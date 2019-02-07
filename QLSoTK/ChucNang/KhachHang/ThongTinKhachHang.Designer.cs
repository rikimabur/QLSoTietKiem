namespace QLSoTK.ChucNang.KhachHang
{
    partial class frm_khachhang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_khachhang));
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.simbtn_save = new DevExpress.XtraEditors.SimpleButton();
            this.txt_ten = new DevExpress.XtraEditors.TextEdit();
            this.txt_cmnd = new DevExpress.XtraEditors.TextEdit();
            this.txt_sdt = new DevExpress.XtraEditors.TextEdit();
            this.simbtn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.mem_diachi = new DevExpress.XtraEditors.MemoEdit();
            this.txt_ngaysinh = new DevExpress.XtraEditors.DateEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.dateEdit_ngaycap = new DevExpress.XtraEditors.DateEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.radio_gender = new System.Windows.Forms.RadioButton();
            this.radio_genderN = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_cmnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_sdt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mem_diachi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ngaysinh.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ngaysinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_ngaycap.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_ngaycap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(26, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 16);
            this.label10.TabIndex = 86;
            this.label10.Text = "Tên khách hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(441, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 88;
            this.label1.Text = "Số điện thoại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 90;
            this.label2.Text = "CMND";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 91;
            this.label3.Text = "Địa Chỉ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(441, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 94;
            this.label4.Text = "Ngày sinh";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(318, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(287, 33);
            this.label5.TabIndex = 95;
            this.label5.Text = "THÊM KHÁCH HÀNG";
            // 
            // simbtn_save
            // 
            this.simbtn_save.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simbtn_save.Appearance.Options.UseFont = true;
            this.simbtn_save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simbtn_save.ImageOptions.Image")));
            this.simbtn_save.Location = new System.Drawing.Point(555, 271);
            this.simbtn_save.Name = "simbtn_save";
            this.simbtn_save.Size = new System.Drawing.Size(104, 31);
            this.simbtn_save.TabIndex = 97;
            this.simbtn_save.Text = "Lưu";
            this.simbtn_save.Click += new System.EventHandler(this.simbtn_save_Click);
            // 
            // txt_ten
            // 
            this.txt_ten.Location = new System.Drawing.Point(157, 62);
            this.txt_ten.Name = "txt_ten";
            this.txt_ten.Size = new System.Drawing.Size(256, 20);
            this.txt_ten.TabIndex = 98;
            // 
            // txt_cmnd
            // 
            this.txt_cmnd.Location = new System.Drawing.Point(157, 97);
            this.txt_cmnd.Name = "txt_cmnd";
            this.txt_cmnd.Size = new System.Drawing.Size(256, 20);
            this.txt_cmnd.TabIndex = 99;
            this.txt_cmnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cmnd_KeyPress);
            // 
            // txt_sdt
            // 
            this.txt_sdt.Location = new System.Drawing.Point(555, 137);
            this.txt_sdt.Name = "txt_sdt";
            this.txt_sdt.Size = new System.Drawing.Size(274, 20);
            this.txt_sdt.TabIndex = 102;
            this.txt_sdt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_sdt_KeyPress);
            // 
            // simbtn_Close
            // 
            this.simbtn_Close.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simbtn_Close.Appearance.Options.UseFont = true;
            this.simbtn_Close.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simbtn_Close.ImageOptions.Image")));
            this.simbtn_Close.Location = new System.Drawing.Point(727, 271);
            this.simbtn_Close.Name = "simbtn_Close";
            this.simbtn_Close.Size = new System.Drawing.Size(102, 31);
            this.simbtn_Close.TabIndex = 103;
            this.simbtn_Close.Text = "Đóng";
            this.simbtn_Close.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // mem_diachi
            // 
            this.mem_diachi.Location = new System.Drawing.Point(157, 187);
            this.mem_diachi.Name = "mem_diachi";
            this.mem_diachi.Size = new System.Drawing.Size(256, 71);
            this.mem_diachi.TabIndex = 104;
            // 
            // txt_ngaysinh
            // 
            this.txt_ngaysinh.EditValue = null;
            this.txt_ngaysinh.Location = new System.Drawing.Point(555, 97);
            this.txt_ngaysinh.Name = "txt_ngaysinh";
            this.txt_ngaysinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_ngaysinh.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_ngaysinh.Size = new System.Drawing.Size(274, 20);
            this.txt_ngaysinh.TabIndex = 105;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 106;
            this.label6.Text = "Ngày Cấp";
            // 
            // dateEdit_ngaycap
            // 
            this.dateEdit_ngaycap.EditValue = null;
            this.dateEdit_ngaycap.Location = new System.Drawing.Point(157, 140);
            this.dateEdit_ngaycap.Name = "dateEdit_ngaycap";
            this.dateEdit_ngaycap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_ngaycap.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_ngaycap.Size = new System.Drawing.Size(256, 20);
            this.dateEdit_ngaycap.TabIndex = 107;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(441, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 16);
            this.label7.TabIndex = 108;
            this.label7.Text = "Giới Tính";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(555, 44);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup1.Size = new System.Drawing.Size(248, 41);
            this.radioGroup1.TabIndex = 111;
            // 
            // radio_gender
            // 
            this.radio_gender.AutoSize = true;
            this.radio_gender.Checked = true;
            this.radio_gender.Location = new System.Drawing.Point(555, 62);
            this.radio_gender.Name = "radio_gender";
            this.radio_gender.Size = new System.Drawing.Size(47, 17);
            this.radio_gender.TabIndex = 112;
            this.radio_gender.TabStop = true;
            this.radio_gender.Text = "Nam";
            this.radio_gender.UseVisualStyleBackColor = true;
            // 
            // radio_genderN
            // 
            this.radio_genderN.AutoSize = true;
            this.radio_genderN.Location = new System.Drawing.Point(658, 62);
            this.radio_genderN.Name = "radio_genderN";
            this.radio_genderN.Size = new System.Drawing.Size(39, 17);
            this.radio_genderN.TabIndex = 113;
            this.radio_genderN.Text = "Nữ";
            this.radio_genderN.UseVisualStyleBackColor = true;
            // 
            // frm_khachhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(841, 314);
            this.Controls.Add(this.radio_genderN);
            this.Controls.Add(this.radio_gender);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateEdit_ngaycap);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_ngaysinh);
            this.Controls.Add(this.mem_diachi);
            this.Controls.Add(this.simbtn_Close);
            this.Controls.Add(this.txt_sdt);
            this.Controls.Add(this.txt_cmnd);
            this.Controls.Add(this.txt_ten);
            this.Controls.Add(this.simbtn_save);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frm_khachhang";
            this.Text = "Thông tin khách hàng";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_khachhang_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.txt_ten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_cmnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_sdt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mem_diachi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ngaysinh.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ngaysinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_ngaycap.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_ngaycap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton simbtn_save;
        private DevExpress.XtraEditors.TextEdit txt_ten;
        private DevExpress.XtraEditors.TextEdit txt_cmnd;
        private DevExpress.XtraEditors.TextEdit txt_sdt;
        private DevExpress.XtraEditors.SimpleButton simbtn_Close;
        private DevExpress.XtraEditors.MemoEdit mem_diachi;
        private DevExpress.XtraEditors.DateEdit txt_ngaysinh;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.DateEdit dateEdit_ngaycap;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private System.Windows.Forms.RadioButton radio_gender;
        private System.Windows.Forms.RadioButton radio_genderN;
    }
}