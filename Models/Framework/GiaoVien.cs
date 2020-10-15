namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiaoVien")]
    public partial class GiaoVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GiaoVien()
        {
            KhoaHocs = new HashSet<KhoaHoc>();
        }

        [Key]
        public int MaGiaoVien { get; set; }

        [StringLength(100,ErrorMessage ="Số ký tự tối đa là 100")]
        [DisplayName("Tên giáo viên")]
        [Required(ErrorMessage ="Vui lòng nhập tên giáo viên")]
        public string TenGiaoVien { get; set; }

        [DisplayName("Giới tính")]
        [StringLength(50)]
        public string GioiTinh { get; set; }

        [DisplayName("Ngày sinh")]
        //[Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [DisplayName("Ngày đăng ký")]
        [Column(TypeName = "date")]
        public DateTime? NgayDangKy { get; set; }

        [DisplayName("Email")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage ="Vui lòng nhập đúng định dạng email")]
        public string Email { get; set; }

        [DisplayName("Số điện thoại")]
        //[Phone(ErrorMessage ="Vui lòng nhập số điện thoại")]
        public int? SDT { get; set; }

        [DisplayName("Ghi chú")]
        [StringLength(100)]
        public string GhiChu { get; set; }

        [DisplayName("Địa chỉ")]
        [StringLength(200)]
        public string DiaChi { get; set; }

        [DisplayName("Quốc tịch")]
        [StringLength(50)]
        public string QuocTich { get; set; }

        [DisplayName("Trạng thái")]
        public bool? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoaHoc> KhoaHocs { get; set; }
    }
}
