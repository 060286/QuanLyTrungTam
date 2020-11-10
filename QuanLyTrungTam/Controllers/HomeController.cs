using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTrungTam.Controllers
{
    [Authorize] // => Bắt buộc đăng nhập
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string hello()
        {



            return "HelloWorld";
        }
    }
}