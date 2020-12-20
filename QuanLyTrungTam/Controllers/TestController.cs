using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTrungTam.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public string Hello()
        {
            return "Hello";
        }

        public ActionResult TestPartialView()
        {
            eCenterDbContext db = new eCenterDbContext();

            
            return PartialView();
        }

        public ActionResult DemoAjax()
        {

            return View();
        }

        public ActionResult LoadAjaxActionLink()
        {

            return Content("Hello Ajax");
        }

        public ActionResult LoadAjaxBeginForm(FormCollection f)
        {
            string KQ = f["txt1"].ToString();
            return Content(KQ);
        }
    }
}