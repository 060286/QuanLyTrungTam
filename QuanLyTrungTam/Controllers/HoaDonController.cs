using Models;
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
   
    public class HoaDonController : BaseController
    {
        // GET: HoaDon
        [HasCredential(Roles = "Xem_HoaDon")]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            ViewBag.Current = DateTime.UtcNow;
            var hoaDonDao = new HoaDonDao();
            var modelHoaDon = hoaDonDao.ListAllPaging(searchString, page, pageSize);
            
            return View(modelHoaDon);
        }

        // Thêm view như Giao Vien 
        [HasCredential(Roles = "Xem_HoaDon")]
        public ActionResult testSearchByStatus(string searchStatus, int page = 1, int pageSize = 10)
        {
            // Thêm view bag như Index
            
            var _daoHoaDon = new HoaDonDao();
            var _modalHoaDon = _daoHoaDon.ListAllPagingByStatus(searchStatus, page, pageSize);
            ViewBag.SearchStatus = searchStatus;
            return View(_modalHoaDon);
        }

        // Thêm view như Giao Vien 
        [HasCredential(Roles = "Xem_HoaDon")]
        public ActionResult testSearchByTotalMoney(string searchStatus, int page = 1, int pageSize = 10)
        {
            // Thêm view bag như Index

            var _daoHoaDon = new HoaDonDao();
            var _modalHoaDon = _daoHoaDon.ListAllPagingTotalMoney(searchStatus, page, pageSize);
            ViewBag.SearchStatus = searchStatus;
            return View(_modalHoaDon);
        }


        public void SetViewBagHoaDon(int? maHoaDon = null)
        {
            var khoaHocDao = new KhoaHocDao();
            ViewBag.MaKhoaHoc = new SelectList(khoaHocDao.ListAll(), "MaKhoaHoc", "TenKhoaHoc", maHoaDon);
        }

        public void SetViewBagLopHoc(int? maLopHoc = null)
        {
            var daoLopHoc = new LopHocDao();
            ViewBag.MaLopHoc = new SelectList(daoLopHoc.ListAll(), "MaLopHoc", "TenLopHoc", maLopHoc);
        }

        public void SetViewBagHV(int? maHocVien = null)
        {
            var daoHocVien = new HocVienDao();
            ViewBag.MaHocVien = new SelectList(daoHocVien.ListAll(), "MaHocVien", "TenHocVien", maHocVien);
        }

        // GET: HoaDon/Details/5
        public ActionResult Details(int id)
        {
            var hoaDon = new HoaDonDao().ViewDetail(id);

            return View();
        }

        // GET: HoaDon/Create
        public ActionResult Create()
        {
            SetViewBagHoaDon();
            SetViewBagLopHoc();
            SetViewBagHV();
            return View();
        }

        // POST: HoaDon/Create
        [HttpPost]
        public ActionResult Create(HoaDon hoaDon)
        {
            try
            {
                if(ModelState.IsValid)
                // TODO: Add insert logic here
                {
                    var hoaDonDao = new HoaDonDao();
                    hoaDon.NgayLap = DateTime.Now;
                    int maHoaDon = hoaDonDao.Insert(hoaDon);
                    if (maHoaDon > 0)
                    {
                        return RedirectToAction("Index", "HoaDon");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm thất bại");
                    }
                }
                SetViewBagHoaDon();
                SetViewBagLopHoc();
                SetViewBagHV();
                return View(hoaDon);
            }
            catch
            {
                return RedirectToAction("Index","HoaDon");
            }
        }

        // GET: HoaDon/Edit/5
        public ActionResult Edit(int id)
        {
            SetViewBagHoaDon();
            var _hocVien = new HocVienDao().ViewDetails(id);

            return View(_hocVien);
        }

        // POST: HoaDon/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                SetViewBagHoaDon();
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
        [HttpDelete]
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
