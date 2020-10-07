using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTrungTam.Code
{
    [Serializable] // => Tuần tự hóa ra nhị phân
    public class UserSession
    {
        public string TaiKhoan { set; get; }
    }
}