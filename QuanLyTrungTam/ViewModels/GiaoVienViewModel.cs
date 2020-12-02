using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyTrungTam.ViewModels
{
    public class GiaoVienViewModel
    {
        [Key]
        public int MaGiaoVien { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Vui lòng nhập tên giáo viên")]
        [DisplayName("Tên giáo viên")]
        public string TenGiaoVien { get; set; }

        [DisplayName("Giới tính")]
        [Required(ErrorMessage = "Vui lòng nhập giới tính")]
        [StringLength(50)]
        public string GioiTinh { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayName("Ngày sinh")]
        [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NgaySinh { get; set; }

        [Column(TypeName = "date")]
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

        [StringLength(200)]
        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(50)]
        [DisplayName("Quốc tịch")]
        public string QuocTich { get; set; }

        [DisplayName("Trạng thái")]
        [Required(ErrorMessage = "Vui lòng nhập trạng thái")]
        public bool? TrangThai { get; set; }
    }
}