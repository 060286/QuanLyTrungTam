using Models.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyTrungTam.ViewModels
{
    public class HocVienViewModels
    {
        [Key]
        public int MaHocVien { get; set; }

        [StringLength(100)]
        public string TenHocVien { get; set; }

        [StringLength(100)]
        public string MatKhau { get; set; }

        [StringLength(100)]
        public string TaiKhoan { get; set; }

        public string HinhAnh { get; set; }

        public int? MaHVDD { get; set; }

        [StringLength(50)]
        public string GioiTinh { get; set; }

        public int? SDT { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDangKy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        public string GhiChu { get; set; }

        public bool? TrangThai { get; set; }

        [StringLength(100)]
        public string Nguon { get; set; }

         
    }
}