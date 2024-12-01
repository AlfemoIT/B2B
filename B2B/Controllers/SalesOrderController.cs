using B2B.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Security;

namespace B2B.Controllers
{
    public class SalesOrderController : Controller
    {
        const string GUARANTI_KEY = "KYS-ELK01-L002-L002";

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
                    TempData["Orders"] = orders;
                }
            }

            var headers = (from order in orders
                           group order by new
                           {
                               order.CMPT_ABGRU,
                               order.AUDAT,
                               order.VBELN,
                               order.CMTD_DELIV_DATE,
                               order.KUNAGTANIM,
                               order.ZZMUSTERI_AD,
                               order.WAERK
                           }
                           into grouped
                           select new ZAL_S_SIPARIS_HEADER
                           {
                               CMPT_ABGRU = grouped.Key.CMPT_ABGRU,
                               AUDAT = grouped.Key.AUDAT,
                               VBELN = grouped.Key.VBELN,
                               CMTD_DELIV_DATE = grouped.Key.CMTD_DELIV_DATE,
                               KUNAGTANIM = grouped.Key.KUNAGTANIM,
                               ZZMUSTERI_AD = grouped.Key.ZZMUSTERI_AD,
                               WAERK = grouped.Key.WAERK == "TRY" ? "TL" : grouped.Key.WAERK,
                               TOTAL_ORDER_PRICE = grouped.Sum(x => x.CMPT_TOTAL_ORDER_PRICE).ToString()
                           }).Where(x => x.CMPT_TOTAL_ORDER_PRICE > 0)
                             .ToList();

            var jsonResult = Json(new { data = headers }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpGet]
        public JsonResult GetDataRow(string siparis)
        {
            List<ZAL_S_SIPARIS_ROW> orders = new List<ZAL_S_SIPARIS_ROW>();
            if (TempData["Orders"] != null)
            {
                TempData.Keep("Orders");

                orders = (List<ZAL_S_SIPARIS_ROW>)TempData["Orders"];
                orders = (from order in orders
                          where order.VBELN == siparis
                          select new ZAL_S_SIPARIS_ROW
                          {
                              VBELN = order.VBELN,
                              POSNR = order.POSNR,
                              MATNR = order.MATNR,
                              MAKTX = order.MAKTX,
                              LONG_MAKTX = order.LONG_MAKTX,
                              KWMENG = order.KWMENG,
                              TOTAL_FKIMG = order.TOTAL_FKIMG,
                              TOTAL_LFIMG = order.TOTAL_LFIMG,
                              TOTAL_BMENG = order.TOTAL_BMENG,
                              READY_VOLUM = order.READY_VOLUM,
                              TOTAL_IN_PRODUCTION = (order.CMPT_TOTAL_IN_PRODUCTION + order.CMPT_TOTAL_IN_PLAN).ToString(),
                              ZZURTM_WEEK_DESC = order.ZZURTM_WEEK_DESC,
                              TOTAL_ORDER_PRICE = order.TOTAL_ORDER_PRICE,
                              WAERK = order.WAERK
                          }).ToList();
            }

            var jsonResult = Json(new { data = orders }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}