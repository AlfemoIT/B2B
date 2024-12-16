using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class CategoryWithPagesDTO
    {
        public string CategoryName { get; set; }
        public string Icon { get; set; }
        public int Index { get; set; }
        public List<PageDTO> Pages { get; set; }
    }
    public class PageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}