using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSoTietKiem.DTO
{
    [Table("QuayGiaoDich")]
    public class QuayGiaoDichDto
    {
        public QuayGiaoDichDto()
        {
            GiaoDich = new List<GiaoDichDto>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaQGD { get; set; }
        public string TenQuayGiaoDich { get; set; }
        public string DiaChi { get; set; }
        public bool TinhTrang { get; set; }
        public virtual IEnumerable<NhanVienDto> NhanVien { get; set; }
        public virtual ICollection<GiaoDichDto> GiaoDich { get; set; }
    }
}
