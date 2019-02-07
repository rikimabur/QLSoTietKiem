using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSoTietKiem.DTO
{
    [Table("NhanVien")]
    public class NhanVienDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNV { get; set; }
        public int MaQGD { get; set; }
        public string TenNhanVien { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public int ChucVu { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SoDT { get; set; }
        public bool TrangThai { set; get; }//Add field
        public bool DoiMatKhau { set; get; }
        [ForeignKey("MaQGD")]
        public virtual QuayGiaoDichDto QuayGiaoDich { get; set; }
        public virtual ICollection<TaiKhoanDto> TaiKhoan { get; set; }
        public virtual ICollection<GiaoDichDto> GiaoDich { get; set; }
        public virtual ICollection<SoTietKiemDto> SoTietKiem { get; set; }
        public virtual ChucVuDto ChucVuDto { get; set; }
    }
    [Table("ChucVu")]
    public class ChucVuDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaChucVu { get; set; }
        public string TenChucVu { get; set; }
        public bool TrangThai { get; set; }
        public virtual ICollection<NhanVienDto> NhanVien { get; set; }
    }
}
