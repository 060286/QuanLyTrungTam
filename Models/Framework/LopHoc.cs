namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LopHoc")]
    public partial class LopHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LopHoc()
        {
            BangDiems = new HashSet<BangDiem>();
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [DisplayName("Mã lớp học")]
        public int MaLopHoc { get; set; }

        [StringLength(100)]
        [DisplayName("Tên lớp hoc")]
        public string TenLopHoc { get; set; }

        [DisplayName("Tình trạng")]
        public bool? TinhTrang { get; set; }

        [DisplayName("Chọn giáo viên")]
        public int? MaGiaoVien { get; set; }

        [DisplayName("Chọn khóa học")]
        public int? MaKhoaHoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangDiem> BangDiems { get; set; }

        public virtual GiaoVien GiaoVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual KhoaHoc KhoaHoc { get; set; }

        public virtual LopHoc_Tuan LopHoc_Tuan { get; set; }
    }
}
