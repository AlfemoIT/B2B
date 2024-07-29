using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class SalesOffice
    {
        public SalesOffice() //bolgeler
        {
            Companies = new List<Company>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}