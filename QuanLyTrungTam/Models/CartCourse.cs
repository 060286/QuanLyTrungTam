using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTrungTam.Models
{
    [Serializable]
    public class CartCourse
    {
        public KhoaHoc KhoaHoc { get; set; }

        public int SoLuong { get; set; }


    }
}