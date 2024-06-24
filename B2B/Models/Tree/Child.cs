using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models.Tree
{
    public class Child
    {
        public string text { get; set; }
        public State state { get; set; }
        public string icon { get; set; }
        public List<Child> children { get; set; }
    }
}