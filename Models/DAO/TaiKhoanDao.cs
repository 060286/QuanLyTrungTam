//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using Common1;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace Models
{
    public class TaiKhoanDao
    {
        private eCenterDbContext context = null;

        public TaiKhoanDao()
        {
            context = new eCenterDbContext();
        }

        //public bool Login(string taiKhoan, string matKhau)
        //{
        //    // Khởi tạo đối tượng tham số truyền vào bao gồm tài khoản + mật khẩu
        //    object[] sqlParams =
        //    {
        //    new SqlParameter("@TaiKhoan",taiKhoan),
        //    new SqlParameter("@MatKhau",matKhau),
        //};

        //    var res = context.Database.SqlQuery<bool>("Sp_TaiKhoan_DangNhap @TaiKhoan ,@MatKhau", sqlParams).SingleOrDefault();

        //    return res;
        //}

        public List<string> GetListCredential(string userName)
        {
            var user = context.DangNhaps.Single(x => x.TaiKhoan == userName);
            var data = (from a in context.VaiTro_ChucNangs
                        join b in context.VaiTroes on a.MaVaiTro equals b.MaVaiTro
                        join c in context.ChucNangs on a.MaChucNang equals c.MaChucNang
                        where b.MaVaiTro == user.MaVaiTro
                        select new
                        {
                            MaVaiTro = a.MaVaiTro,
                            MaChucNang = a.MaChucNang
                        }).AsEnumerable().Select(x => new VaiTro_ChucNang()
                        {
                            MaChucNang = x.MaChucNang,
                            MaVaiTro = x.MaVaiTro
                        });
            return data.Select(x => x.MaChucNang).ToList();
        }


        public int Login(string taiKhoan, string matKhau, bool isLoginAdmin = false)
        {
            var result = context.DangNhaps.SingleOrDefault(x => x.TaiKhoan == taiKhoan);

            if (result == null)
            {
                return 0;
            }
            else
            {
                //if(isLoginAdmin == true)
                //{
                //    {
                //        if (result.MaVaiTro == CommonConstants.ADMIN_GROUP || result.MaVaiTro == CommonConstants.USER_GROUP)
                //        {
                //            if (result.MatKhau == matKhau)
                //            {
                //                return 1;
                //            }
                //            else
                //                return -1;
                //        }
                //    }
                //    return 2;
                //}

                if (result.TrangThai == false)
                {
                    return -1;
                }
                else
                {
                    if (result.MatKhau == matKhau)
                        return 1;
                    else
                        return -2;
                }
            }
        }


        public int Insert(DangNhap entity)
        {
            context.DangNhaps.Add(entity);
            context.SaveChanges();
            return entity.MaTaiKhoan;
        }

        public DangNhap GetById(string taiKhoan)
        {
            return context.DangNhaps.SingleOrDefault(x => x.TaiKhoan == taiKhoan);
        }
    }

}
