using QLSoTietKiem.DAO.Helpers;
using QLSoTietKiem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLSoTietKiem.DAO
{
    public class NhomTaiKhoanDao
    {
        private static NhomTaiKhoanDao _instance;
        public static NhomTaiKhoanDao Instance = _instance ?? (_instance = new NhomTaiKhoanDao());
        public List<NhomTaiKhoanDto> GetAll()
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                return ql.NhomTaiKhoan.ToList();
            }
        }
        public static bool CreatePermission(NhomTaiKhoanDto _permission)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    ql.NhomTaiKhoan.Add(_permission);
                    ql.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogError("NhomTaiKhoanDao CreatePermission", ex.Message);
                return false;
            }
        }
    }
}
