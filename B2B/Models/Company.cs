using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class Company
    {
        public int ID { get; set; }
        public int SalesOfficeID { get; set; }

        public string SapCode { get; set; }
        public string Name { get; set; }
        public string TaxNo { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }

        public virtual SalesOffice SalesOffice { get; set; }
        public ICollection<CompanyAssignment> CompanyAssignments { get; set; }
    }
}