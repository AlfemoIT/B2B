using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class Tvm5t
    {
        public Tvm5t()
        {
            Materials = new List<Material>();
        }
        public int ID { get; set; }
        public string MVGR5 { get; set; }
        public string BEZEI { get; set; }

        [JsonIgnore]
        public ICollection<Material> Materials { get; set; }
    }
}