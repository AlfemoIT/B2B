using B2B.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class ZSD_S_FIY_TICKET
    {
        public string URUN_GRUBU { get; set; }
        public string URUN { get; set; }
        public string MALZEME_NO { get; set; }
        public string ETIKET_TANIM { get; set; }
        public string ALT_MARKA { get; set; }
        public string TOPTAN_FIYAT { get; set; }
        public string PESIN_FIYAT { get; set; }
        public string CMPT_PESIN_FIYAT
        {
            get
            {
                double amount = 0;
                if (!string.IsNullOrEmpty(PESIN_FIYAT))
                {
                    amount = Convert.ToDouble(PESIN_FIYAT, CultureHelper.TRCultureInfo);
                    return string.Format("{0:N0}", amount);
                }
                return amount.ToString();
            }
        }

        public string TAKSIT_9 { get; set; }
        public string CMPT_TAKSIT_9
        {
            get
            {
                double amount = 0;
                if (!string.IsNullOrEmpty(TAKSIT_9))
                {
                    amount = Convert.ToDouble(TAKSIT_9, CultureHelper.TRCultureInfo);
                    return string.Format("{0:N0}", amount);
                }
                return amount.ToString();
            }
        }
        public string TAKSIT_18 { get; set; }
        public string TAKSIT_24 { get; set; }
        public string TAKSIT_36 { get; set; }
    }
}