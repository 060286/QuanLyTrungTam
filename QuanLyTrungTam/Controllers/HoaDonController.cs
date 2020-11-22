using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTrungTam.Controllers
{
    public class HoaDonController : BaseController
    {
        // GET: HoaDon
        public ActionResult Index()
        {
            return View();
        }

        // GET: HoaDon/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HoaDon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HoaDon/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HoaDon/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HoaDon/Edit/5
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

        // GET: HoaDon/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HoaDon/Delete/5
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
