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
        [CustomAuthorize((int)EnumHelper.UserGroup.Admin, (int)EnumHelper.UserGroup.PowerUser)]
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
                         where customera.CustomerID == int.Parse(iv_cID)
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
            List<Roles> SQLRoleList = new List<Roles>();
            List<Customers> SQLCustomerList = new List<Customers>();
            List<UserGroups> SQLUserGroupList = new List<UserGroups>();
            List<Pages> SQLPageList = new List<Pages>();

            var userModel = new UserViewModel();
            using (var context = new B2bContext())
            {
                SQLRoleList = context.Roles.Select(p => new Roles { Id = p.ID, Name = p.Name }).ToList();
                SQLCustomerList = context.Customers.Select(p => new Customers { Id = p.ID, Name = p.Name }).ToList();
                SQLUserGroupList = context.UserGroups.Select(c => new UserGroups { Id = c.ID, Name = c.Name }).ToList();
                SQLPageList = context.Pages.Select(c => new Pages { Id = c.ID, Name = c.Name }).ToList();

                userModel = (from _user in context.Users.AsEnumerable()
                             join role in context.Roles.AsEnumerable()
                             on _user.RoleID equals role.ID
                             join _customera in context.CustomerAssignments.AsEnumerable()
                             on _user.ID equals _customera.UserID
                             where _user.ID == int.Parse(userID)
                             select new UserViewModel
                             {
                                 RegistrationNo = _user.RegistrationNo,
                                 NameSurname = _user.NameSurname,
                                 Eposta = _user.Email,
                                 Phone = _user.Phone1,
                                 Role = role.Name,

                                 // Roles
                                 SelectedRole = SQLRoleList.Find(p => p.Id == _user.RoleID).Id.ToString(),

                                 Roles = SQLRoleList.Select(c => new SelectListItem
                                 {
                                     Value = c.Id.ToString(),
                                     Text = c.Name
                                 }).ToList(),

                                 // Customers
                                 SelectedCustomer = SQLCustomerList.Find(p => p.Id == _customera.CustomerID).Id.ToString(),

                                 Customers = SQLCustomerList.Select(c => new SelectListItem
                                 {
                                     Value = c.Id.ToString(),
                                     Text = c.Name
                                 }).ToList(),

                                 // User Groups
                                 SelectedUserGroup = SQLUserGroupList.Find(p => p.Id == _user.UserGroupID).Id.ToString(),

                                 UserGroups = SQLUserGroupList.Select(c => new SelectListItem
                                 {
                                     Value = c.Id.ToString(),
                                     Text = c.Name
                                 }).ToList(),

                                 // Pages
                                 SelectedPages = SQLPageList.Select(p => p.Id).ToList(),

                                 Pages = SQLPageList.Select(c => new SelectListItem
                                 {
                                     Value = c.Id.ToString(),
                                     Text = c.Name
                                 }).ToList()

                             }).FirstOrDefault();
            };

            //List<int> listDeneme = SQLPageList.Where(p => p.).ToList();

            return View(userModel);
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

        public ActionResult AddUser()
        {
            var userModel = new UserViewModel();

            List<Roles> SQLRoleList = new List<Roles>();
            List<Customers> SQLCustomerList = new List<Customers>();
            List<UserGroups> SQLUserGroupList = new List<UserGroups>();
            List<Pages> SQLPageList = new List<Pages>();

            using (var context = new B2bContext())
            {
                SQLRoleList = context.Roles.Select(p => new Roles { Id = p.ID, Name = p.Name }).ToList();
                SQLCustomerList = context.Customers.Select(p => new Customers { Id = p.ID, Name = p.Name }).ToList();
                SQLUserGroupList = context.UserGroups.Select(p => new UserGroups { Id = p.ID, Name = p.Name }).ToList();
                SQLPageList = context.Pages.Select(p => new Pages { Id = p.ID, Name = p.Name }).ToList();

                // Roles
                userModel.Roles = SQLRoleList.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

                userModel.Roles.Add(new SelectListItem { Text = "Seçiniz", Value = "", Selected = true });

                // Customers
                userModel.Customers = SQLCustomerList.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

                userModel.Customers.Add(new SelectListItem { Text = "Seçiniz", Value = "", Selected = true });

                // User Groups
                userModel.UserGroups = SQLUserGroupList.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

                userModel.UserGroups.Add(new SelectListItem { Text = "Seçiniz", Value = "", Selected = true });

                // Pages
                userModel.Pages = SQLPageList.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

                //userModel.Pages.Add(new SelectListItem { Text = "Seçiniz", Value = "", Selected = true });
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