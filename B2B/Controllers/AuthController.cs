using B2B.Dal;
using B2B.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace B2B.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (string.IsNullOrEmpty(user.RegistrationNo) ||
                string.IsNullOrEmpty(user.Password))
            {
                ViewBag.Message = String
                    .Concat("<div class='alert alert-warning alert-dismissable'>",
                            "Tc/Vergi ve Telefon No boş geçilemez!.",
                            "</div> ");
                return View();
            }

            using (var context = new B2bContext())
            {
                var _user = context.Users.FirstOrDefault(x => x.RegistrationNo.Equals(user.RegistrationNo) &&
                                                              x.Password.Equals(user.Password));
                if (_user == null)
                {
                    ViewBag.Message = String
                        .Concat("<div class='alert alert-danger alert-dismissable'>",
                                "Giriş bilgilerinizi kontrol ediniz.",
                                "</div>");
                    return View();
                }

                SetAuthCookie(_user);
                return RedirectToAction("Index", "Home");
            }
        }
        private void SetAuthCookie(User user)
        {
            var userData = JsonConvert.SerializeObject(user);
            var authTicket = new FormsAuthenticationTicket(
                  1,
                  user.NameSurname,
                  DateTime.Now,
                  DateTime.Now.AddMinutes(20),
                  false,
                  userData,
                  FormsAuthentication.FormsCookiePath);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                        FormsAuthentication.Encrypt(authTicket));
            Response.Cookies.Add(cookie);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();

            HttpCookie rFormsCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            rFormsCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(rFormsCookie);

            HttpCookie rSessionCookie = new HttpCookie("ASP.NET_SessionId", "");
            rSessionCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(rSessionCookie);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}