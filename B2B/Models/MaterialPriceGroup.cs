using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class MaterialPriceGroup
    {
        public MaterialPriceGroup()
        {
            Materials = new List<Material>();
        }

        public int ID { get; set; }
        public string MANDT { get; set; }
        public string SPRAS { get; set; }
        public string KONDM { get; set; }
        public string BEZEI20 { get; set; }

        [JsonIgnore]
        public virtual ICollection<Material> Materials { get; set; }
    }
}