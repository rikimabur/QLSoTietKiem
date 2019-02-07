using QLSoTietKiem.DAO;
using QLSoTietKiem.DTO;
using System;

namespace QLSoTietKiem.Business
{
    public class TaiKhoanBus
    {
        public TaiKhoanDto Login(string username, string password)
        {
            return TaiKhoanDao.Login(username, password);
        }
        public bool CreateNewAccount(TaiKhoanDto _taiKhoan)
        {
            return TaiKhoanDao.CreateNewAccount(_taiKhoan);
        }
        public int ChangePassWord(int maNhanVien, string passwordOld, string passwordNew)
        {
            TaiKhoanDao _tkDAO = new TaiKhoanDao();
            if (TaiKhoanDao.CheckValidPass(maNhanVien,passwordOld) == false)
            {
                return 0;
            }
            else if (TaiKhoanDao.ChangePassWord(maNhanVien, passwordOld, passwordNew) == true)
            {
                return 1;
            }
            else
            {
                return 2;
            }            
        }
        public bool Delete(int id)
        {
            return TaiKhoanDao.Delete(id);
        }

    }
}
