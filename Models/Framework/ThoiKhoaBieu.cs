namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThoiKhoaBieu")]
    public partial class ThoiKhoaBieu
    {
        [Key]
        public int MaTKB { get; set; }

        //[Column(TypeName = "date")]
        //public DateTime? TuanBatDau { get; set; }

        public int? ThoiGianHoc { get; set; }

        //[Column(TypeName = "date")]
        //public DateTime? TuanKetThuc { get; set; }

        public bool ThuHai { get; set; } = false;

        public int? MaKhoaHoc { get; set; }

        public bool ThuBa { get; set; } = false;

        public bool ThuTu { get; set; } = false;

        public bool ThuNam { get; set; } = false;

        public bool ThuSau { get; set; } = false;

        public bool ThuBay { get; set; } = false;

        public bool ChuNhat { get; set; } = false;

        public virtual KhoaHoc KhoaHoc { get; set; }
    }
}
