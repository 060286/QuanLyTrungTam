namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    public partial class LopHoc_Tuan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaLopHoc { get; set; }
        
        public int? MaTuan { get; set; }
        [DisplayName("Số giờ")]
        public int? SoGio { get; set; }

        public virtual LopHoc LopHoc { get; set; }

        public virtual Tuan Tuan { get; set; }
    }
}
