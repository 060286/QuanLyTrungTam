namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tuan")]
    public partial class Tuan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tuan()
        {
            LopHoc_Tuan = new HashSet<LopHoc_Tuan>();
        }

        [Key]
        public int MaTuan { get; set; }

        [StringLength(50)]
        public string TenTuan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopHoc_Tuan> LopHoc_Tuan { get; set; }
    }
}
