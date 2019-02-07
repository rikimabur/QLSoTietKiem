using QLSoTietKiem.Business;
using QLSoTietKiem.DTO;
using QLSoTK.Helpers;
using QLSoTK.Login;
using System;
using System.Windows.Forms;
namespace QLSoTK.HeThong
{
    public partial class frm_DoiMatKhau_HeThong : Form
    {
        public static TaiKhoanDto _loginTaiKhoan = null;
        public delegate TaiKhoanDto AccountFromMainDelegate();// Receive info user login from MainForm
        public delegate TaiKhoanDto AccountFromLoginDelegate();// Receive info user login from LoginForm
        public frm_DoiMatKhau_HeThong()
        {
            InitializeComponent();
        }       
        private void frm_DoiMatKhau_HeThong_Load(object sender, EventArgs e)
        {
            _loginTaiKhoan = getDataChangePasswordFormFromMainForm != null ? getDataChangePasswordFormFromMainForm() : getDataChangePasswordFormFromLoginForm();
            Form activeForm = frmLogin.ActiveForm;
            if (activeForm != null && activeForm.Name.ToString() == "frmLogin")
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
                frmLogin.ActiveForm.Close();
            }
        }               
        private void but_ConfirmChangePass_Click(object sender, EventArgs e)
        {
            TaiKhoanBus _tkBUS = new TaiKhoanBus();
            #region "Check valid front end"
            string l_PasswordOld = Extensions.EncryptMD5(txt_passwordOld.Text, true).Trim();
            string l_PasswordNew = Extensions.EncryptMD5(txt_passwordNew.Text, true).Trim();
            string l_PasswordRe = Extensions.EncryptMD5(txt_PasswordRe.Text, true).Trim();
            string ErrorValidPassword = string.Empty;
            if (string.IsNullOrEmpty(l_PasswordOld) || string.IsNullOrEmpty(l_PasswordNew) || string.IsNullOrEmpty(l_PasswordRe))
            {
                DialogResult dialogResult = MessageBox.Show("Thông tin nhập vào không được rỗng!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(l_PasswordOld))
                    {
                        txt_passwordOld.Focus();
                    }
                    if (string.IsNullOrEmpty(l_PasswordNew))
                    {
                        txt_passwordNew.Focus();
                    }
                    if (string.IsNullOrEmpty(l_PasswordRe))
                    {
                        txt_PasswordRe.Focus();
                    }

                    if (string.IsNullOrEmpty(l_PasswordOld) && string.IsNullOrEmpty(l_PasswordNew) && string.IsNullOrEmpty(l_PasswordRe))
                    {
                        txt_passwordOld.Focus();
                    }
                }
            }
            #endregion
            else if (l_PasswordNew != l_PasswordRe)
            {
                MessageBox.Show("Mật khẩu nhập lại không trùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Extensions.IsValidPassword(txt_passwordNew.Text, out ErrorValidPassword) == false)
            {
                MessageBox.Show(ErrorValidPassword, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_passwordNew.Focus();
            }
            else
            {
                int result = _tkBUS.ChangePassWord(_loginTaiKhoan.MaNhanVien, l_PasswordOld, l_PasswordNew);
                if (result == 0)
                {
                    MessageBox.Show("Sai mật khẩu cũ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_passwordOld.Focus();
                }
                else if (result == 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.OK && getDataChangePasswordFormFromLoginForm != null)
                    {
                        this.Hide();
                        frm_main _frmMain = new frm_main();
                        _frmMain.accountLoginOrchangePasswordDelegate += delegate { return _loginTaiKhoan; };//Set data from form change password
                        _frmMain.Show();
                    }
                    else if (dialogResult == DialogResult.OK && getDataChangePasswordFormFromMainForm != null)
                    {
                        this.Dispose();
                    }
                }
                else if (result == 2)
                {
                    MessageBox.Show("Có lỗi trong quá trình đổi mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_passwordOld.Focus();
                }
            }
        }
        private void but_Exit_Click(object sender, EventArgs e)
        {
            if (getDataChangePasswordFormFromMainForm != null)
                this.Dispose();
            else
                Application.Exit();
        }
        private void frm_DoiMatKhau_HeThong_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (getDataChangePasswordFormFromMainForm != null)
                this.Dispose();
            else
                Application.Exit();
        }
        public AccountFromMainDelegate getDataChangePasswordFormFromMainForm;// Receive info user login from MainForm
        public AccountFromLoginDelegate getDataChangePasswordFormFromLoginForm;// Receive info user login from LoginForm
    }
}
