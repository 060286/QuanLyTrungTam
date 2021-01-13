using Models.DAO;
using Models.Framework;
using QuanLyTrungTam.Common;
using QuanLyTrungTam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QuanLyTrungTam.Controllers
{
    public class DangNhapController : Controller
    {
        private eCenterDbContext _context = new eCenterDbContext();

       

        // GET: DangNhap
        public ActionResult Index(DangNhap dn)
        {
            return View(dn);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Update(DangNhap dn)
        {
            var dangNhapDao = new DangNhapDao();

            var dangNhap = new DangNhap();

            var check = dangNhapDao.UpdateAccount(dn);

            if(check)
            {
                return RedirectToAction("Logout", "Login");
            }
            return View("Index");
        }

        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(DangNhap model, FormCollection collection)
        {
            var matKhauCu = collection["MatKhauCu"];
            var matKhauMoi = collection["MatKhauMoi"];
            var nhaplaiMK = collection["NhapLaiMK"];
            var encryptedMd5Pas = Encryptor.MD5Hash(matKhauCu);
            var newPass = Encryptor.MD5Hash(matKhauMoi);
            var dao = new DangNhapDao();
            model = dao.ViewDetails(model.MaTaiKhoan);
            if (model.MatKhau == encryptedMd5Pas)
            {
                if (matKhauMoi == nhaplaiMK)
                {
                    var nhanvien = _context.DangNhaps.Find(model.MaTaiKhoan);
                    nhanvien.MatKhau = newPass;

                    _context.SaveChanges();

                    return RedirectToAction("Logout", "Login");

                }
                else
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
