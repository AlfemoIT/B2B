using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class PageCategory
    {
        public PageCategory()
        {
            Pages = new List<Page>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Index { get; set; }

        [JsonIgnore]
        public virtual ICollection<Page> Pages { get; set; }
    }
}