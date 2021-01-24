namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
            ThoiKhoaBieux = new HashSet<ThoiKhoaBieu>();
        }

        [Key]
        [DisplayName("Mã khóa học")]
        public int MaKhoaHoc { get; set; }

        [StringLength(100)]
        [DisplayName("Tên khóa học")]
        public string TenKhoaHoc { get; set; }

        [DisplayName("Số lượng")]
        public int? SoLuong { get; set; }

        [DisplayName("Ngày kết thúc")]
        [Column(TypeName = "date")]
        public DateTime? NgayKetThuc { get; set; }

        [DisplayName("Trạng thái")]
        public bool? TinhTrang { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày bắt đầ")]
        public DateTime? NgayBatDau { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Giá tiền")]
        public decimal GiaTien { get; set; } 

        [StringLength(100)]
        [DisplayName("Mô tả")]
        public string MoTa { get; set; }

        [DisplayName("Mã giáo viên")]
        public int? MaGiaoVien { get; set; }

        [DisplayName("Số tuần")]
        public int? SoTuan { get; set; }

        [DisplayName("Mã danh mục")]
        public int? MaDanhMuc { get; set; }

        [DisplayName("Lứa tuổi phù hợp")]
        public int? LuaTuoiPhuHop { get; set; }

        public virtual DanhMucKhoaHoc DanhMucKhoaHoc { get; set; }

        public virtual GiaoVien GiaoVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HoaDon> CT_HoaDon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopHoc> LopHocs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThoiKhoaBieu> ThoiKhoaBieux { get; set; }
    }
}
