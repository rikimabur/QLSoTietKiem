using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSoTietKiem.DTO.Model
{
    public class LoaiTien_DTO
    {
        public int MaLoaiTien { get; set; }
        public string LoaiTien { get; set; }
        public string TinhTrang { get; set; }
        public decimal MenhGiaQuyDoi { set; get; }
    }
}
