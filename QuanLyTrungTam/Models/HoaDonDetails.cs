using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTrungTam.Models
{
    public class HoaDonDetails
    {
       public HoaDon HoaDon { get; set; }

       public CT_HoaDon CT_HoaDon { get; set; }

       public LopHoc LopHoc { get; set; }

       public HocVien HocVien { get; set; }
    }
}