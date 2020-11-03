namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHoaDon { get; set; }

        public int MaKhoaHoc { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLap { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual KhoaHoc KhoaHoc { get; set; }
    }
}
