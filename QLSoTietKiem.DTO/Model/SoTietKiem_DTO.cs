using System;

namespace QLSoTietKiem.DTO.Model
{
    public class SoTietKiem_DTO
    {
        public int MaSTK { get; set; }
        public int MaKh { get; set; }
        public int MaKyHan { get; set; }
        public DateTime NgayMo { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public DateTime NgayDenHan { get; set; }
        public int KyHanGui { get; set; }
        public string TienTe { get; set; }
        public string TenNhanVien { get; set; }
        public string KhachHang { get; set; }
        public string CMND { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public double SoTienGui { get; set; }
        public decimal LaiXuat { get; set; }
        public string TrangThai { get; set; }
    }
}
