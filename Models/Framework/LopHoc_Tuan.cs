namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LopHoc_Tuan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã lớp học")]
        public int MaLopHoc { get; set; }

        [DisplayName("Mã tuần")]
        public int? MaTuan { get; set; }

        [DisplayName("Số giờ học")]
        public int? SoGio { get; set; }

        public virtual LopHoc LopHoc { get; set; }

        public virtual Tuan Tuan { get; set; }
    }
}
