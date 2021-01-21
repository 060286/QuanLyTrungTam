namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HV_DiemDanh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HV_DiemDanh()
        {
            HocViens = new HashSet<HocVien>();
        }

        [Key]
        public int MaHVDD { get; set; }

        public int? TinhTrang { get; set; }

        [StringLength(50)]
        public string GhiChu { get; set; }

        public bool ThuHai { get; set; }

        public bool ThuBa { get; set; }

        public bool ThuTu { get; set; }

        public bool ThuNam { get; set; }

        public bool ThuSau { get; set; }

        public bool ThuBay { get; set; }

        public bool ChuNhat { get; set; }

        [Column(TypeName = "date")]
        public DateTime Tuan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocVien> HocViens { get; set; }
    }
}
