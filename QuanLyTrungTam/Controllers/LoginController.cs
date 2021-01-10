using Models;
using QuanLyTrungTam.Code;
using QuanLyTrungTam.Common;
using QuanLyTrungTam.Models;
using System.Text.RegularExpressions;
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
        public ActionResult Login(LoginModel model)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(model.TaiKhoan);

            if (match.Success)
            {
                if(ModelState.IsValid)
                {
                    
                }    
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var dao = new TaiKhoanDao();
                    var result = dao.Login(model.TaiKhoan, Encryptor.MD5Hash(model.MatKhau));
                    if (result == 1)
                    {
                        var user = dao.GetById(model.TaiKhoan);
                        var userSession = new UserLogin();
                        userSession.UserId = user.MaTaiKhoan;
                        userSession.TaiKhoan = user.TaiKhoan;
                        userSession.MaVaiTro = user.MaVaiTro;
                        var listCredentials = dao.GetListCredential(model.TaiKhoan);

                        Session.Add(CommonConstants.SESSION_CREDENTIALS, listCredentials);
                        Session.Add(CommonConstants.USER_SESSION, userSession);
                        return RedirectToAction("Index", "Home");
                    }
                    else if (result == -1)
                    {
                        ModelState.AddModelError("", "Tài khoản hiện đang bị khóa");
                    }
                    else if (result == -2)
                    {
                        ModelState.AddModelError("", "Vui lòng nhập lại mật khẩu");
                    }
                    else if (result == 0)
                    {
                        ModelState.AddModelError("", "Tài khoản không tồn tại");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng nhập thất bại, vui lòng liên hệ Admin");
                    }
                }
            }
            return View("Index");
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(LoginModel model)
        //{
        //    //var result = new TaiKhoanModel().Login(model.TaiKhoan, model.MatKhau);
        //    if(Membership.ValidateUser(model.TaiKhoan,model.MatKhau) && ModelState.IsValid)
        //    {
        //        //SessionHelper.SetSession(new UserSession() { TaiKhoan = model.TaiKhoan });
        //        FormsAuthentication.SetAuthCookie(model.TaiKhoan,model.TinhTrang);
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu sai.");
        //    }

        //    return View(model);
        //}

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}