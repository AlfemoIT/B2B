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
        public ActionResult Login(KNA1 kna1)
        {
            if (string.IsNullOrEmpty(kna1.STCD2) ||
                string.IsNullOrEmpty(kna1.TELF1))
            {
                ViewBag.Message = String
                    .Concat("<div class='alert alert-warning alert-dismissable'>",
                            "Tc/Vergi ve Telefon No boş geçilemez!.",
                            "</div> ");
                return View();
            }

            var client = new ServiceAuth.WebServiceAuthSoapClient();
            var hd = new ServiceAuth.AuthHeader()
            {
                Username = "AlfemoUB2B_ServiceUser",
                Password = "Alfemo!2024_!"
            };

            var sonuc = client.AuthUser(hd, kna1.STCD2, kna1.TELF1);
            if (sonuc.Contains("-111"))
            {
                ViewBag.Message = String
                         .Concat("<div class='alert alert-danger alert-dismissable'>",
                                  sonuc.Replace("-111-", string.Empty),
                                 "</div>");
                return View();
            }

            SetAuthCookie(JsonConvert.DeserializeObject<KNA1>(sonuc));
            return RedirectToAction("Index", "Home");
        }
        private void SetAuthCookie(KNA1 user)
        {
            var userData = JsonConvert.SerializeObject(user);
            var authTicket = new FormsAuthenticationTicket(
                  1,
                  user.NAME1,
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

            //clear authentication cookie
            HttpCookie rFormsCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            rFormsCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(rFormsCookie);

            //clear session cookie 
            HttpCookie rSessionCookie = new HttpCookie("ASP.NET_SessionId", "");
            rSessionCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(rSessionCookie);

            return RedirectToAction("Login");
        }
    }
}