namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChucNang")]
    public partial class ChucNang
    {
        [Key]
        [StringLength(50)]
        [DisplayName("Mã chức năng")]
        public string MaChucNang { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Tên chức năng")]
        public string TenChucNang { get; set; }
    }
}
