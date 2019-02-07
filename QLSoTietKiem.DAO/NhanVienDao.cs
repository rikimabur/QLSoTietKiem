using QLSoTietKiem.DAO.Helpers;
using QLSoTietKiem.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace QLSoTietKiem.DAO
{
    public class NhanVienDao
    {
        public static bool CreateNewStaff(NhanVienDto _nhanVien)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    ql.NhanVien.Add(_nhanVien);
                    ql.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogError("NhanVienDao CreateNewStaff", ex.ToString());
                return false;
            }
        }
        public static NhanVienDto ReadSingleStaff(int maNhanVien)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    return ql.NhanVien.FirstOrDefault(s => (s.MaNV == maNhanVien && s.TrangThai == true));
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogError("NhanVienDao UpdateStaff", ex.ToString());
                return null;
            }
        }
        public static bool UpdateStaff(List<DTO.Model.StaffUpdateModel> _nhanVien)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    int count = 0;
                    foreach(var item in _nhanVien)
                    {
                        var nhanVien = ql.NhanVien.FirstOrDefault(s => s.MaNV == item.StaffCode);
                        if (nhanVien != null)
                        {
                            nhanVien.TenNhanVien = item.StaffName;
                            nhanVien.NgaySinh = item.StaffBirthday;
                            nhanVien.GioiTinh = item.StaffGender;
                            nhanVien.ChucVu = item.StaffJobtitle;
                            nhanVien.MaQGD = item.StaffPaymentStore;
                            nhanVien.DiaChi = item.StaffAddress;
                            nhanVien.Email = item.StaffEmail;
                            nhanVien.SoDT = item.StaffPhoneNumber;
                            TaiKhoanDao.UpdateStaffPermission(item.StaffCode, item.StaffPermission);
                            ql.SaveChanges();
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogError("NhanVienDao UpdateStaff", ex.ToString());
                return false;
            }
        }
        public static bool DeleteStaff(int maNhanVien)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    var nhanVien = ql.NhanVien.FirstOrDefault(s => s.MaNV == maNhanVien);
                    nhanVien.TrangThai = false;
                    var taikhoan = ql.TaiKhoan.FirstOrDefault(s => s.MaNhanVien == maNhanVien);
                    taikhoan.TrangThai = false;
                    ql.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogError("NhanVienDao DeleteStaff", ex.ToString());
                return false;
            }
        }
        public static List<DTO.Model.StaffManager_DTO> ReadListStaff(string _tenNhanVien, string _email, bool _gender, DateTime _birthday, DateTime _birthdayT, string _phoneNumber, int _quayGiaoDich)
        {
            try
            {
                List<DTO.Model.StaffManager_DTO> lst_StaffManager = new List<DTO.Model.StaffManager_DTO>();
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    var query = ql.NhanVien
                        .Join(ql.TaiKhoan, nv => nv.MaNV, tk => tk.MaNhanVien,
                        (nv, tk) => new { nv.MaNV, nv.TenNhanVien, nv.GioiTinh, nv.NgaySinh, nv.Email, nv.SoDT, nv.DiaChi,nv.ChucVu, nv.MaQGD, tk.TenDangNhap, tk.MatKhau, tk.MaNhomTK, nv.TrangThai })
                        .Where(nv => (nv.TrangThai == true
                            && (string.IsNullOrEmpty(_tenNhanVien) || nv.TenNhanVien.Contains(_tenNhanVien))
                            && (string.IsNullOrEmpty(_email) || nv.Email.Contains(_email))
                            && (_gender == false || nv.GioiTinh == _gender)
                            && (nv.NgaySinh >= _birthday && nv.NgaySinh <= _birthdayT)
                            && (string.IsNullOrEmpty(_phoneNumber) || nv.SoDT.Contains(_phoneNumber))
                            && (_quayGiaoDich == 0 || nv.MaQGD == _quayGiaoDich)
                            ))
                        .Select(nv => nv).ToList();
                    foreach (var item in query)
                    {
                        DTO.Model.StaffManager_DTO _staffManager = new DTO.Model.StaffManager_DTO();
                        _staffManager.StaffCode = item.MaNV;
                        _staffManager.StaffName = item.TenNhanVien;
                        _staffManager.StaffGender = item.GioiTinh;
                        _staffManager.StaffBirthday = item.NgaySinh;
                        _staffManager.StaffEmail = item.Email;
                        _staffManager.StaffPhoneNumber = item.SoDT;
                        _staffManager.StaffAddress = item.DiaChi;
                        _staffManager.StaffJobtitle = item.ChucVu;
                        _staffManager.StaffPaymentStore = item.MaQGD;
                        _staffManager.StaffAccount = item.TenDangNhap;
                        _staffManager.StaffPassword = item.MatKhau;
                        _staffManager.StaffPermission = item.MaNhomTK;    
                        lst_StaffManager.Add(_staffManager);
                    }
                    return lst_StaffManager;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogError("NhanVienDao ReadListStaff", ex.ToString());
                return null;
            }
        }
        public static List<ChucVuDto> GetAllJobtitle()
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    return ql.ChucVu.Where(x=>x.TrangThai == true).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogError("NhanVienDao GetAllJobtitle", ex.ToString());
                return null;
            }
        }

        public static bool CreateJobtitle(ChucVuDto cvNhanVien)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    ql.ChucVu.Add(cvNhanVien);
                    ql.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogError("NhanVienDao CreateNewStaff", ex.ToString());
                return false;
            }
        }
    }
}
