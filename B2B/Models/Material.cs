using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace B2B.Models
{
    public class Material
    {
        public int ID { get; set; }
        public string MATNR { get; set; }
        public string MATKL { get; set; }
        public string MAKTX { get; set; }
        public string ZCL_MAKTX { get; set; }

        public string BRGEW { get; set; }   //brüt agirlik
        public string NETGW { get; set; }   //net agirlik
        public string GEWEI { get; set; }   //birim

        public string VOLUM { get; set; }
        public string VOLEH { get; set; }   //hacim birimi

        public string LAENG { get; set; }   //uzunluk
        public string BREIT { get; set; }   //genişlik
        public string HOEHE { get; set; }   //yükseklik
        public string MEABM { get; set; }   //Uzunluk/genişlik/yükseklik birimi

        public int Tvm1tID { get; set; }
        public int Tvm2tID { get; set; }
        public int Tvm3tID { get; set; }
        public int Tvm4tID { get; set; }
        public int Tvm5tID { get; set; }
        public int MaterialPriceGroupID { get; set; }

        public string LVORM { get; set; }    //silme isareti
        public string VMSTA { get; set; }    //Dağıtım zincirine özgü malzeme durumu

        public string VSTAT { get; set; }    //Z_KULLANIMDURUM
        public string BIRINCI_BOLGE { get; set; }
        public string IKINCI_BOLGE { get; set; }
        public string UCUNCU_BOLGE { get; set; }

        public string AYAK_RENGI { get; set; }

        public string BELKIRLENTI_1 { get; set; }
        public string BELKIRLENTI_2 { get; set; }

        public string KIRLENT45_1 { get; set; }
        public string KIRLENT45_2 { get; set; }
        public string KIRLENT45_3 { get; set; }

        public string KIRLENT50_1 { get; set; }
        public string KIRLENT50_2 { get; set; }
        public string KIRLENT50_3 { get; set; }

        public string KIRLENT52_1 { get; set; }
        public string KIRLENT52_2 { get; set; }
        public string KIRLENT52_3 { get; set; }

        public string ROUNDKIRLENT_1 { get; set; }
        public string ROUNDKIRLENT_2 { get; set; }


        [JsonIgnore]
        public virtual Tvm1t Tvm1t { get; set; }

        [JsonIgnore]
        public virtual Tvm2t Tvm2t { get; set; }

        [JsonIgnore]
        public virtual Tvm3t Tvm3t { get; set; }

        [JsonIgnore]
        public virtual Tvm4t Tvm4t { get; set; }

        [JsonIgnore]
        public virtual Tvm5t Tvm5t { get; set; }

        [JsonIgnore]
        public virtual MaterialPriceGroup MaterialPriceGroup { get; set; }
    }
}