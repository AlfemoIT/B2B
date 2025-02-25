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
    public class AccountController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var user = GetUser();
            var userModel = new UserViewModel();
            using (var context = new B2bContext())
            {
                userModel = (from _user in context.Users.AsEnumerable()
                             join role in context.Roles.AsEnumerable()
                             on _user.RoleID equals role.ID
                             where _user.ID == user.ID
                             select new UserViewModel
                             {
                                 RegistrationNo = _user.RegistrationNo,
                                 NameSurname = _user.NameSurname,
                                 Eposta = _user.Email,
                                 Phone = _user.Phone1,
                                 Role = role.Name
                             }).FirstOrDefault();
            };
            return View(userModel);
        }

        [HttpPost]
        public JsonResult Save(UserViewModel user)
        {
            using (var context = new B2bContext())
            {
                var cuser = GetUser();
                var dbuser = context.Users.FirstOrDefault(x => x.ID == cuser.ID);
                if (dbuser != null)
                {
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        dbuser.Password = user.Password.TrimStart().TrimEnd();
                    }

                    if (!string.IsNullOrEmpty(user.Eposta))
                    {
                        dbuser.Email = user.Eposta;
                    }

                    if (!string.IsNullOrEmpty(user.Phone))
                    {
                        dbuser.Phone1 = user.Phone;
                    }
                    context.SaveChanges();
                }
                var jsonResult = Json(new { data = "success" }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
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
    }
}