using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTrungTam.Models
{
    [Serializable]
    public class DangKy
    {
        public HoaDon HoaDon { get; set; }

        public CT_HoaDon CT_HoaDon { get; set; }

        public int MaKhoaHoc { get; set; }

        public int MaLopHoc { get; set; }

        public int MaHocVien { get; set; }
    }
}