using DevExpress.Export;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraPrinting;
using QLSoTietKiem.Business;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace QLSoTK.ChucNang
{
    public partial class Timkiem : System.Windows.Forms.UserControl
    {
        public Timkiem()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void toolStripbtn_dong_Click(object sender, EventArgs e)
        {
            frm_main f = this.ParentForm as frm_main;
            f.Tab_Closed();
        }

        private void Timkiem_Load(object sender, EventArgs e)
        {
            var _sotietkiem = SoTietKiemBus.GetAll();
            if (_sotietkiem != null)
            {
                gridControl_timKiem.DataSource = _sotietkiem;
            }
            GridLocalizer.Active = new MyGridLocalizer();
        }
        [DllImport("user32.dll")]
        static extern int SetWindowText(IntPtr hWnd, string text);
        private void toolStripButton_excel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialogBox = new SaveFileDialog();
            saveDialogBox.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal).ToString();
            saveDialogBox.Filter = "XLS files (*.xls, *.xlt)|*.xls;*.xlt|XLSX files (*.xlsx, *.xlsm, *.xltx, *.xltm)|*.xlsx;*.xlsm;*.xltx;*.xltm|CSV (*.csv)|*.csv";
            saveDialogBox.Title = "Save a CSV File";
            saveDialogBox.ShowDialog();
            if (saveDialogBox.FileName != "")
            {
                try
                {
                    XlsxExportOptionsEx options = new XlsxExportOptionsEx();
                    options.SheetName = "QLSTK";
                    options.ExportType = ExportType.DataAware;
                    options.AllowFixedColumnHeaderPanel = DevExpress.Utils.DefaultBoolean.True;
                    options.CustomizeCell += Options_CustomizeCell;
                    options.TextExportMode = TextExportMode.Value;
                    options.RawDataMode = false;
                    gridView_timkiem.ExportToXlsx(saveDialogBox.FileName, options);
                    Process p = Process.Start(saveDialogBox.FileName);
                    Thread.Sleep(100);
                    SetWindowText(p.MainWindowHandle, "My Notepad");
                    MessageBox.Show("File " + saveDialogBox.FileName + " đã lưu thành công", "Thông Báo", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Không thể tải được.","Thông Báo", MessageBoxButtons.OK);
                }
            }
           
        }
        private void Options_CustomizeCell(DevExpress.Export.CustomizeCellEventArgs e)
        {
            if (e.ColumnFieldName != "SoTienGui")
                return;
            e.Formatting.NumberFormat = "@";
            //or
            //e.Formatting.NumberFormat = XlNumberFormat.Text;
            e.Handled = true;
        }
    }
    #region change button clear and find of gridcontrol
    public class MyGridLocalizer : GridLocalizer
    {
        public override string GetLocalizedString(GridStringId id)
        {
            string retval = "";
            switch (id)
            {
                case GridStringId.FindControlClearButton: return "Làm mới";
                case GridStringId.FindControlFindButton: return "Tìm";

                default:
                    retval = "";
                    break;
            }
            return retval;
        }
    }
    #endregion
}
