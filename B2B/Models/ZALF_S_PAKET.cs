using B2B.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class ZALF_S_PAKET
    {
        public string MATNR { get; set; }
        public string MAKTX { get; set; }
        public string LONG_MAKTX { get; set; }
        public string MATKL { get; set; }
        public string MVGR1 { get; set; }
        public string BEZEI1 { get; set; }
        public string MVGR2 { get; set; }
        public string BEZEI2 { get; set; }
        public string MVGR3 { get; set; }
        public string BEZEI3 { get; set; }
        public string MVGR4 { get; set; }
        public string BEZEI4 { get; set; }
        public string MVGR5 { get; set; }
        public string BEZEI5 { get; set; }

        public string ANPD { get; set; }
        public string CMPT_ANPD
        {
            get
            {
                double amount = 0;
                if (!string.IsNullOrEmpty(ANPD))
                {
                    amount = Convert.ToDouble(ANPD, CultureHelper.TRCultureInfo);
                    return string.Format("{0:N0}", amount);
                }
                return amount.ToString();
            }
        }

        public string MRSN { get; set; }
        public string CMPT_MRSN
        {
            get
            {
                double amount = 0;
                if (!string.IsNullOrEmpty(MRSN))
                {
                    amount = Convert.ToDouble(MRSN, CultureHelper.TRCultureInfo);
                    return string.Format("{0:N0}", amount);
                }
                return amount.ToString();
            }
        }

        public string A049 { get; set; }
        public string CMPT_A049
        {
            get
            {
                double amount = 0;
                if (!string.IsNullOrEmpty(A049))
                {
                    amount = Convert.ToDouble(A049, CultureHelper.TRCultureInfo);
                    return string.Format("{0:N0}", amount);
                }
                return amount.ToString();
            }
        }

        public string SEVK { get; set; }
        public string CMPT_SEVK
        {
            get
            {
                double amount = 0;
                if (!string.IsNullOrEmpty(SEVK))
                {
                    amount = Convert.ToDouble(SEVK, CultureHelper.TRCultureInfo);
                    return string.Format("{0:N0}", amount);
                }
                return amount.ToString();
            }
        }

        public string TESHIR { get; set; }
        public string CMPT_TESHIR
        {
            get
            {
                double amount = 0;
                if (!string.IsNullOrEmpty(TESHIR))
                {
                    amount = Convert.ToDouble(TESHIR, CultureHelper.TRCultureInfo);
                    return string.Format("{0:N0}", amount);
                }
                return amount.ToString();
            }
        }

        public string VRKME { get; set; }
        public string LVORM { get; set; } //silme isareti
        public string VMSTA { get; set; } //blokaj
        public string IS_EXIST_PRICE { get; set; } //fiyat durumu

    }
}