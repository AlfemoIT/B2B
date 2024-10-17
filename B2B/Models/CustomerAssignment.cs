using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class CustomerAssignment
    {
        public int ID { get; set; }

        public int UserID { get; set; }
        public int CustomerID { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual Customer Customer { get; set; }
    }
}