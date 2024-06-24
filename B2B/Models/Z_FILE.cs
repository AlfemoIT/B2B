using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class Z_FILE
    {
        public string NAME { get; set; }
        public string PATH { get; set; }
        public DateTime CREATION_TIME { get; set; }
        public string CMPT_CREATION_TIME
        {
            get
            {
                if (CREATION_TIME != null)
                {
                    return Convert.ToDateTime(CREATION_TIME)
                                  .ToString("dd-MM-yyyy");
                }
                return string.Empty;
            }
        }
    }
}