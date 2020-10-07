//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace Models
{
    public class TaiKhoanModel
    {
        private eCenterDbContext context = null;

        public TaiKhoanModel()
        {
            context = new eCenterDbContext();
        }

        public bool Login(string taiKhoan, string matKhau)
        {
            // Khởi tạo đối tượng tham số truyền vào bao gồm tài khoản + mật khẩu
            object[] sqlParams =
            {
            new SqlParameter("@TaiKhoan",taiKhoan),
            new SqlParameter("@MatKhau",matKhau),
        };

            var res = context.Database.SqlQuery<bool>("Sp_TaiKhoan_DangNhap @TaiKhoan ,@MatKhau", sqlParams).SingleOrDefault();

            return res;
        }
    }
    
}
