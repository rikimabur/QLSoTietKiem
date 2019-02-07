using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSoTietKiem.DTO
{
    [Table("NhomTaiKhoan")]
    public class NhomTaiKhoanDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNhom { get; set; }
        public string TenNhom { get; set; }
        public bool TrangThai { get; set; }
        public virtual IEnumerable<TaiKhoanDto> TaiKhoanDto { get; set; }
    }
}
