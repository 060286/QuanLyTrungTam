using Models.DAO;
using Models.Framework;
using System.Web.Mvc;

namespace QuanLyTrungTam.Controllers
{
    public class LopHocController : BaseController
    {
        // GET: LopHoc
        public ActionResult Index(string searchString, int page = 1, int pageSize = 1)
        {
            var _lopHocDao = new LopHocDao();
            var _modelLopHoc = _lopHocDao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(_modelLopHoc);
        }

        // GET: LopHoc/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LopHoc/Create
        public ActionResult Create()
        {
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
        [HttpPost]
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
    }
}
