namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucKhoaHoc")]
    public partial class DanhMucKhoaHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMucKhoaHoc()
        {
            KhoaHocs = new HashSet<KhoaHoc>();
        }

        [Key]
        [DisplayName("Mã danh mục")]
        public int MaDanhMuc { get; set; }

        [StringLength(100)]
        [DisplayName("Tên danh mục")]
        public string TenDanhMuc { get; set; }

        [DisplayName("Tình trạng")]
        public bool TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoaHoc> KhoaHocs { get; set; }
    }
}
