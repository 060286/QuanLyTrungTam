using System.Web.Mvc;
using Models;
using Models.Framework;

namespace QuanLyTrungTam.Controllers
{
    public class GiaoVienController : Controller
    {
        // GET: GiaoVien
        public ActionResult Index()
        {
            var iplGv = new GiaoVienDao();
            var model = iplGv.listAll();

            return View(model);
        }

        // GET: GiaoVien/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GiaoVien/Create
        [HttpGet]
        public ActionResult Create()
        {
            //var dao = new GiaoVienDao();

            return View();
        }

        // POST: GiaoVien/Create
        [HttpPost]
        public ActionResult Create(GiaoVien gv)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dao = new GiaoVienDao();
                    int id = dao.Insert(gv);
                    if(id>0)
                    {
                        return RedirectToAction("Index", "GiaoVien");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm thất bại");
                    }
                }
                return View(gv);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: GiaoVien/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GiaoVien/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GiaoVien/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GiaoVien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
