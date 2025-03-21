using B2B.Dal;
using B2B.Models;
using B2B.Models.ViewModels;
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
        public JsonResult GetMaterials(int IsLoad, string UseCaseID, string LegColor,
                                      string Mvgr2, string Mvgr3, string Mvgr4, string Mvgr5,
                                      string Region1, string Region2, string Region3)
        {
            List<MaterialViewModel> materials = new List<MaterialViewModel>();
            if (IsLoad == 1)
            {
                using (var context = new B2bContext())
                {
                    materials = (from material in context.Materials.AsEnumerable()

                                 join tvmt2 in context.Mvgr2s.AsEnumerable()
                                 on material.Tvm2tID equals tvmt2.ID

                                 join tvmt3 in context.Mvgr3s.AsEnumerable()
                                 on material.Tvm3tID equals tvmt3.ID into g3
                                 from subTvmt3 in g3.DefaultIfEmpty()

                                 join tvmt4 in context.Mvgr4s.AsEnumerable()
                                 on material.Tvm4tID equals tvmt4.ID into g4
                                 from subTvmt4 in g4.DefaultIfEmpty()

                                 join tvmt5 in context.Mvgr5s.AsEnumerable()
                                 on material.Tvm5tID equals tvmt5.ID into g5
                                 from subTvmt5 in g5.DefaultIfEmpty()

                                 join r1 in context.StoffCodes.AsEnumerable()
                                 on material.BIRINCI_BOLGE equals r1.KUMAS_KOD into gr1
                                 from subR1 in gr1.DefaultIfEmpty()

                                 join r2 in context.StoffCodes.AsEnumerable()
                                 on material.IKINCI_BOLGE equals r2.KUMAS_KOD into gr2
                                 from subR2 in gr2.DefaultIfEmpty()

                                 join r3 in context.StoffCodes.AsEnumerable()
                                 on material.UCUNCU_BOLGE equals r3.KUMAS_KOD into gr3
                                 from subR3 in gr3.DefaultIfEmpty()

                                 join legColor in context.Cawnts.AsEnumerable().Where(x => x.ATINN == "AYAKRENGI")
                                 on material.AYAK_RENGI equals legColor.ATZHL.ToString() into gleg
                                 from subLeg in gleg.DefaultIfEmpty()

                                 where material.VSTAT == UseCaseID && material.VMSTA != "ZZ" && tvmt2.MVGR2 == Mvgr2
                                 select new MaterialViewModel
                                 {
                                     ID = material.ID,
                                     MATNR = material.MATNR,
                                     MAKTX = material.MAKTX,
                                     ZCL_MAKTX = string.IsNullOrEmpty(material.ZCL_MAKTX) ? material.MAKTX : material.ZCL_MAKTX,

                                     MVGR2 = tvmt2.MVGR2,
                                     BEZEI2 = tvmt2.BEZEI,

                                     MVGR3 = subTvmt3 != null ? subTvmt3.MVGR3 : string.Empty,
                                     BEZEI3 = subTvmt3 != null ? subTvmt3.BEZEI : string.Empty,

                                     MVGR4 = subTvmt4 != null ? subTvmt4.MVGR4 : string.Empty,
                                     BEZEI4 = subTvmt4 != null ? subTvmt4.BEZEI : string.Empty,

                                     MVGR5 = subTvmt5 != null ? subTvmt5.MVGR5 : string.Empty,
                                     BEZEI5 = subTvmt5 != null ? subTvmt5.BEZEI : string.Empty,


                                     BIRINCI_BOLGE = subR1 != null ? subR1.KUMAS_KOD : string.Empty,
                                     BIRINCI_BOLGE_DEF = subR1 != null ? subR1.KUMAS_TANIM : string.Empty,

                                     IKINCI_BOLGE = subR2 != null ? subR2.KUMAS_KOD : string.Empty,
                                     IKINCI_BOLGE_DEF = subR2 != null ? subR2.KUMAS_TANIM : string.Empty,

                                     UCUNCU_BOLGE = subR3 != null ? subR3.KUMAS_KOD : string.Empty,
                                     UCUNCU_BOLGE_DEF = subR3 != null ? subR3.KUMAS_TANIM : string.Empty,

                                     AYAK_RENGI = subLeg != null ? subLeg.ATZHL.ToString() : string.Empty,
                                     AYAK_RENGI_DEF = subLeg != null ? subLeg.ATWTB : string.Empty
                                 }).ToList();

                    HttpContext.Cache.Remove("Materials");
                    HttpContext.Cache.Insert("Materials", materials, null,
                        DateTime.Now.AddMinutes(60),
                        System.Web.Caching.Cache.NoSlidingExpiration);
                }
            }

            if (IsLoad == 2)
            {
                var cmaterials = HttpContext.Cache["Materials"] as List<MaterialViewModel>;
                if (cmaterials != null)
                {
                    if (!string.IsNullOrEmpty(Mvgr3) && Mvgr3 != "0")
                    {
                        materials = cmaterials.Where(x => x.MVGR3 == Mvgr3).ToList();
                    }

                    if (!string.IsNullOrEmpty(Mvgr4) && Mvgr4 != "0")
                    {
                        materials = cmaterials.Where(x => x.MVGR4 == Mvgr4).ToList();
                    }

                    if (!string.IsNullOrEmpty(Mvgr5.Trim()))
                    {
                        materials = cmaterials.Where(x => x.MVGR5 == Mvgr5).ToList();
                    }

                    if (!string.IsNullOrEmpty(Region1.Trim()))
                    {
                        materials = cmaterials.Where(x => x.BIRINCI_BOLGE == Region1).ToList();
                    }

                    if (!string.IsNullOrEmpty(Region2.Trim()))
                    {
                        materials = cmaterials.Where(x => x.IKINCI_BOLGE == Region2).ToList();
                    }

                    if (!string.IsNullOrEmpty(Region3.Trim()))
                    {
                        materials = cmaterials.Where(x => x.UCUNCU_BOLGE == Region3).ToList();
                    }

                    if (!string.IsNullOrEmpty(LegColor.Trim()))
                    {
                        materials = cmaterials.Where(x => x.AYAK_RENGI == LegColor).ToList();
                    }
                }
            }

            var jsonResult = Json(new { data = materials }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetCollection(string UseCaseID)
        {
            MATERIAL_GRUB mGroups = new MATERIAL_GRUB();
            using (var context = new B2bContext())
            {
                var materials = context.Materials.Where(x => x.VSTAT == UseCaseID)
                                                 .ToList();

                mGroups.tvm2ts = (from material in materials
                                  join collection in context.Mvgr2s.AsEnumerable()
                                  on material.Tvm2tID equals collection.ID
                                  where material.VMSTA != "ZZ"
                                  group material by material.Tvm2tID into g
                                  select new Tvm2t
                                  {
                                      ID = int.Parse(g.Key.ToString()),
                                      MVGR2 = g.FirstOrDefault().Tvm2t.MVGR2,
                                      BEZEI = g.FirstOrDefault().Tvm2t.BEZEI
                                  }).ToList();
            }

            var jsonResult = Json(new { mGroups }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetFilterData()
        {
            MATERIAL_GRUB mGroups = new MATERIAL_GRUB();
            var cmaterials = HttpContext.Cache["Materials"] as List<MaterialViewModel>;
            if (cmaterials != null)
            {
                mGroups.tvm3ts = (from material in cmaterials
                                  group material by new { material.MVGR3, material.BEZEI3 } into g
                                  select new Tvm3t
                                  {
                                      MVGR3 = g.Key.MVGR3,
                                      BEZEI = g.Key.BEZEI3
                                  }).ToList();

                mGroups.tvm4ts = (from material in cmaterials
                                  group material by new { material.MVGR4, material.BEZEI4 } into g
                                  select new Tvm4t
                                  {
                                      MVGR4 = g.Key.MVGR4,
                                      BEZEI = g.Key.BEZEI4
                                  }).ToList();

                mGroups.tvm5ts = (from material in cmaterials
                                  group material by new { material.MVGR5, material.BEZEI5 } into g
                                  select new Tvm5t
                                  {
                                      MVGR5 = g.Key.MVGR5,
                                      BEZEI = g.Key.BEZEI5
                                  }).ToList();

                mGroups.region1s = (from material in cmaterials
                                    group material by new { material.BIRINCI_BOLGE, material.BIRINCI_BOLGE_DEF } into g
                                    select new StoffCode
                                    {
                                        KUMAS_KOD = g.Key.BIRINCI_BOLGE,
                                        KUMAS_TANIM = g.Key.BIRINCI_BOLGE_DEF
                                    }).ToList();

                mGroups.region2s = (from material in cmaterials
                                    group material by new { material.IKINCI_BOLGE, material.IKINCI_BOLGE_DEF } into g
                                    select new StoffCode
                                    {
                                        KUMAS_KOD = g.Key.IKINCI_BOLGE,
                                        KUMAS_TANIM = g.Key.IKINCI_BOLGE_DEF
                                    }).ToList();

                mGroups.region3s = (from material in cmaterials
                                    group material by new { material.UCUNCU_BOLGE, material.UCUNCU_BOLGE_DEF } into g
                                    select new StoffCode
                                    {
                                        KUMAS_KOD = g.Key.UCUNCU_BOLGE,
                                        KUMAS_TANIM = g.Key.UCUNCU_BOLGE_DEF
                                    }).ToList();
            }

            var jsonResult = Json(new { mGroups }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}