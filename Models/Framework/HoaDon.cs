namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            CT_HoaDon = new HashSet<CT_HoaDon>();
        }

        [Key]
        [DisplayName("Mã hóa đơn")]
        public int MaHoaDon { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Tổng tiền")]
        public decimal? TongTien { get; set; }

        [DisplayName("Ngày lập")]
        public DateTime? NgayLap { get; set; }

        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }
        
        [DisplayName("Trạng thái")]
        public bool TinhTrang { get; set; } = true;

        [DisplayName("Chọn khóa học")]
        public int? MaKhoaHoc { get; set; }

        [DisplayName("Chọn lớp học")]
        public int? MaLopHoc { get; set; }

        [DisplayName("Chọn học viên" )]
        public int? MaHocVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HoaDon> CT_HoaDon { get; set; }

        public virtual HocVien HocVien { get; set; }

        public virtual LopHoc LopHoc { get; set; }
    }
}
