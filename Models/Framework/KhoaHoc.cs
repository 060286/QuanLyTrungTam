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
            LopHocs = new HashSet<LopHoc>();
        }

        [Key]
        public int MaKhoaHoc { get; set; }

        [StringLength(100)]
        public string TenKhoaHoc { get; set; }

        public int? TinhTrang { get; set; }

        [StringLength(100)]
        public string MoTa { get; set; }

        public int? MaHocVien { get; set; }

        public int? MaGiaoVien { get; set; }

        public int? SoTuan { get; set; }

        public int? MaDanhMuc { get; set; }

        public int? LuaTuoiPhuHop { get; set; }

        public virtual DanhMucKhoaHoc DanhMucKhoaHoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopHoc> LopHocs { get; set; }
    }
}
