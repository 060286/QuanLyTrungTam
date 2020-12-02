using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTrungTam.Common
{
    [Serializable]
    public class TaiKhoanLogin
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}