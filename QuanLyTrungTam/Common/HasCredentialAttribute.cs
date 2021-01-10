using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTrungTam.Common
{
    // Kiem tra quyen
    public class HasCredentialAttribute : AuthorizeAttribute
    {
        public string MaChucNang { set; get; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //var isAuthorized = base.AuthorizeCore(httpContext);
            //if(!isAuthorized)
            //{
            //    return false;
            //}
            var session = (UserLogin)HttpContext.Current.Session[Common.CommonConstants.USER_SESSION];
            if (session == null)
            {
                return false;
            }
            //string privilegeLevels = string.Join(";", this.GetCredentialByLoggedInUser(session.TaiKhoan));
            List<string> privilegeLevels = this.GetCredentialByLoggedInUser(session.TaiKhoan);

            if (privilegeLevels.Contains(this.MaChucNang) || session.MaVaiTro == Common1.CommonConstants.ADMIN_GROUP)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/401.cshtml"
            };
        }

        private List<String> GetCredentialByLoggedInUser(string userName)
        {
            var credentials = (List<string>)HttpContext.Current.Session[CommonConstants.SESSION_CREDENTIALS];
            return credentials;
        }
    }
}