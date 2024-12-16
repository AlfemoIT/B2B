﻿using B2B.Dal;
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
    public class AccountStatementController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetData()
        {
            var user = GetUser();
            List<ZAL_S_CARI> accounts = new List<ZAL_S_CARI>();
            using (var context = new B2bContext())
            {
                var iv_kunnr = (from customer in context.Customers
                                where customer.SalesOfficeID == user.SalesOfficeID &&
                                      customer.IsCentral == true
                                select customer.SapCode).FirstOrDefault();

                var client = new ServiceAccount.WebServiceCariSoapClient();
                var hd = new ServiceAccount.AuthHeader()
                {
                    Username = "AlfemoUB2B_ServiceUser",
                    Password = "Alfemo!2024_!"
                };
                var sonuc = client.AccountStatement(hd, iv_kunnr);
                if (!sonuc.Contains("-111"))
                {
                    accounts = JsonConvert.DeserializeObject<List<ZAL_S_CARI>>(sonuc);
                }
            }

            var jsonResult = Json(new
            {
                data = accounts
            }, JsonRequestBehavior.AllowGet);
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