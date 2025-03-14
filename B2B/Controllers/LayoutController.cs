﻿using B2B.Dal;
using B2B.Helper;
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
            TempData["Area"] = "ALFEMO";
            return View();
        }
        public PartialViewResult _SideBar()
        {
            var user = GetUser();
            using (var context = new B2bContext())
            {
                var categoriesWithPages = (from pa in context.PageAssignments.AsEnumerable().Where(pa => pa.UserID == user.ID)
                                           join p in context.Pages.AsEnumerable()
                                           on pa.Page.ID equals p.ID
                                           join c in context.PageCategories on p.PageCategoryID equals c.ID
                                           group p by new { c.Name, c.Icon, c.Index } into g
                                           select new CategoryWithPagesDTO
                                           {
                                               CategoryName = g.Key.Name,
                                               Icon = g.Key.Icon,
                                               Index = g.Key.Index,
                                               Pages = g.Select(p => new PageDTO
                                               {
                                                   Id = p.ID,
                                                   Name = p.Name,
                                                   Url = p.Url,
                                                   Index = p.Index
                                               }).OrderBy(x => x.Index).ToList()
                                           }).OrderBy(x => x.Index)
                                             .ToList();
                return PartialView(categoriesWithPages);
            }
        }
        public PartialViewResult _NavBar()
        {
            var englishCulture = new CultureInfo("en");
            var user = GetUser();
            using (var context = new B2bContext())
            {
                if (user.UserGroupID == (int)EnumHelper.UserGroup.Admin ||
                    user.UserGroupID == (int)EnumHelper.UserGroup.PowerUser)
                {
                    var customers = (from customer in context.Customers.AsEnumerable()
                                     join cgroup in context.CustomerGroups.AsEnumerable()
                                     on customer.CustomerGroupID equals cgroup.ID
                                     select new CustomerDto
                                     {
                                         ID = customer.ID,
                                         Name = customer.Name,
                                         IsCentral = customer.IsCentral,
                                         SapCode = customer.SapCode,
                                         GroupName = cgroup.Name.ToUpper(englishCulture),
                                         RoleID = user.RoleID
                                     }).ToList();

                    return PartialView(new CustomerViewModel
                    {
                        AreaTitle = "ALFEMO",
                        UserName = user.NameSurname,
                        RoleID = user.RoleID,
                        Customers = customers,
                        UserSubMenus = new List<UserSubMenu>() {
                           new UserSubMenu{ Name = "Hesabım" , Url="/account"}
                        }
                    });
                }
                else if (user.RoleID == (int)EnumHelper.Role.BolgeMuduru)
                {
                    List<int> regionIDs = new List<int>();
                    if (user.SalesOfficeID == (int)EnumHelper.SalesOffice.Marmara)
                    {
                        regionIDs.Add((int)EnumHelper.SalesOffice.IstAvrupa);
                        regionIDs.Add((int)EnumHelper.SalesOffice.IstAnadolu);
                    }
                    else
                    {
                        regionIDs.Add((int)user.SalesOfficeID);
                    }

                    var customers = (from customer in context.Customers.AsEnumerable()
                                     join cgroup in context.CustomerGroups.AsEnumerable()
                                     on customer.CustomerGroupID equals cgroup.ID
                                     where regionIDs.Contains(customer.SalesOfficeID)
                                     select new CustomerDto
                                     {
                                         ID = customer.ID,
                                         Name = customer.Name,
                                         IsCentral = customer.IsCentral,
                                         SapCode = customer.SapCode,
                                         GroupName = cgroup.Name.ToUpper(englishCulture),
                                         RoleID = user.RoleID
                                     }).ToList();

                    return PartialView(new CustomerViewModel
                    {
                        AreaTitle = "ALFEMO",
                        UserName = user.NameSurname,
                        RoleID = user.RoleID,
                        Customers = customers,
                        UserSubMenus = new List<UserSubMenu>() {
                           new UserSubMenu{ Name = "Hesabım" , Url="/account"}
                        }
                    });
                }
                else
                {
                    var customers = (from customera in context.CustomerAssignments.Where(x => x.UserID == user.ID).AsEnumerable()
                                     join customer in context.Customers.AsEnumerable()
                                     on customera.CustomerID equals customer.ID
                                     join cgroup in context.CustomerGroups.AsEnumerable()
                                     on customer.CustomerGroupID equals cgroup.ID
                                     select new CustomerDto
                                     {
                                         ID = customer.ID,
                                         Name = customer.Name,
                                         IsCentral = customer.IsCentral,
                                         SapCode = customer.SapCode,
                                         GroupName = cgroup.Name.ToUpper(englishCulture),
                                         RoleID = user.RoleID
                                     }).ToList();

                    return PartialView(new CustomerViewModel
                    {
                        AreaTitle = "ALFEMO",
                        UserName = user.NameSurname,
                        RoleID = user.RoleID,
                        Customers = customers,
                        UserSubMenus = new List<UserSubMenu>() {
                           new UserSubMenu{ Name = "Hesabım" , Url="/account"}
                        }
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