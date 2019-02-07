using QLSoTietKiem.DAO.Helpers;
using QLSoTietKiem.DTO;
using System;
using System.Linq;
using System.Text;

namespace QLSoTietKiem.DAO
{
    public class TaiKhoanDao
    {
        private static TaiKhoanDao _instance;
        public static TaiKhoanDao Instance => _instance ?? (_instance = new TaiKhoanDao());
        #region "Xử lý tài khoản"
        public static TaiKhoanDto Login(string username, string password)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    Logger.WriteLogError("TaiKhoanDao Login", "");
                    return ql.TaiKhoan.Where(x => x.TenDangNhap == username && x.MatKhau == password).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogError("TaiKhoanDao Login", ex.ToString());
                return null;
            }
        }
        public static bool CreateNewAccount(TaiKhoanDto _taiKhoan)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    ql.TaiKhoan.Add(_taiKhoan);
                    ql.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogError("TaiKhoanDao CreateNewAccount", ex.ToString());
                return false;
            }
        }
        public static void UpdateStaffPermission(int _maNV, int _maNhomQuyen)
        {
            using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
            {
                var taikhoan = ql.TaiKhoan.FirstOrDefault(s => s.MaNhanVien == _maNV);
                if (taikhoan != null)
                {
                    taikhoan.MaNhomTK = _maNhomQuyen;
                    ql.SaveChanges();
                }
            }
        }
        public static bool Delete(int id)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    var _taikhoan = ql.TaiKhoan.Where(x => (x.MaNhanVien == id && x.TrangThai == true)).FirstOrDefault();
                    if (_taikhoan != null)
                    {
                        _taikhoan.TrangThai = false;
                    }
                    ql.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogError("TaiKhoanDao Delete", ex.ToString());
                return false;
            }

        }
        public static bool CheckValidPass(int maNhanVien, string passWord)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    var _taikhoan = ql.TaiKhoan.Where(x => x.MaNhanVien == maNhanVien && x.MatKhau == passWord).FirstOrDefault();
                    if (_taikhoan != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogError("TaiKhoanDao CheckValidPass", ex.ToString());
                return false;
            }
        }
        public static bool ChangePassWord(int maNhanVien, string passwordOld, string passwordNew)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    var _taikhoan = ql.TaiKhoan.Where(x => x.MaNhanVien == maNhanVien && x.MatKhau.Equals(passwordOld)).FirstOrDefault();
                    if (_taikhoan != null)
                    {
                        _taikhoan.MatKhau = passwordNew;
                        var _nv = ql.NhanVien.Where(x => x.MaNV == _taikhoan.MaNhanVien).FirstOrDefault();
                        _nv.DoiMatKhau = true;
                        //ql.Entry(_taikhoan).State = System.Data.Entity.EntityState.Modified;
                    }
                    ql.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogError("TaiKhoanDao CreateNewAccount", ex.ToString());
                return false;
            }
        }
        public static string GetAccountName(string shortName)
        {
            try
            {
                using (QLSoTietKiemDBContext ql = new QLSoTietKiemDBContext())
                {
                    var _taikhoan = ql.TaiKhoan.Where(x => (x.TenDangNhap.Contains(shortName))).OrderByDescending(x=>x.MaTaiKhoan).FirstOrDefault();
                    if (_taikhoan != null)
                    {
                        string strAfterReplace = _taikhoan.TenDangNhap.Replace(shortName, "");
                        string tailString = string.Empty;
                        tailString = string.IsNullOrEmpty(strAfterReplace) ? "1" : (Convert.ToInt32(strAfterReplace) + 1).ToString();
                        return shortName + tailString;
                    }
                    else
                    {
                        return shortName;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLogError("TaiKhoanDao GetAccountName", ex.ToString());
                return "";
            }
        }
        #endregion "Xử lý tài khoản"
    }
}
