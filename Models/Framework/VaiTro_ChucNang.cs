namespace Models.Framework
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VaiTro_ChucNang")]
    [Serializable]
    public class VaiTro_ChucNang
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        [DisplayName("Mã vai trò")]
        public string MaVaiTro { get; set; }

        [StringLength(50)]
        [Column(Order = 1)]
        [DisplayName("Mã chức năng")]
        public string MaChucNang { get; set; }

        [StringLength(50)]
        [Column(Order = 2)]
        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }

        public virtual VaiTro VaiTro { get; set; }

        public virtual ChucNang ChucNang { get; set; }
    }
}