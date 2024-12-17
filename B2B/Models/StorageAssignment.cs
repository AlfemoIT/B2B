using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

namespace B2B.Models
{
    public class StorageAssignment
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int StorageID { get; set; }

        [JsonIgnore]
        public virtual Customer Customer { get; set; }

        [JsonIgnore]
        public virtual Storage Storage { get; set; }
    }
}