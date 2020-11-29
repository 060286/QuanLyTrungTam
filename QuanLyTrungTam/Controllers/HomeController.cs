using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTrungTam.Controllers
{
    //[Authorize] // => Bắt buộc đăng nhập
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            eCenterDbContext db = new eCenterDbContext();
            ViewBag.GiaoVien = db.GiaoViens.Count();// return tổng số giáo viên
            ViewBag.HocVien = db.HocViens.Count();  // return tổng số học viên
            ViewBag.KhoaHoc = db.KhoaHocs.Count();  // return tổng số khóa hoc
            ViewBag.TongTien = db.HoaDons.Sum(x => x.TongTien);

            return View();
        }
    }
}