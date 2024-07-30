﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class Customer
    {
        public int ID { get; set; }

        public int SalesOfficeID { get; set; }
        public int CustomerGroupID { get; set; }

        public string SapCode { get; set; }
        public string Name { get; set; }
        public string TaxNo { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }

        public virtual SalesOffice SalesOffice { get; set; }
        public virtual CustomerGroup CustomerGroup { get; set; }
        public ICollection<CustomerAssignment> CustomerAssignments { get; set; }
    }
}