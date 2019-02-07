using QLSoTietKiem.Business;
using QLSoTietKiem.DTO.Model;
using QLSoTK.Helpers;
using QLSoTK.HeThong;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace QLSoTK.DanhMuc
{
    public partial class NhanVien : DevExpress.XtraEditors.XtraUserControl
    {
        public NhanVien()
        {
            InitializeComponent();
            RenderForm();
        }
        private void but_StaffSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void but_StaffCreate_Click(object sender, EventArgs e)
        {
            frm_TaoTaiKhoan _frm = new frm_TaoTaiKhoan();
            _frm.ShowDialog();
        }
        private void but_StaffUpdate_Click(object sender, EventArgs e)
        {
            string Message = string.Empty;
            if (!isValidateUpdateStaff(out Message))
            {
                MessageBox.Show(Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                StaffUpdateModel _staffUpdateInfo = new StaffUpdateModel();
                List<StaffUpdateModel> _lstStaffUpdateInfo = new List<StaffUpdateModel>();
                for (int i = 0; i < gridView_StaffInfo.SelectedRowsCount; i++)
                {
                    int handle = Convert.ToInt32(gridView_StaffInfo.GetRowHandle(gridView_StaffInfo.GetSelectedRows()[i]));
                    _staffUpdateInfo.StaffCode = gridView_StaffInfo.GetRowCellValue(handle, "StaffCode") != null ? Convert.ToInt32(gridView_StaffInfo.GetRowCellValue(handle, "StaffCode").ToString()) : 0;
                    _staffUpdateInfo.StaffName = gridView_StaffInfo.GetRowCellValue(handle, "StaffName") != null ? gridView_StaffInfo.GetRowCellValue(handle, "StaffName").ToString() : "";
                    _staffUpdateInfo.StaffGender = gridView_StaffInfo.GetRowCellValue(handle, "StaffGender") != null ?Convert.ToBoolean(gridView_StaffInfo.GetRowCellValue(handle, "StaffGender").ToString()) : false;
                    _staffUpdateInfo.StaffBirthday = gridView_StaffInfo.GetRowCellValue(handle, "StaffBirthday") != null ? Convert.ToDateTime(gridView_StaffInfo.GetRowCellValue(handle, "StaffBirthday").ToString()) : DateTime.Now;
                    _staffUpdateInfo.StaffEmail = gridView_StaffInfo.GetRowCellValue(handle, "StaffEmail") != null ? gridView_StaffInfo.GetRowCellValue(handle, "StaffEmail").ToString() : "";
                    _staffUpdateInfo.StaffPhoneNumber = gridView_StaffInfo.GetRowCellValue(handle, "StaffPhoneNumber") != null ? gridView_StaffInfo.GetRowCellValue(handle, "StaffPhoneNumber").ToString() : "";
                    _staffUpdateInfo.StaffAddress = gridView_StaffInfo.GetRowCellValue(handle, "StaffAddress") != null ? gridView_StaffInfo.GetRowCellValue(handle, "StaffAddress").ToString() : "";
                    _staffUpdateInfo.StaffJobtitle = gridView_StaffInfo.GetRowCellValue(handle, "StaffJobtitle") != null ? Convert.ToInt32(gridView_StaffInfo.GetRowCellValue(handle, "StaffJobtitle").ToString()) : 0;
                    _staffUpdateInfo.StaffPaymentStore = gridView_StaffInfo.GetRowCellValue(handle, "StaffPaymentStore") != null ?Convert.ToInt32(gridView_StaffInfo.GetRowCellValue(handle, "StaffPaymentStore").ToString()) : 0;
                    _staffUpdateInfo.StaffPermission = gridView_StaffInfo.GetRowCellValue(handle, "StaffPermission") != null ? Convert.ToInt32(gridView_StaffInfo.GetRowCellValue(handle, "StaffPermission").ToString()) : 0;
                    _lstStaffUpdateInfo.Add(_staffUpdateInfo);
                }
                NhanVienBus _nhaVienBUS = new NhanVienBus();
                string updateMessage = string.Empty;
                if (!_nhaVienBUS.UpdateStaff(_lstStaffUpdateInfo, out updateMessage))
                {
                    MessageBox.Show(updateMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(updateMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Search();
                }
            }
        }
        private void but_DeleteStaff_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string Message = string.Empty;
            if (!isValidateDeleteStaff(out Message))
            {
                MessageBox.Show(Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int handle = Convert.ToInt32(gridView_StaffInfo.GetFocusedRowCellValue("StaffCode"));
                NhanVienBus _nhaVienBUS = new NhanVienBus();
                string deleteMessage = string.Empty;
                if (!_nhaVienBUS.DeleteStaff(handle, out deleteMessage))
                {
                    MessageBox.Show(deleteMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(deleteMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Search();
                }
            }
        }
        private void gridView_Staff_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }
        private void RenderForm()
        {
            List<PaymentStoreResult> lstPaymentStore = new List<PaymentStoreResult>();
            lstPaymentStore = QuayGiaoDichBUS.getDataSourcePaymentCombo();
            cbo_PaymentStore.Properties.DataSource = lstPaymentStore;
            cbo_PaymentStore.Properties.DisplayMember = "PaymentStoreName";
            cbo_PaymentStore.Properties.ValueMember = "PaymentStoreCode";
            List<GenderResult> lstGender = new List<GenderResult>();
            lstGender = NhomTaiKhoanBus.Instance.GetAllGender();
            cbo_StaffGender.Properties.DataSource = lstGender;
            cbo_StaffGender.Properties.DisplayMember = "GenderName";
            cbo_StaffGender.Properties.ValueMember = "GenderCode";
        }
        private void BindingGrid()
        {
            List<PaymentStoreResult> lstPaymentStore = new List<PaymentStoreResult>();
            lstPaymentStore = QuayGiaoDichBUS.getDataSourcePaymentCombo();
            cbo_StaffPaymentStore_Grid.DataSource = lstPaymentStore;
            cbo_StaffPaymentStore_Grid.DisplayMember = "PaymentStoreName";
            cbo_StaffPaymentStore_Grid.ValueMember = "PaymentStoreCode";
            List<PermissionResult> lstPermission = new List<PermissionResult>();
            lstPermission = NhomTaiKhoanBus.Instance.GetAllPermission();
            cbo_StaffPermission_Grid.DataSource = lstPermission;
            cbo_StaffPermission_Grid.DisplayMember = "PermissionName";
            cbo_StaffPermission_Grid.ValueMember = "PermissionCode";
            List<GenderResult> lstGender = new List<GenderResult>();
            lstGender = NhomTaiKhoanBus.Instance.GetAllGender();
            cbo_StaffGender_Grid.DataSource = lstGender;
            cbo_StaffGender_Grid.DisplayMember = "GenderName";
            cbo_StaffGender_Grid.ValueMember = "GenderCode";
        }
        private bool isValidateSearchStaff(out string Message)
        {
            Message = "";
            return true;
        }
        private bool isValidateUpdateStaff(out string Message)
        {
            StaffUpdateModel _staffUpdateInfo = new StaffUpdateModel();
            List<StaffUpdateModel> _lstStaffUpdateInfo = new List<StaffUpdateModel>();
            List<string> lstBirthday = new List<string>();//
            List<string> lstEmail = new List<string>();//
            List<string> lstPhoneNumber = new List<string>();//
            List<string> lstBranch = new List<string>();//
            List<string> lstPermission = new List<string>();
            List<string> lstName = new List<string>();

            for (int i = 0; i < gridView_StaffInfo.SelectedRowsCount; i++)
            {
                int handle = Convert.ToInt32(gridView_StaffInfo.GetRowHandle(gridView_StaffInfo.GetSelectedRows()[i]));
                _staffUpdateInfo.StaffCode = gridView_StaffInfo.GetRowCellValue(handle, "StaffCode") != null ? Convert.ToInt32(gridView_StaffInfo.GetRowCellValue(handle, "StaffCode").ToString()) : 0;
                _staffUpdateInfo.StaffName = gridView_StaffInfo.GetRowCellValue(handle, "StaffName") != null ? gridView_StaffInfo.GetRowCellValue(handle, "StaffName").ToString() : "";
                _staffUpdateInfo.StaffGender = gridView_StaffInfo.GetRowCellValue(handle, "StaffGender") != null ? Convert.ToBoolean(gridView_StaffInfo.GetRowCellValue(handle, "StaffGender").ToString()) : false;
                _staffUpdateInfo.StaffBirthday = gridView_StaffInfo.GetRowCellValue(handle, "StaffBirthday") != null ? Convert.ToDateTime(gridView_StaffInfo.GetRowCellValue(handle, "StaffBirthday").ToString()) : DateTime.Now;
                _staffUpdateInfo.StaffEmail = gridView_StaffInfo.GetRowCellValue(handle, "StaffEmail") != null ? gridView_StaffInfo.GetRowCellValue(handle, "StaffEmail").ToString() : "";
                _staffUpdateInfo.StaffPhoneNumber = gridView_StaffInfo.GetRowCellValue(handle, "StaffPhoneNumber") != null ? gridView_StaffInfo.GetRowCellValue(handle, "StaffPhoneNumber").ToString() : "";
                _staffUpdateInfo.StaffAddress = gridView_StaffInfo.GetRowCellValue(handle, "StaffAddress") != null ? gridView_StaffInfo.GetRowCellValue(handle, "StaffAddress").ToString() : "";
                _staffUpdateInfo.StaffJobtitle = gridView_StaffInfo.GetRowCellValue(handle, "StaffJobtitle") != null ? Convert.ToInt32(gridView_StaffInfo.GetRowCellValue(handle, "StaffJobtitle").ToString()) : 0;
                _staffUpdateInfo.StaffPaymentStore = gridView_StaffInfo.GetRowCellValue(handle, "StaffPaymentStore") != null ? Convert.ToInt32(gridView_StaffInfo.GetRowCellValue(handle, "StaffPaymentStore").ToString()) : 0;
                _staffUpdateInfo.StaffPermission = gridView_StaffInfo.GetRowCellValue(handle, "StaffPermission") != null ? Convert.ToInt32(gridView_StaffInfo.GetRowCellValue(handle, "StaffPermission").ToString()) : 0;
                TimeSpan hieu = DateTime.Now - _staffUpdateInfo.StaffBirthday;
                if (hieu.TotalDays < 6570)
                {
                    lstBirthday.Add(_staffUpdateInfo.StaffName);
                }
                if (!Extensions.IsValidEmail(_staffUpdateInfo.StaffEmail))
                {
                    lstEmail.Add(_staffUpdateInfo.StaffName);
                }
                if (Extensions.IsValidPhone(_staffUpdateInfo.StaffPhoneNumber))
                {
                    lstPhoneNumber.Add(_staffUpdateInfo.StaffName);
                }
                if (_staffUpdateInfo.StaffPaymentStore == 0)
                {
                    lstBranch.Add(_staffUpdateInfo.StaffName);
                }
                if (_staffUpdateInfo.StaffPermission == 0)
                {
                    lstPermission.Add(_staffUpdateInfo.StaffName);
                }
                if (string.IsNullOrEmpty(_staffUpdateInfo.StaffName))
                {
                    lstName.Add(_staffUpdateInfo.StaffCode.ToString());
                }
                _lstStaffUpdateInfo.Add(_staffUpdateInfo);
            }
            if (_lstStaffUpdateInfo.Count == 0)
            {
                Message = "Vui lòng chọn dòng dữ liệu để cập nhật";
                return false;
            }
            else if (lstName.Count > 0)
            {
                Message = "Tên nhân viên không được rỗng. Vui lòng kiểm tra: \n" + String.Join("\n", lstName);
                return false;
            }
            else if (lstBirthday.Count > 0)
            {
                Message = "Ngày sinh của nhân viên nhỏ hơn 18 tuổi. Vui lòng kiểm tra: \n" + String.Join("\n", lstBirthday);
                return false;
            }
            else if (lstEmail.Count > 0)
            {
                Message = "Email của nhân viên không hợp lệ. Vui lòng kiểm tra: \n" + String.Join("\n", lstEmail);
                return false;
            }
            else if (lstPhoneNumber.Count > 0)
            {
                Message = "Số điện thoại của nhân viên không hợp lệ. Vui lòng kiểm tra: \n" + String.Join("\n", lstPhoneNumber);
                return false;
            }
            else if (lstBranch.Count > 0)
            {
                Message = "Chi nhánh của nhân viên không hợp lệ. Vui lòng kiểm tra: \n" + String.Join("\n", lstBranch);
                return false;
            }
            else if (lstPermission.Count > 0)
            {
                Message = "Nhóm quyền của nhân viên không hợp lệ. Vui lòng kiểm tra: \n" + String.Join("\n", lstPermission);
                return false;
            }
            else
            {
                Message = "";
                return true;
            }
        }
        private bool isValidateDeleteStaff(out string Message)
        {
            Message = "";
            return true;
        }
        //Main function
        private void Search()
        {
            string _tenNhanVien = txt_StaffName.Text;
            string _email = txt_StaffEmail.Text;
            bool _gender = cbo_StaffGender.EditValue != null ? Convert.ToBoolean(cbo_StaffGender.EditValue) : false;
            DateTime _birthday = DateTime.ParseExact(dtm_StaffBirthday.DateTime.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime _birthdayT = DateTime.ParseExact(dtm_StaffBirthdayT.DateTime.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string _phoneNumber = txt_StaffPhoneNumber.Text;
            int _quayGiaoDich = int.TryParse(cbo_PaymentStore.EditValue.ToString(), out _quayGiaoDich) ? _quayGiaoDich : 0;
            NhanVienBus _nv_BUS = new NhanVienBus();
            List<StaffManager_DTO> _lstStaffManager = new List<StaffManager_DTO>();
            _lstStaffManager = _nv_BUS.ReadListStaff(_tenNhanVien, _email, _gender, _birthday, _birthdayT, _phoneNumber, _quayGiaoDich);
            if (_lstStaffManager == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên nào thõa điều kiện tìm kiếm!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tìm thấy " + _lstStaffManager.Count.ToString() + " kết quả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridControl_StaffInfo.DataSource = _lstStaffManager;
                BindingGrid();
            }
        }
    }
}
