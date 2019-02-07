using QLSoTietKiem.DTO;
using QLSoTK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLSoTietKiem.DAO
{
    public class KyHanVayDao
    {
        /// <summary>
        /// Lấy tất cả các kỳ hạn
        /// </summary>
        /// <returns></returns>
        public static List<KyHanVay_DTO> GetAll()
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                try
                {
                    var lstKyHan = ql.KyHanVay.Select(x => new KyHanVay_DTO
                    {
                        MaKyHan = x.MaKyHan,
                        SoThang = x.SoThang,
                        GhiChu = x.GhiChu,
                        LaiSuat = x.LaiSuat,
                        MucTien = x.MucTien,
                        TinhTrang = (x.TinhTrang ? "Hoạt Động" : "Đã Xóa")
                    }).ToList();

                    return lstKyHan;
                }
                catch (Exception e)
                {
                    return null;
                }
            }

        }
        /// <summary>
        /// Lấy danh sách kỳ hạn đang hoạt động
        /// </summary>
        /// <returns></returns>
        public static List<KyHanVay_DTO> GetKyHanActive()
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                try
                {
                    var lstKyHan = ql.KyHanVay.Where(x => x.TinhTrang).Select(x => new KyHanVay_DTO
                    {
                        MaKyHan = x.MaKyHan,
                        SoThang = x.SoThang,
                        GhiChu = x.GhiChu,
                        LaiSuat = x.LaiSuat,
                        MucTien = x.MucTien
                    }).ToList();

                    return lstKyHan;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// Tìm kỳ hạn theo id
        /// </summary>
        /// <param name="id">mã kỳ hạn</param>
        /// <returns></returns>
        public static KyHanVayDto GetById(int id)
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                return ql.KyHanVay.Where(x => x.MaKyHan == id).FirstOrDefault();
            }
        }
        /// <summary>
        /// Kiểm tra số tháng của kỳ hạn
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static bool CheckNumberMonth(int month)
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                return ql.KyHanVay.Any(x => x.SoThang == month && x.TinhTrang);
            }
        }
        /// <summary>
        /// Thêm mới một kỳ hạn
        /// </summary>
        /// <param name="kyHanVayDto"></param>
        /// <returns></returns>
        public static bool Add(KyHanVayDto kyHanVayDto)
        {
            kyHanVayDto.TinhTrang = true;
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                try
                {
                    ql.KyHanVay.Add(kyHanVayDto);
                    ql.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Update lại danh sách của một kỳ hạn
        /// </summary>
        /// <param name="kyHanVayDto"></param>
        /// <returns></returns>
        public static string Update(KyHanVayDto kyHanVayDto)
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                var _kyHanVay = KyHanVayDao.GetById(kyHanVayDto.MaKyHan);
                if (_kyHanVay == null)
                {
                    return "Hệ thống đang gặp sự cố.";
                }
                if(_kyHanVay.SoThang != kyHanVayDto.SoThang)
                {
                    if (ql.KyHanVay.Any(x => x.SoThang == kyHanVayDto.SoThang && x.TinhTrang))
                        return string.Format("Kỳ hạn vay {0} đang hoạt động. Xin vui lòng chọn kỳ hạn khác",kyHanVayDto.SoThang);
                }
                _kyHanVay.SoThang = kyHanVayDto.SoThang;
                _kyHanVay.GhiChu = kyHanVayDto.GhiChu;
                _kyHanVay.LaiSuat = kyHanVayDto.LaiSuat;
                _kyHanVay.MucTien = kyHanVayDto.MucTien;
                _kyHanVay.TinhTrang = kyHanVayDto.TinhTrang;
                ql.Entry(_kyHanVay).State = System.Data.Entity.EntityState.Modified;
                ql.SaveChanges();
                return "Sửa đổi kỳ hạn thành công";
            }
        }
        /// <summary>
        /// Xóa 1 kỳ hạn dựa vào mã kỳ hạn(cập nhật lại trạng thái đã xóa)
        /// </summary>
        /// <param name="id">Mã kỳ hạn</param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                var _kyHanVay = KyHanVayDao.GetById(id);
                if (_kyHanVay == null)
                {
                    return false;
                }
                _kyHanVay.TinhTrang = false;
                ql.Entry(_kyHanVay).State = System.Data.Entity.EntityState.Modified;
                ql.SaveChanges();
                return true;
            }
        }
        /// <summary>
        /// Cập nhật lại trạng thái đã xóa -> đang hoạt động
        /// </summary>
        /// <param name="id">mã kỳ hạn</param>
        /// <returns></returns>
        public static bool UpdateStatus(int id)
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                var _kyHanVay = KyHanVayDao.GetById(id);
                if (_kyHanVay == null)
                {
                    return false;
                }
                _kyHanVay.TinhTrang = true;
                ql.Entry(_kyHanVay).State = System.Data.Entity.EntityState.Modified;
                ql.SaveChanges();
                return true;
            }
        }
    }
}
