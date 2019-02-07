using QLSoTietKiem.DTO;
using QLSoTietKiem.DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLSoTietKiem.DAO
{
    /// <summary>
    /// Class GiaoDich
    /// </summary>
    public static class GiaoDichDao
    {
        /// <summary>
        /// Lấy danh sách giao dịch
        /// </summary>
        /// <returns></returns>
        public static List<GiaoDich_DTO> GetAll()
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    var lstGiaoDich = (from gd in ql.GiaoDich
                                       join stk in ql.SoTietKiem on gd.MaSTK equals stk.MaSTK
                                       join lkh in ql.KyHanVay on gd.MaKyH equals lkh.MaKyHan
                                       join lt in ql.LoaiTien on stk.MaLoaiTien equals lt.MaLoaiTien
                                       join nv in ql.NhanVien on gd.MaNV equals nv.MaNV
                                       join kh in ql.KhachHang on gd.MaKHang equals kh.MaKh
                                       join quaygd in ql.QuayGiaoDich on gd.MaQuayGD equals quaygd.MaQGD
                                       where gd.TinhTrang == true
                                       select new GiaoDich_DTO
                                       {
                                           MaGiaoDich = gd.MaCTGD,
                                           MaSTK = gd.MaSTK,
                                           SoTienGui = gd.SoTienGui,
                                           TongTienLai = gd.TongTienLai,
                                           TongTien = gd.TongTien,
                                           QuayGiaoDich = quaygd.TenQuayGiaoDich,
                                           LoaiGD = gd.LoaiGD == 0 ? "Gửi tiền" : "Rút tiền",
                                           TenKhachHang = kh.Hoten,
                                           CMND = kh.Cmnd,
                                           MaNV = nv.MaNV,
                                           TenNhanVien = nv.TenNhanVien,
                                           GhiChu = gd.GhiChu,
                                           TinhTrang = gd.TinhTrang == true ? "Giao dịch thành công" : "Giao dịch thất bại",
                                           LoaiTien = lt.LoaiTien,
                                           SoKyHan = lkh.SoThang,
                                           LaiSuat = lkh.LaiSuat
                                       }).ToList();
                    return lstGiaoDich;

                }
            }
            catch(Exception e)
            {
                return null; 
            }
        }
        /// <summary>
        /// Add one deal 
        /// </summary>
        /// <param name="giaoDichDto"></param>
        /// <returns></returns>
        public static bool Add(GiaoDichDto giaoDichDto)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    ql.GiaoDich.Add(giaoDichDto);
                    ql.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Update one of deal 
        /// </summary>
        /// <param name="giaoDichDto"></param>
        /// <param name="mastk"></param>
        /// <returns></returns>
        public static bool Update(GiaoDichDto giaoDichDto, int mastk)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    var _giaoDichDto = ql.GiaoDich.Where(x => x.MaSTK == mastk).FirstOrDefault();
                    if (_giaoDichDto == null)
                    {
                        return false;
                    }
                    _giaoDichDto.SoTienGui = giaoDichDto.SoTienGui;
                    _giaoDichDto.TongTien = giaoDichDto.TongTien;
                    _giaoDichDto.MaKyH = giaoDichDto.MaKyH;
                    if (giaoDichDto.LoaiGD.Equals(1))
                    {
                        _giaoDichDto.TongTienLai = giaoDichDto.TongTienLai;
                    }
                    ql.Entry(_giaoDichDto).State = System.Data.Entity.EntityState.Modified;
                    ql.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Lấy một giao dịch từ mã giao dịch
        /// </summary>
        /// <param name="mastk">mã sổ tiết kiệm</param>
        /// <returns></returns>
        public static GiaoDichDto GetById(int mastk)
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                return ql.GiaoDich.SingleOrDefault(x => x.MaSTK == mastk);
            }
        }
        public static void Delete(int mastk)
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                var giaoDich = ql.GiaoDich.Where(x => x.MaSTK == mastk && x.TinhTrang == true).FirstOrDefault();
                if(giaoDich != null)
                {
                    giaoDich.TinhTrang = false;
                    ql.Entry(giaoDich).State = System.Data.Entity.EntityState.Modified;
                    ql.SaveChanges();
                }
            }
        }
    }
}
