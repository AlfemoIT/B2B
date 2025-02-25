using B2B.Authorize;
using B2B.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B2B.Areas.Management.Controllers
{
    public class DashboardController : Controller
    {
        [CustomAuthorize((int)EnumHelper.UserGroup.Admin, (int)EnumHelper.UserGroup.PowerUser)]
        public ActionResult Index()
        {
            return View();
        }
    }
}