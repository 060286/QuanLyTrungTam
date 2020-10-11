using Models;
using QuanLyTrungTam.Code;
using QuanLyTrungTam.Models;
using System.Web.Mvc;
using System.Web.Security;

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
            //var result = new TaiKhoanModel().Login(model.TaiKhoan, model.MatKhau);
            if(Membership.ValidateUser(model.TaiKhoan,model.MatKhau) && ModelState.IsValid)
            {
                //SessionHelper.SetSession(new UserSession() { TaiKhoan = model.TaiKhoan });
                FormsAuthentication.SetAuthCookie(model.TaiKhoan,model.TinhTrang);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu sai.");
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}