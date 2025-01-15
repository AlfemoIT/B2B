using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B2B.Areas.Management.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}