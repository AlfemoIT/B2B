using B2B.Dal;
using B2B.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B2B.Controllers
{
    public class StoreController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetData(string cID)
        {
            List<ZALF_S_PAKET> pakets = new List<ZALF_S_PAKET>();
            string iv_lgort = string.Empty;
            using (var context = new B2bContext())
            {
                iv_lgort = (from customer in context.Customers.AsEnumerable().Where(x => x.ID == int.Parse(cID))
                            join storageas in context.StorageAssignments.AsEnumerable()
                            on customer.ID equals storageas.CustomerID
                            join storage in context.Storages.AsEnumerable().Where(x => x.IsCentral == true)
                            on storageas.StorageID equals storage.ID
                            select storage.Code).FirstOrDefault();

                if (!string.IsNullOrEmpty(iv_lgort))
                {
                    var client = new ServiceStock.WebServiceStockSoapClient();
                    var hd = new ServiceStock.AuthHeader()
                    {
                        Username = "AlfemoUB2B_ServiceUser",
                        Password = "Alfemo!2024_!"
                    };
                    var sonuc = client.GetStoreObservedStock(hd, iv_lgort, string.Empty, string.Empty, string.Empty);
                    if (!string.IsNullOrEmpty(sonuc))
                    {
                        pakets = JsonConvert.DeserializeObject<List<ZALF_S_PAKET>>(sonuc);
                    }
                    if (pakets.Count > 0)
                    {
                        pakets = pakets.Where(x => int.Parse(x.CMPT_TESHIR) > 0)
                                       .ToList();
                    }
                }
            }

            return Json(new { data = pakets }, JsonRequestBehavior.AllowGet);
        }
    }
}