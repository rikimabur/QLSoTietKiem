using QLSoTietKiem.DAO;
using QLSoTietKiem.DTO;
using QLSoTietKiem.DTO.Model;
using System;
using System.Collections.Generic;

namespace QLSoTietKiem.Business
{
    public class KhachHangBus
    {
        public static List<KhachHang_DTO> GetAll()
        {
            return KhachHangDao.GetAll();
        }
        public static KhachHang_DTO GetById(int id)
        {
            return KhachHangDao.GetById(id);
        }
        public static string Add(KhachHangDto khachHangDto)
        {
            return KhachHangDao.Add(khachHangDto);
        }
        public static bool Update(KhachHangDto khachHangDto)
        {
            return KhachHangDao.Update(khachHangDto);
        }
        public static bool Delete(int id)
        {
            return KhachHangDao.Delete(id);
        }

        public List<DTO.Model.CustManager_DTO> ReadListCust(string _tenKhachHang, string _soDienThoai, string _CMND, bool _gender, DateTime _birthday, DateTime _timeCreateCMND)
        {
            return KhachHangDao.ReadListCust(_tenKhachHang, _soDienThoai, _CMND, _gender, _birthday, _timeCreateCMND);
        }
        public bool CreateNewCust(KhachHangDto _khachHang, out string Message)
        {
            if (!KhachHangDao.CreateNewCust(_khachHang))
            {
                Message = "Có lỗi trong lúc tạo thông tin khách hàng";
                return false;
            }
            else
            {
                Message = "Tạo Khách hàng thành công";
                return true;
            }
        }
        public bool UpdateCust(List<KhachHangDto> _khachHang, out string Message)
        {
            if (!KhachHangDao.UpdateCust(_khachHang))
            {
                Message = "Cập nhật khách hàng thất bại";
                return false;
            }
            else
            {
                Message = "Cập nhật khách hàng thành công";
                return true;
            }
        }
        public bool DeleteCust(int maKhachHang, out string Message)
        {
            if (!KhachHangDao.DeleteCust(maKhachHang))
            {
                Message = "Lỗi khi xóa khách hàng";
                return false;
            }
            else
            {
                Message = "Xóa khách hàng thành công";
                return true;
            };
        }
        public static KhachHang_DTO GetByCmnd(string cmnd)
        {
            return KhachHangDao.GetByCmnd(cmnd);
        }
    }
}
