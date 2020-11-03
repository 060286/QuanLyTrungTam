namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietKhoaHoc")]
    public partial class ChiTietKhoaHoc
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaKhoaHoc { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaTKB { get; set; }

        public DateTime? GioBatDau { get; set; }

        // Thêm Thời lượng, Ngày Bắt Đầu, Ngày kết thúc

        [StringLength(50)]
        public string Phong { get; set; }

        public virtual KhoaHoc KhoaHoc { get; set; }

        public virtual ThoiKhoaBieu ThoiKhoaBieu { get; set; }
    }
}
