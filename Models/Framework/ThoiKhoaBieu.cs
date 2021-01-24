namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
        [DisplayName("Thời gian học")]
        public string ThoiGianHoc { get; set; }

        [DisplayName("Thứ hai")]
        public bool ThuHai { get; set; }

        [DisplayName("Thứ ba")]
        public bool ThuBa { get; set; }

        [DisplayName("Thứ tư")]
        public bool ThuTu { get; set; }

        [DisplayName("Thứ năm")]
        public bool ThuNam { get; set; }

        [DisplayName("Thứ sáu")]
        public bool ThuSau { get; set; }

        [DisplayName("Thứ bảy")]
        public bool ThuBay { get; set; }

        [DisplayName("Chủ nhật")]
        public bool ChuNhat { get; set; }

        [DisplayName("Mã khóa học")]
        public int? MaKhoaHoc { get; set; }

        public virtual KhoaHoc KhoaHoc { get; set; }
    }
}
