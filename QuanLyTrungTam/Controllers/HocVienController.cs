using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using QuanLyTrungTam.Models;
using System.IO;
using Common;
using System.Linq;
using QuanLyTrungTam.ViewModels;
using OfficeOpenXml;

namespace QuanLyTrungTam.Controllers
{
    public class HocVienController : BaseController
    {
        public static int? getId;
        private eCenterDbContext _context = new eCenterDbContext();

        // GET: HocVien
        public ActionResult Index(string searchString,int page = 1, int pageSize = 10)
        {
            ViewBag.HocVienMoi = _context.HocViens.Where(x => x.NgayDangKy.Value.Month == DateTime.Now.Month).Count();
            ViewBag.TongHocVien = _context.HocViens.Where(x => x.TrangThai == true).Count();
            ViewBag.HocVienNam = _context.HocViens.Where(x => x.GioiTinh == "Nam" || x.GioiTinh == "nam").Count();
            ViewBag.HocVienNu = _context.HocViens.Where(x => x.GioiTinh == "Nữ" || x.GioiTinh == "nữ").Count();

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

        //public ActionResult ChiTiet(int id)
        //{
        //    var ctHV = new ChiTietHocVienModel();

        //    var dao = new HocVienDao().ViewDetails(id);

        //    ctHV.TenHocVien = dao.TenHocVien;
        //    ctHV.HocVien.TenHocVien = dao.TenHocVien;
        //    ctHV.HocVien.HinhAnh = dao.HinhAnh;
        //    ctHV.HocVien.MaHVDD = dao.MaHVDD;
        //    ctHV.HocVien.Email = dao.Email;
        //    ctHV.HocVien.GioiTinh = dao.GioiTinh;
        //    ctHV.HocVien.DiaChi = dao.DiaChi;
        //    ctHV.HocVien.NgayDangKy = dao.NgayDangKy;
        //    ctHV.HocVien.NgaySinh = dao.NgaySinh;
        //    ctHV.HocVien.GhiChu = dao.GhiChu;
        //    ctHV.HocVien.Nguon = dao.Nguon;

        //    var daoPH = new PhuHuynhDao().getTwoElementPH(id);

        //    IEnumerable<PhuHuynh> listPH = daoPH;

        //    foreach(var item in listPH)
        //    {
        //        ctHV.PhuHuynh.TenPhuHuynh = item.TenPhuHuynh;
        //        ctHV.PhuHuynh.SDT = item.SDT;
        //        ctHV.PhuHuynh.GioiTinh = item.GioiTinh;
        //        ctHV.PhuHuynh.Email = item.Email;
        //    }

        //    return View(ctHV);
        //}

        [HttpGet] 
        public ActionResult GetSchedule(int id)
        {
            var dao = new ThoiKhoaBieuDao().ViewDetail(id);

            return View();
        }

        
        [HttpGet]
        public ActionResult CreateScore(int id)
        {
            GetViewBagLopHoc();
            var hocVienDao = new BangDiemDao().ViewDetail(id);

            return View(hocVienDao);
        }

        [HttpPost]
        public ActionResult CreateScore(BangDiem bangDiem)
        {
            var _bangDiemDao = new BangDiemDao();
            var _bangDiem = new BangDiem();

            _bangDiem.MaLopHoc = bangDiem.MaLopHoc;
            _bangDiem.MaHocVien = getId;
            _bangDiem.KT1 = bangDiem.KT1;
            _bangDiem.KT2 = bangDiem.KT2;
            _bangDiem.THIL1 = bangDiem.THIL1;
            _bangDiem.KetQua = bangDiem.KetQua;

            int check = _bangDiemDao.Insert(_bangDiem);

            if (check > 0)
            {
                SetAlert("Thêm thành công", 1);
                return RedirectToAction("Index", "HocVien");
            }
            else
            {
                SetAlert("Thêm thất bại", 3);
            }

            return View(bangDiem);
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
        //[ValidateAntiForgeryToken]
        public ActionResult AddCourse()
        {
          
            GetViewBagKhoaHoc();
            GetViewBagLopHoc();
            return View();
        }

        [HttpPost]
        public ActionResult AddCourse(DangKy entity,int id,int maLopHoc,int maKhoaHoc)
        {
            var hocVienDao = new HocVienDao().ViewDetails(id);
            GetViewBagIdHocVien(hocVienDao.MaHocVien);


            var hoaDonDao = new HoaDonDao();
            var ct_HoaDonDao = new CT_HoaDonDao();
            var khoaHocDao = new KhoaHocDao();

            var hoaDon = new HoaDon();
            var ct_HD = new CT_HoaDon();
            var khoaHoc = new KhoaHoc();

            khoaHoc.GiaTien = khoaHocDao.GiaTienKhoaHoc(maKhoaHoc);
          
            hoaDon.TongTien = (khoaHoc.GiaTien * 1);
            hoaDon.TinhTrang = entity.HoaDon.TinhTrang;
            hoaDon.MaHocVien = hocVienDao.MaHocVien;
            hoaDon.NgayLap = DateTime.Now;
            hoaDon.MaLopHoc = maLopHoc;
            hoaDon.MaKhoaHoc = maKhoaHoc;

            int checkHD = hoaDonDao.Insert(hoaDon);

            ct_HD.MaKhoaHoc = maKhoaHoc;
            ct_HD.MaHoaDon = checkHD;
            ct_HD.SoLuong = /*entity.CT_HoaDon.SoLuong*/ 1;

            int checkCTHD = ct_HoaDonDao.Insert(ct_HD);

            var khoaHocDaoEmail = new KhoaHocDao().ViewDetail(maKhoaHoc);
            var hocVienDaoEmail = new HocVienDao().ViewDetails(id);

            if(checkHD > 0 && checkCTHD > 0)
            {
                khoaHocDao.DangKyKhoaHoc(maKhoaHoc);
                SetAlert("Thêm thành công", 1);
                
                if (hocVienDao.Email == null)
                {
                    return RedirectToAction("Index", "HocVien");
                }
                else
                {
                    string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/Email/DangKyKhoaHoc.html"));

                    content = content.Replace("{{TenKH}}", khoaHocDaoEmail.TenKhoaHoc.ToString());
                    content = content.Replace("{{TenHV}}", hocVienDaoEmail.TenHocVien.ToString());
                    content = content.Replace("{{NgaySinh}}", hocVienDaoEmail.NgaySinh.ToString());
                    content = content.Replace("{{SDT}}", hocVienDaoEmail.SDT.ToString());
                    content = content.Replace("{{DiaChi}}", hocVienDaoEmail.DiaChi.ToString());
                    content = content.Replace("{{NgayDangKy}}", hocVienDaoEmail.NgayDangKy.ToString());

                    new MailHelper().SendMail(hocVienDao.Email, "Chào mừng em đã tham gia vào đại gia đình Đan Thanh!", content);
                    //SetAlert("")
                    return RedirectToAction("Index", "HocVien");
                }
            }
            else
            {
                ModelState.AddModelError("", "Có lỗi khi thêm chi tiết học viên");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateDetails()
        {
            return View();
        }    

        [HttpPost]
        public ActionResult CreateDetails(HocVienDetails hocVienDetails, HttpPostedFileBase hinhAnhDetail)
        {
           try
           {
                if(ModelState.IsValid)
                {
                    string path = "";
                    if(hinhAnhDetail != null && hinhAnhDetail.ContentLength > 0)
                    {
                        string extension = Path.GetExtension(hinhAnhDetail.FileName);
                        if (extension.Equals(".jpg") || extension.Equals(".png") || extension.Equals(".jpeg"))
                        {
                            path = Path.Combine(Server.MapPath("~/Img/HocVien/"), hinhAnhDetail.FileName);
                            hinhAnhDetail.SaveAs(path);
                        }
                        
                        var _daoHocVien = new HocVienDao();
                        var _daoPhuHuynh = new PhuHuynhDao();

                        var hocVien = new HocVien();

                        hocVien.TenHocVien = hocVienDetails.HocVien.TenHocVien;
                        hocVien.TaiKhoan = hocVienDetails.HocVien.TaiKhoan;
                        hocVien.MatKhau = hocVienDetails.HocVien.MatKhau;
                        hocVien.HinhAnh = hinhAnhDetail.FileName;
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

                        for (int i = 0; i < 2; i++)
                        {
                            var _phuHuynh = new PhuHuynh();

                            _phuHuynh.TenPhuHuynh = hocVienDetails.LstPhuHuynh[i].TenPhuHuynh;

                            _phuHuynh.TenPhuHuynh = hocVienDetails.LstPhuHuynh[i].TenPhuHuynh;
                            _phuHuynh.SDT = hocVienDetails.LstPhuHuynh[i].SDT;
                            _phuHuynh.GioiTinh = hocVienDetails.LstPhuHuynh[i].GioiTinh;
                            _phuHuynh.DiaChi = hocVienDetails.LstPhuHuynh[i].DiaChi;
                            _phuHuynh.Email = hocVienDetails.LstPhuHuynh[i].Email;
                            _phuHuynh.MaHocVien = _maHocVien;

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
                        return RedirectToAction("Index", "HocVien");
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

        public void GetViewBagKhoaHoc(int? maKhoaHoc = null)
        {
            var dao = new KhoaHocDao();
            ViewBag.MaKhoaHoc = new SelectList(dao.ListAll(), "MaKhoaHoc", "TenKhoaHoc", maKhoaHoc);
        }

        public void GetViewBagLopHoc(int? maLopHoc = null)
        {
            var dao = new LopHocDao();
            ViewBag.MaLopHoc = new SelectList(dao.ListAll(), "MaLopHoc", "TenLopHoc", maLopHoc);
        }

        public void GetViewBagIdHocVien(int maHocVien)
        {
            var dao = new HocVienDao();
            ViewBag.MaHocVien = dao.GetHocVienById(maHocVien);
        }

        public void DanhSachHocVien()
        {
            List<HocVienViewModels> hocVienList = _context.HocViens.Select(x => new HocVienViewModels
            {
                MaHocVien = x.MaHocVien,
                TenHocVien = x.TenHocVien,
                GioiTinh = x.GioiTinh,
                NgaySinh = x.NgaySinh,
                NgayDangKy = x.NgayDangKy,
                Email = x.Email,
                SDT = x.SDT,
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
            ws.Cells["H6"].Value = "Ghi chú";
            ws.Cells["K6"].Value = "Địa chỉ";
            ws.Cells["I6"].Value = "Trạng thái";
            int rowStart = 7;
            foreach (var item in hocVienList)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.MaHocVien;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.TenHocVien;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.GioiTinh;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.NgaySinh;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.NgayDangKy;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.Email;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.SDT;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.GhiChu;
                ws.Cells[string.Format("K{0}", rowStart)].Value = item.DiaChi;
                ws.Cells[string.Format("I{0}", rowStart)].Value = item.TrangThai;
                rowStart++;
            }


            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "aplication/vnd.openxmlformats-officedocument.spreedsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename" + "HocVienReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }

        public ActionResult ChiTietHocVien(int id)
        {
            var hocVienDao = new HocVienDao().ViewDetails(id);

            var details = new HocVienDetailsViewModels();

            details.MaHocVien = hocVienDao.MaHocVien;
            details.TenHocVien = hocVienDao.TenHocVien;
            details.NgayDangKy = hocVienDao.NgaySinh;
            details.NgayDangKy = hocVienDao.NgayDangKy;
            details.SDT = hocVienDao.SDT;
            details.Nguon = hocVienDao.Nguon;
            details.HinhAnh = hocVienDao.HinhAnh;
            details.GioiTinh = hocVienDao.GioiTinh;
            details.GhiChu = hocVienDao.GhiChu;

            ViewBag.MaHocVien = details.MaHocVien;

            return View(details);
        }

        public ActionResult GetBillByStudent(int id)
        {
            var list = new HocVienDao().getListBillByStudent(id);

            ViewBag.TenHocVien = new HocVienDao().ViewDetails(id).TenHocVien;
            ViewBag.TongTien = new HocVienDao().TotalMoney(id);

            return View(list);
        }
    }
}


