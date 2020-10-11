namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhoaHoc")]
    public partial class KhoaHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhoaHoc()
        {
            BangDiems = new HashSet<BangDiem>();
            CTKhoaHocs = new HashSet<CTKhoaHoc>();
        }

        [Key]
        public int MaKhoaHoc { get; set; }

        [StringLength(100)]
        public string TenKhoaHoc { get; set; }

        [StringLength(100)]
        public string MoTa { get; set; }

        public int? MaHocVien { get; set; }

        public int? MaGiaoVien { get; set; }

        [Column(TypeName = "money")]
        public decimal? HocPhi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangDiem> BangDiems { get; set; }

        public virtual GiaoVien GiaoVien { get; set; }

        public virtual HocVien HocVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTKhoaHoc> CTKhoaHocs { get; set; }
    }
}
