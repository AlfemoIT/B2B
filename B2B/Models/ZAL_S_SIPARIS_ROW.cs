﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class ZAL_S_SIPARIS_ROW
    {
        public string CMPT_ABGRU { get; set; }
        public string V_ERDAT { get; set; }  //belge yaratma tarih
        public string CMPT_V_ERDAT
        {
            get
            {
                if (!string.IsNullOrEmpty(V_ERDAT) && V_ERDAT != "0000-00-00")
                {
                    return Convert.ToDateTime(V_ERDAT)
                                  .ToString("dd-MM-yyyy");
                }
                return string.Empty;
            }
        }

        public string VDATU { get; set; }  //İstnn.tsl.trh
        public string CMPT_VDATU
        {
            get
            {
                if (!string.IsNullOrEmpty(VDATU) && VDATU != "0000-00-00")
                {
                    return Convert.ToDateTime(VDATU)
                                  .ToString("dd-MM-yyyy");
                }
                return string.Empty;
            }
        }

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

        public string CMTD_DELIV_DATE { get; set; }  //müşterinin istediği teslim tarihi
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
        public string POSNR { get; set; }
        public string CMPT_POSNR
        {
            get
            {
                return POSNR.TrimStart(new Char[] { '0' });
            }
        }

        public string AUART { get; set; }  //satis belge tur
        public string KUNNR { get; set; }
        public string KUNAGTANIM { get; set; }
        public string ZZMUSTERI_AD { get; set; }
        public string KTEXT { get; set; }
        public string LGORT { get; set; }
        public string LGOBE { get; set; }
        public string MATNR { get; set; }
        public string MAKTX { get; set; }
        public string LONG_MAKTX { get; set; }
        public string VTEXT { get; set; }

        public string KWMENG { get; set; }
        public double CMPT_KWMENG
        {
            get
            {
                CultureInfo info = new CultureInfo("tr-TR");
                info.NumberFormat.NumberDecimalSeparator = ",";

                double amount = 0;
                if (!string.IsNullOrEmpty(TOTAL_LFIMG))
                {
                    amount = Convert.ToDouble(KWMENG, info);
                    return amount;
                }
                return amount;
            }
        }
        public string VRKME { get; set; }        //satis ölcu birim

        public string TKNUM { get; set; }  //nakliye

        public string N_ERDAT { get; set; } //nakliye trh
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

        public string TOTAL_LFIMG { get; set; }  //sevk mkt
        public double CMPT_TOTAL_LFIMG
        {
            get
            {
                CultureInfo info = new CultureInfo("tr-TR");
                info.NumberFormat.NumberDecimalSeparator = ",";

                double amount = 0;
                if (!string.IsNullOrEmpty(TOTAL_LFIMG))
                {
                    amount = Convert.ToDouble(TOTAL_LFIMG, info);
                    return amount;
                }
                return amount;
            }
        }

        public string TOTAL_FKIMG { get; set; }  //teslim mkt
        public double CMPT_TOTAL_FKIMG
        {
            get
            {
                CultureInfo info = new CultureInfo("tr-TR");
                info.NumberFormat.NumberDecimalSeparator = ",";

                double amount = 0;
                if (!string.IsNullOrEmpty(TOTAL_FKIMG))
                {
                    amount = Convert.ToDouble(TOTAL_FKIMG, info);
                    return amount;
                }
                return amount;
            }
        }

        public string TOTAL_BMENG { get; set; }  //teyit
        public double CMPT_TOTAL_BMENG
        {
            get
            {
                CultureInfo info = new CultureInfo("tr-TR");
                info.NumberFormat.NumberDecimalSeparator = ",";

                double amount = 0;
                if (!string.IsNullOrEmpty(TOTAL_BMENG))
                {
                    amount = Convert.ToDouble(TOTAL_BMENG, info);
                    return amount;
                }
                return amount;
            }
        }

        public string READY_VOLUM { get; set; } //sevke hazır hacim
        public double CMPT_READY_VOLUM
        {
            get
            {
                CultureInfo info = new CultureInfo("tr-TR");
                info.NumberFormat.NumberDecimalSeparator = ",";

                double amount = 0;
                if (!string.IsNullOrEmpty(READY_VOLUM))
                {
                    amount = Convert.ToDouble(READY_VOLUM, info);
                    return amount;
                }
                return amount;
            }
        }

        public string TOTAL_IN_PRODUCTION { get; set; }  //uretimde mkt
        public double CMPT_TOTAL_IN_PRODUCTION
        {
            get
            {
                CultureInfo info = new CultureInfo("tr-TR");
                info.NumberFormat.NumberDecimalSeparator = ",";

                double amount = 0;
                if (!string.IsNullOrEmpty(TOTAL_IN_PRODUCTION))
                {
                    amount = Convert.ToDouble(TOTAL_IN_PRODUCTION, info);
                    return amount;
                }
                return amount;
            }
        }

        public string TOTAL_IN_PLAN { get; set; }       //planda mkt
        public double CMPT_TOTAL_IN_PLAN
        {
            get
            {
                CultureInfo info = new CultureInfo("tr-TR");
                info.NumberFormat.NumberDecimalSeparator = ",";

                double amount = 0;
                if (!string.IsNullOrEmpty(TOTAL_IN_PLAN))
                {
                    amount = Convert.ToDouble(TOTAL_IN_PLAN, info);
                    return amount;
                }
                return amount;
            }
        }

        public string ZZURTM_WEEK_DESC { get; set; }    //hafta
        public string WAERK { get; set; }              //para birimi
        public string TOTAL_ORDER_PRICE { get; set; }  //sip bedel
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
        public string TOTAL_ORDER_PRICE_TL { get; set; } //sip bedel tl
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
    }
}