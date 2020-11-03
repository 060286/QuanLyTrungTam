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
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            ChiTietKhoaHocs = new HashSet<ChiTietKhoaHoc>();
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
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual GiaoVien GiaoVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietKhoaHoc> ChiTietKhoaHocs { get; set; }
    }
}
