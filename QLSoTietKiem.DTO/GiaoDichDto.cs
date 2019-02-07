using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSoTietKiem.DTO
{
    [Table("GiaoDich")]
    public class GiaoDichDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaCTGD { set; get; }
        public int MaSTK { get; set; }
        public int MaNV { get; set; }
        public int MaKHang { get; set; }
        public double SoTienGui { get; set; }
        public double? TongTienLai { get; set; }
        public double? TongTien { get; set; }
        public int MaQuayGD { get; set; }
        public byte LoaiGD { get; set; }
        public int MaKyH { get; set; }
        public string GhiChu { get; set; }
        public bool TinhTrang { get; set; }
        public DateTime NgayGiaoDich { get; set; }
        [ForeignKey("MaSTK")]
        public virtual SoTietKiemDto SoTietKiem { get; set; }
        [ForeignKey("MaQuayGD")]
        public virtual QuayGiaoDichDto QuayGiaoDich { get; set; }
        [ForeignKey("MaNV")]
        public virtual NhanVienDto NhanVien { get; set; }
        [ForeignKey("MaKHang")]
        public virtual KhachHangDto KhachHang { get; set; }
        [ForeignKey("MaKyH")]
        public virtual KyHanVayDto KyHanVay { get; set; }
    }
}
