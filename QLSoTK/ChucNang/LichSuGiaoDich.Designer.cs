namespace QLSoTK.ChucNang
{
    partial class LichSuGiaoDich
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LichSuGiaoDich));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simple_close = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl_lichsu = new DevExpress.XtraGrid.GridControl();
            this.gridView_lichsu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_mgd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_loaigd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaSTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_laisuat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KyHanGui = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Tien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenVN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_cmnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TongTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_tonglai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_tongtien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_lichsu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_lichsu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.simple_close);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(830, 38);
            this.panelControl1.TabIndex = 1;
            // 
            // simple_close
            // 
            this.simple_close.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simple_close.ImageOptions.Image")));
            this.simple_close.Location = new System.Drawing.Point(108, 5);
            this.simple_close.Name = "simple_close";
            this.simple_close.Size = new System.Drawing.Size(87, 28);
            this.simple_close.TabIndex = 5;
            this.simple_close.Text = "Đóng";
            this.simple_close.Click += new System.EventHandler(this.simple_close_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(108, 5);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(87, 28);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "Xóa";
            this.simpleButton2.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(15, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(87, 28);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Load";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.gridControl_lichsu);
            this.panelControl2.Location = new System.Drawing.Point(3, 42);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(830, 384);
            this.panelControl2.TabIndex = 2;
            // 
            // gridControl_lichsu
            // 
            this.gridControl_lichsu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_lichsu.Location = new System.Drawing.Point(2, 2);
            this.gridControl_lichsu.MainView = this.gridView_lichsu;
            this.gridControl_lichsu.Name = "gridControl_lichsu";
            this.gridControl_lichsu.Size = new System.Drawing.Size(826, 380);
            this.gridControl_lichsu.TabIndex = 1;
            this.gridControl_lichsu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_lichsu});
            // 
            // gridView_lichsu
            // 
            this.gridView_lichsu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_mgd,
            this.col_loaigd,
            this.MaSTK,
            this.col_laisuat,
            this.KyHanGui,
            this.Tien,
            this.TenVN,
            this.TenKH,
            this.col_cmnd,
            this.TongTien,
            this.col_tonglai,
            this.col_tongtien,
            this.TrangThai});
            this.gridView_lichsu.CustomizationFormBounds = new System.Drawing.Rectangle(688, 324, 210, 172);
            this.gridView_lichsu.GridControl = this.gridControl_lichsu;
            this.gridView_lichsu.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "Mã Sổ Tiết Kiệm", this.MaSTK, "")});
            this.gridView_lichsu.Name = "gridView_lichsu";
            this.gridView_lichsu.OptionsFind.AlwaysVisible = true;
            this.gridView_lichsu.OptionsFind.FindNullPrompt = "Bạn cần tìm.....";
            this.gridView_lichsu.OptionsSelection.MultiSelect = true;
            this.gridView_lichsu.OptionsView.ShowAutoFilterRow = true;
            this.gridView_lichsu.OptionsView.ShowGroupPanel = false;
            this.gridView_lichsu.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.KyHanGui, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Tien, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.TongTien, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.TrangThai, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.col_laisuat, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.TenVN, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // col_mgd
            // 
            this.col_mgd.Caption = "Mã Giao Dịch";
            this.col_mgd.FieldName = "MaGiaoDich";
            this.col_mgd.Name = "col_mgd";
            this.col_mgd.OptionsColumn.AllowEdit = false;
            this.col_mgd.Visible = true;
            this.col_mgd.VisibleIndex = 0;
            // 
            // col_loaigd
            // 
            this.col_loaigd.Caption = "Giao Dịch";
            this.col_loaigd.FieldName = "LoaiGD";
            this.col_loaigd.Name = "col_loaigd";
            this.col_loaigd.Visible = true;
            this.col_loaigd.VisibleIndex = 2;
            // 
            // MaSTK
            // 
            this.MaSTK.Caption = "Mã Sổ Tiết Kiệm";
            this.MaSTK.FieldName = "MaSTK";
            this.MaSTK.Name = "MaSTK";
            this.MaSTK.OptionsColumn.AllowEdit = false;
            this.MaSTK.Visible = true;
            this.MaSTK.VisibleIndex = 1;
            // 
            // col_laisuat
            // 
            this.col_laisuat.Caption = "Lãi Suất(%)";
            this.col_laisuat.FieldName = "LaiSuat";
            this.col_laisuat.Name = "col_laisuat";
            this.col_laisuat.OptionsColumn.AllowEdit = false;
            this.col_laisuat.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.col_laisuat.Visible = true;
            this.col_laisuat.VisibleIndex = 3;
            // 
            // KyHanGui
            // 
            this.KyHanGui.Caption = "Kỳ Hạn Gửi";
            this.KyHanGui.FieldName = "SoKyHan";
            this.KyHanGui.Name = "KyHanGui";
            this.KyHanGui.OptionsColumn.AllowEdit = false;
            this.KyHanGui.Visible = true;
            this.KyHanGui.VisibleIndex = 4;
            this.KyHanGui.Width = 83;
            // 
            // Tien
            // 
            this.Tien.Caption = "Tiền Tệ";
            this.Tien.FieldName = "LoaiTien";
            this.Tien.Name = "Tien";
            this.Tien.OptionsColumn.AllowEdit = false;
            this.Tien.Visible = true;
            this.Tien.VisibleIndex = 5;
            // 
            // TenVN
            // 
            this.TenVN.Caption = "Tên Nhân Viên";
            this.TenVN.FieldName = "TenNhanVien";
            this.TenVN.Name = "TenVN";
            this.TenVN.OptionsColumn.AllowEdit = false;
            this.TenVN.Visible = true;
            this.TenVN.VisibleIndex = 6;
            // 
            // TenKH
            // 
            this.TenKH.Caption = "Tên Khách Hàng";
            this.TenKH.FieldName = "TenKhachHang";
            this.TenKH.Name = "TenKH";
            this.TenKH.OptionsColumn.AllowEdit = false;
            this.TenKH.Visible = true;
            this.TenKH.VisibleIndex = 8;
            // 
            // col_cmnd
            // 
            this.col_cmnd.Caption = "CMND";
            this.col_cmnd.FieldName = "CMND";
            this.col_cmnd.Name = "col_cmnd";
            this.col_cmnd.OptionsColumn.AllowEdit = false;
            this.col_cmnd.Visible = true;
            this.col_cmnd.VisibleIndex = 9;
            // 
            // TongTien
            // 
            this.TongTien.Caption = "Số Tiền Gửi";
            this.TongTien.DisplayFormat.FormatString = "{0:N0},000";
            this.TongTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.TongTien.FieldName = "SoTienGui";
            this.TongTien.Name = "TongTien";
            this.TongTien.OptionsColumn.AllowEdit = false;
            this.TongTien.Visible = true;
            this.TongTien.VisibleIndex = 7;
            // 
            // col_tonglai
            // 
            this.col_tonglai.Caption = "Tổng Tiền Lãi";
            this.col_tonglai.DisplayFormat.FormatString = "{0:N0},000";
            this.col_tonglai.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.col_tonglai.FieldName = "TongTienLai";
            this.col_tonglai.Name = "col_tonglai";
            this.col_tonglai.OptionsColumn.AllowEdit = false;
            this.col_tonglai.Visible = true;
            this.col_tonglai.VisibleIndex = 10;
            // 
            // col_tongtien
            // 
            this.col_tongtien.Caption = "Tổng Tiền";
            this.col_tongtien.DisplayFormat.FormatString = "{0:N0},000";
            this.col_tongtien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.col_tongtien.FieldName = "TongTien";
            this.col_tongtien.Name = "col_tongtien";
            this.col_tongtien.OptionsColumn.AllowEdit = false;
            this.col_tongtien.Visible = true;
            this.col_tongtien.VisibleIndex = 11;
            // 
            // TrangThai
            // 
            this.TrangThai.Caption = "Trạng Thái";
            this.TrangThai.FieldName = "TinhTrang";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.OptionsColumn.AllowEdit = false;
            // 
            // LichSuGiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "LichSuGiaoDich";
            this.Size = new System.Drawing.Size(836, 430);
            this.Load += new System.EventHandler(this.LichSuGiaoDich_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_lichsu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_lichsu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simple_close;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControl_lichsu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_lichsu;
        private DevExpress.XtraGrid.Columns.GridColumn col_mgd;
        private DevExpress.XtraGrid.Columns.GridColumn MaSTK;
        private DevExpress.XtraGrid.Columns.GridColumn col_laisuat;
        private DevExpress.XtraGrid.Columns.GridColumn KyHanGui;
        private DevExpress.XtraGrid.Columns.GridColumn Tien;
        private DevExpress.XtraGrid.Columns.GridColumn TenVN;
        private DevExpress.XtraGrid.Columns.GridColumn TenKH;
        private DevExpress.XtraGrid.Columns.GridColumn TongTien;
        private DevExpress.XtraGrid.Columns.GridColumn col_tonglai;
        private DevExpress.XtraGrid.Columns.GridColumn col_tongtien;
        private DevExpress.XtraGrid.Columns.GridColumn TrangThai;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraGrid.Columns.GridColumn col_cmnd;
        private DevExpress.XtraGrid.Columns.GridColumn col_loaigd;
    }
}
