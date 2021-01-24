namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
        [DisplayName("Trình độ")]
        public int MaTrinhDo { get; set; }

        [DisplayName("Tên trình độ")]
        [StringLength(50)]
        public string TenTrinhDo { get; set; }

        [DisplayName("Ghi chú")]
        [StringLength(100)]
        public string GhiChu { get; set; }

        [DisplayName("Trạng thái")]
        public bool TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiaoVien> GiaoViens { get; set; }
    }
}
