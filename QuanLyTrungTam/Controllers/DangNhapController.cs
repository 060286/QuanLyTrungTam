using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTrungTam.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap
        public ActionResult Index(DangNhap dn)
        {
            return View(dn);
        }

        // GET: DangNhap/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DangNhap/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DangNhap/Create
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

        // GET: DangNhap/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DangNhap/Edit/5
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

        // GET: DangNhap/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DangNhap/Delete/5
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
