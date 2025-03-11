using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using B2B.Authorize;
using B2B.Dal;
using B2B.Helper;
using B2B.Models;
using B2B.Models.ViewModels;
using Newtonsoft.Json;
using System.Web.Security;

namespace B2B.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [CustomAuthorize((int)EnumHelper.UserGroup.Admin)]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetData(string iv_cID, string iv_user_state)
        {
            List<Z_USER> users = new List<Z_USER>();
            using (var context = new B2bContext())
            {
                users = (from customera in context.CustomerAssignments.AsEnumerable()
                         join user in context.Users.AsEnumerable()
                         on customera.UserID equals user.ID
                         join role in context.Roles.AsEnumerable()
                         on user.RoleID equals role.ID
                         where customera.CustomerID == int.Parse(iv_cID) && user.IsDeleted == false
                         select new Z_USER
                         {
                             ID = user.ID,
                             RoleID = user.RoleID,
                             Role = role.Name,
                             NameSurname = user.NameSurname,
                             RegistrationNo = user.RegistrationNo,
                             Password = user.Password,
                             Phone1 = user.Phone1,
                             IsActive = user.IsActive,
                             IsDeleted = user.IsDeleted
                         }).ToList();

                if (iv_user_state == "0")
                {
                    users = users.Where(x => x.IsActive == false)
                                 .ToList();
                }

                if (iv_user_state == "1")
                {
                    users = users.Where(x => x.IsActive == true)
                                 .ToList();
                }
            }
            return Json(new { data = users }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ChangeUserState(string userID, bool state)
        {
            int userIdValue = int.Parse(userID);
            using (var context = new B2bContext())
            {
                var user = context.Users.FirstOrDefault(x => x.ID == userIdValue);
                if (user != null)
                {
                    user.IsActive = state;
                    context.SaveChanges();
                }
            }
            return Json(new { data = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditUser(string userID)
        {
            var userModel = new UserViewModel();
            using (var context = new B2bContext())
            {
                var userGroups = context.UserGroups
                    .Select(c => new SelectListItem
                    {
                        Value = c.ID.ToString(),
                        Text = c.Name
                    }).ToList();

                int _userID = GetUser().ID;
                int userRoleIndex = (from user in context.Users
                                     join role in context.Roles
                                     on user.RoleID equals role.ID
                                     where user.ID == _userID
                                     select role.Index).FirstOrDefault();

                var roles = context.Roles
                    .Where(c => c.Index >= userRoleIndex)
                    .Select(c => new SelectListItem
                    {
                        Value = c.ID.ToString(),
                        Text = c.Name
                    }).ToList();

                var customers = context.Customers
                    .Select(c => new SelectListItem
                    {
                        Value = c.ID.ToString(),
                        Text = c.Name
                    }).ToList();

                var pages = context.Pages
                    .Select(c => new SelectListItem
                    {
                        Value = c.ID.ToString(),
                        Text = c.Name
                    }).ToList();

                userModel = (from _user in context.Users.AsEnumerable()
                             join _customera in context.CustomerAssignments.AsEnumerable()
                             on _user.ID equals _customera.UserID
                             join userGrp in context.UserGroups.AsEnumerable()
                             on _user.UserGroupID equals userGrp.ID
                             join page in context.PageAssignments.AsEnumerable()
                             on _user.ID equals page.UserID
                             where _user.ID == int.Parse(userID)
                             group _user by new { _user.ID, } into g
                             select new UserViewModel
                             {
                                 RegistrationNo = g.FirstOrDefault().RegistrationNo,
                                 NameSurname = g.FirstOrDefault().NameSurname,
                                 Eposta = g.FirstOrDefault().Email,
                                 Phone = g.FirstOrDefault().Phone1,

                                 SelectedUserGroup = g.FirstOrDefault().UserGroupID.ToString(),
                                 UserGroups = userGroups,

                                 SelectedRole = g.FirstOrDefault().RoleID.ToString(),
                                 Roles = roles,

                                 SelectedCustomer = g.FirstOrDefault().CustomerAssignment.FirstOrDefault().CustomerID.ToString(),
                                 Customers = customers,

                                 SelectedPages = g.FirstOrDefault().PageAssignment.Select(x => x.PageID).ToList(),
                                 Pages = pages
                             }).FirstOrDefault();
            };
            return View(userModel);
        }

        [HttpPost]
        public JsonResult DeleteUser(string userID)
        {
            var jsonResult = Json(new { result = true }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            int _userID = int.Parse(userID);

            using (var context = new B2bContext())
            {
                var user = context.Users.FirstOrDefault(p => p.ID == _userID);
                if (user != null)
                {
                    user.IsDeleted = true;
                    context.SaveChanges();
                }
                else
                {
                    jsonResult = Json(new { result = false }, JsonRequestBehavior.AllowGet);
                }
            }

            return jsonResult;
        }

        public ActionResult AddUser()
        {
            var userModel = new UserViewModel();

            using (var context = new B2bContext())
            {
                var userGroups = context.UserGroups
                    .Select(c => new SelectListItem
                    {
                        Value = c.ID.ToString(),
                        Text = c.Name
                    }).ToList();

                userGroups.Add(new SelectListItem { Text = "Seçiniz", Value = "", Selected = true });

                int userID = GetUser().ID;     
                
                int userRoleIndex = (from user in context.Users
                                    join role in context.Roles
                                    on user.RoleID equals role.ID
                                    where user.ID == userID
                                    select role.Index).FirstOrDefault();

                var roles = context.Roles
                    .Where(c => c.Index >= userRoleIndex)
                    .Select(c => new SelectListItem
                    {
                        Value = c.ID.ToString(),
                        Text = c.Name
                    }).ToList();

                roles.Add(new SelectListItem { Text = "Seçiniz", Value = "", Selected = true });

                var customers = context.Customers
                    .Select(c => new SelectListItem
                    {
                        Value = c.ID.ToString(),
                        Text = c.Name
                    }).ToList();

                customers.Add(new SelectListItem { Text = "Seçiniz", Value = "", Selected = true });

                var pages = context.Pages
                    .Select(c => new SelectListItem
                    {
                        Value = c.ID.ToString(),
                        Text = c.Name
                    }).ToList();

                userModel.Roles = roles;
                userModel.Customers = customers;
                userModel.UserGroups = userGroups;
                userModel.Pages = pages;
            }

            return View(userModel);
        }

        [HttpPost]
        public JsonResult Save(UserViewModel user)
        {
            using (var context = new B2bContext())
            {
                var jsonResult = Json(new { result = true, message = "Kayıt İşlemi Başarılı" }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                // User 
                var userData = context.Users
                                        .Where(x => x.RegistrationNo == user.RegistrationNo && x.Password == user.Password)
                                        .FirstOrDefault();
                if (userData != null)
                {
                    jsonResult = Json(new { result = false, message = "Bu kullanıcı zaten bulunmaktadır" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var newUser = new User
                    {
                        RegistrationNo = user.RegistrationNo,
                        NameSurname = user.NameSurname,
                        Password = user.Password,
                        Email = user.Eposta,
                        Phone1 = user.Phone,
                        RoleID = int.Parse(user.SelectedRole),
                        UserGroupID = int.Parse(user.SelectedUserGroup),
                        IsActive = true
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();

                    // Page Assignment
                    string[] selectedPages = user.SelectedPage.Split(',');

                    foreach (string page in selectedPages)
                    {
                        int selectedPageID = int.Parse(page);
                        var newPage = new PageAssignment()
                        {
                            UserID = newUser.ID,
                            PageID = selectedPageID
                        };

                        context.PageAssignments.Add(newPage);
                        context.SaveChanges();
                    }

                    // Customer Assignment
                    int selectedCustomerID = int.Parse(user.SelectedCustomer);
                    var newUserGroup = new CustomerAssignment()
                    {
                        UserID = newUser.ID,
                        CustomerID = selectedCustomerID
                    };

                    context.CustomerAssignments.Add(newUserGroup);
                    context.SaveChanges();
                }
                return jsonResult;
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

        public class Roles
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Customers
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class UserGroups
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Pages
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}