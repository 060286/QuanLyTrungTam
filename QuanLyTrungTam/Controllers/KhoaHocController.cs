using Models;
using Models.DAO;
using Models.Framework;
using QuanLyTrungTam.Models;
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
        public ActionResult Index(string searchString,int page = 1 ,int pageSize = 10)
        {
            eCenterDbContext _context = new eCenterDbContext();
            ViewBag.TongKhoaHoc = _context.KhoaHocs.Count();
            // Khóa học còn chỗ
            ViewBag.KhoaHocConCho = _context.KhoaHocs.Where(x => x.SoLuong > 0).Count();
            // Khóa học hết chỗ
            ViewBag.KhoaHocHetCho = _context.KhoaHocs.Where(x => x.SoLuong == 0).Count();
            var _khoaHocDao = new KhoaHocDao();
            var _modelKhoaHoc = _khoaHocDao.ListAllPaging(searchString, page, pageSize);
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
            return View(_khoaHoc);
        }


        public ActionResult TaoMoiVaSuaDanhMuc()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateDetails()
        {
            SetViewBagDMKHDetails();
            SetViewBagGVDetails();

            return View();
        }

        [HttpPost]
        public ActionResult CreateDetails(KhoaHocDetailsModels khoaHocDetails)
        {
            try
            {
                if(ModelState.IsValid)
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
                    khoaHoc.MaDanhMuc = khoaHocDetails.KhoaHoc.MaDanhMuc;
                    khoaHoc.MaGiaoVien = khoaHocDetails.KhoaHoc.MaGiaoVien;

                    int idKH = _khoaHocDao.Insert(khoaHoc);

                    // Thêm Danh muc khóa học
                    //danhMuc.TenDanhMuc = khoaHocDetails.DanhMucKhoaHoc.TenDanhMuc;

                    //int idDM = _danhMucDao.Insert(danhMuc);

                    // Thêm thời khóa biểu
                    thoiKhoaBieu.TuanBatDau = khoaHocDetails.ThoiKhoaBieu.TuanBatDau;
                    thoiKhoaBieu.TuanKetThuc = khoaHocDetails.ThoiKhoaBieu.TuanKetThuc;
                    thoiKhoaBieu.ThoiGianHoc = khoaHocDetails.ThoiKhoaBieu.ThoiGianHoc;

                    int idTKB = _tkbDao.Insert(thoiKhoaBieu);

                    if(idKH > 0 && idTKB > 0)
                    {
                        return RedirectToAction("Index", "KhoaHoc");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Xảy ra lỗi khi thêm khóa học");
                    }

                    //SetViewBagDMKHDetails();
                    //SetViewBagGVDetails();
                    //SetViewBagGV();
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
        public JsonResult TaoMoiVaSuaDanhMuc(DanhMucKhoaHoc danhMuc)
        {
            eCenterDbContext _context = new eCenterDbContext();
            var danhMucDao = new DanhMucKhoaHocDao();

            int _maKhoaHoc = danhMucDao.Insert(danhMuc);

            var modal = danhMucDao.GetById(_maKhoaHoc);

            return Json(modal, JsonRequestBehavior.AllowGet);
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

    }
}
