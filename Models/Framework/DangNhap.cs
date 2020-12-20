namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("DangNhap")]
    public partial class DangNhap
    {
        [Key]
        public int MaTaiKhoan { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Tài khoản")]
        public string TaiKhoan { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }

        public bool? TrangThai { get; set; }
    }
}