using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Models.Framework;

namespace QuanLyTrungTam.Models
{
    public class KhoaHocDetailsModels
    {
        public KhoaHoc KhoaHoc { get; set; }

        //public DanhMucKhoaHoc DanhMucKhoaHoc { get; set; }
        [DisplayName("Mã giáo viên")]
        public int MaGiaoVien { get; set; }

        [DisplayName("Mã danh mục")]
        public int MaDanhMuc { get; set; }

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
    }
}