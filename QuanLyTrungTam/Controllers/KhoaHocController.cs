using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTrungTam.Controllers
{
    public class KhoaHocController : Controller
    {
        // GET: KhoaHoc
        public ActionResult Index(string searchString,int page = 1 ,int pageSize = 10)
        {
            var _khoaHocDao = new KhoaHocDao();
            var _modelKhoaHoc = _khoaHocDao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(_modelKhoaHoc);
        }

        // GET: KhoaHoc/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KhoaHoc/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhoaHoc/Create
        [HttpPost]
        public ActionResult Create(KhoaHoc khoaHoc)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var _khoaHocDao = new KhoaHocDao();

                    int _maKhoaHoc = _khoaHocDao.Insert(khoaHoc);

                    if (_maKhoaHoc > 0)
                    {
                        return RedirectToAction("Index", "KhoaHoc");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm thất bại");
                    }
                }
                return View(khoaHoc);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: KhoaHoc/Edit/5
        public ActionResult Edit(int id)
        {
            var _khoaHoc = new KhoaHocDao().ViewDetail(id);

            return View(_khoaHoc);
        }

        // POST: KhoaHoc/Edit/5
        [HttpPost]
        public ActionResult Edit(KhoaHoc khoaHoc)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var _daoKhoaHoc = new KhoaHocDao();

                    var res = _daoKhoaHoc.Update(khoaHoc);
                    if (res)
                    {
                        return RedirectToAction("Index", "KhoaHoc");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật lỗi");
                    }
                }
                return View(khoaHoc);
            }
            catch
            {
                return RedirectToAction("Index", "KhoaHoc");
            }
        }

        // GET: KhoaHoc/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: KhoaHoc/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                new KhoaHocDao().Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }
        }
    }
}
