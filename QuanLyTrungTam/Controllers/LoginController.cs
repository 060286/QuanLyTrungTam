using Models;
using QuanLyTrungTam.Code;
using QuanLyTrungTam.Models;
using System.Web.Mvc;

namespace QuanLyTrungTam.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        // Nhận từ URL
        [HttpGet] 
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var result = new TaiKhoanModel().Login(model.TaiKhoan, model.MatKhau);
            if(result && ModelState.IsValid)
            {   
                SessionHelper.SetSession(new UserSession() { TaiKhoan = model.TaiKhoan });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu sai.");
            }

            return View(model);
        }
    }
}