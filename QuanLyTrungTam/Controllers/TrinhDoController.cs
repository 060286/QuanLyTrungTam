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
    public class TrinhDoController : Controller
    {
        // GET: TrinhDo
        [HasCredential(Roles = "Xem_TrinhDo")]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var trinhDoDao = new TrinhDoDao();
            var modelTrinhDo = trinhDoDao.ListAllPaging(searchString, page, pageSize);

            return View(modelTrinhDo);
        }

        // GET: TrinhDo/Details/5
        public ActionResult Details(int id)
        {
            var model = new TrinhDoDao().ViewDetails(id);
            return View(model);
        }

        // GET: TrinhDo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrinhDo/Create
        [HttpPost]
        public ActionResult Create(TrinhDo trinhDo)
        {
            // TODO: Add insert logic here
            var trinhDoDao = new TrinhDoDao();

            int maTrinhDo = trinhDoDao.Insert(trinhDo);
            if (maTrinhDo > 0)
            {
                return RedirectToAction("Index", "TrinhDo");
            }
            else
            {
                ModelState.AddModelError("", "Thêm thất bại");
            }

            return View(trinhDo);


        }

        // GET: TrinhDo/Edit/5
        public ActionResult Edit(int id)
        {
            var trinhDo = new TrinhDoDao().ViewDetails(id);
            return View(trinhDo);
        }

        // POST: TrinhDo/Edit/5
        [HttpPost]
        public ActionResult Edit(TrinhDo trinhDo)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var _trinhDoDao = new TrinhDoDao();

                    var res = _trinhDoDao.Update(trinhDo);
                    if (res)
                    {
                        return RedirectToAction("Index", "TrinhDo");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật lỗi");
                    }
                }

                return View(trinhDo);
            }
            catch
            {
                return RedirectToAction("Index", "TrinhDo");
            }
        }

        // GET: TrinhDo/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: TrinhDo/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                new TrinhDoDao().Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
