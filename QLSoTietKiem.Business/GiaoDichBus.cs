using QLSoTietKiem.DAO;
using QLSoTietKiem.DTO.Model;
using System.Collections.Generic;

namespace QLSoTietKiem.Business
{
    public class GiaoDichBus
    {
        public static List<GiaoDich_DTO> GetAll()
        {
            return GiaoDichDao.GetAll();
        }
    }
}
