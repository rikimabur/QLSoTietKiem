using DevExpress.LookAndFeel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using QLSoTietKiem.DTO;
using QLSoTK.ChucNang;
using QLSoTK.ChucNang.Phieu;
using QLSoTK.DanhMuc;
using QLSoTK.Helpers;
using QLSoTK.HeThong;
using QLSoTK.Login;
using System;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace QLSoTK
{
    public partial class frm_main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static TaiKhoanDto _loginTaiKhoan = null;
        public delegate TaiKhoanDto AccountLoginOrChangePasswordDelegate();

        #region add and close Xtab
        public void AddTabControl(UserControl usercontrol, string itemTabName)
        {
            bool _isExists = false;
            foreach (XtraTabPage tabItem in XTabMain.TabPages)
            {
                if (tabItem.Text == itemTabName)// tab ton tai
                {
                    _isExists = true;
                    XTabMain.SelectedTabPage = tabItem;
                }
            }
            if (_isExists == false) // kiem tra chua ton tai tab
            {
                //tao them tab moi 
                XtraTabPage xtratabpage = new XtraTabPage();
                xtratabpage.Name = "tab_phanquyen";
                xtratabpage.Text = itemTabName;
                xtratabpage.AutoScroll = true;
                //usercontrol.Dock = DockStyle.Fill;
                xtratabpage.Controls.Add(usercontrol);
                XTabMain.TabPages.Add(xtratabpage);
            }
        }
        public void Tab_Closed()
        {
            XTabMain.TabPages.RemoveAt(XTabMain.SelectedTabPageIndex);
            //System.Diagnostics.Process.GetCurrentProcess().Kill();
            //XTabMain.SelectedTabPageIndex = XTabMain.TabPages.Count() - 1;
        }
        #endregion
        #region Khởi tạo 
        public frm_main()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            barStaticItem_tenMay.Caption = Environment.MachineName.ToString();
            barStaticItem_Ngay.Caption = DateTime.Today.ToString("dd/MM/yyyy");
            barStaticItem_Clock.Caption = DateTime.Today.ToString("hh:mm tt");
        }
        #endregion
        /// <summary>
        /// load from main
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {           
            _loginTaiKhoan = null;
            if(accountLoginOrchangePasswordDelegate != null)
            {
                _loginTaiKhoan = accountLoginOrchangePasswordDelegate();
            }
            #region Custom the ribbon
            //menu_ribbonControl.ShowFullScreenButton = DefaultBoolean.False; // turn off auto hide ribbon
            //menu_ribbonControl.ShowApplicationButton = DefaultBoolean.False; // turn off mini the ribbon button
            //menu_ribbonControl.ShowExpandCollapseButton = DefaultBoolean.False; //turn off minize the ribbon button
            //menu_ribbonControl.ShowToolbarCustomizeItem = false;// turn off show quick access toolbar below the ribbon
            //menu_ribbonControl.ShowApplicationButton = DefaultBoolean.False;
            #endregion
        }
        // add tab new
        private void XTabMain_ControlAdded(object sender, ControlEventArgs e)
        {
            XTabMain.SelectedTabPageIndex = XTabMain.TabPages.Count - 1;
        }
        #region Thoát khỏi màn hình chức năng
        private void btn_KetThuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();
            frmLogin _frmLogin = new frmLogin();
            _frmLogin.ShowDialog();
        }
        #endregion
        private void barButton_DoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_DoiMatKhau_HeThong _frm = new frm_DoiMatKhau_HeThong();
            //_frm.MdiParent = this;
            _frm.getDataChangePasswordFormFromMainForm += delegate { return _loginTaiKhoan; };//Set data from main form
            Form activeForm = frm_DoiMatKhau_HeThong.ActiveForm;
            if (activeForm.Name.ToString() == "frm_DoiMatKhau_HeThong" && activeForm != null)
            {
                MessageBox.Show("Đang có form đổi mật khẩu đang hoạt động", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
            }
            else
            {
                _frm.ShowDialog();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbclock.Caption = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");
        }
        #region Quy định Kỳ Hạn Vay
        private void barbtn_Vay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KyHanVay _kyHanVayControl = new KyHanVay();
            AddTabControl(_kyHanVayControl, "Kỳ Hạn Vay");
        }
        #endregion
        #region Hổ trợ trực tuyến
        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        private void barButtonItem_HotroTrucTuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process p = Process.Start(@"C:\Program Files (x86)\TeamViewer\TeamViewer.exe");
            Thread.Sleep(500); // Allow the process to open it's window
            SetParent(p.MainWindowHandle, this.Handle);
        }
        #endregion
        #region Hướng dẫn sử dụng
        // Tài liệu
        private void barButtonItem_document_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("http://google.com.vn");
            Process.Start(processStartInfo);
        }
        // Bằng video
        private void barButtonItem_Video_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("https://www.youtube.com/");
            Process.Start(processStartInfo);
        }
        #endregion
        #region Liên Hệ
        private void barButtonItem_LienHe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("http://google.com.vn");
            Process.Start(processStartInfo);
        }
        #endregion

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void btn_thongtin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_ThongTin thongTinCaNhan = new frm_ThongTin();
            thongTinCaNhan.ShowDialog();
        }
        private void btn_saoLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_SaoLuu saoLuu = new frm_SaoLuu();
            saoLuu.ShowDialog();
        }

        private void btn_MoSoTietKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MoSoTietKiemControl _moSoTietKiemControl = new MoSoTietKiemControl();
            AddTabControl(_moSoTietKiemControl, "Mở Sổ Tiết Kiệm");
        }

        private void btn_phieugui_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhieuGuiTien phieuChi = new PhieuGuiTien();
            ReportPrintTool reportPrintTool = new ReportPrintTool(phieuChi);
            UserLookAndFeel userLookAndFeel = new UserLookAndFeel(this);
            userLookAndFeel.UseDefaultLookAndFeel = false;
            userLookAndFeel.SkinName = "Office 2016 colorful";
            reportPrintTool.ShowRibbonPreviewDialog(userLookAndFeel);
        }

        // Tìm kiếm
        private void btn_timkiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Timkiem _timKiemControl = new Timkiem();
            AddTabControl(_timKiemControl, "Tìm Kiếm");
        }

        private void frm_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }
        #region "proccess delegate"
        public AccountLoginOrChangePasswordDelegate accountLoginOrchangePasswordDelegate;
        #endregion
        private void barBut_Register_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_TaoTaiKhoan _frm = new frm_TaoTaiKhoan();
            _frm.Show();
        }

        private void XTabMain_CloseButtonClick(object sender, EventArgs e)
        {
            XTabMain.TabPages.RemoveAt(XTabMain.SelectedTabPageIndex);
        }

        private void barBut_StaffManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NhanVien _nhanVienControl = new NhanVien();
            // _moSoTietKiemControl.Closed += Tab_Closed;
            _nhanVienControl.Dock = System.Windows.Forms.DockStyle.Fill;
            AddTabControl(_nhanVienControl, "Quản lý nhân viên");
        }

        private void barBut_CustManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Khachhang  _khachhangControl = new Khachhang();
            // _moSoTietKiemControl.Closed += Tab_Closed;
            _khachhangControl.Dock = System.Windows.Forms.DockStyle.Fill;
            AddTabControl(_khachhangControl, "Quản lý khách hàng");
        }
        // Gửi thêm tiền vào sổ tiết kiệm
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GuiThemTien _guiThemTienControl = new GuiThemTien();
            _guiThemTienControl.Closed += Tab_Closed;
            AddTabControl(_guiThemTienControl, "Gửi Thêm Tiền");
        }

        private void barButtonItem_RutTien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RutSoTietKiem  rutSoTietKiem = new RutSoTietKiem();
            AddTabControl(rutSoTietKiem, "Rút sổ tiết kiệm");
        }
        #region Kiểm tra thiết bị đang kết nỗi đến db nào
        private void TestConnection()
        {
            using (var db = new QLSoTietKiemDBContext())
            {
                try
                {
                    db.Database.Connection.Open();
                    if (db.Database.Connection.State == ConnectionState.Open)
                    {
                        MessageBox.Show(@"INFO: ConnectionString: " + db.Database.Connection.ConnectionString
                            + "\n DataBase: " + db.Database.Connection.Database
                            + "\n DataSource: " + db.Database.Connection.DataSource
                            + "\n ServerVersion: " + db.Database.Connection.ServerVersion
                            + "\n TimeOut: " + db.Database.Connection.ConnectionTimeout,"Thông báo thông tin db đang dùng");
                        db.Database.Connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        // Lịch sử giao dịch
        private void barButtonItem_lichsuGD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LichSuGiaoDich lichSuGiaoDich = new LichSuGiaoDich();
            AddTabControl(lichSuGiaoDich, "Lịch sử giao dịch");
        }

        private void XTabMain_Click(object sender, EventArgs e)
        {
           
        }
        // phiếu rút tiền
        private void barButtonItem_phieuthu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhieuRutTien phieuChi = new PhieuRutTien();
            ReportPrintTool reportPrintTool = new ReportPrintTool(phieuChi);
            UserLookAndFeel userLookAndFeel = new UserLookAndFeel(this);
            userLookAndFeel.UseDefaultLookAndFeel = false;
            userLookAndFeel.SkinName = "Office 2016 colorful";
            reportPrintTool.ShowRibbonPreviewDialog(userLookAndFeel);
        }
    }
}
