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
            LopHocs = new HashSet<LopHoc>();
        }

        [Key]
        [DisplayName("Mã giáo viên")]
        public int MaGiaoVien { get; set; }

        [StringLength(100)]
        [DisplayName("Tên giáo viên")]
        public string TenGiaoVien { get; set; }

        [DisplayName("Hình ảnh")]
        public string HinhAnh { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Mức lương")]
        public decimal? MucLuong { get; set; }

        [StringLength(50)]
        [DisplayName("Giới tính")]
        public string GioiTinh { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày đăng ký")]
        public DateTime? NgayDangKy { get; set; }

        [StringLength(50)]
        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }

        [DisplayName("Mã giáo viên điểm danh")]
        public int? MaGVDD { get; set; }

        [StringLength(100)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Số điện thoại")]
        public int? SDT { get; set; }

        [StringLength(100)]
        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }

        [DisplayName("Mã trình độ")]
        public int? MaTrinhDo { get; set; }

        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(50)]
        [DisplayName("Quốc tịch")]
        public string QuocTich { get; set; }

        [DisplayName("Trạng thái")]
        public bool? TrangThai { get; set; }

        public virtual GV_DiemDanh GV_DiemDanh { get; set; }

        public virtual TrinhDo TrinhDo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoaHoc> KhoaHocs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopHoc> LopHocs { get; set; }
    }
}
