namespace Models.Framework
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;


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
        [DisplayName("Tên khóa học")]
        public string TenKhoaHoc { get; set; }

        [DisplayName("Số lượng")]
        public int? SoLuong { get; set; }

        [DisplayName("Tình trạng")]
        public int? TinhTrang { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Giá tiền")]
        public decimal? GiaTien { get; set; }

        [StringLength(100)]
        [DisplayName("Mô tả")]
        public string MoTa { get; set; }

        //public int? MaHocVien { get; set; }

        [DisplayName("Mã giáo viên ")]
        public int? MaGiaoVien { get; set; }
        [DisplayName("Số tuần")]
        public int? SoTuan { get; set; }
        [DisplayName("Mã Danh mục ")]
        public int? MaDanhMuc { get; set; }
        [DisplayName("Mã thời khóa biểu ")]
        public int? MaTKB { get; set; }

        [DisplayName("Lứa tuổi phù hợp")]
        public int? LuaTuoiPhuHop { get; set; }

        public virtual DanhMucKhoaHoc DanhMucKhoaHoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HoaDon> CT_HoaDon { get; set; }

        public virtual ThoiKhoaBieu ThoiKhoaBieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopHoc> LopHocs { get; set; }
    }
}
