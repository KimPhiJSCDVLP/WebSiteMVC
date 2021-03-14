using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebSiteBanHangMVC.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<CTSanPham> CTSanPhams { get; set; }
        public virtual DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; }
        public virtual DbSet<DiaChiNhanHang> DiaChiNhanHangs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiDanhMucSanPham> LoaiDanhMucSanPhams { get; set; }
        public virtual DbSet<LoaiThongSo> LoaiThongSoes { get; set; }
        public virtual DbSet<LoSanPham> LoSanPhams { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhapKho> NhapKhoes { get; set; }
        public virtual DbSet<PhanLoaiSanPham> PhanLoaiSanPhams { get; set; }
        public virtual DbSet<QuanHuyen> QuanHuyens { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<SanPhamDonHang> SanPhamDonHangs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThanhPho> ThanhPhoes { get; set; }
        public virtual DbSet<ThongSoSanPham> ThongSoSanPhams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<XaPhuong> XaPhuongs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Content>()
                .Property(e => e.Detail)
                .IsFixedLength();

            modelBuilder.Entity<Content>()
                .Property(e => e.Warranty)
                .IsFixedLength();

            modelBuilder.Entity<Content>()
                .Property(e => e.MetaKeywords)
                .IsUnicode(false);

            modelBuilder.Entity<Content>()
                .Property(e => e.MetaDescriptions)
                .IsUnicode(false);

            modelBuilder.Entity<Content>()
                .Property(e => e.Tags)
                .IsUnicode(false);

            modelBuilder.Entity<Content>()
                .Property(e => e.Language)
                .IsFixedLength();

            modelBuilder.Entity<CTSanPham>()
                .Property(e => e.AnhSanPham)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<LoSanPham>()
                .Property(e => e.SoSerie)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<PhanLoaiSanPham>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.PhanLoaiSanPham)
                .HasForeignKey(e => e.LoaiSanPhamID);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.AnhSanPham)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaSanPham)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PasswordSalt)
                .IsUnicode(false);

            modelBuilder.Entity<UserGroup>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.UserGroup)
                .HasForeignKey(e => e.GroupID);

            modelBuilder.Entity<XaPhuong>()
                .HasMany(e => e.DiaChiNhanHangs)
                .WithOptional(e => e.XaPhuong)
                .HasForeignKey(e => e.XqaPhuongID);
        }
    }
}
