namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("HocVien")]
    public partial class HocVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HocVien()
        {
            BangDiems = new HashSet<BangDiem>();
            HoaDons = new HashSet<HoaDon>();
            PhuHuynhs = new HashSet<PhuHuynh>();
        }

        [Key]
        
        public int MaHocVien { get; set; }
        [DisplayName("Tên học viên")]
        [StringLength(100)]
        public string TenHocVien { get; set; }

        [StringLength(50)]
        [DisplayName("Giới tính")]
        public string GioiTinh { get; set; }

        [DisplayName("Số điện thoại")]
        public int? SDT { get; set; }

        [StringLength(100)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [StringLength(200)]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDangKy { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayName("Ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NgaySinh { get; set; }

        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }

        [DisplayName("Trạng th")]
        public bool? TrangThai { get; set; }

        [StringLength(100)]
        [DisplayName("Nguồn")]
        public string Nguon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangDiem> BangDiems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhuHuynh> PhuHuynhs { get; set; }
    }
}
