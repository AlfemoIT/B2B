using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace B2B.Models
{
    public class Tvm1t
    {
        public Tvm1t()
        {
            Materials = new List<Material>();
        }
        public int ID { get; set; }
        public string MVGR1 { get; set; }
        public string BEZEI { get; set; }

        [JsonIgnore]
        public ICollection<Material> Materials { get; set; }
    }
}