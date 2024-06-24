using B2B.Models.Tree;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace B2B.Controllers
{
    public class PictureController : Controller
    {
        const string rootPath = @"D:\Pazarlama\Gorseller";

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetFileNames()
        {
            List<Child> roots = GetAllDirectories(rootPath);

            var jsonResult = Json(new { data = roots }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        List<Child> GetAllDirectories(string rootPath)
        {
            List<Child> childs = new List<Child>();
            try
            {
                string[] subdirectories = Directory.GetDirectories(rootPath);
                foreach (string subdirectory in subdirectories)
                {
                    var dirName = new DirectoryInfo(subdirectory).Name;
                    Child root = new Child()
                    {
                        text = dirName,
                        state = new State { opened = false },
                        children = new List<Child>()
                    };

                    childs.Add(root);

                    string[] files = new DirectoryInfo(subdirectory).GetFiles()
                                                      .Select(o => o.Name)
                                                      .ToArray();
                    foreach (var file in files)
                    {
                        root.children.Add(new Child
                        {
                            text = file,
                            state = new State { selected = false },
                            icon = "jstree-file"
                        });
                    }

                    root.children.AddRange(GetAllDirectories(subdirectory));
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Access denied to folder: {rootPath}. {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }

            return childs;
        }

        [HttpGet]
        public ActionResult DownloadFile(string folderNames, string fileName)
        {
            folderNames = RemoveLastCharacter(folderNames);

            string filePath = string.Format(rootPath + "\\{0}\\{1}", folderNames, fileName);

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes,
                  System.Net.Mime.MediaTypeNames.Image.Jpeg,
                  fileName);
        }

        string RemoveLastCharacter(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length == 1)
            {
                return string.Empty; // Return empty if input is null, empty, or only one character long
            }

            return input.Substring(0, input.Length - 1);
        }
    }
}