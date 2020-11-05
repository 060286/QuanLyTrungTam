namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiaoVien")]
    public partial class GiaoVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GiaoVien()
        {
            LopHocs = new HashSet<LopHoc>();
        }

        [Key]
        public int MaGiaoVien { get; set; }

        [StringLength(100)]
        public string TenGiaoVien { get; set; }

        [StringLength(50)]
        public string GioiTinh { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NgaySinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDangKy { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int? SDT { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string QuocTich { get; set; }

        public bool? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopHoc> LopHocs { get; set; }
    }
}
