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
    }
}