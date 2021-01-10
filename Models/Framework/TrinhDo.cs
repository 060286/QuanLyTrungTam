namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrinhDo")]
    public partial class TrinhDo
    {
        [Key]
        public int MaTrinhDo { get; set; }

        [StringLength(50)]
        public string TenTrinhDo { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        public virtual GiaoVien GiaoVien { get; set; }
    }
}
