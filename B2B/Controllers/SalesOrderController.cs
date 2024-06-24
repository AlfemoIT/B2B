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
            return View(GetUser());
        }

        [HttpPost]
        public JsonResult GetData()
        {
            List<VBAP> vbaps = new List<VBAP>();
            var kna1 = GetUser();
            if (!string.IsNullOrEmpty(kna1.KUNNR))
            {
                var client = new ServiceSalesOrder.WebServiceSalesOrderSoapClient();
                var hd = new ServiceSalesOrder.AuthHeader()
                {
                    Username = "AlfemoUB2B_ServiceUser",
                    Password = "Alfemo!2024_!"
                };
                var sonuc = client.GetSalesOrder(hd, string.Empty, kna1.KUNNR);
                if (!sonuc.Contains("-111"))
                {
                    vbaps = JsonConvert.DeserializeObject<List<VBAP>>(sonuc);
                }
            }

            var jsonResult = Json(new { data = vbaps }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpGet]
        public ActionResult GetMontagePdf(string matnr)
        {
            var client = new ServiceQdms.AlfemoWebSiteServiceSoapClient();
            var hd = new ServiceQdms.AuthHeader()
            {
                Username = "Alf_mntj_user",
                Password = "ALF6G#_@09yUr#s!"
            };

            var sonuc = client.AlfemoUrunPdf(hd, string.Join("-", "M", matnr));
            if (sonuc.Contains("404 Hata: Malzemenin teknik resmi yok."))
            {
                sonuc = client.AlfemoUrunPdf(hd, GUARANTI_KEY);
            }

            byte[] fileBytes = Convert.FromBase64String(sonuc);
            return File(fileBytes,
                        System.Net.Mime.MediaTypeNames.Application.Pdf,
                        string.Concat(string.Join("-", "ALFEMO", matnr), ".pdf"));
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
    }
}