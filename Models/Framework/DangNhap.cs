namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DangNhap")]
    public partial class DangNhap
    {
        [Key]
        [DisplayName("Mã tài khoản")]
        public int MaTaiKhoan { get; set; }

        [StringLength(100)]
        [DisplayName("Tên người dùng")]
        public string TenNguoiDung { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Tài khoản")]
        public string TaiKhoan { get; set; }

        [StringLength(50)]
        [DisplayName("Mã vai trò")]
        public string MaVaiTro { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }

        [DisplayName("Trạng thái")]
        public bool TrangThai { get; set; }

        public virtual VaiTro VaiTro { get; set; }
    }
}
