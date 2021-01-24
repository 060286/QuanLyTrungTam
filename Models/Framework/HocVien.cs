namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
        [DisplayName("Mã học viên")]
        public int MaHocVien { get; set; }

        [StringLength(100)]
        [DisplayName("Tên học viên")]
        public string TenHocVien { get; set; }

        [StringLength(100)]
        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }

        [StringLength(100)]
        [DisplayName("Tài khoản")]
        public string TaiKhoan { get; set; }

        [DisplayName("Hình ảnh")]
        public string HinhAnh { get; set; }

        public int? MaHVDD { get; set; }

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
        [DisplayName("Ngày đăng ký")]
        public DateTime? NgayDangKy { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }

        [DisplayName("Trạng thái")]
        public bool? TrangThai { get; set; }

        [StringLength(100)]
        [DisplayName("Nguồn")]
        public string Nguon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangDiem> BangDiems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual HV_DiemDanh HV_DiemDanh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhuHuynh> PhuHuynhs { get; set; }
    }
}
