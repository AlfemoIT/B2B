using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class Tvm2t
    {
        public Tvm2t()
        {
            Materials = new List<Material>();
        }
        public int ID { get; set; }
        public string MVGR2 { get; set; }
        public string BEZEI { get; set; }

        [JsonIgnore]
        public ICollection<Material> Materials { get; set; }
    }
}