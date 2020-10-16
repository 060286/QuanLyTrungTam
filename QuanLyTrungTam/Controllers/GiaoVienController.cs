using System.Web.Mvc;
using Models;
using Models.Framework;
using PagedList;
namespace QuanLyTrungTam.Controllers
{
    public class GiaoVienController : Controller
    {
        // GET: GiaoVien
        public ActionResult Index(int page = 1, int pageSize = 1)
        {
            var daoGiaoVien = new GiaoVienDao();
            var modelGiaoVien = daoGiaoVien.ListAllPaging(page, pageSize);

            return View(modelGiaoVien);
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
        public ActionResult Create(GiaoVien giaoVien)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var daoGiaoVien = new GiaoVienDao();
                    int layMaGiaoVien = daoGiaoVien.Insert(giaoVien);

                    if (layMaGiaoVien > 0)
                    {
                        return RedirectToAction("Index", "GiaoVien");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm thất bại");
                    }
                }
                return View(giaoVien);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: GiaoVien/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var _giaoVien = new GiaoVienDao().ViewDetail(id);

            return View(_giaoVien);
        }

        // POST: GiaoVien/Edit/5
        [HttpPost]
        public ActionResult Edit(GiaoVien giaoVien)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var daoGiaoVien = new GiaoVienDao();

                    var res = daoGiaoVien.Update(giaoVien);
                    if (res)
                    {
                        return RedirectToAction("Index", "GiaoVien");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm thất bại");
                    }
                }
                return View(giaoVien);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: GiaoVien/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: GiaoVien/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                new GiaoVienDao().Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}