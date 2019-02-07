using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLSoTietKiem.DTO;
using QLSoTietKiem.Business;
using QLSoTK.Helpers;

namespace QLSoTK.HeThong
{
    public partial class frm_TaoTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        public frm_TaoTaiKhoan()
        {
            InitializeComponent();
        }
        private void frm_TaoTaiKhoan_Load(object sender, EventArgs e)
        {
            RenderForm();
            HideControlSupportPermission();
            HideControlSupportPaymentStore();
            HideControlSupportJobtitle();
            but_CreateStaff.Enabled = true;
            but_CreatePermission.Enabled = false;
            but_CreatePaymentStore.Enabled = false;
            but_CreateJobtitle.Enabled = false;
            //frm_TaoTaiKhoan.size
            this.ClientSize = new System.Drawing.Size(500, 240);
        }
        private void but_CreateStaff_Click(object sender, EventArgs e)
        {
            string out_Message = string.Empty;
            if (!isValidateCreateForm(out out_Message))
            {
                MessageBox.Show(out_Message, "Lỗi tạo nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Get data from form
                string nameStaff = txt_StaffName.Text;
                int jobtitleStaff = int.TryParse(cbo_StaffJobtitle.EditValue.ToString(), out jobtitleStaff) ? jobtitleStaff : 0;
                DateTime birthdayStaff = dtm_StaffBirthday.DateTime;
                bool genderStaff = bool.TryParse(cbo_StaffGender.EditValue.ToString(), out genderStaff) ? genderStaff : false;
                int permissionStaff = int.TryParse(gridLook_Permission.EditValue.ToString(), out permissionStaff) ? permissionStaff : 0;
                int paymentStoreStaff = int.TryParse(gridLook_PaymentStore.EditValue.ToString(), out paymentStoreStaff) ? paymentStoreStaff : 0;
                string shortNameStaff = Extensions.ConvertToUnSign(Extensions.GetShortName(nameStaff)).ToLower();
                string addressStaff = txt_StaffAddress.Text;
                string emailStaff = txt_StaffEmail.Text;
                string phoneNumberStaff = txt_StaffPhoneNumber.Text;

                //Call function create staff
                string msg_CreateStaff = string.Empty;
                NhanVienBus _nvBus = new NhanVienBus();
                if (!_nvBus.CreateStaffAndAccount(nameStaff, shortNameStaff, genderStaff, birthdayStaff, jobtitleStaff, paymentStoreStaff, permissionStaff, addressStaff, emailStaff, phoneNumberStaff, out msg_CreateStaff))
                {
                    MessageBox.Show(msg_CreateStaff, "Lỗi tạo nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show(msg_CreateStaff+ "\nBạn có muốn tạo tiếp nhân viên?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        RefreshForm();
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
        }
        private void frm_TaoTaiKhoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
        private void RenderForm()
        {
            List<PaymentStoreResult> lstPaymentStore = new List<PaymentStoreResult>();
            lstPaymentStore = QuayGiaoDichBUS.getDataSourcePaymentCombo();
            gridLook_PaymentStore.Properties.DataSource = lstPaymentStore;
            gridLook_PaymentStore.Properties.DisplayMember = "PaymentStoreName";
            gridLook_PaymentStore.Properties.ValueMember = "PaymentStoreCode";
            List<PermissionResult> lstPermission = new List<PermissionResult>();
            lstPermission = NhomTaiKhoanBus.Instance.GetAllPermission();
            gridLook_Permission.Properties.DataSource = lstPermission;
            gridLook_Permission.Properties.DisplayMember = "PermissionName";
            gridLook_Permission.Properties.ValueMember = "PermissionCode";
            List<GenderResult> lstGender = new List<GenderResult>();
            lstGender = NhomTaiKhoanBus.Instance.GetAllGender();
            cbo_StaffGender.Properties.DataSource = lstGender;
            cbo_StaffGender.Properties.DisplayMember = "GenderName";
            cbo_StaffGender.Properties.ValueMember = "GenderCode";
            List<ChucVuDto> lstJobtitle = new List<ChucVuDto>();
            NhanVienBus _nvBUS = new NhanVienBus();
            lstJobtitle = _nvBUS.GetAllJobtitle();
            cbo_StaffJobtitle.Properties.DataSource = lstJobtitle;
            cbo_StaffJobtitle.Properties.DisplayMember = "TenChucVu";
            cbo_StaffJobtitle.Properties.ValueMember = "MaChucVu";

        }
        private void RefreshForm()
        {
            txt_StaffName.Text = "";
            cbo_StaffJobtitle.EditValue = "";
            dtm_StaffBirthday.EditValue = DateTime.Now;
            cbo_StaffGender.EditValue = "";
            gridLook_Permission.EditValue = "";
            gridLook_PaymentStore.EditValue = "";
            txt_StaffAddress.Text = "";
            txt_StaffEmail.Text = "";
            txt_StaffPhoneNumber.Text = "";
        }
        private bool isValidateCreateForm(out string Message)
        {
            TimeSpan hieu = DateTime.Now - dtm_StaffBirthday.DateTime;
            if (string.IsNullOrEmpty(txt_StaffName.Text))
            {
                Message = "Họ tên nhân viên không được rỗng";
                return false;
            }
            else if (string.IsNullOrEmpty(cbo_StaffGender.EditValue.ToString()))
            {
                Message = "Giới tính nhân viên không được rỗng";
                return false;
            }
            else if (hieu.TotalDays < 6570)
            {
                Message = "Nhân viên tạo phải lớn hơn 18 tuổi";
                return false;
            }
            else if (string.IsNullOrEmpty(cbo_StaffJobtitle.EditValue.ToString()))
            {
                Message = "Chức vụ nhân viên không được rỗng";
                return false;
            }
            else if (string.IsNullOrEmpty(txt_StaffEmail.Text))
            {
                Message = "Email nhân viên không được rỗng";
                return false;
            }
            else if (!Extensions.IsValidEmail(txt_StaffEmail.Text))
            {
                Message = "Email nhân viên không hợp lệ";
                return false;
            }
            else if (string.IsNullOrEmpty(txt_StaffPhoneNumber.Text))
            {
                Message = "Số điện thoại nhân viên không được rỗng";
                return false;
            }
            else if (Extensions.IsValidPhone(txt_StaffPhoneNumber.Text))
            {
                Message = "Số điện thoại nhân viên không hợp lệ";
                return false;
            }
            else if (string.IsNullOrEmpty(gridLook_Permission.EditValue.ToString()))
            {
                Message = "Chi nhánh làm việc nhân viên không hợp lệ";
                return false;
            }
            else if (string.IsNullOrEmpty(gridLook_PaymentStore.EditValue.ToString()))
            {
                Message = "Nhóm quyền nhân viên không hợp lệ";
                return false;
            }
            else
            {
                Message = "";
                return true;
            }
        }

        private void gridLook_PaymentStore_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                HideControlSupportPermission();
                HideControlSupportJobtitle();
                ShowControlSupportPaymentStore();
                but_CreateStaff.Enabled = false;
                but_CreatePermission.Enabled = false;
                but_CreatePaymentStore.Enabled = true;
                but_CreateJobtitle.Enabled = true;
                this.ClientSize = new System.Drawing.Size(950, 240);
            }
        }
        private void gridLook_Permission_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                HideControlSupportPaymentStore();
                HideControlSupportJobtitle();
                ShowControlSupportPermission();
                but_CreateStaff.Enabled = false;
                but_CreatePermission.Enabled = true;
                but_CreatePaymentStore.Enabled = false;
                but_CreateJobtitle.Enabled = true;
                this.ClientSize = new System.Drawing.Size(950, 240);
            }
        }
        private void cbo_StaffJobtitle_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {               
                HideControlSupportPaymentStore();
                HideControlSupportPermission();
                ShowControlSupportJobtitle();
                but_CreateStaff.Enabled = false;
                but_CreatePermission.Enabled = false;
                but_CreatePaymentStore.Enabled = false;
                but_CreateJobtitle.Enabled = true;
                this.ClientSize = new System.Drawing.Size(950, 240);
            }
        }

        private void but_CreatePermission_Click(object sender, EventArgs e)
        {
            NhomTaiKhoanDto _ntkDTO = new NhomTaiKhoanDto();
            _ntkDTO.TenNhom = txt_PermissionName.Text;
            _ntkDTO.TrangThai = true;
            NhomTaiKhoanBus _ntkBUS = new NhomTaiKhoanBus();
            string _ntkMessage = string.Empty;
            if (!_ntkBUS.CreatePermission(_ntkDTO, out _ntkMessage))
            {
                MessageBox.Show(_ntkMessage, "Lỗi tạo nhóm quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show(_ntkMessage + "\nBạn có tiếp tục tạo nhóm quyền", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    txt_PermissionName.Text = "";
                }
                else if (dialogResult == DialogResult.No)
                {
                    RenderForm();
                    HideControlSupportPermission();
                    but_CreateStaff.Enabled = true;
                    but_CreatePermission.Enabled = false;
                    but_CreatePaymentStore.Enabled = false;
                    this.ClientSize = new System.Drawing.Size(500, 240);
                }
            }
        }
        private void but_CreatePaymentStore_Click(object sender, EventArgs e)
        {
            QuayGiaoDichDto _qgdDTO = new QuayGiaoDichDto();
            _qgdDTO.TenQuayGiaoDich = txt_PaymentStoreAddress.Text;
            _qgdDTO.DiaChi = txt_PaymentStoreName.Text;
            QuayGiaoDichBUS _qgdBUS = new QuayGiaoDichBUS();
            string _qgdMessage = string.Empty;
            if (!_qgdBUS.CreatePaymentStore(_qgdDTO, out _qgdMessage))
            {
                MessageBox.Show(_qgdMessage, "Lỗi tạo chi nhánh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show(_qgdMessage + "\nBạn có tiếp tục tạo chi nhánh", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    txt_PaymentStoreAddress.Text = "";
                    txt_PaymentStoreName.Text = "";
                }
                else if (dialogResult == DialogResult.No)
                {
                    RenderForm();
                    HideControlSupportPaymentStore();
                    but_CreateStaff.Enabled = true;
                    but_CreatePermission.Enabled = false;
                    but_CreatePaymentStore.Enabled = false;
                    this.ClientSize = new System.Drawing.Size(500, 240);
                }
            }
        }
        private void but_CreateJobtitle_Click(object sender, EventArgs e)
        {
            ChucVuDto _cvdDTO = new ChucVuDto();
            _cvdDTO.TenChucVu = txt_JobtitleName.Text;
            _cvdDTO.TrangThai = true;
            NhanVienBus _nvBUS = new NhanVienBus();
            string _qgdMessage = string.Empty;
            if (!_nvBUS.CreateJobtitle(_cvdDTO, out _qgdMessage))
            {
                MessageBox.Show(_qgdMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show(_qgdMessage + "\nBạn có tiếp tục tạo chức vụ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    txt_JobtitleName.Text = "";
                }
                else if (dialogResult == DialogResult.No)
                {
                    RenderForm();
                    HideControlSupportJobtitle();
                    but_CreateStaff.Enabled = true;
                    but_CreatePermission.Enabled = false;
                    but_CreatePaymentStore.Enabled = false;
                    but_CreateJobtitle.Enabled = false;
                    this.ClientSize = new System.Drawing.Size(500, 240);
                }
            }
        }

        private void HideControlSupportPermission()
        {
            layoutControlItem_PermissionName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem18.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem_lbl1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }
        private void HideControlSupportPaymentStore()
        {
            layoutControlItem_PaymentStoreName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem_PaymentStoreAddress.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem_lbl1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem16.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem_lbl1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }
        private void HideControlSupportJobtitle()
        {
            layoutControlItem_Jobtitle.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem_lbl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem_lbl1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

        }

        private void ShowControlSupportPermission()
        {
            layoutControlItem_PermissionName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem18.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem_lbl1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

        }
        private void ShowControlSupportPaymentStore()
        {
            layoutControlItem_PaymentStoreName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem_PaymentStoreAddress.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem_lbl1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem16.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem_lbl1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }
        private void ShowControlSupportJobtitle()
        {
            layoutControlItem_Jobtitle.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem_lbl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem_lbl1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void but_HideSupport_Click(object sender, EventArgs e)
        {
            HideControlSupportJobtitle();
            HideControlSupportPaymentStore();
            HideControlSupportPermission();
            this.ClientSize = new System.Drawing.Size(500, 240);
        }
    }
}