namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrinhDo")]
    public partial class TrinhDo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrinhDo()
        {
            GiaoViens = new HashSet<GiaoVien>();
        }

        [Key]
        public int MaTrinhDo { get; set; }

        [StringLength(50)]
        public string TenTrinhDo { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        public bool TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiaoVien> GiaoViens { get; set; }
    }
}
