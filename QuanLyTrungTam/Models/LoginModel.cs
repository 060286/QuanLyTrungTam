using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyTrungTam.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Nhập tài khoản")]
        public string TaiKhoan { set; get; }

        [Required(ErrorMessage = "Nhập mật khẩu")]
        public string MatKhau { set; get; }
        
        
        public bool TinhTrang { set; get; }
    }
}