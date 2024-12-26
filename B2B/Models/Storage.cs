using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

namespace B2B.Models
{
    public class Storage
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsCentral { get; set; }

        [JsonIgnore]
        public ICollection<StorageAssignment> StorageAssignments { get; set; }
    }
}