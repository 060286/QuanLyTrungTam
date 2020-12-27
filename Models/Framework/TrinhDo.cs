namespace Models.Framework
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;

    [Table("TrinhDo")]
    public partial class TrinhDo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã trình độ")]
        public int MaTrinhDo { get; set; }

        [StringLength(50)]
        [DisplayName("Tên trình độ")]
        public string TenTrinhDo { get; set; }

        [StringLength(100)]
        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }

        public virtual GiaoVien GiaoVien { get; set; }
    }
}