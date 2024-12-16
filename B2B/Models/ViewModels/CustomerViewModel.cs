using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models.ViewModels
{
    public class CustomerViewModel
    {
        public string UserName { get; set; }
        public List<CustomerDto> Customers { get; set; }
    }

    public class CustomerDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public string SapCode { get; set; }
        public bool IsCentral { get; set; }
    }
}