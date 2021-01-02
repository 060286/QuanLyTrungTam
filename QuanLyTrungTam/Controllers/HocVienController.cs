using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using QuanLyTrungTam.Models;
using System.IO;
using Common;

namespace QuanLyTrungTam.Controllers
{
    public class HocVienController : BaseController
    {
        // GET: HocVien
        public ActionResult Index(string searchString,int page = 1, int pageSize = 10)
        {
            var _daoHocVien = new HocVienDao();
            var _modelHocVien = _daoHocVien.ListAllPaging(searchString,page, pageSize);
            return View(_modelHocVien);
        }

        // GET: HocVien/Details/5
        public ActionResult Details(int id)
        {
            var hocVienDao = new HocVienDao().ViewDetails(id);
            return View(hocVienDao);
        }

        // GET: HocVien/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: HocVien/Create
        [HttpPost]
        public ActionResult Create(HocVien hocVien, HttpPostedFileBase hinhAnh)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    string path = "";
                    if(hinhAnh != null && hinhAnh.ContentLength > 0 )
                    {
                        string extension = Path.GetExtension(hinhAnh.FileName);

                        if(extension.Equals(".jpg") || extension.Equals(".png") || extension.Equals(".jpeg"))
                        {
                            path = Path.Combine(Server.MapPath("~/Img/HocVien/"), hinhAnh.FileName);
                            hinhAnh.SaveAs(path);
                        }

                        hocVien.HinhAnh = hinhAnh.FileName;
                        var _daoHocVien = new HocVienDao();
                        hocVien.NgayDangKy = DateTime.Now;
                        int _maGiaoVien = _daoHocVien.Insert(hocVien);

                        if (_maGiaoVien > 0)
                        {
                            if(hocVien.Email == null)
                            {
                                return RedirectToAction("Index", "HocVien");
                            }
                            else
                            {
                                string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/Email/HocVien.html"));

                                content = content.Replace("{{TenHV}}", hocVien.TenHocVien.ToString());
                                content = content.Replace("{{NgaySinh}}", hocVien.NgaySinh.ToString());
                                content = content.Replace("{{SDT}}", hocVien.SDT.ToString());
                                content = content.Replace("{{DiaChi}}", hocVien.DiaChi.ToString());
                                content = content.Replace("{{NgayDangKy}}", hocVien.NgayDangKy.ToString());

                                new MailHelper().SendMail(hocVien.Email, "Chào mừng em đã tham gia vào đại gia đình Đan Thanh!", content);
                                //SetAlert("")
                                return RedirectToAction("Index", "HocVien");
                            }    
                        }
                        else
                        {
                            ModelState.AddModelError("", "Có lỗi khi thêm học viên");
                        }
                    }   
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult CreateDetails()
        {
            return View();
        }    

        [HttpPost]
        public ActionResult CreateDetails(HocVienDetails hocVienDetails, HttpPostedFileBase hinhAnh)
        {
           try
           {
                if(ModelState.IsValid)
                {
                    string path = "";
                    if(hinhAnh != null && hinhAnh.ContentLength > 0)
                    {
                        string extension = Path.GetExtension(hinhAnh.FileName);
                        if (extension.Equals(".jpg") || extension.Equals(".png") || extension.Equals(".jpeg"))
                        {
                            path = Path.Combine(Server.MapPath("~/Img/HocSinh/"), hinhAnh.FileName);
                            hinhAnh.SaveAs(path);
                        }
                        

                        var _daoHocVien = new HocVienDao();
                        var _daoPhuHuynh = new PhuHuynhDao();

                        var hocVien = new HocVien();

                        hocVien.TenHocVien = hocVienDetails.HocVien.TenHocVien;
                        hocVien.TaiKhoan = hocVienDetails.HocVien.TaiKhoan;
                        hocVien.MatKhau = hocVienDetails.HocVien.MatKhau;
                        hocVien.HinhAnh = hinhAnh.FileName;
                        hocVien.GioiTinh = hocVienDetails.HocVien.GioiTinh;
                        hocVien.SDT = hocVienDetails.HocVien.SDT;
                        hocVien.Email = hocVienDetails.HocVien.Email;
                        hocVien.DiaChi = hocVienDetails.HocVien.DiaChi;
                        hocVien.NgaySinh = hocVienDetails.HocVien.NgaySinh;
                        hocVien.GhiChu = hocVienDetails.HocVien.GhiChu;
                        hocVien.TrangThai = hocVienDetails.HocVien.TrangThai;
                        hocVien.Nguon = hocVienDetails.HocVien.Nguon;

                        // Thêm học viên
                        int _maHocVien = _daoHocVien.Insert(hocVien);

                        List<PhuHuynh> listPH = new List<PhuHuynh>();

                        for (int i = 0; i < 2; i++)
                        {
                            var _phuHuynh = new PhuHuynh();

                            _phuHuynh.TenPhuHuynh = hocVienDetails.LstPhuHuynh[i].TenPhuHuynh;

                            _phuHuynh.TenPhuHuynh = hocVienDetails.LstPhuHuynh[i].TenPhuHuynh;
                            _phuHuynh.SDT = hocVienDetails.LstPhuHuynh[i].SDT;
                            _phuHuynh.GioiTinh = hocVienDetails.LstPhuHuynh[i].GioiTinh;
                            _phuHuynh.DiaChi = hocVienDetails.LstPhuHuynh[i].DiaChi;
                            _phuHuynh.Email = hocVienDetails.LstPhuHuynh[i].Email;
                            _phuHuynh.MaHocVien = hocVienDetails.HocVien.MaHocVien;

                            int _maPhuHuynh = _daoPhuHuynh.Insert(_phuHuynh);
                        }

                        if (_maHocVien > 0 && _maHocVien > 0)
                        {
                            if (hocVien.Email == null)
                            {
                                return RedirectToAction("Index", "HocVien");
                            }
                            else
                            {
                                string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/Email/HocVien.html"));

                                content = content.Replace("{{TenHV}}", hocVien.TenHocVien.ToString());
                                content = content.Replace("{{NgaySinh}}", hocVien.NgaySinh.ToString());
                                content = content.Replace("{{SDT}}", hocVien.SDT.ToString());
                                content = content.Replace("{{DiaChi}}", hocVien.DiaChi.ToString());
                                content = content.Replace("{{NgayDangKy}}", hocVien.NgayDangKy.ToString());

                                new MailHelper().SendMail(hocVien.Email, "Chào mừng em đã tham gia vào đại gia đình Đan Thanh!", content);
                                SetAlert("Thêm thành công", 1);
                                return RedirectToAction("Index","HocVien");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Có lỗi khi thêm chi tiết học viên");
                        }
                    }
                }
                return RedirectToAction("Index");
            }
           catch
           {
                return View();
            }
        }

        //[HttpGet]
        //public ActionResult EditDetails(int id)
        //{
        //    var _hocVien = new HocVienDao
        //}

        // GET: HocVien/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var _hocVien = new HocVienDao().ViewDetails(id);

            return View(_hocVien);
        }

        // POST: HocVien/Edit/5
        [HttpPost]
        public ActionResult Edit(HocVien hocVien)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var _daoGiaoVien = new HocVienDao();

                    var res = _daoGiaoVien.Update(hocVien);
                    if (res)
                    {
                        return RedirectToAction("Index", "GiaoVien");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật thất bại");
                    }
                }
                return View(hocVien);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: HocVien/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: HocVien/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                new HocVienDao().Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}


