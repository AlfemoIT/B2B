using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class KNA1 //Müşteri ana verileri
    {
        [Description("Müsteri")]
        public string KUNNR { get; set; }

        [Description("AramaDizilimi")]
        public string SORTL { get; set; } //bayi,personel ?

        [Description("FirmaAd")]
        public string NAME1 { get; set; }

        [Description("TCVergiNo2")]
        public string STCD2 { get; set; }
        public string TELF1 { get; set; }
        public string TELF2 { get; set; }
    }
}