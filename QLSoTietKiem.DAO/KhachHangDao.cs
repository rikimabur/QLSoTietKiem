using QLSoTietKiem.DAO.Helpers;
using QLSoTietKiem.DTO;
using QLSoTietKiem.DTO.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace QLSoTietKiem.DAO
{
    public static class KhachHangDao
    {
        /// <summary>
        /// Danh sách tất cả các khách hàng
        /// </summary>
        /// <returns></returns>
        public static List<KhachHang_DTO> GetAll()
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                var lst = ql.KhachHang.Select(c => new KhachHang_DTO
                {
                    MaKh = c.MaKh,
                    Hoten = c.Hoten,
                    GioiTinh = c.GioiTinh ? "Nam" : "Nữ",
                    Cmnd = c.Cmnd,
                    DiaChi = c.DiaChi,
                    NgaySinh = (DateTime)c.NgaySinh,
                    NgayCap = c.NgayCap,
                    TrangThai = c.TrangThai == 1 ? "Hoạt Động" : "Đã Xóa"
                }).ToList();
                return lst;
            }
        }
        /// <summary>
        /// Tìm một khách hàng dựa vào mã khách hàng
        /// </summary>
        /// <param name="id">mã khách hàng</param>
        /// <returns></returns>
        public static KhachHang_DTO GetById(int id)
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                var _kh = ql.KhachHang.Where(x => x.MaKh == id).Select(c => new KhachHang_DTO
                {
                    MaKh = c.MaKh,
                    Hoten = c.Hoten,
                    GioiTinh = c.GioiTinh ? "Nam" : "Nữ",
                    Cmnd = c.Cmnd,
                    Sdt = c.Sdt,
                    DiaChi = c.DiaChi,
                    NgaySinh = (DateTime)c.NgaySinh,
                    NgayCap = c.NgayCap,
                    TrangThai = c.TrangThai == 1 ? "Hoạt Động" : "Đã Xóa"
                }).FirstOrDefault();
                return _kh;
            }
        }
        /// <summary>
        /// Tìm một khách hàng dựa vào cmnd
        /// </summary>
        /// <param name="Cmnd"></param>
        /// <returns></returns>
        public static KhachHang_DTO GetByCmnd(string Cmnd)
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                var _kh = ql.KhachHang.Where(x => x.Cmnd.Equals(Cmnd)).Select(c => new KhachHang_DTO
                {
                    MaKh = c.MaKh,
                    Hoten = c.Hoten,
                    GioiTinh = c.GioiTinh ? "Nam" : "Nữ",
                    Cmnd = c.Cmnd,
                    DiaChi = c.DiaChi,
                    Sdt = c.Sdt,
                    NgaySinh = (DateTime)c.NgaySinh,
                    NgayCap = c.NgayCap
                }).FirstOrDefault();
                return _kh;
            }
        }
        /// <summary>
        /// Cập nhật thay đổi của một khách hàng
        /// </summary>
        /// <param name="khachHangDto"></param>
        /// <returns></returns>
        public static bool Update(KhachHangDto khachHangDto)
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                var _kh = ql.KhachHang.Where(a => a.MaKh == khachHangDto.MaKh).FirstOrDefault();
                if (_kh == null)
                {
                    return false;
                }
                _kh.Hoten = khachHangDto.Hoten;
                _kh.GioiTinh = khachHangDto.GioiTinh;
                _kh.DiaChi = khachHangDto.DiaChi;
                _kh.NgaySinh = khachHangDto.NgaySinh;
                _kh.NgayCap = khachHangDto.NgayCap;
                _kh.Sdt = khachHangDto.Sdt;
                ql.Entry(_kh).State = System.Data.Entity.EntityState.Modified;
                ql.SaveChanges();
                return true;
            }
        }
        /// <summary>
        /// Thêm một khách hàng mới
        /// (khách hàng chỉ có một mã khách hàng và mã cmnd là duy nhất)
        /// </summary>
        /// <param name="khachHangDto"></param>
        /// <returns>string</returns>
        public static string Add(KhachHangDto khachHangDto)
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                try
                {
                    if (ql.KhachHang.Any(x => x.Cmnd.Equals(khachHangDto.Cmnd)))
                    {
                        return "CMND này đã có người sử dụng";
                    }
                    ql.KhachHang.Add(khachHangDto);
                    ql.SaveChanges();
                    return "";
                }
                catch (Exception e)
                {
                    return "Hệ thống đang bị lỗi";
                }
            }
        }
        /// <summary>
        /// Xóa một khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                try
                {
                    var _kh = ql.KhachHang.Where(n => n.MaKh == id).FirstOrDefault();
                    if (_kh == null)
                    {
                        return false;
                    }
                    ql.KhachHang.Remove(_kh);
                    ql.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public static bool CreateNewCust(KhachHangDto _khachHang)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    ql.KhachHang.Add(_khachHang);
                    ql.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogError("KhachHangDao CreateNewCust", ex.ToString());
                return false;
            }
        }
        public static bool UpdateCust(List<KhachHangDto> _khachHang)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    int count = 0;
                    foreach (var item in _khachHang)
                    {
                        var khachhang = ql.KhachHang.FirstOrDefault(s => s.MaKh == item.MaKh);
                        if (khachhang != null)
                        {
                            khachhang.Hoten = item.Hoten;
                            khachhang.Sdt = item.Sdt;
                            khachhang.Cmnd = item.Cmnd;
                            khachhang.GioiTinh = item.GioiTinh;
                            khachhang.NgaySinh = item.NgaySinh;
                            khachhang.NgayCap = item.NgayCap;
                            khachhang.DiaChi = item.DiaChi;
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
                Logger.WriteLogError("KhachHangDao UpdateCust", ex.ToString());
                return false;
            }
        }
        public static bool DeleteCust(int maKhachHang)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    var khahcHang = ql.KhachHang.FirstOrDefault(s => s.MaKh == maKhachHang);
                    khahcHang.TrangThai = 0;
                    ql.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogError("KhachHangDao DeleteCust", ex.ToString());
                return false;
            }
        }
        public static List<DTO.Model.CustManager_DTO> ReadListCust(string _tenKhachHang, string _soDienThoai, string _CMND, bool _gender, DateTime _birthday, DateTime _timeCreateCMND)
        {
            try
            {
                List<DTO.Model.CustManager_DTO> lst_CustManager = new List<DTO.Model.CustManager_DTO>();
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    var query = ql.KhachHang
                        .Where(Kh => (Kh.TrangThai == 1
                            && (string.IsNullOrEmpty(_tenKhachHang) || Kh.Hoten.Contains(_tenKhachHang))
                            && (string.IsNullOrEmpty(_soDienThoai) || Kh.Sdt.Contains(_soDienThoai))
                            && (_gender == false || Kh.GioiTinh == _gender)
                            ))
                        .Select(Kh => Kh).ToList();
                    foreach (var item in query)
                    {
                        DTO.Model.CustManager_DTO _custManager = new DTO.Model.CustManager_DTO();
                        _custManager.CustCode = item.MaKh;
                        _custManager.CustName = item.Hoten;
                        _custManager.CustGender = item.GioiTinh;
                        _custManager.CustCMND = item.Cmnd;
                        _custManager.CustPhoneNumber = item.Sdt;
                        _custManager.CustAddress = item.DiaChi;
                        _custManager.CreateTimeCMND = item.NgayCap;
                        _custManager.CustBirthday = item.NgaySinh;
                        lst_CustManager.Add(_custManager);
                    }
                    return lst_CustManager;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogError("KhachHangDao ReadListStaff", ex.ToString());
                return null;
            }
        }
    }
}
