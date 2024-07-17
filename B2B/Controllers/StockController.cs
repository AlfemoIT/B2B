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
    public class StockController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View(GetUser());
        }

        public KNA1 GetUser()
        {
            var formsIdentity = HttpContext.User.Identity as FormsIdentity;
            if (formsIdentity == null) { return null; }

            var ticket = formsIdentity.Ticket;
            var userData = ticket.UserData;
            var user = JsonConvert.DeserializeObject<KNA1>(userData);
            return user;
        }

        [HttpPost]
        public JsonResult GetMaterialGrub()
        {
            MATERIAL_GRUB grub = new MATERIAL_GRUB();

            var client = new ServiceMalzeme.WebServiceMalzemeSoapClient();
            var hd = new ServiceMalzeme.AuthHeader()
            {
                Username = "AlfemoUB2B_ServiceUser",
                Password = "Alfemo!2024_!"
            };
            var sonuc = client.GetMaterialGrub(hd);
            if (!string.IsNullOrEmpty(sonuc))
            {
                grub = JsonConvert.DeserializeObject<MATERIAL_GRUB>(sonuc);
            }

            try
            {
                grub.tvm3ts = grub.tvm3ts.OrderBy(x => x.BEZEI).ToList();
                grub.tvm2ts = grub.tvm2ts.OrderBy(x => x.BEZEI).ToList();
                grub.tvm4ts = grub.tvm4ts.OrderBy(x => x.BEZEI).ToList();
            }
            catch (Exception) { }

            var jsonResult = Json(new { data = grub }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpGet]
        public JsonResult GetData(string sortl, string mvgr2, string mvgr3, string mvgr4)
        {
            List<ZALF_S_PAKET> pakets = new List<ZALF_S_PAKET>();
            var client = new ServiceStock.WebServiceStockSoapClient();
            var hd = new ServiceStock.AuthHeader()
            {
                Username = "AlfemoUB2B_ServiceUser",
                Password = "Alfemo!2024_!"
            };

            var sonuc = client.GetObservedStock(hd, sortl, mvgr2, mvgr3, mvgr4);
            if (!string.IsNullOrEmpty(sonuc))
            {
                pakets = JsonConvert.DeserializeObject<List<ZALF_S_PAKET>>(sonuc);
            }

            if (sortl.Equals("BAYI"))
            {
                pakets = pakets.Where(x => int.Parse(x.CMPT_SEVK) > 0)
                               .ToList();
            }
            else if (sortl.Equals("PERAKENDE"))
            {
                pakets = pakets.Where(x => int.Parse(x.CMPT_SEVK + x.CMPT_MRSN + x.CMPT_A049 + x.CMPT_ANPD) > 0)
                               .ToList();
            }

            return Json(new { data = pakets }, JsonRequestBehavior.AllowGet);
        }
    }
}