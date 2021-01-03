namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChucNang")]
    public partial class ChucNang
    {
        [Key]
        [StringLength(50)]
        public string MaChucNang { get; set; }

        [Required]
        [StringLength(50)]
        public string TenChucNang { get; set; }
    }
}
