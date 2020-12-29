namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;
    using System.Web;

    [Table("GiaoVien")]
    public partial class GiaoVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GiaoVien()
        {
            LopHocs = new HashSet<LopHoc>();
        }

        [Key]
        public int MaGiaoVien { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Vui lòng nhập tên giáo viên")]
        [DisplayName("Tên giáo viên")]
        public string TenGiaoVien { get; set; }

        [DisplayName("File ảnh")]
        [StringLength(200)]
        public string HinhAnh { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Mức lương")]
        public decimal? MucLuong { get; set; }

        [DisplayName("Giới tính")]
        [Required(ErrorMessage = "Vui lòng nhập giới tính")]
        [StringLength(50)]
        public string GioiTinh { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập mật khẩu")]
        [StringLength(50)]
        public string MatKhau { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayName("Ngày sinh")]
        [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgaySinh { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayDangKy { get; set; }

        [StringLength(100)]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Vui lòng nhập email")]
        public string Email { get; set; }

        [DisplayName("Số điện thoại")]
        public int? SDT { get; set; }

        [StringLength(100)]
        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }

        [StringLength(10)]
        public string MaTrinhDo { get; set; }

        [StringLength(200)]
        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(50)]
        [DisplayName("Quốc tịch")]
        public string QuocTich { get; set; }

        [DisplayName("Tình trạng hoạt động")]
        [Required(ErrorMessage = "Vui lòng nhập trạng thái")]
        public bool? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopHoc> LopHocs { get; set; }

        public virtual TrinhDo TrinhDo { get; set; }
    }
}