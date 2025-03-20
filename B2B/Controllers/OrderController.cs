using B2B.Dal;
using B2B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B2B.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetMaterials(int IsLoad, string UseCaseID,
                                      string Mvgr2ID, string Mvgr3ID, string Mvgr4ID, string Mvgr5ID,
                                      string Region1, string Region2, string Region3, string LegColor)
        {
            List<Material> materials = new List<Material>();
            if (IsLoad == 1)
            {
                using (var context = new B2bContext())
                {
                    materials = context.Materials.Where(x => x.VSTAT == UseCaseID).ToList();
                }
            }

            var jsonResult = Json(new { data = materials }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetData()
        {
            MATERIAL_GRUB mGroups = new MATERIAL_GRUB();
            using (var context = new B2bContext())
            {
                mGroups.tvm2ts = context.Mvgr2s.ToList();
            }

            var jsonResult = Json(new { mGroups }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}