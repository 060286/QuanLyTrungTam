using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTrungTam.Common
{
    [Serializable]
    public class UserLogin
    {
        public int UserId {set; get;}
        public string TaiKhoan { set; get; }
        public string MaVaiTro { get; set; }
    }
}