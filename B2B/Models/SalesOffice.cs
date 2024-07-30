﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class SalesOffice
    {
        public SalesOffice() //bolgeler
        {
            Customers = new List<Customer>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}