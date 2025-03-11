using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace B2B.Models
{
    public class PageAssignment
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int PageID { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual Page Page { get; set; }
    }
}