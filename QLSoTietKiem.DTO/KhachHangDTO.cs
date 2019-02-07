using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSoTietKiem.DTO
{
    [Table("KhachHang")]
    public class KhachHangDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaKh { get; set; }
        public string Hoten { get; set; }
        public bool GioiTinh { get; set; }
        public string Cmnd { get; set; }
        public string Sdt { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayCap { get; set; }
        public string DiaChi { get; set; }
        public byte TrangThai { get; set; }
        public virtual IEnumerable<SoTietKiemDto> SoTietKiem { get; set; }
        public virtual ICollection<GiaoDichDto> GiaoDich { get; set; }
    }
}
