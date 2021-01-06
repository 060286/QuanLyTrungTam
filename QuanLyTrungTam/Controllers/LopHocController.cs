using Models;
using Models.DAO;
using Models.Framework;
using System.Web.Mvc;

namespace QuanLyTrungTam.Controllers
{
    public class LopHocController : BaseController
    {
        // GET: LopHoc
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var _lopHocDao = new LopHocDao();
            var _modelLopHoc = _lopHocDao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(_modelLopHoc);
        }

        public ActionResult testSearchByEndDate(string searchStringEndDate, int page = 1, int pageSize = 10)
        {
            var _lopHocDao = new LopHocDao();
            var _modelLopHoc = _lopHocDao.testSearchByEndDate(searchStringEndDate, page, pageSize);
            ViewBag.SearchStringEndDate = searchStringEndDate;
            return View(_modelLopHoc);
        }

        public ActionResult testSearchByStartDate(string searchStringStartDate, int page = 1, int pageSize = 10)
        {
            var _lopHocDao = new LopHocDao();
            var _modelLopHoc = _lopHocDao.testSearchByEndDate(searchStringStartDate, page, pageSize);
            ViewBag.SearchStringStartDate = searchStringStartDate;
            return View(_modelLopHoc);
        }

        public ActionResult testSearchByStatus(string searchStringStatus, int page = 1, int pageSize = 10)
        {
            var _lopHocDao = new LopHocDao();
            var _modelLopHoc = _lopHocDao.testSearchByEndDate(searchStringStatus, page, pageSize);
            ViewBag.SearchStringStatus = searchStringStatus;
            return View(_modelLopHoc);
        }

        public ActionResult TamTest()
        {
            var _lopHocDao = new LopHocDao();
            var _modelLopHoc = _lopHocDao.GetClassByStatus(true);
            return PartialView(_modelLopHoc);
        }

        // GET: LopHoc/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var lopHocDao = new LopHocDao().ViewDetail(id);
            return View(lopHocDao);
        }

        // GET: LopHoc/Create
        [HttpGet]
        public ActionResult Create()
        {
            GetViewBagKhoaHoc();
            GetViewBagGiaoVien();

            return View();
        }

        // POST: LopHoc/Create
        [HttpPost]
        public ActionResult Create(LopHoc lopHoc)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var _lopHocDao = new LopHocDao();

                    int _maLopHoc = _lopHocDao.Insert(lopHoc);

                    if (_maLopHoc > 0)
                    {
                        return RedirectToAction("Index", "LopHoc");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm thất bại");
                    }
                }
                return View(lopHoc);
            }
            catch
            {
                return View();
            }
        }

        // GET: LopHoc/Edit/5
        public ActionResult Edit(int id)
        {
            var _lopHoc = new LopHocDao().ViewDetail(id);

            return View(_lopHoc);
        }

        // POST: LopHoc/Edit/5
        [HttpPost]
        public ActionResult Edit(LopHoc lopHoc)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var _lopHocDao = new LopHocDao();

                    var res = _lopHocDao.Update(lopHoc);
                    if (res)
                    {
                        return RedirectToAction("Index", "LopHoc");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật lỗi");
                    }
                }
                return View(lopHoc);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: LopHoc/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: LopHoc/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                new LopHocDao().Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }
        }

        public void GetViewBagKhoaHoc(int? maKhoaHoc = null)
        {
            var dao = new KhoaHocDao();
            ViewBag.MaKhoaHoc = new SelectList(dao.ListAll(), "MaKhoaHoc", "TenKhoaHoc", maKhoaHoc);
        }

        public void GetViewBagGiaoVien(int? maGiaoVien = null)
        {
            var dao = new GiaoVienDao();
            ViewBag.MaGiaoVien = new SelectList(dao.ListAll(), "MaGiaoVien", "TenGiaoVien", maGiaoVien);
        }
    }
}
