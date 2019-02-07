using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSoTietKiem.Business;
using QLSoTietKiem.DTO;
using System.Globalization;

namespace QLSoTK.DanhMuc
{
    public partial class Khachhang : DevExpress.XtraEditors.XtraUserControl
    {
        public Khachhang()
        {
            InitializeComponent();
            RenderForm();
        }

        private void but_CustCreate_Click(object sender, EventArgs e)
        {
            string outMessage = string.Empty;
            if (!isValidateCreateCust(out outMessage))
            {
                MessageBox.Show(outMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                KhachHangDto _khDTO = new KhachHangDto();
                KhachHangBus _khBUS = new KhachHangBus();
                string khMessage = string.Empty;
                if (!_khBUS.CreateNewCust(_khDTO, out khMessage))
                {
                    MessageBox.Show(outMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(outMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshForm();
                }
            }
        }

        private void but_CustUpdate_Click(object sender, EventArgs e)
        {
            string outMessage = string.Empty;
            if (gridView_CustInfo.SelectedRowsCount == 0)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu để thao tác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!isValidateCreateCust(out outMessage))
            {
                MessageBox.Show(outMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                List<KhachHangDto> _lstkhDTO = new List<KhachHangDto>();
                KhachHangBus _khBUS = new KhachHangBus();
                string khMessage = string.Empty;
                if (!_khBUS.UpdateCust(_lstkhDTO, out khMessage))
                {
                    MessageBox.Show(outMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(outMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshForm();
                }
            }
        }

        private void but_DeleteCust_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string outMessage = string.Empty;
            if (gridView_CustInfo.SelectedRowsCount == 0)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu để thao tác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(!isValidateCreateCust(out outMessage))
            {
                MessageBox.Show(outMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                KhachHangDto _khDTO = new KhachHangDto();
                KhachHangBus _khBUS = new KhachHangBus();
                string khMessage = string.Empty;
                if (!_khBUS.DeleteCust(_khDTO.MaKh, out khMessage))
                {
                    MessageBox.Show(outMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(outMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshForm();
                }
            }
        }

        private void but_CustSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btn_OpenBook_Grid_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }
        private void RenderForm()
        {
            List<GenderResult> lstGender = new List<GenderResult>();
            lstGender = NhomTaiKhoanBus.Instance.GetAllGender();
            cbo_CustGender.Properties.DataSource = lstGender;
            cbo_CustGender.Properties.DisplayMember = "GenderName";
            cbo_CustGender.Properties.ValueMember = "GenderCode";
        }
        private void RefreshForm()
        {
             txt_CustName.Text = "";
            txt_CustPhoneNumber.Text = "";
            txt_CustCMND.Text = "";
            cbo_CustGender.EditValue = "";
            dtm_CustBirthday.DateTime = DateTime.Now;
            dtm_CustTimeCreateCMDN.DateTime = DateTime.Now;
            txt_CustAddress.Text = "";
        }
        private void BindingGrid()
        {
            List<GenderResult> lstGender = new List<GenderResult>();
            lstGender = NhomTaiKhoanBus.Instance.GetAllGender();
            cbo_CustGender_Grid.DataSource = lstGender;
            cbo_CustGender_Grid.DisplayMember = "GenderName";
            cbo_CustGender_Grid.ValueMember = "GenderCode";
        }
        private bool isValidateSearchCust(out string Message)
        {
            Message = "";
            return true;
        }
        private bool isValidateCreateCust(out string Message)
        {
            string _tenKhachHang = txt_CustName.Text;
            string _soDienThoai = txt_CustPhoneNumber.Text;
            string _CMND = txt_CustCMND.Text;
            bool _gender = Convert.ToBoolean(cbo_CustGender.EditValue);
            TimeSpan hieuCMND = dtm_CustTimeCreateCMDN.DateTime - dtm_CustBirthday.DateTime;
            TimeSpan hieuNgaySinh = DateTime.Now - dtm_CustBirthday.DateTime;
            string _diachi = txt_CustAddress.Text;
            if (string.IsNullOrEmpty(_tenKhachHang))
            {
                Message = "Tên khách hàng không được rỗng";
                return false;
            }
            else if (string.IsNullOrEmpty(_CMND))
            {
                Message = "Số CMND của khách hàng không được rỗng";
                return false;
            }
            else if (string.IsNullOrEmpty(_soDienThoai))
            {
                Message = "Số điện thoại khách hàng không được rỗng";
                return false;
            }
            else if (string.IsNullOrEmpty(_diachi))
            {
                Message = "Địa chỉ khách hàng không được rỗng";
                return false;
            }
            else if (hieuCMND.TotalDays < 5475)
            {
                Message = "Ngày cấp chứng minh nhân dân không hợp lệ";
                return false;
            }
            else if (hieuNgaySinh.TotalDays < 6570)
            {
                Message = "Ngày sinh khách hàng không hợp lệ";
                return false;
            }
            else
            {
                Message = "";
                return true;
            }            
        }
        private bool isValidateUpdateCust(out string Message)
        {
            Message = "";
            return true;
        }
        private bool isValidateDeleteCust(out string Message)
        {
            Message = "";
            return true;
        }
        private void Search()
        {
            string _tenKhachHang = txt_CustName.Text;
            string _soDienThoai = txt_CustPhoneNumber.Text;
            string _CMND = txt_CustCMND.Text;
            bool _gender = cbo_CustGender.EditValue.ToString() != "" ? Convert.ToBoolean(cbo_CustGender.EditValue) : false;
            DateTime _birthday = DateTime.ParseExact(dtm_CustBirthday.DateTime.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime _timeCreateCMND = DateTime.ParseExact(dtm_CustTimeCreateCMDN.DateTime.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);

            string _diachi = txt_CustAddress.Text;
            KhachHangBus _Kh_BUS = new KhachHangBus();
            List<QLSoTietKiem.DTO.Model.CustManager_DTO> _lstCustManager = new List<QLSoTietKiem.DTO.Model.CustManager_DTO>();
            _lstCustManager = _Kh_BUS.ReadListCust(_tenKhachHang, _soDienThoai, _CMND, _gender, _birthday, _timeCreateCMND);
            if (_lstCustManager == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng nào thõa điều kiện tìm kiếm!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tìm thấy " + _lstCustManager.Count.ToString() + " kết quả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridControl_CustInfo.DataSource = _lstCustManager;
                BindingGrid();
            }
        }
    }
}
