using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class Page
    {
        public Page()
        {
            PageAssignments = new List<PageAssignment>();
        }
        public int ID { get; set; }
        public int PageCategoryID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Index { get; set; }
        public bool IsManagement { get; set; }

        [JsonIgnore]
        public virtual PageCategory PageCategory { get; set; }

        [JsonIgnore]
        public ICollection<PageAssignment> PageAssignments { get; set; }
    }
}