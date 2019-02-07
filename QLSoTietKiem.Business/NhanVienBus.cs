using QLSoTietKiem.DAO;
using QLSoTietKiem.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace QLSoTietKiem.Business
{
    public class NhanVienBus
    {
        public bool CreateNewStaff(NhanVienDto _nhanVien)
        {
            return NhanVienDao.CreateNewStaff(_nhanVien);
        }
        public NhanVienDto ReadStaff(int maNhanVien)
        {
            return NhanVienDao.ReadSingleStaff(maNhanVien);
        }
        public bool UpdateStaff(List<DTO.Model.StaffUpdateModel> _nhanVien, out string Message)
        {
            if (!NhanVienDao.UpdateStaff(_nhanVien))
            {
                Message = "Có lỗi khi cập nhật nhân viên";
                return false;
            }
            else
            {
                Message = "Cập nhật nhân viên thành công";
                return true;
            }

        }
        public bool DeleteStaff(int maNhanVien, out string Message)
        {
            if (!NhanVienDao.DeleteStaff(maNhanVien))
            {
                Message = "Có lỗi trong quá trình xóa nhân viên";
                return false;
            }
            else
            {
                Message = "Xóa nhân viên thành công";
                return true;
            };
        }
        public bool CreateStaffAndAccount(string _staffName, string _staffShortName, bool _staffGender, DateTime _staffBirthday, int _staffJobtitle, int _staffPaymentStore, int _staffPermission, string _staffAddress, string _staffEmail, string _staffPhoneNumber, out string Message)
        {
            NhanVienDto _nhanVien = new NhanVienDto();
            _nhanVien.TenNhanVien = _staffName;
            _nhanVien.GioiTinh = _staffGender;
            _nhanVien.NgaySinh = _staffBirthday;
            _nhanVien.ChucVu = _staffJobtitle;
            _nhanVien.MaQGD = _staffPaymentStore;
            _nhanVien.DoiMatKhau = false;
            _nhanVien.TrangThai = true;
            _nhanVien.DiaChi = _staffAddress;
            _nhanVien.Email = _staffEmail;
            _nhanVien.SoDT = _staffPhoneNumber;

            if (CreateNewStaff(_nhanVien))
            {
                TaiKhoanDto _taiKhoan = new TaiKhoanDto();
                _taiKhoan.TenDangNhap = TaiKhoanDao.GetAccountName(_staffShortName);
                _taiKhoan.MatKhau = Helpers.EncryptMD5("123456a@", true);
                _taiKhoan.MaNhomTK = _staffPermission;
                _taiKhoan.MaNhanVien = _nhanVien.MaNV;
                _taiKhoan.TrangThai = true;
                TaiKhoanBus _tkBUS = new TaiKhoanBus();
                if (_tkBUS.CreateNewAccount(_taiKhoan))
                {
                    Message = "Tạo tài khoản thành công.\nVui lòng đăng nhập với tên: " + _taiKhoan.TenDangNhap;
                    return true;
                }
                else
                {
                    Message = "Có lỗi trong lúc tạo tài khoản cho nhân viên";
                    return false;
                }
            }
            else
            {
                Message = "Có lỗi trong quá trình tạo nhâ viên mới";
                return false;
            }
        }
        public List<DTO.Model.StaffManager_DTO> ReadListStaff(string _tenNhanVien, string _email, bool _gender, DateTime _birthday, DateTime _birthdayT, string _phoneNumber, int _quayGiaoDich)
        {
            return NhanVienDao.ReadListStaff(_tenNhanVien, _email, _gender, _birthday, _birthdayT, _phoneNumber, _quayGiaoDich);
        }
        public List<ChucVuDto> GetAllJobtitle()
        {
            return NhanVienDao.GetAllJobtitle();
        }
        public bool CreateJobtitle(ChucVuDto cvNhanVien, out string outMsg)
        {
            if (!NhanVienDao.CreateJobtitle(cvNhanVien))
            {
                outMsg = "Tạo chức vụ không thành công";
                return false;
            }
            else
            {
                outMsg = "Tạo chức vụ thành công";
                return true;
            }
        }
    }
}
