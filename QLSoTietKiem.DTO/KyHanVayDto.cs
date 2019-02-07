using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSoTietKiem.DTO
{
    [Table("KyHanVay")]
    public class KyHanVayDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaKyHan { get; set; }
        public int SoThang { get; set; }
        public string GhiChu { get; set; }
        public decimal LaiSuat { get; set; }
        public decimal MucTien { get; set; }
        public bool TinhTrang { get; set; }
        public virtual IEnumerable<SoTietKiemDto> SoTietKiem { get; set; }
        public virtual ICollection<GiaoDichDto> GiaoDich { get; set; }
    }
}
