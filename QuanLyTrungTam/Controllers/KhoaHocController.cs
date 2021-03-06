﻿using Models;
using Models.DAO;
using Models.Framework;
using QuanLyTrungTam.Models;
using QuanLyTrungTam.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTrungTam.Controllers
{
    public class KhoaHocController : BaseController
    {
        // GET: KhoaHoc
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            eCenterDbContext _context = new eCenterDbContext();
            ViewBag.TongKhoaHoc = _context.KhoaHocs.Count();
            // Khóa học còn chỗ
            ViewBag.KhoaHocConCho = _context.KhoaHocs.Where(x => x.SoLuong > 0).Count();
            // Khóa học hết chỗ
            ViewBag.KhoaHocHetCho = _context.KhoaHocs.Where(x => x.SoLuong == 0).Count();

           
            var _khoaHocDao = new KhoaHocDao();
            var _modelKhoaHoc = _khoaHocDao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SoLuongCon = _khoaHocDao.CountQuantityRemaining();
            ViewBag.SearchString = searchString;



            return View(_modelKhoaHoc);
        }

        public ActionResult testSearchByMoney(string searchStringMoney, int page = 1, int pageSize = 10)
        {
            eCenterDbContext _context = new eCenterDbContext();
            ViewBag.TongKhoaHoc = _context.KhoaHocs.Count();
            // Khóa học còn chỗ
            ViewBag.KhoaHocConCho = _context.KhoaHocs.Where(x => x.SoLuong > 0).Count();
            // Khóa học hết chỗ
            ViewBag.KhoaHocHetCho = _context.KhoaHocs.Where(x => x.SoLuong == 0).Count();
            var _khoaHocDao = new KhoaHocDao();
            var _modelKhoaHoc = _khoaHocDao.ListAllPagingByMoney(searchStringMoney, page, pageSize);
            ViewBag.SearchStringByMoney = searchStringMoney;


            return View(_modelKhoaHoc);
        }

        public ActionResult testSearchByOld(string searchStringOld, int page = 1, int pageSize = 10)
        {
            eCenterDbContext _context = new eCenterDbContext();
            ViewBag.TongKhoaHoc = _context.KhoaHocs.Count();
            // Khóa học còn chỗ
            ViewBag.KhoaHocConCho = _context.KhoaHocs.Where(x => x.SoLuong > 0).Count();
            // Khóa học hết chỗ
            ViewBag.KhoaHocHetCho = _context.KhoaHocs.Where(x => x.SoLuong == 0).Count();
            var _khoaHocDao = new KhoaHocDao();
            var _modelKhoaHoc = _khoaHocDao.ListAllPagingByOld(searchStringOld, page, pageSize);
            ViewBag.SearchStringByOld = searchStringOld;


            return View(_modelKhoaHoc);
        }

        public ActionResult testSearchByQuatity(string searchStringQuatity, int page = 1, int pageSize = 10)
        {
            eCenterDbContext _context = new eCenterDbContext();
            ViewBag.TongKhoaHoc = _context.KhoaHocs.Count();
            // Khóa học còn chỗ
            ViewBag.KhoaHocConCho = _context.KhoaHocs.Where(x => x.SoLuong > 0).Count();
            // Khóa học hết chỗ
            ViewBag.KhoaHocHetCho = _context.KhoaHocs.Where(x => x.SoLuong == 0).Count();
            var _khoaHocDao = new KhoaHocDao();
            var _modelKhoaHoc = _khoaHocDao.ListAllPagingByQuatity(searchStringQuatity, page, pageSize);
            ViewBag.SearchStringByQuatity = searchStringQuatity;


            return View(_modelKhoaHoc);
        }

        public ActionResult testSearchByStatus(string searchStringStatus, int page = 1, int pageSize = 10)
        {
            eCenterDbContext _context = new eCenterDbContext();
            ViewBag.TongKhoaHoc = _context.KhoaHocs.Count();
            // Khóa học còn chỗ
            ViewBag.KhoaHocConCho = _context.KhoaHocs.Where(x => x.SoLuong > 0).Count();
            // Khóa học hết chỗ
            ViewBag.KhoaHocHetCho = _context.KhoaHocs.Where(x => x.SoLuong == 0).Count();
            var _khoaHocDao = new KhoaHocDao();
            var _modelKhoaHoc = _khoaHocDao.ListAllPagingByStatus(searchStringStatus, page, pageSize);
            ViewBag.SearchStringByStatus = searchStringStatus;


            return View(_modelKhoaHoc);
        }

        // GET: KhoaHoc/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var _khoaHoc = new KhoaHocDao().ViewDetail(id);

            _khoaHoc.GiaTien.ToString("0.#");


            return View(_khoaHoc);
        }

        [HttpGet]
        public ActionResult TaoMoiVaSuaDanhMuc()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateDetails()
        {
            SetViewBagKH();
            SetViewBagGV();

            return View();
        }

        [HttpPost]
        public ActionResult CreateDetails(KhoaHocDetailsModels khoaHocDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Create Data Access Object
                    var _khoaHocDao = new KhoaHocDao();
                    var _tkbDao = new ThoiKhoaBieuDao();
                    var _danhMucDao = new DanhMucKhoaHocDao();

                    // Create Model
                    var khoaHoc = new KhoaHoc();
                    var danhMuc = new DanhMucKhoaHoc();
                    var thoiKhoaBieu = new ThoiKhoaBieu();

                    // Thêm khóa học
                    khoaHoc.TenKhoaHoc = khoaHocDetails.KhoaHoc.TenKhoaHoc;
                    khoaHoc.SoLuong = khoaHocDetails.KhoaHoc.SoLuong;
                    khoaHoc.TinhTrang = khoaHocDetails.KhoaHoc.TinhTrang;
                    khoaHoc.GiaTien = khoaHocDetails.KhoaHoc.GiaTien;
                    khoaHoc.MoTa = khoaHocDetails.KhoaHoc.MoTa;
                    khoaHoc.LuaTuoiPhuHop = khoaHocDetails.KhoaHoc.LuaTuoiPhuHop;
                    khoaHoc.MaDanhMuc = khoaHocDetails.MaDanhMuc;
                    khoaHoc.MaGiaoVien = khoaHocDetails.MaGiaoVien;

                    int idKH = _khoaHocDao.Insert(khoaHoc);


                    //// Thêm thời khóa biểu
                    thoiKhoaBieu.ThoiGianHoc = khoaHocDetails.ThoiGianHoc.ToString();
                    thoiKhoaBieu.ThuHai = khoaHocDetails.ThuHai;
                    thoiKhoaBieu.ThuBa = khoaHocDetails.ThuBa;
                    thoiKhoaBieu.ThuTu = khoaHocDetails.ThuTu;
                    thoiKhoaBieu.ThuNam = khoaHocDetails.ThuNam;
                    thoiKhoaBieu.ThuSau = khoaHocDetails.ThuSau;
                    thoiKhoaBieu.ThuBay = khoaHocDetails.ThuBay;
                    thoiKhoaBieu.ChuNhat = khoaHocDetails.ChuNhat;
                    thoiKhoaBieu.MaKhoaHoc = idKH;
                    int idTKB = _tkbDao.Insert(thoiKhoaBieu);

                    if (idKH > 0 && idTKB > 0)
                    {
                        return RedirectToAction("Index", "KhoaHoc");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Xảy ra lỗi khi thêm khóa học");
                    }
                    SetViewBagKH();
                    SetViewBagGV();
                    return View(khoaHoc);
                }

                return RedirectToAction("Index", "KhoaHoc");
            }

            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult TaoMoiVaSuaDanhMuc(DanhMucKhoaHoc danhMuc)
        {
            eCenterDbContext _context = new eCenterDbContext();
            var danhMucDao = new DanhMucKhoaHocDao();

            int _maDanhMuc = danhMucDao.Insert(danhMuc);

            //var modal = danhMucDao.GetById(_maDanhMuc);

            if (_maDanhMuc > 0)
            {
                return RedirectToAction("Index", "KhoaHoc");
            }
            else
            {
                ModelState.AddModelError("", "Thêm thất bại");
            }

            return View(danhMuc);
        }

        // GET: KhoaHoc/Create

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBagKH();
            SetViewBagGV();
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
                SetViewBagKH();
                SetViewBagGV();
                return View(khoaHoc);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult EditSchedule(int id)
        {
            var _tkb = new ThoiKhoaBieuDao().ViewDetailsByMaKhoaHoc(id);

            return View(_tkb);
        }

        [HttpPost]
        public ActionResult EditSchedule(ThoiKhoaBieu tkb)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var _tkbDao = new ThoiKhoaBieuDao();

                    var res = _tkbDao.Update(tkb);
                    if (res)
                    {
                        return RedirectToAction("Index", "KhoaHoc");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật lỗi");
                    }
                }
                return View(tkb);
            }
            catch
            {
                return RedirectToAction("Index", "KhoaHoc");
            }
        }

        // GET: KhoaHoc/Edit/5
        public ActionResult Edit(int id)
        {
            SetViewBagKH();
            SetViewBagGV();
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

        [HttpGet]
        public ActionResult CreateSchedule(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSchedule(ThoiKhoaBieu tkb, int id)
        {
            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                tkb.MaKhoaHoc = id;

                var thoiKhoaBieuDao = new ThoiKhoaBieuDao();

                int maTKB = thoiKhoaBieuDao.Insert(tkb);

                if (maTKB > 0)
                {
                    return RedirectToAction("Index", "KhoaHoc");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }
            }
            SetViewBagKH();
            SetViewBagGV();
            return View(tkb);


        }

        // GET: KhoaHoc/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: KhoaHoc/Delete/5
        [HttpDelete]
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

        public void SetViewBagKH(int? maDanhMucKhoaHoc = null)
        {
            var dao = new DanhMucKhoaHocDao();
            ViewBag.MaDanhMuc = new SelectList(dao.ListAll(), "MaDanhMuc", "TenDanhMuc", maDanhMucKhoaHoc);
        }
        public void SetViewBagGV(int? maGiaoVien = null)
        {
            var daoGiaoVien = new GiaoVienDao();
            ViewBag.MaGiaoVien = new SelectList(daoGiaoVien.ListAll(), "MaGiaoVien", "TenGiaoVien", maGiaoVien);
        }

        public void SetViewBagDMKHDetails(int? maDanhMucKhoaHoc = null)
        {
            var dao = new DanhMucKhoaHocDao();
            ViewBag.MaDanhMucDetails = new SelectList(dao.ListAll(), "MaDanhMuc", "TenDanhMuc", maDanhMucKhoaHoc);
        }

        public void SetViewBagGVDetails(int? maGiaoVien = null)
        {
            var dao = new GiaoVienDao();
            ViewBag.MaGiaoVienDetails = new SelectList(dao.ListAll(), "MaGiaoVien", "TenGiaoVien", maGiaoVien);
        }

        //Thêm danh mục khóa học
        [HttpGet]
        public ViewResult CreateCatagoryCourse()
        {
            eCenterDbContext _context = new eCenterDbContext();
            List<DanhMucKhoaHoc> listDanhMucKhoaHoc = _context.DanhMucKhoaHocs.ToList();
            return View(listDanhMucKhoaHoc);
        }

        public ActionResult ChiTietKhoaHoc(int id)
        {
            var details = new KhoaHocDetailsViewModels();

            var khoaHocDao = new KhoaHocDao().ViewDetail(id);
            var tkbDao = new ThoiKhoaBieuDao().getScheduleByCourse(khoaHocDao.MaKhoaHoc);

            details.MaKhoaHoc = khoaHocDao.MaKhoaHoc;
            details.TenKhoaHoc = khoaHocDao.TenKhoaHoc;
            details.GiaTien = khoaHocDao.GiaTien;
            details.GiaTien.ToString("0.#");
            details.SoLuong = khoaHocDao.SoLuong.GetValueOrDefault(0);
            details.NgayBatDau = khoaHocDao.NgayBatDau.GetValueOrDefault(DateTime.Now);
            details.NgayKetThuc = khoaHocDao.NgayKetThuc.GetValueOrDefault(DateTime.Now);
            details.TinhTrang = khoaHocDao.TinhTrang;
            details.Mota = khoaHocDao.MoTa;
            details.SoTuan = khoaHocDao.SoTuan.GetValueOrDefault(8);
            details.LuaTuoiPhuHop = khoaHocDao.LuaTuoiPhuHop.GetValueOrDefault(18);
            details.MaDanhMuc = khoaHocDao.MaDanhMuc.GetValueOrDefault(1);


            if(tkbDao == null)
            {
                // Fix bug chưa tạo tkb
                details.MaTKB = tkbDao.MaTKB;
                details.ThuBa = tkbDao.ThuBa;
                details.ThuTu = tkbDao.ThuTu;
                details.ThuNam = tkbDao.ThuNam;
                details.ThuSau = tkbDao.ThuSau;
                details.ThuHai = tkbDao.ThuHai;
                details.ThuBay = tkbDao.ThuBay;
                details.ChuNhat = tkbDao.ChuNhat;
                details.ThoiGianHoc = tkbDao.ThoiGianHoc;
            }    
            else
            {
                details.MaTKB = tkbDao.MaTKB;
                details.ThuBa = tkbDao.ThuBa;
                details.ThuTu = tkbDao.ThuTu;
                details.ThuNam = tkbDao.ThuNam;
                details.ThuSau = tkbDao.ThuSau;
                details.ThuHai = tkbDao.ThuHai;
                details.ThuBay = tkbDao.ThuBay;
                details.ChuNhat = tkbDao.ChuNhat;
                details.ThoiGianHoc = tkbDao.ThoiGianHoc;
            }    
            
            return View(details);
        }

        [HttpGet]
        public ActionResult EditCategoryCourse(int id)
        {
            var model = new DanhMucKhoaHocDao().ViewDetails(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditCategoryCourse(DanhMucKhoaHoc _danhMuc)
        {
            var _dao = new DanhMucKhoaHocDao();

            var res = _dao.Update(_danhMuc);
            if (res)
            {
                return RedirectToAction("Index", "KhoaHoc");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật lỗi");
            }

            return View(_danhMuc);
        }
    }
}
