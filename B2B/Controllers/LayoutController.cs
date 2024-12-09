using B2B.Dal;
using B2B.Models;
using B2B.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            var englishCulture = new CultureInfo("en");
            var user = GetUser();
            using (var context = new B2bContext())
            {
                if (user.RoleID == 6) //bolge muduru
                {
                    var customers = (from customer in context.Customers.AsEnumerable()
                                     join cgroup in context.CustomerGroups.AsEnumerable() on customer.CustomerGroupID equals cgroup.ID
                                     where customer.SalesOfficeID == user.SalesOfficeID
                                     select new CustomerDto
                                     {
                                         ID = customer.ID,
                                         Name = customer.Name,
                                         SapCode = customer.SapCode,
                                         GroupName = cgroup.Name.ToUpper(englishCulture)
                                     }).ToList();

                    return PartialView(new CustomerViewModel
                    {
                        UserName = user.NameSurname,
                        Customers = customers
                    });
                }
                else
                {
                    var customers = (from customera in context.CustomerAssignments.Where(x => x.UserID == user.ID).AsEnumerable()
                                     join customer in context.Customers.AsEnumerable() on customera.CustomerID equals customer.ID
                                     join cgroup in context.CustomerGroups.AsEnumerable() on customer.CustomerGroupID equals cgroup.ID
                                     select new CustomerDto
                                     {
                                         ID = customer.ID,
                                         Name = customer.Name,
                                         SapCode = customer.SapCode,
                                         GroupName = cgroup.Name.ToUpper(englishCulture)
                                     }).ToList();

                    return PartialView(new CustomerViewModel
                    {
                        UserName = user.NameSurname,
                        Customers = customers
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