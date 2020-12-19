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
    public class CartCourseController : Controller
    {
        private const string CartSession = "CartSession";
        eCenterDbContext _context = new eCenterDbContext();
        // GET: CartCourse
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var khoaHocDao = new KhoaHocDao();
            var model = khoaHocDao.ListAllPaging(searchString, page, pageSize);
            ViewBag.Search = searchString;

            return View(model);
            //var cart = Session[CartSession];
            //var list = new List<CartCourse>();

            //if(cart != null)
            //{
            //    list = (List<CartCourse>)cart;
            //}  

            //return View(list);
        }

        public ActionResult AddItem(int maKhoaHoc, int soLuong)
        {
            var khoaHoc = new KhoaHocDao().ViewDetail(maKhoaHoc);
            var cart = Session[CartSession];

            // Đã có sản phẩm trong giỏ hàng 
            if (cart != null)
            {
                var list = (List<CartCourse>)cart;
                if (list.Exists(x => x.KhoaHoc.MaKhoaHoc == maKhoaHoc))
                {
                    foreach (var item in list)
                    {
                        if (item.KhoaHoc.MaKhoaHoc == maKhoaHoc)
                        {
                            item.SoLuong += soLuong;
                        }
                    }
                }
                else
                {
                    var item = new CartCourse();
                    item.KhoaHoc.MaKhoaHoc = maKhoaHoc;
                    item.SoLuong = soLuong;

                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                // Tạo mới đối tượng 
                var item = new CartCourse();
                item.KhoaHoc = khoaHoc;
                item.SoLuong = soLuong;

                // Gán vào session
                var list = new List<CartCourse>();
                list.Add(item);
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        // GET: CartCourse/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartCourse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartCourse/Create
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

        // GET: CartCourse/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartCourse/Edit/5
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

        // GET: CartCourse/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartCourse/Delete/5
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
