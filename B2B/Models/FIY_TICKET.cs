using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class FIY_TICKET
    {
        public string CAMPAIGN_DATE { get; set; }
        public List<ZSD_S_FIY_TICKET> ZSD_S_FIY_TICKETS { get; set; }
    }
}