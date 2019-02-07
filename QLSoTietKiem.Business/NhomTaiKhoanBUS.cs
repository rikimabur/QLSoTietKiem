using QLSoTietKiem.DAO;
using QLSoTietKiem.DTO;
using System.Collections.Generic;

namespace QLSoTietKiem.Business
{
    public class NhomTaiKhoanBus
    {
        private static NhomTaiKhoanBus _instance;
        public static NhomTaiKhoanBus Instance => _instance ?? (_instance = new NhomTaiKhoanBus());
        public List<PermissionResult> GetAllPermission()
        {
            //return NhomTaiKhoanDao.Instance.GetAll();
            List<NhomTaiKhoanDto> _permissionDTO = new List<NhomTaiKhoanDto>();
            List<PermissionResult> g_Permission = new List<PermissionResult>();
            _permissionDTO = NhomTaiKhoanDao.Instance.GetAll();
            foreach (var item in _permissionDTO)
            {
                PermissionResult _permission = new PermissionResult();
                _permission.PermissionCode = item.MaNhom;
                _permission.PermissionName = item.TenNhom;
                g_Permission.Add(_permission);
            }
            return g_Permission;
        }
        public bool CreatePermission(NhomTaiKhoanDto _permission, out string Message)
        {
            if (string.IsNullOrEmpty(_permission.TenNhom))
            {
                Message = "Tên nhóm quyền không được rỗng";
                return false;
            }
            else if (!NhomTaiKhoanDao.CreatePermission(_permission))
            {
                Message = "Lỗi tạo nhóm quyền";
                return false;
            }
            else
            {
                Message = "Tạo nhóm quyền thành công";
                return false;
            }
        }
        public List<GenderResult> GetAllGender()
        {
            List<GenderResult> lstGender = new List<GenderResult>();
            lstGender.Add(new GenderResult() { GenderCode =false, GenderName = "Nữ" });
            lstGender.Add(new GenderResult() { GenderCode = true, GenderName = "Nam" });
            return lstGender;
        }
    }
    public class PermissionResult
    {
        public int PermissionCode { set; get; }
        public string PermissionName { set; get; }
    }
    public class GenderResult
    {
        public bool GenderCode { set; get; }
        public string GenderName { set; get; }
    }
}
