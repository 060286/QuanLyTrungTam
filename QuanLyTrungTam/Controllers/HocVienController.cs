using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTrungTam.Controllers
{
    public class HocVienController : BaseController
    {
        // GET: HocVien
        public ActionResult Index(string searchString,int page = 1, int pageSize = 10)
        {
            var _daoHocVien = new HocVienDao();
            var _modelHocVien = _daoHocVien.ListAllPaging(searchString,page, pageSize);
            return View(_modelHocVien);
        }

        // GET: HocVien/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HocVien/Create
        [HttpGet]
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
                    hocVien.NgayDangKy = DateTime.Now;
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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var _hocVien = new HocVienDao().ViewDetails(id);

            return View(_hocVien);
        }

        // POST: HocVien/Edit/5
        [HttpPost]
        public ActionResult Edit(HocVien hocVien)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var _daoGiaoVien = new HocVienDao();

                    var res = _daoGiaoVien.Update(hocVien);
                    if (res)
                    {
                        return RedirectToAction("Index", "GiaoVien");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật thất bại");
                    }
                }
                return View(hocVien);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: HocVien/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: HocVien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                new HocVienDao().Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}


