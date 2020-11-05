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
        public virtual DbSet<DangNhap> DangNhaps { get; set; }
        public virtual DbSet<DanhMucKhoaHoc> DanhMucKhoaHocs { get; set; }
        public virtual DbSet<GiaoVien> GiaoViens { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }
        public virtual DbSet<LopHoc> LopHocs { get; set; }
        public virtual DbSet<LopHoc_Tuan> LopHoc_Tuan { get; set; }
        public virtual DbSet<PhuHuynh> PhuHuynhs { get; set; }
        public virtual DbSet<ThoiKhoaBieu> ThoiKhoaBieux { get; set; }
        public virtual DbSet<Tuan> Tuans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LopHoc>()
                .HasOptional(e => e.LopHoc_Tuan)
                .WithRequired(e => e.LopHoc);
        }
    }
}
