namespace Models.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class eCenterDbContext : DbContext
    {
        public eCenterDbContext()
            : base("name=eCenterDbContext")
        {
        }

        public virtual DbSet<BangDiem> BangDiems { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<DangNhap> DangNhaps { get; set; }
        public virtual DbSet<GiaoVien> GiaoViens { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }
        public virtual DbSet<PhuHuynh> PhuHuynhs { get; set; }
        public virtual DbSet<ThoiKhoaBieu> ThoiKhoaBieux { get; set; }
        public virtual DbSet<ChiTietKhoaHoc> ChiTietKhoaHocs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HoaDon>()
                .HasOptional(e => e.ChiTietHoaDon)
                .WithRequired(e => e.HoaDon);

            modelBuilder.Entity<KhoaHoc>()
                .Property(e => e.HocPhi)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KhoaHoc>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.KhoaHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhoaHoc>()
                .HasMany(e => e.ChiTietKhoaHocs)
                .WithRequired(e => e.KhoaHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThoiKhoaBieu>()
                .HasMany(e => e.ChiTietKhoaHocs)
                .WithRequired(e => e.ThoiKhoaBieu)
                .WillCascadeOnDelete(false);
        }
    }
}
