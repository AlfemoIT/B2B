using B2B.Helper;
using B2B.Models;
using B2B.Models.Chart;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B2B.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //public JsonResult GetChartData(string iv_kunnr, string iv_cmpt_abgru)
        //{
        //    List<string> lst_kunnr = new List<string>();
        //    List<ZAL_S_SIPARIS_ROW> orders = new List<ZAL_S_SIPARIS_ROW>();
        //    if (!string.IsNullOrEmpty(iv_kunnr))
        //    {
        //        lst_kunnr.Add(iv_kunnr);
        //        var client = new ServiceSalesOrder.WebServiceSalesOrderSoapClient();
        //        var hd = new ServiceSalesOrder.AuthHeader()
        //        {
        //            Username = "AlfemoUB2B_ServiceUser",
        //            Password = "Alfemo!2024_!"
        //        };

        //        var sonuc = client.GetOpenOrders(hd, lst_kunnr.ToArray(), iv_cmpt_abgru);
        //        if (!sonuc.Contains("-111"))
        //        {
        //            orders = JsonConvert.DeserializeObject<List<ZAL_S_SIPARIS_ROW>>(sonuc);
        //            orders = orders.OrderBy(x => x.CMPT_YEAR)
        //                  .ThenBy(x => x.CMPT_MONTH)
        //                  .ToList();
        //        }
        //    }

        //    var groupedData = (from order in orders
        //                       group order by new { order.CMPT_YEAR, order.CMPT_MONTH, order.CMPT_MONTH_NAME }
        //                       into orderGroup
        //                       select new SalesOrderChart
        //                       {
        //                           YearMonth = string.Join("-", orderGroup.Key.CMPT_YEAR.ToString(),
        //                                                        orderGroup.Key.CMPT_MONTH_NAME),
        //                           OpenOrderAmount = orderGroup.Where(x => x.CMPT_ABGRU == "ACIK")
        //                                                       .Sum(x => x.CMPT_TOTAL_ORDER_PRICE),
        //                           CloseOrderAmount = orderGroup.Where(x => x.CMPT_ABGRU == "KAPALI")
        //                                                        .Sum(x => x.CMPT_TOTAL_ORDER_PRICE)
        //                       }).ToList();

        //    var jsonResult = Json(groupedData, JsonRequestBehavior.AllowGet);
        //    jsonResult.MaxJsonLength = int.MaxValue;
        //    return jsonResult;
        //}
        public int GetWeek()
        {
            DateTime today = DateTime.Now;
            Calendar calendar = CultureHelper.TRCultureInfo.Calendar;
            CalendarWeekRule weekRule = CalendarWeekRule.FirstDay;
            DayOfWeek firstDayOfWeek = DayOfWeek.Monday;
            int weekNumber = calendar.GetWeekOfYear(today, weekRule, firstDayOfWeek);
            return weekNumber;
        }
    }
}