using QLSoTietKiem.Business;
using QLSoTietKiem.DTO;
using QLSoTietKiem.Helpers;
using QLSoTK.Helpers;
using QLSoTK.HeThong;
using System;
using System.Windows.Forms;

namespace QLSoTK.Login
{
    public partial class frmLogin : Form
    {
        public static TaiKhoanDto _tkDto = null;
        public frmLogin()
        {
            InitializeComponent();
        }        
        private void Login()
        {
            string l_UserName = txt_UserName.Text.Trim();
            string en_Password = string.Empty;

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.userName) && Properties.Settings.Default.passWord == txt_Password.Text)
            {
                en_Password = Extensions.DecryptMD5(Properties.Settings.Default.passWord, true);
            }
            string l_Password = string.IsNullOrEmpty(en_Password) ? Extensions.EncryptMD5(txt_Password.Text,true).Trim(): Extensions.EncryptMD5(en_Password, true).Trim();
            
            if (string.IsNullOrEmpty(l_UserName) || string.IsNullOrEmpty(l_Password))
            {
                DialogResult dialogResult = MessageBox.Show("Tên đăng nhập hoặc mật khẩu không được trống!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(l_UserName))
                    {
                        txt_UserName.Focus();
                    }
                    if (string.IsNullOrEmpty(l_Password))
                    {
                        txt_Password.Focus();
                    }
                    if (string.IsNullOrEmpty(l_UserName) && string.IsNullOrEmpty(l_Password))
                    {
                        txt_UserName.Focus();
                    }
                }
            }
            else
            {
                try
                {
                    TaiKhoanBus _tk = new TaiKhoanBus();
                    var _login = _tk.Login(l_UserName,l_Password);
                    if (_login == null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Không lấy được thông tin đăng nhập!!!", "Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (string.IsNullOrEmpty(l_UserName))
                            {
                                txt_UserName.Focus();
                            }
                            if (string.IsNullOrEmpty(l_Password))
                            {
                                txt_Password.Focus();
                            }
                            if (string.IsNullOrEmpty(l_UserName) && string.IsNullOrEmpty(l_Password))
                            {
                                txt_UserName.Focus();
                            }
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            Application.Exit();
                        }
                    }
                    else {
                        _tkDto = _login;
                        NhanVienDto _nvDTO = new NhanVienDto();
                        NhanVienBus _nvBUS = new NhanVienBus();
                        _nvDTO =  _nvBUS.ReadStaff(_tkDto.MaNhanVien);
                        if (_nvDTO != null)
                        {
                            if (!_nvDTO.DoiMatKhau)
                            {
                                DialogResult dialogResult = MessageBox.Show("Vui lòng đổi mật khẩu cho lần đầu tiên đăng nhập", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    this.Hide();
                                    frm_DoiMatKhau_HeThong _frmChangPass = new frm_DoiMatKhau_HeThong();
                                    _frmChangPass.getDataChangePasswordFormFromLoginForm += delegate { return _login; };//set data from login form
                                    _frmChangPass.Show();
                                }
                                else if (dialogResult == DialogResult.No)
                                {
                                    Application.Exit();
                                }
                            }
                            else
                            {
                                this.Hide();
                                if (chkRememberUser.Checked)
                                {
                                    if (Properties.Settings.Default.userName != string.Empty)
                                    {
                                        Properties.Settings.Default.Upgrade();
                                        Properties.Settings.Default.userName = l_UserName;
                                        Properties.Settings.Default.passWord = l_Password;
                                        Properties.Settings.Default.is_Check = chkRememberUser.Checked;
                                        Properties.Settings.Default.Save();
                                    }
                                    else
                                    {
                                        Properties.Settings.Default.userName = l_UserName;
                                        Properties.Settings.Default.passWord = l_Password;
                                        Properties.Settings.Default.is_Check = chkRememberUser.Checked;
                                        Properties.Settings.Default.Save();
                                    }
                                }
                                else
                                {
                                    Properties.Settings.Default.Reset();
                                    Properties.Settings.Default.Save();
                                }
                                frm_main _frmMain = new frm_main();
                                _frmMain.accountLoginOrchangePasswordDelegate += delegate { return _login; };//Set data from form login
                                _frmMain.Show();
                            }
                        }
                        else
                        {
                            DialogResult dialogResult = MessageBox.Show("Vui lòng kiểm tra trạng thái nhân viên", "Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.Yes)
                            {
                                if (string.IsNullOrEmpty(l_UserName))
                                {
                                    txt_UserName.Focus();
                                }
                                if (string.IsNullOrEmpty(l_Password))
                                {
                                    txt_Password.Focus();
                                }
                                if (string.IsNullOrEmpty(l_UserName) && string.IsNullOrEmpty(l_Password))
                                {
                                    txt_UserName.Focus();
                                }
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                Application.Exit();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogError("Login Login", ex.ToString());
                    DialogResult dialogResult = MessageBox.Show("Vui lòng kiểm tra trạng thái nhận viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {
            try
            {                
                if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.userName))
                {
                    Properties.Settings.Default.Reload();
                    txt_UserName.Text = Properties.Settings.Default.userName.Trim();
                    txt_Password.Text = Properties.Settings.Default.passWord.Trim();
                    chkRememberUser.Checked = Properties.Settings.Default.is_Check;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void but_Login_Click(object sender, EventArgs e)
        {
            Login();
        }
        private void but_Exit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }
    }
}
