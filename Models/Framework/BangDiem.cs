namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BangDiem")]
    public partial class BangDiem
    {
        [Key]
        public int MaBangDiem { get; set; }

        public double? KT1 { get; set; }

        public double? KT2 { get; set; }

        public double? THIL1 { get; set; }

        public int? MaKhoaHoc { get; set; }

        public double? KetQua { get; set; }

        public virtual KhoaHoc KhoaHoc { get; set; }
    }
}
