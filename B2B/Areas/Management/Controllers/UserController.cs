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

        [HttpGet]
        public JsonResult GetData(string cID)
        {
            List<Z_USER> users = new List<Z_USER>();
            using (var context = new B2bContext())
            {
                users = (from customera in context.CustomerAssignments.AsEnumerable()
                         join user in context.Users.AsEnumerable()
                         on customera.UserID equals user.ID
                         join role in context.Roles.AsEnumerable()
                         on user.RoleID equals role.ID
                         where customera.CustomerID == int.Parse(cID)
                         select new Z_USER
                         {
                             ID = user.ID,
                             RoleID = user.RoleID,
                             Role = role.Name,
                             NameSurname = user.NameSurname,
                             RegistrationNo = user.RegistrationNo,
                             Password = user.Password,
                             Phone1 = user.Phone1
                         }).ToList();
            }
            return Json(new { data = users }, JsonRequestBehavior.AllowGet);
        }
    }
}