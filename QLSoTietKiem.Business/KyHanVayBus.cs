using QLSoTietKiem.DAO;
using QLSoTietKiem.DTO;
using QLSoTK;
using System.Collections.Generic;

namespace QLSoTietKiem.Business
{
    public class KyHanVayBus
    {
        // Lấy danh sách kỳ hạn
        public static List<KyHanVay_DTO> GetAll()
        {
            return KyHanVayDao.GetAll();
        }
        // Lấy danh sách kỳ hạn đang áp dụng
        public static List<KyHanVay_DTO> GetKyHanActive()
        {
            return KyHanVayDao.GetKyHanActive();
        }
        // Tìm một kỳ hạn
        public static KyHanVayDto GetById(int id)
        {
            return KyHanVayDao.GetById(id);
        }
        // Thêm một kỳ hạn mới
        public static bool Add(KyHanVayDto kyHanVayDto)
        {
            return KyHanVayDao.Add(kyHanVayDto);
        }
        // Xóa một kỳ hạn 
        public static bool Delete(int id)
        {
            return KyHanVayDao.Delete(id);
        }
        // Cập nhật lại tất cả thay đổi của một kỳ hạn
        public static string Update(KyHanVayDto kyHanVayDto)
        {
            return KyHanVayDao.Update(kyHanVayDto);
        }
        // cập nhật lại trạng thái đã xóa -> hoạt động
        public static bool UpdateStatus(int id)
        {
            return KyHanVayDao.UpdateStatus(id);
        }
        // Kiểm tra kỳ hạn vay khi update hoặc thêm vào
        public static bool CheckNumberMonth(int soThang)
        {
            return KyHanVayDao.CheckNumberMonth(soThang);
        }
    }
}
