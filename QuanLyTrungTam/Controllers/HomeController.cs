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
            ViewBag.TongTien = db.HoaDons.Sum(x => x.TongTien).Value.ToString("#,##").Replace(',', '.');
            ViewBag.HocVienDangKyMoi = db.HocViens.Where(x => x.NgayDangKy == DateTime.Today).Count();
            ViewBag.HocVienDangKyMoiTheoThang = db.HocViens.Where(x => x.NgayDangKy.Value.Month == DateTime.Today.Month).Count();
            return View();
        }

        public ActionResult GetData()
        {
            eCenterDbContext db = new eCenterDbContext();
            var query = db.HoaDons.Include("HoaDon")
                            .GroupBy(p => p.NgayLap.Value.Month)
                            .Select(g => new { name = g.Key, count = g.Sum(x => x.TongTien) });

            return Json(query, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataPieChart()
        {
            eCenterDbContext db = new eCenterDbContext();
            int male = db.GiaoViens.Where(x => x.GioiTinh == "Nam").Count();
            int female = db.GiaoViens.Where(x => x.GioiTinh == "Nữ").Count();

            Ratio obj = new Ratio();
            obj.Male = male;
            obj.Female = female;

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public class Ratio
        {
            public int Male {get;set;}
            public int Female {get;set;}
        }

    }
}
