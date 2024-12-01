using B2B.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B2B.Controllers
{
    public class ShipmentController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetData(string iv_kunnr)
        {
            List<ZAL_S_SIPARIS_ROW> orders = new List<ZAL_S_SIPARIS_ROW>();
            //if (!string.IsNullOrEmpty(iv_kunnr))
            //{
            //    var client = new ServiceSalesOrder.WebServiceSalesOrderSoapClient();
            //    var hd = new ServiceSalesOrder.AuthHeader()
            //    {
            //        Username = "AlfemoUB2B_ServiceUser",
            //        Password = "Alfemo!2024_!"
            //    };
            //    var sonuc = client.GetShipments(hd, iv_kunnr);
            //    if (!sonuc.Contains("-111"))
            //    {
            //        orders = JsonConvert.DeserializeObject<List<ZAL_S_SIPARIS_ROW>>(sonuc);
            //        TempData["Shipments"] = orders;
            //    }
            //}

            //var headers = (from order in orders
            //               group order by new
            //               {
            //                   order.TKNUM,
            //                   order.KUNAGTANIM,
            //                   order.SURUCU,
            //                   order.TELEFON,
            //                   order.PLAKA,
            //                   order.CMPT_ABGRU
            //               }
            //               into grouped
            //               select new ZAL_S_SIPARIS_HEADER
            //               {
            //                   CMPT_ABGRU = grouped.Key.CMPT_ABGRU,
            //                   TKNUM = grouped.Key.TKNUM,
            //                   KUNAGTANIM = grouped.Key.KUNAGTANIM,
            //                   SURUCU = grouped.Key.SURUCU,
            //                   TELEFON = grouped.Key.TELEFON,
            //                   PLAKA = grouped.Key.PLAKA
            //               }).ToList();

            var jsonResult = Json(new { data = new List<ZAL_S_SIPARIS_HEADER>() }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}