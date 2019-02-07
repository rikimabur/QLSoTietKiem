using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSoTietKiem.DTO.Model
{
    public class KhachHang_DTO
    {
        public int MaKh { get; set; }
        public string Hoten { get; set; }
        public string GioiTinh { get; set; }
        public string Cmnd { get; set; }
        public string Sdt { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayCap { get; set; }
        public string DiaChi { get; set; }
        public string TrangThai { get; set; }
    }
}
