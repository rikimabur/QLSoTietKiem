namespace QLSoTK.ChucNang
{
    partial class Timkiem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Timkiem));
            this.gridControl_timKiem = new DevExpress.XtraGrid.GridControl();
            this.gridView_timkiem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaSTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dateOpen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dateEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.number = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KyHanGui = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Tien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenVN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TongTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripbtn_dong = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_excel = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_timKiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_timkiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl_timKiem
            // 
            this.gridControl_timKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_timKiem.Location = new System.Drawing.Point(2, 2);
            this.gridControl_timKiem.MainView = this.gridView_timkiem;
            this.gridControl_timKiem.Name = "gridControl_timKiem";
            this.gridControl_timKiem.Size = new System.Drawing.Size(668, 419);
            this.gridControl_timKiem.TabIndex = 0;
            this.gridControl_timKiem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_timkiem});
            // 
            // gridView_timkiem
            // 
            this.gridView_timkiem.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaSTK,
            this.dateOpen,
            this.dateEnd,
            this.number,
            this.KyHanGui,
            this.Tien,
            this.TenVN,
            this.TenKH,
            this.TongTien,
            this.TrangThai});
            this.gridView_timkiem.CustomizationFormBounds = new System.Drawing.Rectangle(688, 324, 210, 172);
            this.gridView_timkiem.GridControl = this.gridControl_timKiem;
            this.gridView_timkiem.GroupCount = 1;
            this.gridView_timkiem.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "Mã Sổ Tiết Kiệm", this.MaSTK, "")});
            this.gridView_timkiem.Name = "gridView_timkiem";
            this.gridView_timkiem.OptionsFind.AlwaysVisible = true;
            this.gridView_timkiem.OptionsFind.FindNullPrompt = "Bạn cần tìm.....";
            this.gridView_timkiem.OptionsSelection.MultiSelect = true;
            this.gridView_timkiem.OptionsView.ShowAutoFilterRow = true;
            this.gridView_timkiem.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.TenKH, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.dateOpen, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.KyHanGui, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Tien, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.TongTien, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.TrangThai, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.dateEnd, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.number, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.TenVN, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // MaSTK
            // 
            this.MaSTK.Caption = "Mã Sổ Tiết Kiệm";
            this.MaSTK.FieldName = "MaSTK";
            this.MaSTK.Name = "MaSTK";
            this.MaSTK.Visible = true;
            this.MaSTK.VisibleIndex = 0;
            // 
            // dateOpen
            // 
            this.dateOpen.Caption = "Ngày Mở";
            this.dateOpen.FieldName = "NgayMo";
            this.dateOpen.Name = "dateOpen";
            this.dateOpen.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.dateOpen.Visible = true;
            this.dateOpen.VisibleIndex = 3;
            this.dateOpen.Width = 83;
            // 
            // dateEnd
            // 
            this.dateEnd.Caption = "Ngày Đáo Hạn";
            this.dateEnd.FieldName = "NgayDenHan";
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.dateEnd.Visible = true;
            this.dateEnd.VisibleIndex = 2;
            // 
            // number
            // 
            this.number.Caption = "Số Ngày Hiệu Lực";
            this.number.FieldName = "SoNgayHieuLuc";
            this.number.Name = "number";
            this.number.Visible = true;
            this.number.VisibleIndex = 1;
            // 
            // KyHanGui
            // 
            this.KyHanGui.Caption = "Kỳ Hạn Gửi";
            this.KyHanGui.FieldName = "KyHanGui";
            this.KyHanGui.Name = "KyHanGui";
            this.KyHanGui.Visible = true;
            this.KyHanGui.VisibleIndex = 4;
            this.KyHanGui.Width = 83;
            // 
            // Tien
            // 
            this.Tien.Caption = "Tiền Tệ";
            this.Tien.FieldName = "TienTe";
            this.Tien.Name = "Tien";
            this.Tien.Visible = true;
            this.Tien.VisibleIndex = 5;
            // 
            // TenVN
            // 
            this.TenVN.Caption = "Tên Nhân Viên";
            this.TenVN.FieldName = "TenNhanVien";
            this.TenVN.Name = "TenVN";
            this.TenVN.Visible = true;
            this.TenVN.VisibleIndex = 6;
            // 
            // TenKH
            // 
            this.TenKH.Caption = "Tên Khách Hàng";
            this.TenKH.FieldName = "KhachHang";
            this.TenKH.Name = "TenKH";
            this.TenKH.Visible = true;
            this.TenKH.VisibleIndex = 7;
            // 
            // TongTien
            // 
            this.TongTien.Caption = "Số Tiền Gửi";
            this.TongTien.DisplayFormat.FormatString = "{0:N0},000";
            this.TongTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.TongTien.FieldName = "SoTienGui";
            this.TongTien.Name = "TongTien";
            this.TongTien.Visible = true;
            this.TongTien.VisibleIndex = 7;
            // 
            // TrangThai
            // 
            this.TrangThai.Caption = "Trạng Thái";
            this.TrangThai.FieldName = "TrangThai";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Visible = true;
            this.TrangThai.VisibleIndex = 8;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.AutoSize = true;
            this.panelControl1.Controls.Add(this.gridControl_timKiem);
            this.panelControl1.Location = new System.Drawing.Point(3, 30);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(672, 423);
            this.panelControl1.TabIndex = 2;
            // 
            // panelControl2
            // 
            this.panelControl2.AutoSize = true;
            this.panelControl2.Controls.Add(this.toolStrip1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(675, 31);
            this.panelControl2.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_excel,
            this.toolStripbtn_dong});
            this.toolStrip1.Location = new System.Drawing.Point(2, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(188, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripbtn_dong
            // 
            this.toolStripbtn_dong.Image = ((System.Drawing.Image)(resources.GetObject("toolStripbtn_dong.Image")));
            this.toolStripbtn_dong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripbtn_dong.Name = "toolStripbtn_dong";
            this.toolStripbtn_dong.Size = new System.Drawing.Size(56, 22);
            this.toolStripbtn_dong.Text = "Đóng";
            this.toolStripbtn_dong.Click += new System.EventHandler(this.toolStripbtn_dong_Click);
            // 
            // toolStripButton_excel
            // 
            this.toolStripButton_excel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_excel.Image")));
            this.toolStripButton_excel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_excel.Name = "toolStripButton_excel";
            this.toolStripButton_excel.Size = new System.Drawing.Size(89, 22);
            this.toolStripButton_excel.Text = "Export Excel";
            this.toolStripButton_excel.Click += new System.EventHandler(this.toolStripButton_excel_Click);
            // 
            // Timkiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "Timkiem";
            this.Size = new System.Drawing.Size(675, 453);
            this.Load += new System.EventHandler(this.Timkiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_timKiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_timkiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl_timKiem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_timkiem;
        private DevExpress.XtraGrid.Columns.GridColumn MaSTK;
        private DevExpress.XtraGrid.Columns.GridColumn dateOpen;
        private DevExpress.XtraGrid.Columns.GridColumn dateEnd;
        private DevExpress.XtraGrid.Columns.GridColumn number;
        private DevExpress.XtraGrid.Columns.GridColumn KyHanGui;
        private DevExpress.XtraGrid.Columns.GridColumn Tien;
        private DevExpress.XtraGrid.Columns.GridColumn TenVN;
        private DevExpress.XtraGrid.Columns.GridColumn TenKH;
        private DevExpress.XtraGrid.Columns.GridColumn TongTien;
        private DevExpress.XtraGrid.Columns.GridColumn TrangThai;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripbtn_dong;
        private System.Windows.Forms.ToolStripButton toolStripButton_excel;
    }
}
