using DevExpress.LookAndFeel;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using QLSoTietKiem.Business;
using QLSoTietKiem.DTO;
using QLSoTietKiem.DTO.Model;
using QLSoTK.ChucNang.KhachHang;
using QLSoTK.ChucNang.Phieu;
using QLSoTK.Helpers;
using System;
using System.Windows.Forms;

namespace QLSoTK.ChucNang
{
    public partial class MoSoTietKiemControl : UserControl
    {
        private SoTietKiem_DTO _soTietKiemDTO = new SoTietKiem_DTO();
        public MoSoTietKiemControl()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        //Load
        private void MoSoTietKiemControl_Load(object sender, EventArgs e)
        {
            /* Load ds kỳ hạn */
            gridLookUpEditKyhan.Properties.DataSource = KyHanVayBus.GetKyHanActive();
            gridLookUpEditKyhan.Properties.DisplayMember = "SoThang";
            gridLookUpEditKyhan.Properties.ValueMember = "MaKyHan";

            /* Load ds khách hàng */
            grid_khachhang.Properties.DataSource = KhachHangBus.GetAll();
            grid_khachhang.Properties.DisplayMember = "Hoten";
            grid_khachhang.Properties.ValueMember = "MaKh";

            /* Load ds Loại tiền */
            gridLookUpEditLoaiTien.Properties.DataSource = LoaiTienBus.GetAll();
            gridLookUpEditLoaiTien.Properties.DisplayMember = "LoaiTien";
            gridLookUpEditLoaiTien.Properties.ValueMember = "MaLoaiTien";
            /*Load ds sổ tiết kiệm*/
            gridControl_SoTietKiem.DataSource = SoTietKiemBus.GetAll();

            // scroll 
            gridView_SoTietKiem.ScrollStyle = ScrollStyleFlags.LiveHorzScroll;
            gridView_SoTietKiem.HorzScrollVisibility = ScrollVisibility.Always;
        }
        // Đóng tab control
        private void toolStripbtn_dong_Click(object sender, EventArgs e)
        {
            frm_main f = this.ParentForm as frm_main;
            f.Tab_Closed();
        }
        // In văn bản
        private void toolStripbtn_print_Click(object sender, EventArgs e)
        {

        }
        //TODO: pending
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        // Bắt 2 sự kiện button trên cùng một girdlookup edit
        private void grid_khachhang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            {
                // thêm một khách hàng mới
                frm_khachhang _frmCustomer = new frm_khachhang();
                _frmCustomer.KhachHangCmndEvent += OnCMND;
                DialogResult dr = _frmCustomer.ShowDialog();
                if(dr == DialogResult.OK)
                {                
                }
            
            }
            else
            if( e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            {
                grid_khachhang.ShowPopup();
                gridLookUpEdit_khachHang.OptionsView.ShowAutoFilterRow = true;
            }
        }
        // bắt sự kiện event của form khách hàng
        public void OnCMND(string cmnd)
        {
            if(!string.IsNullOrEmpty(cmnd))
            {
                var _customerNew = KhachHangBus.GetByCmnd(cmnd);
                if(_customerNew != null)
                {
                    grid_khachhang.Refresh();
                    grid_khachhang.Properties.DataSource = KhachHangBus.GetAll();
                    grid_khachhang.EditValue = _customerNew.MaKh;
                    textBoxSDT.Text = _customerNew.Sdt;
                    textBox_cmnd.Text = cmnd;
                    textBox_Diachi.Text = cmnd;
                }
            }
           // Commons.MessageInfo(cmnd);
        }
        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
        // init form
        private void ClearForm()
        {
            grid_khachhang.EditValue = null;
            dateEditCreate.EditValue = null;
            dateEditDaoHan.EditValue = null;
            txtTienGui.Text = string.Empty;
            //gridLookUpEditLoaiTien.EditValue = null;
        }
        // Nạp load form
        private void toolStripbtn_reload_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        // tạo mới form
        private void toolStripbtn_create_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // focus RowChange
        private void gridView_SoTietKiem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            _soTietKiemDTO = (SoTietKiem_DTO)gridView_SoTietKiem.GetRow(e.FocusedRowHandle);
        }
        #region Event change
        // event change Khách hàng
        private void grid_khachhang_EditValueChanged(object sender, EventArgs e)
        {
            if (grid_khachhang.EditValue != null)
            {
                int id = int.Parse(grid_khachhang.EditValue.ToString());
                var _khachang = KhachHangBus.GetById(id);
                if (_khachang != null)
                {
                    textBox_cmnd.Text = _khachang.Cmnd;
                    textBoxSDT.Text = _khachang.Sdt;
                    textBox_Diachi.Text = _khachang.DiaChi;
                }
            }
        }
        // event change gridLookUpEditKyHan
        private void gridLookUpEditKyhan_EditValueChanged(object sender, EventArgs e)
        {
            int id = int.Parse(gridLookUpEditKyhan.EditValue.ToString());
            var _kyhan = KyHanVayBus.GetById(id);
            if (_kyhan != null)
            {
                textBox_LaiXuat.Text = _kyhan.LaiSuat.ToString();
                dateEditCreate.DateTime = DateTime.Now;
                dateEditDaoHan.DateTime = _kyhan.SoThang == 0 ? DateTime.Now.AddYears(1) : DateTime.Now.AddMonths(_kyhan.SoThang);
            }
        }
        #endregion

        /// <summary>
        /// button thêm một kỳ hạn mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                SoTietKiemDto soTietKiem = new SoTietKiemDto()
                {
                    NgayMo = dateEditCreate.DateTime,
                    NgayHieuLuc = DateTime.Now,
                    NgayDenHan = dateEditDaoHan.DateTime,
                    SoTienGui = Convert.ToDouble(txtTienGui.Text),
                    MaKyHan = Convert.ToInt32(gridLookUpEditKyhan.EditValue),
                    MaLoaiTien = Convert.ToInt32(gridLookUpEditLoaiTien.EditValue),
                    MaNV = Extensions.GetMANV(),
                    MaKhachHang = Convert.ToInt32(grid_khachhang.EditValue)
                };
                try
                {
                    if (SoTietKiemBus.Add(soTietKiem))
                    {
                        this.MoSoTietKiemControl_Load(sender, e);
                        Commons.MessageInfo("Thêm sổ tiết kiệm thành công!");
                        return;
                    }
                    else
                    {
                        Commons.MessageErr("Đã có lỗi xảy ra, vui lòng thử lại");
                        return;
                    }
           
                }
                catch (Exception ex)
                {
                    Commons.MessageErr("Đã có lỗi xảy ra, vui lòng thử lại");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                this.MoSoTietKiemControl_Load(sender, e);
                return;
            }
        }

        private void txtTienGui_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if((sender as TextBox).Text.Length > 10 || (sender as TextBox).Text.IndexOf('-') > 1)
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Kiểm tra form 
        /// </summary>
        /// <returns></returns>
        private bool Validation()
        {
            if (dateEditCreate.DateTime == null || dateEditDaoHan.DateTime == null || txtTienGui.Text == null ||
                (grid_khachhang.EditValue == null && String.IsNullOrEmpty(grid_khachhang.EditValue.ToString())) ||
                (gridLookUpEditKyhan.EditValue == null && String.IsNullOrEmpty(gridLookUpEditKyhan.EditValue.ToString())) ||
                (gridLookUpEditLoaiTien.EditValue == null && String.IsNullOrEmpty(gridLookUpEditLoaiTien.EditValue.ToString())))
            {
                return false;
            }
            return true;
        }
        // xuất ra phiếu gửi tiền
        private void btn_phieuguitien_Click(object sender, EventArgs e)
        {
            PhieuGuiTien phieuChi = new PhieuGuiTien();
            ReportPrintTool reportPrintTool = new ReportPrintTool(phieuChi);
            UserLookAndFeel userLookAndFeel = new UserLookAndFeel(this);
            userLookAndFeel.UseDefaultLookAndFeel = false;
            userLookAndFeel.SkinName = "Office 2016 colorful";
            reportPrintTool.ShowRibbonPreviewDialog(userLookAndFeel);
        }
        // event row click
        private void gridView_SoTietKiem_Click(object sender, EventArgs e)
        {
            if (gridView_SoTietKiem.GetFocusedRowCellValue("MaSTK") != null)
            {
                var _maSoTietKiem = int.Parse(gridView_SoTietKiem.GetFocusedRowCellValue("MaSTK").ToString());
                SoTietKiem_DTO _soTietKiem = SoTietKiemBus.GetById(_maSoTietKiem);
                textBox_masotk.Text = _soTietKiem.MaSTK.ToString();
                dateEditCreate.DateTime = _soTietKiem.NgayHieuLuc;
                dateEditDaoHan.DateTime = _soTietKiem.NgayDenHan;
                txtTienGui.Text = _soTietKiem.SoTienGui.ToString();
                grid_khachhang.EditValue = _soTietKiem.MaKh;
                var kyhan = KyHanVayBus.GetById(_soTietKiem.MaKyHan);
                gridLookUpEditKyhan.EditValue = kyhan.MaKyHan;
                textBox_LaiXuat.Text = kyhan.LaiSuat.ToString();
                var tienTe = LoaiTienBus.GetById(_soTietKiem.TienTe);
                gridLookUpEditLoaiTien.EditValue = tienTe.MaLoaiTien;
            }
        }
        // event change textbox
        private void textBox_masotk_TextChanged(object sender, EventArgs e)
        {
            toolStripButton_suadoi.Visible = string.IsNullOrEmpty(textBox_masotk.Text) ? false : true;
        }
        // click lưu khi thay đổi
        private void toolStripButton_suadoi_Click(object sender, EventArgs e)
        {
            var mstk = textBox_masotk.Text;
            if (Validation() && mstk !=null)
            {
                SoTietKiemDto soTietKiem = new SoTietKiemDto()
                {
                    NgayMo = dateEditCreate.DateTime,
                    NgayHieuLuc = DateTime.Now,
                    NgayDenHan = dateEditDaoHan.DateTime,
                    SoTienGui = Convert.ToDouble(txtTienGui.Text),
                    MaKyHan = Convert.ToInt32(gridLookUpEditKyhan.EditValue),
                    MaLoaiTien = Convert.ToInt32(gridLookUpEditLoaiTien.EditValue),
                    MaNV = Extensions.GetMANV(),
                    MaKhachHang = Convert.ToInt32(grid_khachhang.EditValue),
                    MaSTK = int.Parse(mstk)
                };
                try
                {
                    if (SoTietKiemBus.Update(soTietKiem))
                    {
                        this.MoSoTietKiemControl_Load(sender, e);
                        Commons.MessageInfo("Sửa sổ tiết kiệm thành công!");
                        return;
                    }
                    else
                    {
                        Commons.MessageErr("Đã có lỗi xảy ra, vui lòng thử lại");
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Commons.MessageErr("Đã có lỗi xảy ra, vui lòng thử lại");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                this.MoSoTietKiemControl_Load(sender, e);
                return;
            }
        }
    }
}
