using B2B.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class ZAL_S_NAKLIYE
    {
        public string CMPT_ABGRU { get; set; } //nakliye durum
        public string TKNUM { get; set; }      //nakliye no
        public string CMPT_TKNUM
        {
            get
            {
                return TKNUM.TrimStart(new Char[] { '0' });
            }
        }
        public string N_ERDAT { get; set; }    //kaydin eklendi tarih
        public string CMPT_N_ERDAT
        {
            get
            {
                if (!string.IsNullOrEmpty(N_ERDAT) && N_ERDAT != "0000-00-00")
                {
                    return Convert.ToDateTime(N_ERDAT)
                                  .ToString("dd-MM-yyyy");
                }
                return string.Empty;
            }
        }
        public string PLAKA { get; set; }
        public string SURUCU { get; set; }
        public string TELEFON { get; set; }

        public string ERDAT { get; set; }      //teslimat yaratma tarih
        public string CMPT_ERDAT
        {
            get
            {
                if (!string.IsNullOrEmpty(ERDAT) && ERDAT != "0000-00-00")
                {
                    return Convert.ToDateTime(ERDAT)
                                  .ToString("dd-MM-yyyy");
                }
                return string.Empty;
            }
        }

        public string WADAT_IST { get; set; }
        public string CMPT_WADAT_IST
        {
            get
            {
                if (!string.IsNullOrEmpty(WADAT_IST) && WADAT_IST != "0000-00-00")
                {
                    return Convert.ToDateTime(WADAT_IST)
                                  .ToString("dd-MM-yyyy");
                }
                return string.Empty;
            }
        }

        public string LPS_VBELN { get; set; }
        public string CMPT_LPS_VBELN
        {
            get
            {
                return LPS_VBELN.TrimStart(new Char[] { '0' });
            }
        }

        public string LPS_POSNR { get; set; }
        public string CMPT_LPS_POSNR
        {
            get
            {
                return LPS_POSNR.TrimStart(new Char[] { '0' });
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

        public string POSNR { get; set; }
        public string CMPT_POSNR
        {
            get
            {
                return POSNR.TrimStart(new Char[] { '0' });
            }
        }

        public string MATNR { get; set; }
        public string MAKTX { get; set; }
        public string LONG_MAKTX { get; set; }

        public string KWMENG { get; set; }
        public double CMPT_KWMENG 
        {
            get
            {
                double amount = 0;
                if (!string.IsNullOrEmpty(KWMENG))
                {
                    amount = Convert.ToDouble(KWMENG, CultureHelper.TRCultureInfo);
                    return amount;
                }
                return amount;
            }
        }
        public string VRKME { get; set; }

        public string ZZMUSTERI_AD { get; set; }
        public string KUNNR { get; set; }
        public string KUNAGTANIM { get; set; }
    }
}