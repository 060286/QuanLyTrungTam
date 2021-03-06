﻿using Models;
using Models.DAO;
using Models.Framework;
using QuanLyTrungTam.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using QuanLyTrungTam.Models;
using QuanLyTrungTam.ViewModels;

namespace QuanLyTrungTam.Controllers
{
   
    public class HoaDonController : BaseController
    {
        private eCenterDbContext db = new eCenterDbContext();
        // GET: HoaDon
        //[HasCredential(Roles = "Xem_HoaDon")]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            ViewBag.Current = DateTime.UtcNow;
            ViewBag.DoanhThuHomNay = db.HoaDons.Where(i => i.NgayLap.Value.Day == DateTime.Now.Day 
                                                && i.NgayLap.Value.Year == DateTime.Now.Year)
                                                .Sum(i => i.TongTien).GetValueOrDefault(0).ToString("#,##").Replace(',', '.');

            ViewBag.DoanhThuThangNay = db.HoaDons.Where(i => i.NgayLap.Value.Month == DateTime.Now.Month 
                                                         && i.NgayLap.Value.Year == DateTime.Now.Year)
                                                        .Sum(i => i.TongTien).GetValueOrDefault(0).ToString("#,##").Replace(',', '.');

            ViewBag.TongHoaDonHomNay = db.HoaDons.Where(i => i.NgayLap.Value.Day == DateTime.Now.Day
                                                && i.NgayLap.Value.Year == DateTime.Now.Year)
                                                .Count();

            ViewBag.TongHoaDonThangNay = db.HoaDons.Where(i => i.NgayLap.Value.Month == DateTime.Now.Month
                                                   && i.NgayLap.Value.Year == DateTime.Now.Year)
                                                   .Count();

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

            ViewBag.TenHocVien = new HocVienDao().ViewDetails(hoaDon.MaHocVien.GetValueOrDefault(0)).TenHocVien;
            ViewBag.TenLopHoc = new LopHocDao().ViewDetail(hoaDon.MaLopHoc.GetValueOrDefault(0)).TenLopHoc;
            ViewBag.TenKhoaHoc = new KhoaHocDao().ViewDetail(hoaDon.MaKhoaHoc.GetValueOrDefault(0)).TenKhoaHoc;

            return View(hoaDon);
        }

        [HttpGet] 
        public ActionResult CreateDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDetails(HoaDonDetails hoaDonDetails)
        {
            var hoaDonDao = new HoaDonDao();
            var ctHDDao = new CT_HoaDonDao();
            var lopHocDao = new LopHocDao();
            var hocVienDao = new HocVienDao();

            var hocVien = new HocVien();
            var ctHD = new CT_HoaDon();
            var lopHoc = new LopHoc();
            var hoaDon = new HoaDon();

            return RedirectToAction("Index");
        }

        // GET: HoaDon/Create
        [HttpGet]
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
            var _hocVien = new HoaDonDao().ViewDetail(id);

            return View(_hocVien);
        }

        // POST: HoaDon/Edit/5
        [HttpPost]
        public ActionResult Edit(HoaDon _hoaDon)
        {
            try
            {
                // TODO: Add update logic here
                var _hoaDonDao = new HoaDonDao();

                var res = _hoaDonDao.Update(_hoaDon);
                if (res)
                {


                    return RedirectToAction("Index", "HoaDon");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật lỗi");
                }

                SetViewBagHoaDon();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HoaDon/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: HoaDon/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                new HoaDonDao().Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public JsonResult GetData()
        {
            eCenterDbContext db = new eCenterDbContext();
            var query = db.HoaDons.Include("HoaDon")
                            .Where(i=>i.NgayLap.Value.Month == DateTime.Now.Month)
                            .GroupBy(p => p.NgayLap.Value.Day )
                            .Select(g => new { name = g.Key, count = g.Sum(x => x.TongTien) });

            return Json(query, JsonRequestBehavior.AllowGet);
        }


        public void DanhSachHoaDon()
        {
            List<HoaDonViewModels> hoaDonList = db.HoaDons.Select(x => new HoaDonViewModels
            {
                MaHoaDon = x.MaHoaDon,
                NgayLap = x.NgayLap,
                TinhTrang = x.TinhTrang,
                MaHocVien = x.MaHocVien,
                MaKhoaHoc = x.MaKhoaHoc,
            }).ToList();

        }

        public ActionResult ChiTietHoaDon(int id)
        {
            var hoaDonDao = new HoaDonDao().ViewDetail(id);

            var ctHDDao = new HoaDonDao().getBill(id);

            var details = new HoaDonViewModels();

            details.MaHoaDon = hoaDonDao.MaHoaDon;
            details.MaHocVien = hoaDonDao.MaHocVien;
            details.MaKhoaHoc = hoaDonDao.MaKhoaHoc;
            details.MaLopHoc = hoaDonDao.MaLopHoc;
            if(ctHDDao!= null)
            {
               details.SoLuong = ctHDDao.SoLuong;
            }
            else
            {
                details.SoLuong = 0;
            }
            details.TinhTrang = hoaDonDao.TinhTrang;
            details.TongTien = hoaDonDao.TongTien;

            ViewBag.MaHoaDon = details.MaHoaDon;
            return View(details);
        }
    }
}
