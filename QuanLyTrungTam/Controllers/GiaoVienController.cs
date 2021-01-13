using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Models;
using Models.Framework;
using OfficeOpenXml;
using QuanLyTrungTam.ViewModels;
using System.IO;
using System.Web;
using Models.DAO;
using QuanLyTrungTam.Common;

namespace QuanLyTrungTam.Controllers
{
    public class GiaoVienController : BaseController
    {
        eCenterDbContext db = new eCenterDbContext();
        private int maTrinhDo { get; set; }
        // GET: GiaoVien
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var _daoGiaoVien = new GiaoVienDao();
            var _modelGiaoVien = _daoGiaoVien.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            //ViewBag.GiaoVien = db.GiaoViens.Count();// return tổng số giáo viên
            ViewBag.TongGiaoVien = db.GiaoViens.Count();
            ViewBag.NhanVienNam = db.GiaoViens.Where(x => x.GioiTinh == "Nam").Count();
            ViewBag.NhanVienNu = db.GiaoViens.Where(x => x.GioiTinh == "Nữ").Count();
            ViewBag.TongTienLuong = db.GiaoViens.Sum(x => x.MucLuong).Value.ToString("#,##").Replace(',', '.');
            return View(_modelGiaoVien);
        }

        public ActionResult testListAllPagingOrderByDescending(int page = 1, int pageSize = 10)
        {
            ViewBag.TongGiaoVien = db.GiaoViens.Count();
            ViewBag.NhanVienNam = db.GiaoViens.Where(x => x.GioiTinh == "Nam").Count();
            ViewBag.NhanVienNu = db.GiaoViens.Where(x => x.GioiTinh == "Nữ").Count();
            ViewBag.TongTienLuong = db.GiaoViens.Sum(x => x.MucLuong).ToString();

            var _daoGiaoVien = new GiaoVienDao();
            var _modelGiaoVien = _daoGiaoVien.ListAllOrderByDescending(page, pageSize);

            return View(_modelGiaoVien);
        }

        public ActionResult testSearchByEmail(string searchStringEmail, int page, int pageSize)
        {
            ViewBag.TongGiaoVien = db.GiaoViens.Count();
            ViewBag.NhanVienNam = db.GiaoViens.Where(x => x.GioiTinh == "Nam").Count();
            ViewBag.NhanVienNu = db.GiaoViens.Where(x => x.GioiTinh == "Nữ").Count();
            ViewBag.TongTienLuong = db.GiaoViens.Sum(x => x.MucLuong).ToString();

            var _daoGiaoVien = new GiaoVienDao();
            var _modelGiaoVien = _daoGiaoVien.ListAllPagingByEmail(searchStringEmail, page, pageSize);
            ViewBag.SearchStringByEmail = searchStringEmail;
            return View(_modelGiaoVien);
        }

        public ActionResult testSearchByPhoneNumber(string searchStringPhoneNumber, int page, int pageSize)
        {
            ViewBag.TongGiaoVien = db.GiaoViens.Count();
            ViewBag.NhanVienNam = db.GiaoViens.Where(x => x.GioiTinh == "Nam").Count();
            ViewBag.NhanVienNu = db.GiaoViens.Where(x => x.GioiTinh == "Nữ").Count();
            ViewBag.TongTienLuong = db.GiaoViens.Sum(x => x.MucLuong).ToString();

            var _daoGiaoVien = new GiaoVienDao();
            var _modelGiaoVien = _daoGiaoVien.ListAllPagingByPhoneNumber(searchStringPhoneNumber, page, pageSize);
            ViewBag.SearchStringByPhoneNumber = searchStringPhoneNumber;
            return View(_modelGiaoVien);
        }

        public ActionResult testSearchByBirthDay(string searchStringBirthDay, int page, int pageSize)
        {
            ViewBag.TongGiaoVien = db.GiaoViens.Count();
            ViewBag.NhanVienNam = db.GiaoViens.Where(x => x.GioiTinh == "Nam").Count();
            ViewBag.NhanVienNu = db.GiaoViens.Where(x => x.GioiTinh == "Nữ").Count();
            ViewBag.TongTienLuong = db.GiaoViens.Sum(x => x.MucLuong).ToString();

            var _daoGiaoVien = new GiaoVienDao();
            var _modelGiaoVien = _daoGiaoVien.ListAllPagingByEmail(searchStringBirthDay, page, pageSize);
            ViewBag.SearchStringByBirthDay = searchStringBirthDay;
            return View(_modelGiaoVien);
        }

        public ActionResult testSearchByGender(string searchStringGender, int page = 1, int pageSize = 10)
        {
            ViewBag.TongGiaoVien = db.GiaoViens.Count();
            ViewBag.NhanVienNam = db.GiaoViens.Where(x => x.GioiTinh == "Nam").Count();
            ViewBag.NhanVienNu = db.GiaoViens.Where(x => x.GioiTinh == "Nữ").Count();
            ViewBag.TongTienLuong = db.GiaoViens.Sum(x => x.MucLuong).ToString();

            var _daoGiaoVien = new GiaoVienDao();
            var _modelGiaoVien = _daoGiaoVien.ListAllPagingByGender(searchStringGender, page, pageSize);
            ViewBag.SearchStringByGender = searchStringGender;
            return View(_modelGiaoVien);
        }

        public ActionResult testSearchByAddress(string searchStringAddress, int page = 1, int pageSize = 10)
        {
            ViewBag.TongGiaoVien = db.GiaoViens.Count();
            ViewBag.NhanVienNam = db.GiaoViens.Where(x => x.GioiTinh == "Nam").Count();
            ViewBag.NhanVienNu = db.GiaoViens.Where(x => x.GioiTinh == "Nữ").Count();
            ViewBag.TongTienLuong = db.GiaoViens.Sum(x => x.MucLuong).ToString();

            var _daoGiaoVien = new GiaoVienDao();
            var _modelGiaoVien = _daoGiaoVien.ListAllByAddress(searchStringAddress, page, pageSize);
            ViewBag.SearchStringByAddress = searchStringAddress;
            return View(_modelGiaoVien);
        }

        public ActionResult testSearchBySalary(string searchSalary, int page = 1, int pageSize = 10)
        {
            ViewBag.TongGiaoVien = db.GiaoViens.Count();
            ViewBag.NhanVienNam = db.GiaoViens.Where(x => x.GioiTinh == "Nam").Count();
            ViewBag.NhanVienNu = db.GiaoViens.Where(x => x.GioiTinh == "Nữ").Count();
            ViewBag.TongTienLuong = db.GiaoViens.Sum(x => x.MucLuong).ToString();

            var _daoGiaoVien = new GiaoVienDao();
            var _modelGiaoVien = _daoGiaoVien.ListAllPagingBySalary(searchSalary, page, pageSize);
            ViewBag.SearchStringBySalary = searchSalary;
            return View(_modelGiaoVien);
        }

        public ActionResult testSearchByStatus(string searchStatus, int page = 1, int pageSize = 10)
        {
            ViewBag.TongGiaoVien = db.GiaoViens.Count();
            ViewBag.NhanVienNam = db.GiaoViens.Where(x => x.GioiTinh == "Nam").Count();
            ViewBag.NhanVienNu = db.GiaoViens.Where(x => x.GioiTinh == "Nữ").Count();
            ViewBag.TongTienLuong = db.GiaoViens.Sum(x => x.MucLuong).ToString();

            var _daoGiaoVien = new GiaoVienDao();
            var _modelGiaoVien = _daoGiaoVien.ListAllPagingByStatus(searchStatus, page, pageSize);
            ViewBag.SearchStatus = searchStatus;
            return View(_modelGiaoVien);
        }
        // GET: GiaoVien/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var detailGiaoVien = new GiaoVienDao().ViewDetail(id);
            return PartialView(detailGiaoVien);
        }

        // GET: GiaoVien/Create
        [HttpGet]
        public ActionResult Create()
        {
            //var dao = new GiaoVienDao();

            return View();
        }

        // POST: GiaoVien/Create
        [HttpPost]
        public ActionResult Create(GiaoVien giaoVien, HttpPostedFileBase hinhAnh)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    string path = "";
                    if (hinhAnh != null && hinhAnh.ContentLength > 0)
                    {
                        string extension = Path.GetExtension(hinhAnh.FileName);
                        if (extension.Equals(".jpg") || extension.Equals(".png") || extension.Equals(".jpeg"))
                        {
                            path = Path.Combine(Server.MapPath("~/Img/GiaoVien/"), hinhAnh.FileName);
                            hinhAnh.SaveAs(path);
                        }
                        giaoVien.HinhAnh = hinhAnh.FileName;
                        var _daoGiaoVien = new GiaoVienDao();
                        giaoVien.NgayDangKy = DateTime.Now;
                        giaoVien.QuocTich = "Việt Nam";

                        var encryptMd5Password = Encryptor.MD5Hash(giaoVien.MatKhau);
                        giaoVien.MatKhau = encryptMd5Password;

                        int _maGiaoVien = _daoGiaoVien.Insert(giaoVien);

                        if (_maGiaoVien > 0)
                        {
                            SetAlert("Thêm thành công", 1);
                            return RedirectToAction("Index", "GiaoVien");
                        }
                        else
                        {
                            SetAlert("Thêm thất bại", 3);
                            //ModelState.AddModelError("", "Thêm thất bại");
                        }
                    }

                }
                return View(giaoVien);
            }
            catch
            {
                return RedirectToAction("Index", "GiaoVien");
            }
        }

        [HttpGet]
        public ActionResult ThemMoiTrinhDo()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ThemMoiTrinhDo(TrinhDo trinhDo)
        {
            maTrinhDo = db.TrinhDoes.Max(x => x.MaTrinhDo);

            if (ModelState.IsValid)
            {
                var trinhDoDao = new GiaoVienDao();

                //trinhDo.MaTrinhDo = maTrinhDo + 1;

                int _maTrinhDo = trinhDoDao.InsertTrinhDo(trinhDo);

                if (_maTrinhDo > 0)
                {
                    SetAlert("Thêm thành công", 1);
                    return RedirectToAction("Index", "GiaoVien");
                }
                else
                {
                    SetAlert("Thêm thất bại", 3);
                    //ModelState.AddModelError("", "Thêm thất bại");
                }
            }
            return View(trinhDo);


        }

        [HttpGet]
        public ActionResult EditLevel(int id)
        {
            var _trinhDo = new TrinhDoDao().ViewDetails(id);

            return View(_trinhDo);
        }

        [HttpPost]
        public ActionResult EditLevel(TrinhDo trinhDo)
        {
            var _daoTrinhDo = new TrinhDoDao();

            var res = _daoTrinhDo.Update(trinhDo);

            return View();
        }

        // GET: GiaoVien/Edit/5  
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var _giaoVien = new GiaoVienDao().ViewDetail(id);

            return View(_giaoVien);
        }

        // POST: GiaoVien/Edit/5
        [HttpPost]
        public ActionResult Edit(GiaoVien giaoVien)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var _daoGiaoVien = new GiaoVienDao();

                    var res = _daoGiaoVien.Update(giaoVien);
                    if (res)
                    {
                        return RedirectToAction("Index", "GiaoVien");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật lỗi");
                    }
                }
                return View(giaoVien);
            }
            catch
            {
                return RedirectToAction("Index", "GiaoVien");
            }
        }

        // GET: GiaoVien/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: GiaoVien/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                new GiaoVienDao().Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void DanhSachGiaoVien()
        {
            List<GiaoVienViewModel> giaoVienList = db.GiaoViens.Select(x => new GiaoVienViewModel
            {
                MaGiaoVien = x.MaGiaoVien,
                TenGiaoVien = x.TenGiaoVien,
                GioiTinh = x.GioiTinh,
                NgaySinh = x.NgaySinh,
                NgayDangKy = x.NgayDangKy,
                Email = x.Email,
                SDT = x.SDT,
                QuocTich = x.QuocTich,
                GhiChu = x.GhiChu,
                DiaChi = x.DiaChi,
                TrangThai = x.TrangThai
            }).ToList();

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Communication";
            ws.Cells["A2"].Value = "Com1";

            ws.Cells["A2"].Value = "Báo cáo";
            ws.Cells["B2"].Value = "Báo cáo 1";

            ws.Cells["A3"].Value = "Date";
            ws.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

            ws.Cells["A6"].Value = "Mã giáo vien";
            ws.Cells["B6"].Value = "Tên giáo viên";
            ws.Cells["C6"].Value = "Giới tính";
            ws.Cells["D6"].Value = "Ngày sinh";
            ws.Cells["E6"].Value = "Ngày đăng ký";
            ws.Cells["F6"].Value = "Email";
            ws.Cells["G6"].Value = "Số điện thoại";
            ws.Cells["H6"].Value = "Quốc tịch";
            ws.Cells["K6"].Value = "Ghi chú";
            ws.Cells["I6"].Value = "Địa chỉ";
            ws.Cells["J6"].Value = "Trạng thái";
            int rowStart = 7;
            foreach (var item in giaoVienList)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.MaGiaoVien;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.TenGiaoVien;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.GioiTinh;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.NgaySinh;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.NgayDangKy;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.Email;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.SDT;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.QuocTich;
                ws.Cells[string.Format("K{0}", rowStart)].Value = item.GhiChu;
                ws.Cells[string.Format("I{0}", rowStart)].Value = item.DiaChi;
                ws.Cells[string.Format("J{0}", rowStart)].Value = item.TrangThai;
                rowStart++;
            }


            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "aplication/vnd.openxmlformats-officedocument.spreedsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename" + "GiaoVienReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }

    }
}