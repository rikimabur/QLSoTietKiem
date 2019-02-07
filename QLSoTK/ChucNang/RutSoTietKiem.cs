using DevExpress.LookAndFeel;
using DevExpress.XtraReports.UI;
using QLSoTietKiem.Business;
using QLSoTietKiem.DTO.Model;
using QLSoTK.ChucNang.Phieu;
using QLSoTK.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLSoTK.ChucNang
{
    /// <summary>
    /// Giao diện rút sổ tiết kiệm
    /// </summary>
    public partial class RutSoTietKiem : UserControl
    {
        SoTietKiem_DTO soTietKiem = new SoTietKiem_DTO();
        public delegate void _totalMoneyHandel(double totalMoney);
        public event _totalMoneyHandel TotalMoneyEvent;

        public delegate void PhieuRutTienDeleagte(PhieuRut_DTO phieuRut_DTO);
        public event PhieuRutTienDeleagte PhieuRutEvent;
        /// <summary>
        /// Constructor 
        /// </summary>
        public RutSoTietKiem()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            Init(soTietKiem);
        }
        /// <summary>
        /// Khởi tạo tất cả các label and dataEdit 
        /// </summary>
        /// <param name="soTietKiem"></param>
        private void Init(SoTietKiem_DTO soTietKiem)
        {
            label_tongtien.Visible = true;
            label_infotongtien.Visible = true;

            if (soTietKiem != null && soTietKiem.MaSTK > 0)
            {
                double _lai = SoTietKiemBus.TinhLaiXuat(soTietKiem);
                label_tenkh.Text = soTietKiem.KhachHang;
                label_cmnd.Text = soTietKiem.CMND;
                label_diachi.Text = soTietKiem.DiaChi;
                label_loaitien.Text = soTietKiem.TienTe.ToString();
                label_kyhan.Text = soTietKiem.KyHanGui.ToString();
                label_laixuat.Text = soTietKiem.LaiXuat.ToString();
                label_sotien.Text = soTietKiem.SoTienGui.ToString();
                label_tongtien.Text = (_lai + soTietKiem.SoTienGui).ToString();
                dateEditCreate.DateTime = soTietKiem.NgayHieuLuc;
                dateEditDaoHan.DateTime = soTietKiem.NgayDenHan;
                label_sotienlai.Text = _lai.ToString();
                label_std.Text = soTietKiem.SDT;
                textBox_tinhtrang.Text = soTietKiem.TrangThai;
                label_ngaysinh.Text = soTietKiem.NgaySinh.ToString("dd/MM/yyyy");
                comb_stk.EditValue = soTietKiem.MaSTK;
            }
            else
            {
                label_tenkh.Text = null;
                label_sotienlai.Text = null;
                label_cmnd.Text = null;
                label_std.Text = null;
                label_diachi.Text = null;
                label_kyhan.Text = null;
                label_loaitien.Text = null;
                label_laixuat.Text = null;
                label_sotien.Text = null;
                label_tongtien.Text = null;
                label_sotienlai.Text = null;
                label_tongtien.Visible = false;
                label_infotongtien.Visible = false;
                textBox_tinhtrang.Text = null;
                comb_stk.EditValue = null;
                label_ngaysinh.Text = null;
            }
        }
        // Load usercontrol
        private void RutSoTietKiem_Load(object sender, EventArgs e)
        {
            List<SoTietKiem_DTO> _listSTK = SoTietKiemBus.GetListActive();
            gridControl_SoTietKiem.DataSource = _listSTK;
            comb_stk.Properties.Items.AddRange(_listSTK.Select(x => x.MaSTK).ToList());
        }
        // Row click of grid view 
        private void gridView_SoTietKiem_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView_SoTietKiem.GetFocusedRowCellValue("MaSTK") != null)
            {
                var _maSoTietKiem = int.Parse(gridView_SoTietKiem.GetFocusedRowCellValue("MaSTK").ToString());
                SoTietKiem_DTO _soTietKiem = SoTietKiemBus.GetById(_maSoTietKiem);
                Init(_soTietKiem);
            }
        }
        // Event change of one combobox
        private void comb_stk_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _maSoTietKiem = int.Parse(comb_stk.EditValue.ToString());
            SoTietKiem_DTO _soTietKiem = SoTietKiemBus.GetById(_maSoTietKiem);
            Init(_soTietKiem);
        }
        //Close one userControl
        private void toolStripbtn_dong_Click(object sender, EventArgs e)
        {
            frm_main f = this.ParentForm as frm_main;
            f.Tab_Closed();
        }
        // Rút sổ tiết kiệm
        private void toolStripButton_RutSo_Click(object sender, EventArgs e)
        {
            if (comb_stk.EditValue !=null)
            {
                int sothang = int.Parse(label_tongtien.Text);
                var message = SoTietKiemBus.CheckSTK(dateEditCreate.DateTime, dateEditDaoHan.DateTime,sothang);
                if (!string.IsNullOrEmpty(message))
                {
                    Commons.MessageErr(message);
                    return;
                }
                if (Commons.MessageConfirm("Bạn có muốn thực hiện việc rút sổ này") == DialogResult.Yes)
                {
                    int _maSoTietKiem = int.Parse(comb_stk.EditValue.ToString());
                    double tongTien = 0;
                    double tongLai = 0;
                    double.TryParse(label_tongtien.Text, out tongTien);
                    double.TryParse(label_sotienlai.Text, out tongLai);
                    if (SoTietKiemBus.Delete(_maSoTietKiem, Extensions.GetMANV(), tongTien, tongLai))
                    {
                        Commons.MessageInfo("Rút sổ tiết kiệm thành công!");
                        RutSoTietKiem_Load(sender, e);
                        return;
                    }
                    else
                    {
                        Commons.MessageErr("Server đang bảo trì. Xin vui lòng chờ...");
                        return;
                    }
                }
                return;
            }
            Commons.MessageInfo("Xin vui lòng chọn mã sổ tiết kiệm bạn cần thực hiện!");
        }
        // Phiếu rút tiền
        private void btn_phieuruttien_Click(object sender, EventArgs e)
        {
            PhieuRutTien phieuChi = new PhieuRutTien();
            GetPhieu();
            ReportPrintTool reportPrintTool = new ReportPrintTool(phieuChi);
            UserLookAndFeel userLookAndFeel = new UserLookAndFeel(this);
            userLookAndFeel.UseDefaultLookAndFeel = false;
            userLookAndFeel.SkinName = "Office 2016 colorful";
            reportPrintTool.ShowRibbonPreviewDialog(userLookAndFeel);
        
        }
        // event khi trạng thái
        private void textBox_tinhtrang_TextChanged(object sender, EventArgs e)
        {
            // ẩn 2 nút button khi sổ đã được rút
            if(textBox_tinhtrang.Text.ToLower().Equals("đã rút"))
            {
                toolStripButton_RutSo.Visible = false;
                btn_phieuruttien.Visible = false;
            }
        }
        // Lấy danh sách tất cả các thuộc tính trên form
        protected virtual void GetPhieu()
        {
            if (PhieuRutEvent != null)
            {
                PhieuRut_DTO phieuRut_DTO = new PhieuRut_DTO();
                phieuRut_DTO.HoTenKh = label_tenkh.Text;
                phieuRut_DTO.CMND = label_cmnd.Text;
                phieuRut_DTO.DiaChi = label_diachi.Text;
                phieuRut_DTO.LoaiTien = label_loaitien.Text;
                phieuRut_DTO.KyHan = label_kyhan.Text;
                phieuRut_DTO.SoTienGui = label_sotien.Text;
                phieuRut_DTO.TongNhan = label_tongtien.Text;
                phieuRut_DTO.TongLai = label_sotienlai.Text;
                phieuRut_DTO.NgaySinh = label_ngaysinh.Text;
                PhieuRutEvent(phieuRut_DTO);
            }
        }
        //private PhieuRut_DTO GetPhieu()
        //{
        //    PhieuRut_DTO phieuRut_DTO = new PhieuRut_DTO();
        //    phieuRut_DTO.HoTenKh = label_tenkh.Text;
        //    phieuRut_DTO.CMND = label_cmnd.Text;
        //    phieuRut_DTO.DiaChi = label_diachi.Text;
        //    phieuRut_DTO.LoaiTien = label_loaitien.Text;
        //    phieuRut_DTO.KyHan = label_kyhan.Text;
        //    phieuRut_DTO.SoTienGui = label_sotien.Text;
        //    phieuRut_DTO.TongNhan = label_tongtien.Text;
        //    phieuRut_DTO.TongLai = label_sotienlai.Text;
        //    phieuRut_DTO.NgaySinh = label_ngaysinh.Text;
        //    return phieuRut_DTO;
        //}
        // Cho phép gửi lại
        private void toolStripButton_RutAndGui_Click(object sender, EventArgs e)
        {
            if (comb_stk.EditValue == null || TotalMoneyEvent == null || string.IsNullOrEmpty(label_tongtien.Text))
            {
                Commons.MessageInfo("Xin vui lòng chọn mã sổ tiết kiệm bạn cần thực hiện!");
                return;
            }
            TotalMoney();
        }
        protected virtual void TotalMoney()
        {
            if (TotalMoneyEvent != null)
            {
                double total = 0;
                double.TryParse(label_tongtien.Text, out total);
                TotalMoneyEvent(total);
                frm_main frm_Main = new frm_main();
                MoSoTietKiemControl _moSoTietKiemControl = new MoSoTietKiemControl();
                frm_Main.AddTabControl(_moSoTietKiemControl, "Mở Sổ Tiết Kiệm");
            }
        }
    }
}
