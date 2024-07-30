using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class CustomerAssignment
    {
        public int ID { get; set; }

        public int UserID { get; set; }
        public int CustomerID { get; set; }

        public virtual User User { get; set; }
        public virtual Customer Customer { get; set; }
    }
}