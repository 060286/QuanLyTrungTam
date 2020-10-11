namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhuHuynh")]
    public partial class PhuHuynh
    {
        [Key]
        public int MaPhuHuynh { get; set; }

        [StringLength(100)]
        public string TenPhuHuynh { get; set; }

        public int? SDT { get; set; }

        [StringLength(50)]
        public string GioiTinh { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        public bool? TinhTrang { get; set; }

        public int? MaHocVien { get; set; }

        public virtual HocVien HocVien { get; set; }
    }
}
