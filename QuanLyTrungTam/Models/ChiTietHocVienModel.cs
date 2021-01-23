using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Models.Framework;

namespace QuanLyTrungTam.Models
{
    public class ChiTietHocVienModel
    {
        public HocVien HocVien { set; get; }
        public PhuHuynh PhuHuynh { set; get; }

        [DisplayName("Tên học viên")]
        public string TenHocVien { get; set; }
    }

}