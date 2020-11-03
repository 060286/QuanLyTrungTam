using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTrungTam.Controllers
{
    public class HocVienController : Controller
    {
        // GET: HocVien
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var _daoHocVien = new HocVienDao();
            var _modelHocVien = _daoHocVien.ListAllPaging(page, pageSize);
            return View(_modelHocVien);
        }

        // GET: HocVien/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HocVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HocVien/Create
        [HttpPost]
        public ActionResult Create(HocVien hocVien)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var _daoHocVien = new HocVienDao();
                    int _maGiaoVien = _daoHocVien.Insert(hocVien);

                    if(_maGiaoVien > 0)
                    {
                        return RedirectToAction("Index", "HocVien");
                    }
                    else
                    {
                        ModelState.AddModelError("","Có lỗi khi thêm học viên");
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HocVien/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HocVien/Edit/5
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

        // GET: HocVien/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HocVien/Delete/5
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
