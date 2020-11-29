namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

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
        [DisplayName("Tên giáo viên")]
        public string TenGiaoVien { get; set; }
        [DisplayName("Giới tính")]
        [StringLength(50)]
        public string GioiTinh { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayName("Ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NgaySinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDangKy { get; set; }

        [StringLength(100)]
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Số điện thoại")]
        public int? SDT { get; set; }

        [StringLength(100)]
        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }

        [StringLength(200)]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(50)]
        [DisplayName("Quốc tịch")]
        public string QuocTich { get; set; }

        [DisplayName("Trạng thái")]
        public bool? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopHoc> LopHocs { get; set; }
    }
}
