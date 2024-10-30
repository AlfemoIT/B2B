using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models.ViewModels
{
    public class CustomerViewModel
    {
        public string UserName { get; set; }
        public List<string> Customers { get; set; }
    }
}