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
        public JsonResult GetMaterial(int IsLoad, string UseCaseID, string Mvgr2ID, string Mvgr3ID, string Mvgr4ID, string Mvgr5ID)
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
            MATERIAL_GRUB mGroups = new MATERIAL_GRUB()
            {
                tvm2ts = new List<Tvm2t>() { new Tvm2t { ID = 0, MVGR2 = "0", BEZEI = "Seçiniz" } },
                tvm3ts = new List<Tvm3t>() { new Tvm3t { ID = 0, MVGR3 = "0", BEZEI = "Seçiniz" } },
                tvm4ts = new List<Tvm4t>() { new Tvm4t { ID = 0, MVGR4 = "0", BEZEI = "Seçiniz" } },
                tvm5ts = new List<Tvm5t>() { new Tvm5t { ID = 0, MVGR5 = "0", BEZEI = "Seçiniz" } },
                legColors = new List<Cawnt>() { new Cawnt { ID = 0, ATZHL = 0, ATWTB = "Seçiniz" } },
                useCases = new List<Cawnt>() { new Cawnt { ID = 0, ATZHL = 0, ATWTB = "Seçiniz" } },
                stoffCodes = new List<StoffCode> { new StoffCode { ID = 0, KUMAS_KOD = "0", KUMAS_TANIM = "Seçiniz" } }
            };

            using (var context = new B2bContext())
            {
                mGroups.tvm2ts.AddRange(context.Mvgr2s.ToList());
                mGroups.tvm3ts.AddRange(context.Mvgr3s.ToList());
                mGroups.tvm4ts.AddRange(context.Mvgr4s.ToList());
                mGroups.tvm5ts.AddRange(context.Mvgr5s.ToList());
                mGroups.stoffCodes.AddRange(context.StoffCodes.ToList());
                mGroups.legColors.AddRange(context.Cawnts.Where(x => x.ATINN == "AYAKRENGI").ToList());
                mGroups.useCases.AddRange(context.Cawnts.Where(x => x.ATINN == "Z_KULLANIMDURUMU" && (x.ATZHL == 1 || x.ATZHL == 2))
                                                        .ToList());
            }

            var jsonResult = Json(new { mGroups }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}