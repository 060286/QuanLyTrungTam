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
            CT_HoaDon = new HashSet<CT_HoaDon>();
            LopHocs = new HashSet<LopHoc>();
        }

        [Key]
        public int MaKhoaHoc { get; set; }

        [StringLength(100)]
        public string TenKhoaHoc { get; set; }

        public int? SoLuong { get; set; }

        public int? TinhTrang { get; set; }

        [Column(TypeName = "money")]
        public decimal GiaTien { get; set; } 

        [StringLength(100)]
        public string MoTa { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayKetThuc { get; set; }

        public int? MaGiaoVien { get; set; }

        public int? SoTuan { get; set; }

        public int? MaDanhMuc { get; set; }

        public int? MaTKB { get; set; }

        public int? LuaTuoiPhuHop { get; set; }

        public virtual DanhMucKhoaHoc DanhMucKhoaHoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HoaDon> CT_HoaDon { get; set; }

        public virtual ThoiKhoaBieu ThoiKhoaBieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopHoc> LopHocs { get; set; }
    }
}
