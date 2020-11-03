namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ThoiKhoaBieu")]
    public partial class ThoiKhoaBieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThoiKhoaBieu()
        {
            ChiTietKhoaHocs = new HashSet<ChiTietKhoaHoc>();
        }

        [Key]
        public int MaTKB { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TuanBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TuanKetThuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietKhoaHoc> ChiTietKhoaHocs { get; set; }
    }
}
