using B2B.Dal;
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
    public class SalesOrderDetailController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetData(string iv_kunnr, string iv_cmpt_abgru)
        {
            var user = GetUser();
            var orders = new List<ZAL_S_SIPARIS_ROW>();
            List<string> lst_kunnr = new List<string>();
            if (!string.IsNullOrEmpty(iv_kunnr))
            {
                lst_kunnr.Add(iv_kunnr);

                var client = new ServiceSalesOrder.WebServiceSalesOrderSoapClient();
                var hd = new ServiceSalesOrder.AuthHeader()
                {
                    Username = "AlfemoUB2B_ServiceUser",
                    Password = "Alfemo!2024_!"
                };
                var sonuc = client.GetOpenOrders(hd, lst_kunnr.ToArray(), iv_cmpt_abgru);
                if (!sonuc.Contains("-111"))
                {
                    orders = JsonConvert.DeserializeObject<List<ZAL_S_SIPARIS_ROW>>(sonuc);
                }
            }

            var jsonResult = Json(new
            {
                data = orders.Where(x => x.CMPT_TOTAL_ORDER_PRICE > 0)
                             .ToList()
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