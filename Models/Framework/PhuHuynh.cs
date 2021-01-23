namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhuHuynh")]
    public partial class PhuHuynh
    {
        [Key]
        [DisplayName("Mã phụ huynh")]
        public int MaPhuHuynh { get; set; }

        [StringLength(100)]
        [DisplayName("Tên phụ huynh")]
        public string TenPhuHuynh { get; set; }

        [DisplayName("Số điện thoại")]
        public int? SDT { get; set; }

        [StringLength(50)]
        [DisplayName("Giới tính")]
        public string GioiTinh { get; set; }

        [StringLength(200)]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(200)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Mã học viên")]
        public int? MaHocVien { get; set; }

        public virtual HocVien HocVien { get; set; }
    }
}
