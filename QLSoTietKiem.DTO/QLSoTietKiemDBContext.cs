using System.Data.Entity;

namespace QLSoTietKiem.DTO
{
    public class QLSoTietKiemDBContext : DbContext
    {
        public QLSoTietKiemDBContext() : base("QLSTKConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<KyHanVayDto> KyHanVay { set; get; }
        public DbSet<LoaiTienDto> LoaiTien { set; get; }
        public DbSet<NhomTaiKhoanDto> NhomTaiKhoan { set; get; }
        public DbSet<TaiKhoanDto> TaiKhoan { set; get; }
        public DbSet<QuayGiaoDichDto> QuayGiaoDich { set; get; }
        public DbSet<NhanVienDto> NhanVien { set; get; }
        public DbSet<KhachHangDto> KhachHang { set; get; }
        public DbSet<SoTietKiemDto> SoTietKiem { set; get; }
        public DbSet<GiaoDichDto> GiaoDich { set; get; }
        public DbSet<ChucVuDto> ChucVu { set; get; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SoTietKiemDto>()
                    .HasRequired(p => p.NhanVien)
                    .WithMany(t => t.SoTietKiem)
                    .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
