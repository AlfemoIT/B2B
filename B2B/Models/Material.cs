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
        public string Matnr { get; set; }
        public string Matkl { get; set; }
        public string Maktx { get; set; }
        public string ZclMaktx { get; set; }

        public string Brgew { get; set; }   //brüt agirlik
        public string Netgw { get; set; }   //net agirlik
        public string Gewei { get; set; }   //birim

        public string Volum { get; set; }
        public string Voleh { get; set; }   //hacim birimi

        public string Laeng { get; set; }   //uzunluk
        public string Breit { get; set; }   //genişlik
        public string Hoehe { get; set; }   //yükseklik
        public string Meabm { get; set; }   //Uzunluk/genişlik/yükseklik birimi

        public int? Tvm1tID { get; set; }
        public int? Tvm2tID { get; set; }
        public int? Tvm3tID { get; set; }
        public int? Tvm4tID { get; set; }
        public int? Tvm5tID { get; set; }
        public int? MaterialPriceGroupID { get; set; }
        public int? MaterialPriceID { get; set; }

        public string Lvorm { get; set; }    //silme isareti
        public string Vmsta { get; set; }    //Dağıtım zincirine özgü malzeme durumu

        public string Vstat { get; set; }    //Z_KULLANIMDURUM
        public string BirinciBolge { get; set; }
        public string İkinciBolge { get; set; }
        public string UcuncuBolge { get; set; }

        public string AyakRengi { get; set; }

        public string Belkirlenti_1 { get; set; }
        public string Belkirlenti_2 { get; set; }

        public string Kirlent45_1 { get; set; }
        public string Kirlent45_2 { get; set; }
        public string Kirlent45_3 { get; set; }

        public string Kirlent50_1 { get; set; }
        public string Kirlent50_2 { get; set; }
        public string Kirlent50_3 { get; set; }

        public string Kirlent52_1 { get; set; }
        public string Kirlent52_2 { get; set; }
        public string Kirlent52_3 { get; set; }

        public string RoundKirlent_1 { get; set; }
        public string RoundKirlent_2 { get; set; }

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

        [JsonIgnore]
        public virtual MaterialPrice MaterialPrice { get; set; }
    }
}