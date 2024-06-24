using B2B.Models.Tree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace B2B.Controllers
{
    public class ProductCardController : Controller
    {
        const string rootPath = @"D:\Pazarlama\TanitimKarti";
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetFileNames()
        {
            List<Root> roots = new List<Root>();

            string[] dirs = Directory.GetDirectories(rootPath, "*", SearchOption.TopDirectoryOnly);
            foreach (var dir in dirs)
            {
                var dirName = new DirectoryInfo(dir).Name;
                Root root = new Root()
                {
                    text = dirName,
                    state = new State { opened = false }
                };
                root.children = new List<Child>();

                string[] subdirs = Directory.GetDirectories(dir, "*", SearchOption.TopDirectoryOnly);
                foreach (var subdir in subdirs)
                {
                    var subdirName = new DirectoryInfo(subdir).Name;
                    Child childRoot = new Child()
                    {
                        text = subdirName,
                        state = new State { opened = false },
                        children = new List<Child>()
                    };

                    string[] files = new DirectoryInfo(subdir).GetFiles()
                                                           .Select(o => o.Name)
                                                           .ToArray();
                    foreach (var file in files)
                    {
                        childRoot.children.Add(new Child
                        {
                            text = file,
                            state = new State { selected = false },
                            icon = "jstree-file"
                        });
                    }
                    root.children.Add(childRoot);
                }
                roots.Add(root);
            }

            var jsonResult = Json(new { data = roots }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}