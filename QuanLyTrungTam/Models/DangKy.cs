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
        
        public int MaHocVien { get; set; }

        public string TenHocVien { get; set; }
    }
}