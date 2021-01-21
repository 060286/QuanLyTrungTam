using Models.DAO;
using Models.Framework;
using QuanLyTrungTam.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTrungTam.Controllers
{
    public class DanhMucKhoaHocController : Controller
    {
        // GET: DanhMucKhoaHoc
        //[HasCredential(Roles = "Xem_HoaDon")]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var danhMucDao = new DanhMucKhoaHocDao();
            var modelDanhMuc = danhMucDao.ListAllPaging(searchString, page, pageSize);

            return View(modelDanhMuc);
        }

        // GET: DanhMucKhoaHoc/Details/5
        public ActionResult Details(int id)
        {
            var danhMuc = new DanhMucKhoaHocDao().ViewDetails(id);

            return View(danhMuc);
        }

        // GET: DanhMucKhoaHoc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DanhMucKhoaHoc/Create
        [HttpPost]
        public ActionResult Create(DanhMucKhoaHoc danhMuc)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    var danhMucDao = new DanhMucKhoaHocDao();
                 
                    int maHoaDon = danhMucDao.Insert(danhMuc);
                    if (maHoaDon > 0)
                    {
                        return RedirectToAction("Index", "DanhMucHoaDon");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm thất bại");
                    }
                }
                return View(danhMuc);
            }
            catch
            {
                return View();
            }
        }

        // GET: DanhMucKhoaHoc/Edit/5
        public ActionResult Edit(int id)
        {
            var danhMuc = new DanhMucKhoaHocDao().ViewDetails(id);
            return View(danhMuc);
        }

        // POST: DanhMucKhoaHoc/Edit/5
        [HttpPost]
        public ActionResult Edit(DanhMucKhoaHoc _danhMuc)
        {
            try
            {
                // TODO: Add update logic here
                if(ModelState.IsValid)
                {
                    var _daoDanhMuc = new DanhMucKhoaHocDao();

                    var res = _daoDanhMuc.Update(_danhMuc);
                    if (res)
                    {
                        return RedirectToAction("Index", "DanhMucKhoaHoc");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật lỗi");
                    }
                }

                return View(_danhMuc);
            }
            catch
            {
                return RedirectToAction("Index", "DanhMucKhoaHoc");
            }
        }

        // GET: DanhMucKhoaHoc/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: DanhMucKhoaHoc/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                new DanhMucKhoaHocDao().Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
