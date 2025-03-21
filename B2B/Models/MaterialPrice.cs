using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

namespace B2B.Models
{
    public class MaterialPrice
    {
        public MaterialPrice()
        {
            Materials = new List<Material>();
        }
        public int ID { get; set; }
        public string MATNR { get; set; }
        public string RowType { get; set; }
        public string ListType { get; set; }
        public string Price1 { get; set; }
        public string Price2 { get; set; }
        public string Price3 { get; set; }
        public string Price4 { get; set; }
        public string Price5 { get; set; }
        public string Currency { get; set; }

        [JsonIgnore]
        public ICollection<Material> Materials { get; set; }
    }
}