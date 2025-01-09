using B2B.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B2B.Controllers
{
    public class DocumentController : Controller
    {
        const string GUARANTI_KEY = "KYS-ELK01-L002-L002";

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetData()
        {
            List<MARA> maras = new List<MARA>();
            var client = new ServiceMalzeme.WebServiceMalzemeSoapClient();
            var hd = new ServiceMalzeme.AuthHeader()
            {
                Username = "AlfemoUB2B_ServiceUser",
                Password = "Alfemo!2024_!"
            };

            var sonuc = client.GelMaterial(hd);
            if (!string.IsNullOrEmpty(sonuc))
            {
                maras = JsonConvert.DeserializeObject<List<MARA>>(sonuc);
            }

            var jsonResult = Json(new { data = maras }, JsonRequestBehavior.AllowGet);
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
    }
}