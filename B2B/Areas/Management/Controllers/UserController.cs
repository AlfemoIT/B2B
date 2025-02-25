using B2B.Authorize;
using B2B.Dal;
using B2B.Helper;
using B2B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B2B.Areas.Management.Controllers
{
    public class UserController : Controller
    {
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

        public ActionResult EditUser()
        {
            return View();
        }
    }
}