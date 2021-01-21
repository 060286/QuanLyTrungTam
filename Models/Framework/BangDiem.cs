namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BangDiem")]
    public partial class BangDiem
    {
        [Key]
        [DisplayName("Mã bảng điểm")]
        public int MaBangDiem { get; set; }

        [DisplayName("Điểm kiểm tra đợt 1")]
        public double? KT1 { get; set; }
        [DisplayName("Điểm kiểm tra đợt 2")]
        public double? KT2 { get; set; }
        [DisplayName("Điểm thi lần 1")]
        public double? THIL1 { get; set; }
        [DisplayName("Mã học viên")]
        public int? MaHocVien { get; set; }
        [DisplayName("Mã lớp học")]
        public int? MaLopHoc { get; set; }
        [DisplayName("Kết quả cuối kỳ")]
        public double? KetQua { get; set; }

        public virtual HocVien HocVien { get; set; }

        public virtual LopHoc LopHoc { get; set; }
    }
}
