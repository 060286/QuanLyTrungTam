namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HocVien")]
    public partial class HocVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HocVien()
        {
            BangDiems = new HashSet<BangDiem>();
            HoaDons = new HashSet<HoaDon>();
            PhuHuynhs = new HashSet<PhuHuynh>();
        }

        [Key]
        public int MaHocVien { get; set; }

        [StringLength(100)]
        public string TenHocVien { get; set; }

        [StringLength(50)]
        public string GioiTinh { get; set; }

        public int? SDT { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDangKy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        public string GhiChu { get; set; }

        public bool? TrangThai { get; set; }

        [StringLength(100)]
        public string Nguon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangDiem> BangDiems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhuHuynh> PhuHuynhs { get; set; }
    }
}
