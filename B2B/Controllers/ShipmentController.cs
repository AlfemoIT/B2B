using B2B.Dal;
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
    public class ShipmentController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetData(string iv_kunnr)
        {
            var user = GetUser();
            List<string> lst_kunnr = new List<string>();
            using (var context = new B2bContext())
            {
                if (user.RoleID == 6) //bolge muduru
                {
                    lst_kunnr.Add(iv_kunnr);
                }
                else
                {
                    lst_kunnr = (from customera in context.CustomerAssignments.Where(x => x.UserID == user.ID)
                                 join customer in context.Customers on customera.CustomerID equals customer.ID
                                 select customer.SapCode).ToList();
                }
            }

            List<ZAL_S_NAKLIYE> shipments = new List<ZAL_S_NAKLIYE>();
            if (lst_kunnr.Count > 0)
            {
                var client = new ServiceShipment.WebServiceShipmentSoapClient();
                var hd = new ServiceShipment.AuthHeader()
                {
                    Username = "AlfemoUB2B_ServiceUser",
                    Password = "Alfemo!2024_!"
                };
                var sonuc = client.GetShipments(hd, lst_kunnr.ToArray());
                if (!sonuc.Contains("-111"))
                {
                    shipments = JsonConvert.DeserializeObject<List<ZAL_S_NAKLIYE>>(sonuc);
                    TempData["Shipments"] = shipments;
                }
            }

            var cmpt_date = DateTime.Now.Date.AddDays(-10);
            var result = shipments.Where(x => x.CMPT_N_ERDAT_DATE > cmpt_date).OrderByDescending(x => x.CMPT_N_ERDAT_DATE)
            .Select(x => new
            {
                id = x.CMPT_TKNUM,
                text = string.Concat(x.CMPT_TKNUM, " / ", x.CMPT_N_ERDAT)
            });

            var jsonResult = Json(new { items = result }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetDriver(string tknum)
        {
            List<ZAL_S_NAKLIYE> shipments = new List<ZAL_S_NAKLIYE>();
            if (TempData["Shipments"] != null)
            {
                TempData.Keep("Shipments");
                shipments = (List<ZAL_S_NAKLIYE>)TempData["Shipments"];
            }
            var jsonResult = Json(new { data = shipments.FirstOrDefault(x => x.CMPT_TKNUM == tknum) }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public JsonResult GetDetail(string nakliye_no, string iv_kunnr)
        {
            var lst_kunnr = new List<string>();
            var shipments = new List<ZAL_S_NAKLIYE>();
            var user = GetUser();
            using (var context = new B2bContext())
            {
                if (user.RoleID == 6) //bolge muduru icin
                {
                    lst_kunnr.Add(iv_kunnr);
                }
                else
                {
                    lst_kunnr = (from customera in context.CustomerAssignments.Where(x => x.UserID == user.ID)
                                 join customer in context.Customers on customera.CustomerID equals customer.ID
                                 select customer.SapCode).ToList();
                }
            }

            var client = new ServiceShipment.WebServiceShipmentSoapClient();
            var hd = new ServiceShipment.AuthHeader()
            {
                Username = "AlfemoUB2B_ServiceUser",
                Password = "Alfemo!2024_!"
            };
            var sonuc = client.GetShipmentDetails(hd, lst_kunnr.ToArray(), nakliye_no);
            if (!sonuc.Contains("-111"))
            {
                shipments = JsonConvert.DeserializeObject<List<ZAL_S_NAKLIYE>>(sonuc);
            }

            var jsonResult = Json(new { data = shipments }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public User GetUser()
        {
            var formsIdentity = HttpContext.User.Identity as FormsIdentity;
            if (formsIdentity == null) { return null; }

            var ticket = formsIdentity.Ticket;
            var userData = ticket.UserData;
            var user = JsonConvert.DeserializeObject<User>(userData);
            return user;
        }
    }
}