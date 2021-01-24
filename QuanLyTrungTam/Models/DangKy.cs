using Models.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace QuanLyTrungTam.Models
{
    [Serializable]
    public class DangKy
    {
        public HoaDon HoaDon { get; set; }

        public CT_HoaDon CT_HoaDon { get; set; }

        [DisplayName("Mã khóa học")]
        public int MaKhoaHoc { get; set; }

        [DisplayName("Mã lớp học")]
        public int MaLopHoc { get; set; }

        [DisplayName("Mã học viên")]
        public int MaHocVien { get; set; }
    }
}