using QLSoTietKiem.DAO.Helpers;
using QLSoTietKiem.DTO;
using QLSoTietKiem.DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLSoTietKiem.DAO
{
    /// <summary>
    /// DAO của sổ tiết kiệm
    /// </summary>
    public class SoTietKiemDao
    {
        /// <summary>
        /// Lấy danh sách tất cả các sổ
        /// </summary>
        /// <returns></returns>
        public static List<SoTietKiem_DTO> GetAll()
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                try
                {
                    var lstSoTietKiem = (from stk in ql.SoTietKiem
                                         join lkh in ql.KyHanVay on stk.MaKyHan equals lkh.MaKyHan
                                         join lt in ql.LoaiTien on stk.MaLoaiTien equals lt.MaLoaiTien
                                         join nv in ql.NhanVien on stk.MaNV equals nv.MaNV
                                         join kh in ql.KhachHang on stk.MaKhachHang equals kh.MaKh
                                         select new SoTietKiem_DTO
                                         {
                                             MaSTK = stk.MaSTK,
                                             NgayMo = stk.NgayMo,
                                             NgayHieuLuc = stk.NgayHieuLuc,
                                             NgayDenHan = stk.NgayDenHan,
                                             KyHanGui = lkh.SoThang,
                                             TienTe = lt.LoaiTien,
                                             TenNhanVien = nv.TenNhanVien,
                                             KhachHang = kh.Hoten,
                                             SoTienGui = stk.SoTienGui,
                                             DiaChi = kh.DiaChi,
                                             CMND = kh.Cmnd,
                                             SDT = kh.Sdt,
                                             LaiXuat = lkh.LaiSuat,
                                             TrangThai = (stk.TrangThai == 0 ? DateTime.Now < stk.NgayDenHan ? "Chưa Đến Hạn" : "Đã Đáo Hạn" : "Đã Xóa")

                                         }).ToList();
                    return lstSoTietKiem;
                }catch(Exception ex)
                {
                    return null;
                }
               
            }
        }
        /// <summary>
        /// Lấy thông tin của một sổ tiết kiệm theo mã sổ tiết kiệm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SoTietKiem_DTO GetById(int id)
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                try
                {
                    var lstSoTietKiem = (from stk in ql.SoTietKiem
                                         join lkh in ql.KyHanVay on stk.MaKyHan equals lkh.MaKyHan
                                         join lt in ql.LoaiTien on stk.MaLoaiTien equals lt.MaLoaiTien
                                         join nv in ql.NhanVien on stk.MaNV equals nv.MaNV
                                         join kh in ql.KhachHang on stk.MaKhachHang equals kh.MaKh
                                         where stk.MaSTK == id
                                         select new SoTietKiem_DTO
                                         {
                                             MaSTK = stk.MaSTK,
                                             MaKh = kh.MaKh,
                                             MaKyHan = lkh.MaKyHan,
                                             NgayMo = stk.NgayMo,
                                             NgayHieuLuc = stk.NgayHieuLuc,
                                             NgayDenHan = stk.NgayDenHan,
                                             KyHanGui = lkh.SoThang,
                                             TienTe = lt.LoaiTien,
                                             TenNhanVien = nv.TenNhanVien,
                                             KhachHang = kh.Hoten,
                                             SoTienGui = stk.SoTienGui,
                                             DiaChi = kh.DiaChi,
                                             CMND = kh.Cmnd,
                                             SDT = kh.Sdt,
                                             LaiXuat = lkh.LaiSuat,
                                             TrangThai = (stk.TrangThai == 0 ? DateTime.Now > stk.NgayDenHan ? "Chưa Đến Hạn" : "Đã Đáo Hạn" : "Đã Xóa")

                                         }).FirstOrDefault();
                    return lstSoTietKiem;
                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }
        /// <summary>
        /// Thêm một sổ tiết kiệm vào CSDL
        /// </summary>
        /// <param name="stkDto"></param>
        /// <returns></returns>
        public static bool Add(SoTietKiemDto stkDto)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    stkDto.GhiChu = "Tạo mới";
                    stkDto.TrangThai = 1;
                    ql.SoTietKiem.Add(stkDto);
                    ql.SaveChanges();
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// Cập nhật lại thông tin sổ tiết kiệm của một sổ bất kỳ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="TienGui"></param>
        /// <returns></returns>
        public static bool Update(SoTietKiemDto soTietKiem_DTO)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    var _soTietKiem = ql.SoTietKiem.SingleOrDefault(x => x.MaSTK == soTietKiem_DTO.MaSTK);
                    if (_soTietKiem != null)
                    {
                        _soTietKiem.NgayDenHan = soTietKiem_DTO.NgayDenHan;
                        _soTietKiem.MaNV = soTietKiem_DTO.MaNV;
                        _soTietKiem.MaKhachHang = soTietKiem_DTO.MaKhachHang;
                        _soTietKiem.MaLoaiTien = soTietKiem_DTO.MaLoaiTien;
                        _soTietKiem.MaKyHan = soTietKiem_DTO.MaKyHan;
                        _soTietKiem.NgayHieuLuc = soTietKiem_DTO.NgayHieuLuc;
                        _soTietKiem.TrangThai = soTietKiem_DTO.TrangThai;
                        _soTietKiem.SoTienGui = soTietKiem_DTO.SoTienGui;
                        ql.Entry(_soTietKiem).State = System.Data.Entity.EntityState.Modified;
                        ql.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch(Exception e)
            {
                return false;
            }
         
        }
        public static bool UpdateMoney(int id, double TienGui)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    var soTietKiemModel = ql.SoTietKiem.Where(c => c.MaSTK == id).FirstOrDefault();
                    if (soTietKiemModel != null)
                    {
                        soTietKiemModel.SoTienGui += TienGui;
                        ql.SaveChanges();
                    }
                    else
                    {
                        return false;
                    }
                    
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        ///  Tính lãi xuất đến ngày hiện tại
        /// </summary>
        /// <param name="soTietKiem_DTO"></param>
        /// <returns></returns>
        public static double TinhLaiXuat(SoTietKiem_DTO soTietKiem_DTO)
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                decimal _laiKhongThoiHan = ql.KyHanVay.FirstOrDefault(x => x.SoThang == 0 && x.TinhTrang).LaiSuat;
                return Utils.TinhLaiXuat(soTietKiem_DTO.NgayHieuLuc, soTietKiem_DTO.NgayDenHan, soTietKiem_DTO.KyHanGui, soTietKiem_DTO.SoTienGui, soTietKiem_DTO.LaiXuat, _laiKhongThoiHan);
            }
        }
        /// <summary>
        /// Kiêm tra điều kiện đủ rút sổ
        /// </summary>
        /// <param name="id">Mã sổ tiết kiệm</param>
        /// <returns></returns>
        public static string CheckSTK(DateTime dateBegin,DateTime dateEnd, int sothang)
        {
            if (!Utils.KiemTraNgayRut(dateBegin) && sothang == 0)
                return "15 ngày sau khi mở sổ mới có thể rút được!";
            DateTime _dateNow = DateTime.Now;
            if (_dateNow.Year < dateEnd.Year || _dateNow.Month < dateEnd.Month)
                return "Sổ chưa đáo hạng để rút tiền.";
            if (!Utils.KiemTraSoThangLai(dateBegin) && sothang == 0)
                return "Sổ không thời hạn chưa thể rút được!";
            return "";
        }
        /// <summary>
        /// Xóa sổ tiết kiệm( bằng cách cập nhật lại tình trạng = 0)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        public static SoTietKiemDto Delete(int id)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    var _stk = ql.SoTietKiem.SingleOrDefault(x => x.MaSTK == id);
                    if (_stk == null)
                        return null;
                    _stk.TrangThai = 0;
                    ql.SaveChanges();
                    return _stk;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Lấy mã sổ tiết kiệm mới tạo
        /// </summary>
        /// <returns></returns>
        public static int GetSTKTopOne()
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                return ql.SoTietKiem.OrderByDescending(x => x.MaSTK).FirstOrDefault().MaSTK;
            }
        }
        /// <summary>
        /// Xóa sổ tiết kiệm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Remove(int id)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    var _soTietKiem = ql.SoTietKiem.Where(x => x.MaSTK == id).FirstOrDefault();
                    ql.SoTietKiem.Remove(_soTietKiem);
                    ql.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        // Lấy danh sách sổ tiết kiệm mà chưa rút sổ
        public static List<SoTietKiem_DTO> GetListActive()
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                try
                {
                    var lstSoTietKiem = (from stk in ql.SoTietKiem
                                         join lkh in ql.KyHanVay on stk.MaKyHan equals lkh.MaKyHan
                                         join lt in ql.LoaiTien on stk.MaLoaiTien equals lt.MaLoaiTien
                                         join nv in ql.NhanVien on stk.MaNV equals nv.MaNV
                                         join kh in ql.KhachHang on stk.MaKhachHang equals kh.MaKh
                                         where stk.TrangThai == 0
                                         select new SoTietKiem_DTO
                                         {
                                             MaSTK = stk.MaSTK,
                                             NgayMo = stk.NgayMo,
                                             NgayHieuLuc = stk.NgayHieuLuc,
                                             NgayDenHan = stk.NgayDenHan,
                                             KyHanGui = lkh.SoThang,
                                             TienTe = lt.LoaiTien,
                                             TenNhanVien = nv.TenNhanVien,
                                             KhachHang = kh.Hoten,
                                             SoTienGui = stk.SoTienGui,
                                             DiaChi = kh.DiaChi,
                                             NgaySinh = kh.NgaySinh,
                                             CMND = kh.Cmnd,
                                             SDT = kh.Sdt,
                                             LaiXuat = lkh.LaiSuat,
                                             TrangThai = (DateTime.Now < stk.NgayDenHan ? "Chưa Đến Hạn" : "Đã Đáo Hạn")

                                         }).ToList();
                    return lstSoTietKiem;
                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }
    }
}
