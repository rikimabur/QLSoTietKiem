using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSoTietKiem.DTO
{
    [Table("TaiKhoan")]
    public class TaiKhoanDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTaiKhoan { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int MaNhanVien { get; set; }
        public int MaNhomTK { get; set; }
        public bool TrangThai { get; set; }
        [ForeignKey("MaNhanVien")]
        public virtual NhanVienDto NhanVien { get; set; }
        [ForeignKey("MaNhomTK")]
        public virtual NhomTaiKhoanDto NhomTaiKhoan { get; set; }
    }
}
