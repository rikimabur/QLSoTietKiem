using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSoTietKiem.DTO.Model
{
    public class GiaoDich_DTO
    {
        public int MaGiaoDich { get; set; }
        public int MaSTK { get; set; }
        public double SoTienGui { get; set; }
        public double? TongTienLai { get; set; }
        public double? TongTien { get; set; }
        public string QuayGiaoDich { get; set; }
        public string LoaiGD { get; set; }
        public string TenKhachHang { get; set; }
        public string CMND { get; set; }
        public int MaNV { get; set; }
        public string TenNhanVien{ get; set; }
        public string GhiChu { get; set; }
        public string TinhTrang { get; set; }
        public string LoaiTien { get; set; }
        public int SoKyHan { get; set; }
        public decimal LaiSuat { get; set; }
    }
}
