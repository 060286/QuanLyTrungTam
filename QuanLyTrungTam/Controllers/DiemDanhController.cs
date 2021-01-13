using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTrungTam.Controllers
{
    public class DiemDanhController : Controller
    {
        // GET: Điemanh
        public ActionResult Index()
        {
            return View();
        }

        // GET: Điemanh/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Điemanh/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Điemanh/Create
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

        // GET: Điemanh/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Điemanh/Edit/5
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

        // GET: Điemanh/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Điemanh/Delete/5
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
