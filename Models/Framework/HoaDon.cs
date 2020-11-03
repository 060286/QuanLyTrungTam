namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        public int MaHoaDon { get; set; }

        [Column(TypeName = "money")]
        public decimal? TongTien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLap { get; set; }

        public int? MaHocVien { get; set; }

        public virtual ChiTietHoaDon ChiTietHoaDon { get; set; }

        public virtual HocVien HocVien { get; set; }
    }
}
