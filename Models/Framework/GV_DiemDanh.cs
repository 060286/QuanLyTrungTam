namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GV_DiemDanh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GV_DiemDanh()
        {
            GiaoViens = new HashSet<GiaoVien>();
        }

        [Key]
        public int MaGVDD { get; set; }

        public int? TrangThai { get; set; }

        [StringLength(50)]
        public string GhiChu { get; set; }

        public bool ThuHai { get; set; } = false;

        public bool ThuBa { get; set; } = false;

        public bool ThuTu { get; set; } = false;

        public bool ThuNam { get; set; } = false;

        public bool ThuSau { get; set; } = false;

        public bool ThuBay { get; set; } = false;

        public bool ChuNhat { get; set; } = false;

        public DateTime Tuan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiaoVien> GiaoViens { get; set; }
    }
}
