using B2B.Dal;
using B2B.Models;
using B2B.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace B2B.Controllers
{
    public class LayoutController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult _SideBar()
        {
            return PartialView(GetUser());
        }
        public PartialViewResult _NavBar()
        {
            var user = GetUser();
            using (var context = new B2bContext())
            {
                if (user.RoleID == 6) //bolge muduru
                {
                    var customers = (from customer in context.Customers
                                     where customer.SalesOfficeID == user.SalesOfficeID
                                     select new
                                     {
                                         customer.Name
                                     }).ToList();

                    return PartialView(new CustomerViewModel
                    {
                        UserName = user.NameSurname,
                        Customers = customers.ConvertAll(x => x.Name)
                    });
                }
                else
                {
                    var customers = (from customera in context.CustomerAssignments.Where(x => x.UserID == user.ID)
                                     join customer in context.Customers on customera.CustomerID equals customer.ID
                                     select new
                                     {
                                         customer.Name
                                     }).ToList();

                    return PartialView(new CustomerViewModel
                    {
                        UserName = user.NameSurname,
                        Customers = customers.ConvertAll(x => x.Name)
                    });
                }
            }
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