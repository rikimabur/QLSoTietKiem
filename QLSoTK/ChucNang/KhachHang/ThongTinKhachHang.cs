using QLSoTietKiem.Business;
using QLSoTietKiem.DTO;
using QLSoTK.Helpers;
using System;
using System.Windows.Forms;

namespace QLSoTK.ChucNang.KhachHang
{
    public partial class frm_khachhang : Form
    {
        // init dellegate 
        public delegate void _khachHangCmndHandel(string cmnd);
        public event _khachHangCmndHandel KhachHangCmndEvent;
        public frm_khachhang()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        // event close form
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // event save 
        private void simbtn_save_Click(object sender, EventArgs e)
        {
            if (!radio_gender.Checked && !radio_genderN.Checked)
            {
                Commons.MessageErr("Xin vui lòng chọn giới tính");
                return;
            }
            if (string.IsNullOrEmpty(txt_ten.Text))
            {
                Commons.MessageErr("Xin vui lòng nhập tên đầy đủ");
                txt_ten.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txt_sdt.Text))
            {
                Commons.MessageErr("Xin vui lòng nhập số điện thoại");
                txt_sdt.Focus();
                return;
            }
            if (Extensions.IsValidPhone(txt_sdt.Text) || txt_sdt.Text.Length > 12 || txt_sdt.Text.Length < 9)
            {
                Commons.MessageErr("Số điện thoại không hợp lệ");
                txt_sdt.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txt_cmnd.Text) && txt_cmnd.Text.Length > 12 || txt_cmnd.Text.Length < 9)
            {
                Commons.MessageErr("Vui lòng nhập số chứng minh nhân dân");
                txt_cmnd.Focus();
                return;
            }
            if (Extensions.IsNumber(txt_cmnd.Text))
            {
                Commons.MessageErr("Số chứng minh nhân không hợp lệ");
                txt_cmnd.Focus();
                return;
            }
            if (string.IsNullOrEmpty(mem_diachi.Text))
            {
                Commons.MessageErr("Vui lòng nhập địa chỉ");
                return;
            }
            if (string.IsNullOrEmpty(txt_ngaysinh.DateTime.ToString()))
            {
                Commons.MessageErr("Vui lòng chọn ngày sinh");
                return;
            }
            if (string.IsNullOrEmpty(dateEdit_ngaycap.DateTime.ToString()))
            {
                Commons.MessageErr("Vui lòng chọn ngày cấp của CMND");
                return;
            }

            // Độ tuổi khách hàng từ 15 tuổi trở lên
            int _age = DateTime.Now.Year - txt_ngaysinh.DateTime.Year;
            if (_age < 10 || _age > 120)
            {
                Commons.MessageErr("Ngày sinh không hợp lệ");
                return;
            }
            KhachHangDto customer = new KhachHangDto();
            //customer.MaKh = 1;
            customer.Hoten = txt_ten.Text;
            customer.Sdt = txt_sdt.Text;
            customer.Cmnd = txt_cmnd.Text;
            customer.DiaChi = mem_diachi.Text;
            customer.NgaySinh = txt_ngaysinh.DateTime;
            customer.TrangThai = 1;
            customer.NgayCap = dateEdit_ngaycap.DateTime;
            customer.GioiTinh = radio_gender.Checked ? true : false; // nam :true | nữ: false
            //OnCMND();
            string _message = KhachHangBus.Add(customer);
            if (string.IsNullOrEmpty(_message) && KhachHangCmndEvent != null)
            {
                KhachHangCmndEvent(txt_cmnd.Text);
            }
            else
            {
                Commons.MessageInfo(_message);
            }
            this.Close();
        }
        private void frm_khachhang_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        // key press CMND
        private void txt_cmnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            //TODO: check kerpress CMND
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        // key press SDT
        private void txt_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //TODO: check kerpress SDT
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        //protected virtual void OnCMND()
        //{
        //    if (KhachHangCmndEvent != null)
        //    {
        //        KhachHangCmndEvent(txt_cmnd.Text);
        //    }
        //}
    }
}
