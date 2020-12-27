using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Framework;

namespace QuanLyTrungTam.Models
{
    public class KhoaHocDetailsModels
    {
        public KhoaHoc KhoaHoc { get; set; }

        //public DanhMucKhoaHoc DanhMucKhoaHoc { get; set; }

        public ThoiKhoaBieu ThoiKhoaBieu { get; set; }

        public int MaGiaoVien { get; set; }
    }
}