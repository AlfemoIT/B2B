using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class CompanyAssignment
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int CompanyID { get; set; }

        public virtual User User { get; set; }
        public virtual Company Company { get; set; }
    }
}