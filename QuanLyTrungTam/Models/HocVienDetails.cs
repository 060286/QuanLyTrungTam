using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Framework;

namespace QuanLyTrungTam.Models
{
    public class HocVienDetails
    {
        public HocVien HocVien { get; set; }

        //public PhuHuynh PhuHuynh { get; set; } 
        public List<PhuHuynh> LstPhuHuynh { get; set; }
    }
}
