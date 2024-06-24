using B2B.Models.Tree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B2B.Controllers
{
    public class HelpController : Controller
    {
        const string rootPath = @"D:\B2B\Yardım";

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetFileNames()
        {
            List<Child> childs = new List<Child>();

            Child root = new Child()
            {
                text = "Yardım",
                state = new State { opened = true },
                children = new List<Child>()
            };

            string[] files = new DirectoryInfo(rootPath).GetFiles()
                                                        .Select(o => o.Name)
                                                        .ToArray();
            foreach (var file in files)
            {
                root.children.Add(new Child
                {
                    text = file,
                    state = new State { selected = false },
                    icon = "pdf-icon"
                });
            }

            childs.Add(root);

            var jsonResult = Json(new { data = childs }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}