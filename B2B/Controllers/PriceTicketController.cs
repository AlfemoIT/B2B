using B2B.Models;
using B2B.Models.Tree;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B2B.Controllers
{
    public class PriceTicketController : Controller
    {
        const string directloc = @"D:\Pazarlama\FiyatEtiketi";

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetData()
        {
            List<ZSD_S_FIY_TICKET> fiy_tickets = new List<ZSD_S_FIY_TICKET>();

            var client = new ServiceTicket.WebServiceTicketSoapClient();
            var hd = new ServiceTicket.AuthHeader()
            {
                Username = "AlfemoUB2B_ServiceUser",
                Password = "Alfemo!2024_!"
            };
            var sonuc = client.GetPriceTicket(hd);
            if (!sonuc.Contains("-111"))
            {
                var t_fiy_ticket = JsonConvert.DeserializeObject<FIY_TICKET>(sonuc);
                fiy_tickets = t_fiy_ticket.ZSD_S_FIY_TICKETS;
            }

            var jsonResult = Json(new { data = fiy_tickets }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetFileNames()
        {
            List<Z_FILE> z_files = new List<Z_FILE>();
            FileInfo[] files = new DirectoryInfo(directloc).GetFiles();
            foreach (var file in files)
            {
                z_files.Add(new Z_FILE
                {
                    NAME = file.Name,
                    CREATION_TIME = file.CreationTime
                });
            }

            var jsonResult = Json(new { data = z_files.OrderBy(x => x.CREATION_TIME) }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpGet]
        public ActionResult GetPricePdf(string file)
        {
            string pdfFilePath = Path.Combine(directloc, file);
            byte[] fileBytes = System.IO.File.ReadAllBytes(pdfFilePath);

            return File(fileBytes,
                        System.Net.Mime.MediaTypeNames.Application.Pdf,
                        file);
        }
    }
}