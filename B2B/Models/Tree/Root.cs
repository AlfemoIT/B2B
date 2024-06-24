using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models.Tree
{
    public class Root
    {
        public string text { get; set; }
        public State state { get; set; }
        public List<Child> children { get; set; }
    }
}