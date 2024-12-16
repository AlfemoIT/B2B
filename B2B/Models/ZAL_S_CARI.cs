using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class ZAL_S_CARI
    {
        public string REFERANS { get; set; }
        public string CMPT_REFERANS
        {
            get
            {
                return REFERANS.TrimStart(new Char[] { '0' });
            }
        }
        public string FATURA_NO { get; set; }
        public string CMPT_FATURA_NO
        {
            get
            {
                return FATURA_NO.TrimStart(new Char[] { '0' });
            }
        }
        public string BELGE_TUR { get; set; }
        public string BELGE_TARIH { get; set; }
        public string CMPT_BELGE_TARIH
        {
            get
            {
                if (!string.IsNullOrEmpty(BELGE_TARIH) && BELGE_TARIH != "0000-00-00")
                {
                    return Convert.ToDateTime(BELGE_TARIH)
                                  .ToString("dd-MM-yyyy");
                }
                return string.Empty;
            }
        }
        public string TUTAR { get; set; }
        public string CURRENCY { get; set; }
        public string METIN { get; set; }
    }
}