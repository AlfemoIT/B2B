using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class KONA                       //anlasmalar
    {
        public string KNUMA { get; set; }   //satis kampanyasi
        public string BOTEXT { get; set; }  //kampanya aciklama
        public string DATAB { get; set; }   //gecerlilik bas trh
        public string CMPT_DATAB
        {
            get
            {
                if (!string.IsNullOrEmpty(DATAB) && DATAB != "0000-00-00")
                {
                    return Convert.ToDateTime(DATAB)
                                  .ToString("dd-MM-yyyy");
                }
                return string.Empty;
            }
        }
        public string DATBI { get; set; }   //gecerlilik bit trh
        public string CMPT_DATBI
        {
            get
            {
                if (!string.IsNullOrEmpty(DATBI) && DATBI != "0000-00-00")
                {
                    return Convert.ToDateTime(DATBI)
                                  .ToString("dd-MM-yyyy");
                }
                return string.Empty;
            }
        }
    }
}