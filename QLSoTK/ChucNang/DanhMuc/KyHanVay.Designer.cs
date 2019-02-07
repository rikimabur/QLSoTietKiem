namespace QLSoTK.DanhMuc
{
    partial class KyHanVay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KyHanVay));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            this.gridView_KyHan = new DevExpress.XtraGrid.GridControl();
            this.gridView_KyHanVay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MAKHV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.numberMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.interestRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.monerUse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.note = new DevExpress.XtraGrid.Columns.GridColumn();
            this.status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gril = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRemove = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnActive = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txt_note = new System.Windows.Forms.TextBox();
            this.checkBox_status = new System.Windows.Forms.CheckBox();
            this.txt_MaKH = new System.Windows.Forms.TextBox();
            this.num_number = new System.Windows.Forms.NumericUpDown();
            this.txt_interest_rate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_money = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripbtn_create = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtn_reload = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtn_print = new System.Windows.Forms.ToolStripButton();
            this.toolStripbtn_dong = new System.Windows.Forms.ToolStripButton();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_KyHan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_KyHanVay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_number)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView_KyHan
            // 
            this.gridView_KyHan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridView_KyHan.Location = new System.Drawing.Point(2, 2);
            this.gridView_KyHan.MainView = this.gridView_KyHanVay;
            this.gridView_KyHan.Name = "gridView_KyHan";
            this.gridView_KyHan.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnRemove,
            this.btnActive});
            this.gridView_KyHan.Size = new System.Drawing.Size(881, 260);
            this.gridView_KyHan.TabIndex = 1;
            this.gridView_KyHan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_KyHanVay});
            // 
            // gridView_KyHanVay
            // 
            this.gridView_KyHanVay.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_KyHanVay.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView_KyHanVay.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView_KyHanVay.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView_KyHanVay.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MAKHV,
            this.numberMonth,
            this.interestRate,
            this.monerUse,
            this.note,
            this.status,
            this.gril});
            this.gridView_KyHanVay.GridControl = this.gridView_KyHan;
            this.gridView_KyHanVay.Name = "gridView_KyHanVay";
            this.gridView_KyHanVay.OptionsSelection.MultiSelect = true;
            this.gridView_KyHanVay.OptionsView.ShowAutoFilterRow = true;
            this.gridView_KyHanVay.OptionsView.ShowGroupPanel = false;
            this.gridView_KyHanVay.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.MAKHV, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.monerUse, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.interestRate, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.numberMonth, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.status, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView_KyHanVay.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView_KyHanVay_RowClick);
            this.gridView_KyHanVay.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView_KyHanVay_CustomDrawCell);
            // 
            // MAKHV
            // 
            this.MAKHV.Caption = "Mã Kỳ Hạn";
            this.MAKHV.FieldName = "MaKyHan";
            this.MAKHV.Name = "MAKHV";
            this.MAKHV.OptionsColumn.AllowEdit = false;
            this.MAKHV.Visible = true;
            this.MAKHV.VisibleIndex = 0;
            // 
            // numberMonth
            // 
            this.numberMonth.Caption = "Số Kỳ Hạn";
            this.numberMonth.FieldName = "SoThang";
            this.numberMonth.Name = "numberMonth";
            this.numberMonth.OptionsColumn.AllowEdit = false;
            this.numberMonth.Visible = true;
            this.numberMonth.VisibleIndex = 1;
            // 
            // interestRate
            // 
            this.interestRate.Caption = "Mức Lãi Xuất(%)";
            this.interestRate.FieldName = "LaiSuat";
            this.interestRate.Name = "interestRate";
            this.interestRate.OptionsColumn.AllowEdit = false;
            this.interestRate.Visible = true;
            this.interestRate.VisibleIndex = 2;
            // 
            // monerUse
            // 
            this.monerUse.Caption = "Mức Tiền Áp Dụng";
            this.monerUse.DisplayFormat.FormatString = "{0:N0},000";
            this.monerUse.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.monerUse.FieldName = "MucTien";
            this.monerUse.Name = "monerUse";
            this.monerUse.OptionsColumn.AllowEdit = false;
            this.monerUse.Visible = true;
            this.monerUse.VisibleIndex = 3;
            // 
            // note
            // 
            this.note.Caption = "Ghi Chú";
            this.note.FieldName = "GhiChu";
            this.note.Name = "note";
            this.note.OptionsColumn.AllowEdit = false;
            this.note.Visible = true;
            this.note.VisibleIndex = 4;
            // 
            // status
            // 
            this.status.Caption = "Trạng Thái";
            this.status.FieldName = "TinhTrang";
            this.status.Name = "status";
            this.status.OptionsColumn.AllowEdit = false;
            this.status.Visible = true;
            this.status.VisibleIndex = 5;
            // 
            // gril
            // 
            this.gril.Caption = "Chức năng";
            this.gril.ColumnEdit = this.btnRemove;
            this.gril.Name = "gril";
            this.gril.OptionsColumn.AllowEdit = false;
            this.gril.Visible = true;
            this.gril.VisibleIndex = 6;
            // 
            // btnRemove
            // 
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.btnRemove.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions1, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // btnActive
            // 
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.btnActive.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions2, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.btnActive.Name = "btnActive";
            this.btnActive.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // groupControl2
            // 
            this.groupControl2.AutoSize = true;
            this.groupControl2.Controls.Add(this.txt_note);
            this.groupControl2.Controls.Add(this.checkBox_status);
            this.groupControl2.Controls.Add(this.txt_MaKH);
            this.groupControl2.Controls.Add(this.num_number);
            this.groupControl2.Controls.Add(this.txt_interest_rate);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.txt_money);
            this.groupControl2.Controls.Add(this.label4);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(2, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(881, 150);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Thông Tin Kỳ Hạn";
            // 
            // txt_note
            // 
            this.txt_note.Location = new System.Drawing.Point(488, 36);
            this.txt_note.Multiline = true;
            this.txt_note.Name = "txt_note";
            this.txt_note.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_note.Size = new System.Drawing.Size(197, 92);
            this.txt_note.TabIndex = 94;
            // 
            // checkBox_status
            // 
            this.checkBox_status.AutoSize = true;
            this.checkBox_status.Location = new System.Drawing.Point(730, 106);
            this.checkBox_status.Name = "checkBox_status";
            this.checkBox_status.Size = new System.Drawing.Size(78, 17);
            this.checkBox_status.TabIndex = 93;
            this.checkBox_status.Text = "Hoạt Động";
            this.checkBox_status.UseVisualStyleBackColor = true;
            // 
            // txt_MaKH
            // 
            this.txt_MaKH.Location = new System.Drawing.Point(719, 58);
            this.txt_MaKH.Name = "txt_MaKH";
            this.txt_MaKH.ReadOnly = true;
            this.txt_MaKH.Size = new System.Drawing.Size(148, 21);
            this.txt_MaKH.TabIndex = 91;
            this.txt_MaKH.Visible = false;
            this.txt_MaKH.TextChanged += new System.EventHandler(this.txt_MaKH_TextChanged);
            // 
            // num_number
            // 
            this.num_number.Location = new System.Drawing.Point(169, 36);
            this.num_number.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.num_number.Name = "num_number";
            this.num_number.Size = new System.Drawing.Size(230, 21);
            this.num_number.TabIndex = 90;
            this.num_number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_number_KeyPress);
            // 
            // txt_interest_rate
            // 
            this.txt_interest_rate.Location = new System.Drawing.Point(169, 83);
            this.txt_interest_rate.Name = "txt_interest_rate";
            this.txt_interest_rate.Size = new System.Drawing.Size(230, 21);
            this.txt_interest_rate.TabIndex = 89;
            this.txt_interest_rate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_interest_rate_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(427, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 87;
            this.label2.Text = "Ghi Chú";
            // 
            // txt_money
            // 
            this.txt_money.Location = new System.Drawing.Point(169, 120);
            this.txt_money.Name = "txt_money";
            this.txt_money.Size = new System.Drawing.Size(230, 21);
            this.txt_money.TabIndex = 85;
            this.txt_money.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_money_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 16);
            this.label4.TabIndex = 72;
            this.label4.Text = "Mức Tiền Áp Dụng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 70;
            this.label3.Text = "Lãi Xuất(%)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số Tháng Gửi";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelControl3);
            this.panel1.Controls.Add(this.panelControl2);
            this.panel1.Controls.Add(this.panelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 203);
            this.panel1.TabIndex = 3;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.groupControl2);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 29);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(885, 154);
            this.panelControl3.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.Location = new System.Drawing.Point(185, 146);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(8, 8);
            this.panelControl2.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.AutoSize = true;
            this.panelControl1.Controls.Add(this.toolStrip1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(885, 29);
            this.panelControl1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripbtn_create,
            this.toolStripButton_Save,
            this.toolStripbtn_reload,
            this.toolStripbtn_print,
            this.toolStripbtn_dong});
            this.toolStrip1.Location = new System.Drawing.Point(5, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(344, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripbtn_create
            // 
            this.toolStripbtn_create.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtn_create.Image")));
            this.toolStripbtn_create.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtn_create.Name = "toolStripbtn_create";
            this.toolStripbtn_create.Size = new System.Drawing.Size(83, 22);
            this.toolStripbtn_create.Text = "&Lưu_Thêm";
            this.toolStripbtn_create.Click += new System.EventHandler(this.toolStripbtn_create_Click);
            // 
            // toolStripButton_Save
            // 
            this.toolStripButton_Save.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Save.Image")));
            this.toolStripButton_Save.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Save.Name = "toolStripButton_Save";
            this.toolStripButton_Save.Size = new System.Drawing.Size(92, 22);
            this.toolStripButton_Save.Text = "Lưu-Sửa Đổi";
            this.toolStripButton_Save.Click += new System.EventHandler(this.toolStripButton_Save_Click);
            // 
            // toolStripbtn_reload
            // 
            this.toolStripbtn_reload.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtn_reload.Image")));
            this.toolStripbtn_reload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtn_reload.Name = "toolStripbtn_reload";
            this.toolStripbtn_reload.Size = new System.Drawing.Size(64, 22);
            this.toolStripbtn_reload.Text = "Nạp lại";
            this.toolStripbtn_reload.Click += new System.EventHandler(this.toolStripbtn_reload_Click);
            // 
            // toolStripbtn_print
            // 
            this.toolStripbtn_print.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtn_print.Image")));
            this.toolStripbtn_print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtn_print.Name = "toolStripbtn_print";
            this.toolStripbtn_print.Size = new System.Drawing.Size(37, 22);
            this.toolStripbtn_print.Text = "&In";
            // 
            // toolStripbtn_dong
            // 
            this.toolStripbtn_dong.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtn_dong.Image")));
            this.toolStripbtn_dong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtn_dong.Name = "toolStripbtn_dong";
            this.toolStripbtn_dong.Size = new System.Drawing.Size(56, 22);
            this.toolStripbtn_dong.Text = "Đóng";
            this.toolStripbtn_dong.Click += new System.EventHandler(this.toolStripbtn_dong_Click_1);
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.gridView_KyHan);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(0, 203);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(885, 264);
            this.panelControl4.TabIndex = 4;
            // 
            // KyHanVay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl4);
            this.Controls.Add(this.panel1);
            this.Name = "KyHanVay";
            this.Size = new System.Drawing.Size(885, 467);
            this.Load += new System.EventHandler(this.KyHanVay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView_KyHan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_KyHanVay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_number)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripbtn_create;
        private System.Windows.Forms.ToolStripButton toolStripbtn_reload;
        private System.Windows.Forms.ToolStripButton toolStripbtn_print;
        private System.Windows.Forms.ToolStripButton toolStripbtn_dong;
        private DevExpress.XtraGrid.GridControl gridView_KyHan;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_KyHanVay;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.TextBox txt_money;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_interest_rate;
        private System.Windows.Forms.NumericUpDown num_number;
        private DevExpress.XtraGrid.Columns.GridColumn numberMonth;
        private DevExpress.XtraGrid.Columns.GridColumn interestRate;
        private DevExpress.XtraGrid.Columns.GridColumn monerUse;
        private DevExpress.XtraGrid.Columns.GridColumn note;
        private System.Windows.Forms.ToolStripButton toolStripButton_Save;
        private System.Windows.Forms.TextBox txt_MaKH;
        private DevExpress.XtraGrid.Columns.GridColumn MAKHV;
        private System.Windows.Forms.CheckBox checkBox_status;
        private System.Windows.Forms.TextBox txt_note;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.Columns.GridColumn status;
        private DevExpress.XtraGrid.Columns.GridColumn gril;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnRemove;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnActive;
    }
}
