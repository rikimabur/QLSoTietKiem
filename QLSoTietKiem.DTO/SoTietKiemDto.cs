using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSoTietKiem.DTO
{
    [Table("SoTietKiem")]
    public class SoTietKiemDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaSTK { get; set; }
        public DateTime NgayMo { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public DateTime NgayDenHan { get; set; }
        public double SoTienGui { get; set; }
        public int MaKyHan { get; set; }
        public int MaLoaiTien { get; set; }
        public int MaNV { get; set; }
        public int MaKhachHang { get; set; }
        public string GhiChu { get; set; }
        // cập nhật trạng thái nếu sổ đã được xóa
        public int TrangThai { get; set; }
        [ForeignKey("MaLoaiTien")]
        public virtual LoaiTienDto LoaiTien { get; set; }
        [ForeignKey("MaNV")]
        public virtual NhanVienDto NhanVien { get; set; }
        [ForeignKey("MaKhachHang")]
        public virtual KhachHangDto KhachHang { get; set; }
        [ForeignKey("MaKyHan")]
        public virtual KyHanVayDto KyHanVay { get; set; }
        public virtual ICollection<GiaoDichDto> GiaoDichChiTiet { get; set; }
    }
    public enum TrangThaiSo
    {
        [Description("Tạo sổ mới")]
        TrangThaiSoMoi = 0,
        [Description("Chuyễn trạng thái sang xóa sổ")] // xóa th gộp sổ
        TrangThaiXoaSo = 1,
    }
}
