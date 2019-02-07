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

namespace QLSoTK.HeThong
{
    public partial class frm_ThongTin : DevExpress.XtraEditors.XtraForm
    {
        public delegate TaiKhoanDto AccountFromMainDelegate();// Receive info user login from MainForm
        public static TaiKhoanDto _loginTaiKhoan = null;
        public frm_ThongTin()
        {
            InitializeComponent();
        }

        private void frm_ThongTin_Load(object sender, EventArgs e)
        {
            _loginTaiKhoan = getDataChangePasswordFormFromMainForm();
            NhanVienDto _nvDTO = new NhanVienDto();
            NhanVienBus _nvBUS = new NhanVienBus();
            _nvDTO = _nvBUS.ReadStaff(_loginTaiKhoan.MaNhanVien);
            txt_HoTen.Text = _nvDTO.TenNhanVien;
            txt_MaNhanVien.Text = _nvDTO.MaNV.ToString();
            txt_ChucVu.Text = _nvDTO.ChucVu.ToString();
            txt_NgaySinh.Text = _nvDTO.NgaySinh.ToString("dd/MM/yyyy hh:mm:ss");
            txt_Email.Text = _nvDTO.Email;
            txt_DiaChi.Text = _nvDTO.DiaChi;
        }
        public AccountFromMainDelegate getDataChangePasswordFormFromMainForm;// Receive info user login from MainForm
    }
}