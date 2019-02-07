using QLSoTietKiem.DTO;
using QLSoTietKiem.DTO.Model;
using System.Collections.Generic;
using System.Linq;

namespace QLSoTietKiem.DAO
{
    public static class LoaiTienDao
    {
        public static List<LoaiTien_DTO> GetAll()
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                return ql.LoaiTien.Where(x=>x.TinhTrang).Select(x => new LoaiTien_DTO
                {
                    MaLoaiTien = x.MaLoaiTien,
                    LoaiTien = x.LoaiTien,
                    MenhGiaQuyDoi = x.MenhGiaQuyDoi,
                    TinhTrang = x.TinhTrang ? "Hoạt động" : "Đã xóa"
                }).ToList();
            }
        }
        public static LoaiTien_DTO GetById(string loai)
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                return ql.LoaiTien.Where(x => x.LoaiTien.ToLower().Equals(loai)).Select(x => new LoaiTien_DTO
                {
                    MaLoaiTien = x.MaLoaiTien,
                    LoaiTien = x.LoaiTien,
                    MenhGiaQuyDoi = x.MenhGiaQuyDoi,
                    TinhTrang = x.TinhTrang ? "Hoạt động" : "Đã xóa"
                }).FirstOrDefault();
            }
        }
    }
}
