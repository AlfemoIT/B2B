using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models.Chart
{
    public class SalesOrderChart
    {
        public string YearMonth { get; set; }
        public double OpenOrderAmount { get; set; }
        public double CloseOrderAmount { get; set; }
    }
}