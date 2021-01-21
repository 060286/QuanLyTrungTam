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

        [Required]
        [StringLength(50)]
        [DataType(DataType.Time)]
        public string ThoiGianHoc { get; set; }

        public bool ThuHai { get; set; }

        public bool ThuBa { get; set; }

        public bool ThuTu { get; set; }

        public bool ThuNam { get; set; }

        public bool ThuSau { get; set; }

        public bool ThuBay { get; set; }

        public bool ChuNhat { get; set; }

        public int? MaKhoaHoc { get; set; }

        public virtual KhoaHoc KhoaHoc { get; set; }
    }
}
