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
    public class PriceController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetColumnNames()
        {
            List<ZALF_SUTUNAD_T> sutuns = new List<ZALF_SUTUNAD_T>();

            var client = new ServiceColumn.WebServiceColumnSoapClient();
            var hd = new ServiceColumn.AuthHeader()
            {
                Username = "AlfemoUB2B_ServiceUser",
                Password = "Alfemo!2024_!"
            };
            var sonuc = client.GetColumnName(hd);
            if (!sonuc.Contains("-111"))
            {
                sutuns = JsonConvert.DeserializeObject<List<ZALF_SUTUNAD_T>>(sonuc);
            }

            var jsonResult = Json(new
            {
                tableColumns = sutuns
                                .Where(x => x.TABLO == "ZMBLY_URUN_FIYAT" || x.TABLO == "KONP")
                                .ToList()
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetData()
        {
            PRODUCT_PRICE product_price = new PRODUCT_PRICE();

            var client = new ServicePrice.WebServicePriceSoapClient();
            var hd = new ServicePrice.AuthHeader()
            {
                Username = "AlfemoUB2B_ServiceUser",
                Password = "Alfemo!2024_!"
            };
            var sonuc = client.GetProductPrice(hd);
            if (!sonuc.Contains("-111"))
            {
                product_price = JsonConvert.DeserializeObject<PRODUCT_PRICE>(sonuc);
            }

            var consolidatedChildren =
                    from price in product_price.PRICES
                    group price by new
                    {
                        price.MAKTX,
                        price.BEZEI,
                        price.BEZEI2,
                        price.BEZEI3,
                        price.BEZEI4,
                        price.BEZEI5,

                        price.CMPT_FIYAT1,
                        price.CMPT_FIYAT2,
                        price.CMPT_FIYAT3,
                        price.CMPT_FIYAT4,
                        price.CMPT_FIYAT5,

                        price.CMPT_Z001,
                        price.CMPT_Z015,
                        price.CMPT_Z022,

                        price.PARA_BIRIMI,
                    } into gcs
                    select new
                    {
                        MATNR = string.Empty,
                        MAKTX = gcs.Key.MAKTX.ToUpper(),
                        BEZEI = gcs.Key.BEZEI,
                        BEZEI2 = gcs.Key.BEZEI2,
                        BEZEI3 = gcs.Key.BEZEI3,
                        BEZEI4 = gcs.Key.BEZEI4,
                        BEZEI5 = gcs.Key.BEZEI5,

                        CMPT_FIYAT1 = gcs.Key.CMPT_FIYAT1,
                        CMPT_FIYAT2 = gcs.Key.CMPT_FIYAT2,
                        CMPT_FIYAT3 = gcs.Key.CMPT_FIYAT3,
                        CMPT_FIYAT4 = gcs.Key.CMPT_FIYAT4,
                        CMPT_FIYAT5 = gcs.Key.CMPT_FIYAT5,

                        CMPT_Z001 = gcs.Key.CMPT_Z001,
                        CMPT_Z015 = gcs.Key.CMPT_Z015,
                        CMPT_Z022 = gcs.Key.CMPT_Z022,

                        PARA_BIRIMI = gcs.Key.PARA_BIRIMI,

                        _children = gcs.ToList()
                    };

            var jsonResult = Json(new { tableData = consolidatedChildren.ToList(), campaign = product_price?.CAMPAIGN }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}