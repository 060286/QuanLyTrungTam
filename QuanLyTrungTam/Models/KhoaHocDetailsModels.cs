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

        public int MaDanhMuc { get; set; }

        public bool ThuHai { get; set; }

        public bool ThuBa { get; set; }

        public bool ThuTu { get; set; }

        public bool ThuNam { get; set; }

        public bool ThuSau { get; set; }

        public bool ThuBay { get; set; }

        public bool ChuNhat { get; set; }


    }
}