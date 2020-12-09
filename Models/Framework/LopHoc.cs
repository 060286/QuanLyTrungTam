namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("LopHoc")]
    public partial class LopHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LopHoc()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaLopHoc { get; set; }

        [StringLength(100)]
        [DisplayName("Tên lớp học")]
        public string TenLopHoc { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày bắt đầu")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Vui lòng nhập ngày bắt đầu")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayBatDau { get; set; }

        [DisplayName("Tình trạng")]
        public bool? TinhTrang { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày kết thúc")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Vui lòng nhập ngày bắt đầu")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayKetThuc { get; set; }

        public int? MaGiaoVien { get; set; }

        public int? MaKhoaHoc { get; set; }

        public virtual GiaoVien GiaoVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual KhoaHoc KhoaHoc { get; set; }

        public virtual LopHoc_Tuan LopHoc_Tuan { get; set; }
    }
}
