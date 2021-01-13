using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Framework;

namespace QuanLyTrungTam.Models
{
    public class ChiTietHocVienModel
    {
        public HocVien HocVien { set; get; }
        public PhuHuynh PhuHuynh { set; get; }

        public string TenHocVien { get; set; }
    }

}