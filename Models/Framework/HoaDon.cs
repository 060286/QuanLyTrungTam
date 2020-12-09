namespace Models.Framework
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        public int MaHoaDon { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Tổng tiền")]
        public decimal? TongTien { get; set; }
        [DisplayName("Trạng thái")]
        public bool? TinhTrang { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày lập hóa đơn")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayLap { get; set; }

        public int? MaKhoaHoc { get; set; }

        public int? MaLopHoc { get; set; }

        public int? MaHocVien { get; set; }

        public virtual KhoaHoc KhoaHoc { get; set; }

        public virtual HocVien HocVien { get; set; }

        public virtual LopHoc LopHoc { get; set; }
    }
}
