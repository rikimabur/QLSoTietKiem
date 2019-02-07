
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QLSoTietKiem.DTO
{

    [Table("LoaiTien")]
    public class LoaiTienDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaLoaiTien { get; set; }
        public string LoaiTien { get; set; }
        public bool TinhTrang { get; set; }
        public decimal MenhGiaQuyDoi { set; get; }
        public virtual IEnumerable<SoTietKiemDto> SoTietKiemDto { get; set; }
    }
}
