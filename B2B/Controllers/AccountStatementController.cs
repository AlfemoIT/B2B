using B2B.Dal;
using B2B.Helper;
using B2B.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace B2B.Controllers
{
    public class AccountStatementController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetData(string iv_kunnr)
        {
            var user = GetUser();
            var accounts = new List<ZAL_S_CARI>();

            if (user.RoleID == (int)EnumHelper.Role.Yatirimci ||
               user.RoleID == (int)EnumHelper.Role.MagazaMuduru ||
               user.RoleID == (int)EnumHelper.Role.SatisDanismani)
            {
                using (var context = new B2bContext())
                {
                    iv_kunnr = (from customera in context.CustomerAssignments.Where(x => x.UserID == user.ID)
                                join customer in context.Customers on customera.CustomerID equals customer.ID
                                where customer.SalesOfficeID == user.SalesOfficeID &&
                                      customer.IsCentral == true
                                select customer.SapCode).FirstOrDefault();
                }
            }

            var client = new ServiceAccount.WebServiceCariSoapClient();
            var hd = new ServiceAccount.AuthHeader()
            {
                Username = "AlfemoUB2B_ServiceUser",
                Password = "Alfemo!2024_!"
            };
            var sonuc = client.AccountStatement(hd, iv_kunnr);
            try
            {
                if (!sonuc.Contains("Liste veri içerm"))
                {
                    accounts = JsonConvert.DeserializeObject<List<ZAL_S_CARI>>(sonuc);
                }
            }
            catch (Exception) { }

            var jsonResult = Json(new
            {
                data = accounts
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public User GetUser()
        {
            var formsIdentity = HttpContext.User.Identity as FormsIdentity;
            if (formsIdentity == null) { return null; }
            var ticket = formsIdentity.Ticket;
            var userData = ticket.UserData;
            var user = JsonConvert.DeserializeObject<User>(userData);
            return user;
        }
    }
}