namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            CT_HoaDon = new HashSet<CT_HoaDon>();
        }

        [Key]
        public int MaHoaDon { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Tổng tiền")]
        public decimal? TongTien { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày lập hóa đơn")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayLap { get; set; }

        [DisplayName("Thanh toán")]
        public bool? TinhTrang { get; set; }
        [DisplayName("Mã khóa học ")]
        public int? MaKhoaHoc { get; set; }
        [DisplayName("Mã lớp học ")]
        public int? MaLopHoc { get; set; }
        [DisplayName("Mã học viên ")]
        public int? MaHocVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HoaDon> CT_HoaDon { get; set; }

        public virtual HocVien HocVien { get; set; }

        public virtual LopHoc LopHoc { get; set; }
    }
}
