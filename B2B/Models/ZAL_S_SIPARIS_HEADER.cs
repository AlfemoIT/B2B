using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class ZAL_S_SIPARIS_HEADER
    {
        public string CMPT_ABGRU { get; set; }
        public string AUDAT { get; set; }  //belge tarih
        public string CMPT_AUDAT
        {
            get
            {
                if (!string.IsNullOrEmpty(AUDAT) && AUDAT != "0000-00-00")
                {
                    return Convert.ToDateTime(AUDAT)
                                  .ToString("dd-MM-yyyy");
                }
                return string.Empty;
            }
        }

        public string CMTD_DELIV_DATE { get; set; } //müşterinin istediği teslim tarihi
        public string CMPT_DELIV_DATE
        {
            get
            {
                if (!string.IsNullOrEmpty(CMTD_DELIV_DATE) && CMTD_DELIV_DATE != "0000-00-00")
                {
                    return Convert.ToDateTime(CMTD_DELIV_DATE)
                                  .ToString("dd-MM-yyyy");
                }
                return string.Empty;
            }
        }

        public string VBELN { get; set; }
        public string CMPT_VBELN
        {
            get
            {
                return VBELN.TrimStart(new Char[] { '0' });
            }
        }

        public string KUNAGTANIM { get; set; }
        public string ZZMUSTERI_AD { get; set; }
        public string TOTAL_ORDER_PRICE { get; set; }
        public double CMPT_TOTAL_ORDER_PRICE
        {
            get
            {
                CultureInfo info = new CultureInfo("tr-TR");
                info.NumberFormat.NumberDecimalSeparator = ",";

                double amount = 0;
                if (!string.IsNullOrEmpty(TOTAL_ORDER_PRICE))
                {
                    amount = Convert.ToDouble(TOTAL_ORDER_PRICE, info);
                    return amount;
                }
                return amount;
            }
        }
        public string TOTAL_ORDER_PRICE_TL { get; set; }
        public double CMPT_TOTAL_ORDER_PRICE_TL
        {
            get
            {
                CultureInfo info = new CultureInfo("tr-TR");
                info.NumberFormat.NumberDecimalSeparator = ",";

                double amount = 0;
                if (!string.IsNullOrEmpty(TOTAL_ORDER_PRICE_TL))
                {
                    amount = Convert.ToDouble(TOTAL_ORDER_PRICE_TL, info);
                    return amount;
                }
                return amount;
            }
        }
        public string WAERK { get; set; } //para birimi
    }
}