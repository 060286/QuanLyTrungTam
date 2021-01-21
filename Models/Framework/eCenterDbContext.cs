using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.Framework
{
    public partial class eCenterDbContext : DbContext
    {
        public eCenterDbContext()
            : base("name=eCenterDbContext")
        {
        }

        public virtual DbSet<BangDiem> BangDiems { get; set; }
        public virtual DbSet<ChucNang> ChucNangs { get; set; }
        public virtual DbSet<DangNhap> DangNhaps { get; set; }
        public virtual DbSet<DanhMucKhoaHoc> DanhMucKhoaHocs { get; set; }
        public virtual DbSet<GiaoVien> GiaoViens { get; set; }
        public virtual DbSet<GV_DiemDanh> GV_DiemDanh { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<HV_DiemDanh> HV_DiemDanh { get; set; }
        public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }
        public virtual DbSet<LopHoc> LopHocs { get; set; }
        public virtual DbSet<LopHoc_Tuan> LopHoc_Tuan { get; set; }
        public virtual DbSet<PhuHuynh> PhuHuynhs { get; set; }
        public virtual DbSet<ThoiKhoaBieu> ThoiKhoaBieux { get; set; }
        public virtual DbSet<TrinhDo> TrinhDoes { get; set; }
        public virtual DbSet<Tuan> Tuans { get; set; }
        public virtual DbSet<VaiTro> VaiTroes { get; set; }
        public virtual DbSet<CT_HoaDon> CT_HoaDon { get; set; }
        public virtual DbSet<VaiTro_ChucNang> VaiTro_ChucNangs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GiaoVien>()
                .Property(e => e.MucLuong)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.CT_HoaDon)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhoaHoc>()
                .Property(e => e.GiaTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KhoaHoc>()
                .HasMany(e => e.CT_HoaDon)
                .WithRequired(e => e.KhoaHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LopHoc>()
                .HasOptional(e => e.LopHoc_Tuan)
                .WithRequired(e => e.LopHoc);

            modelBuilder.Entity<ThoiKhoaBieu>()
                .Property(e => e.ThoiGianHoc)
                .IsUnicode(false);
        }
    }
}
