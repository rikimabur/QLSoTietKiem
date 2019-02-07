using System;

namespace QLSoTietKiem.DTO.Model
{
    public class PhieuRut_DTO : EventArgs
    {
        public string LoaiTien { get; set; }
        public string TenChiNhanh { get; set; }
        public string HoTenKh { get; set; }
        public string CMND { get; set; }
        public string NgaySinh { get; set; }
        public string SDT { get; set; }
        public string NoiCap { get; set; }
        public string DiaChi { get; set; }
        public string KyHan { get; set; }
        public string SoTienGui { get; set; }
        public string TongLai { get; set; }
        public string TongNhan { get; set; }

    }
}
