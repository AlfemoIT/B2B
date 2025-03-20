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
        public string KONDM { get; set; }
        public string VTEXT { get; set; }

        [JsonIgnore]
        public ICollection<Material> Materials { get; set; }
    }
}