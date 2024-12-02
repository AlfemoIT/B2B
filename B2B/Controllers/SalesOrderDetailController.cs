using B2B.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            List<ZAL_S_SIPARIS_ROW> orders = new List<ZAL_S_SIPARIS_ROW>();
            if (!string.IsNullOrEmpty(iv_kunnr))
            {
                var client = new ServiceSalesOrder.WebServiceSalesOrderSoapClient();
                var hd = new ServiceSalesOrder.AuthHeader()
                {
                    Username = "AlfemoUB2B_ServiceUser",
                    Password = "Alfemo!2024_!"
                };
                var sonuc = client.GetOpenOrders(hd, iv_kunnr, iv_cmpt_abgru);
                if (!sonuc.Contains("-111"))
                {
                    orders = JsonConvert.DeserializeObject<List<ZAL_S_SIPARIS_ROW>>(sonuc);
                }
            }

            var jsonResult = Json(new
            {
                data = orders.Where(x => x.CMPT_TOTAL_ORDER_PRICE > 0)
                                                     .ToList()
            },
                                  JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}