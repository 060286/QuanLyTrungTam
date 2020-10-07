using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyTrungTam.Models
{
    public class LoginModel
    {
        [Required]
        public string TaiKhoan { set; get; }

       
        public string MatKhau { set; get; }
        
        
        public bool TinhTrang { set; get; }
    }
}