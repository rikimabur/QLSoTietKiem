using QLSoTietKiem.DAO;
using QLSoTietKiem.DTO.Model;
using System.Collections.Generic;

namespace QLSoTietKiem.Business
{
    public static class LoaiTienBus
    {
        public static List<LoaiTien_DTO> GetAll()
        {
            return LoaiTienDao.GetAll();
        }
        public static LoaiTien_DTO GetById(string loai)
        {
            return LoaiTienDao.GetById(loai.ToUpper());
        }

    }
}
