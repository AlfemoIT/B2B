using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models.ViewModels
{
    public class MaterialViewModel
    {
        public int ID { get; set; }
        public string MATNR { get; set; }
        public string MAKTX { get; set; }
        public string ZCL_MAKTX { get; set; }

        public string MVGR2 { get; set; }
        public string BEZEI2 { get; set; }

        public string MVGR3 { get; set; }
        public string BEZEI3 { get; set; }

        public string MVGR4 { get; set; }
        public string BEZEI4 { get; set; }

        public string MVGR5 { get; set; }
        public string BEZEI5 { get; set; }

        public string KONDM { get; set; }
        public string VTEXT { get; set; } //materai price grup


        public string BIRINCI_BOLGE { get; set; }
        public string BIRINCI_BOLGE_DEF { get; set; }

        public string IKINCI_BOLGE { get; set; }
        public string IKINCI_BOLGE_DEF { get; set; }

        public string UCUNCU_BOLGE { get; set; }
        public string UCUNCU_BOLGE_DEF { get; set; }

        public string AYAK_RENGI { get; set; }
        public string AYAK_RENGI_DEF { get; set; }

        public string BELKIRLENTI_1_DEF { get; set; }
        public string BELKIRLENTI_2_DEF { get; set; }

        public string KIRLENT45_1_DEF { get; set; }
        public string KIRLENT45_2_DEF { get; set; }
        public string KIRLENT45_3_DEF { get; set; }

        public string KIRLENT50_1_DEF { get; set; }
        public string KIRLENT50_2_DEF { get; set; }
        public string KIRLENT50_3_DEF { get; set; }

        public string KIRLENT52_1_DEF { get; set; }
        public string KIRLENT52_2_DEF { get; set; }
        public string KIRLENT52_3_DEF { get; set; }

        public string ROUNDKIRLENT_1_DEF { get; set; }
        public string ROUNDKIRLENT_2_DEF { get; set; }
    }
}