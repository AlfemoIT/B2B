﻿using B2B.Helper;
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
                double amount = 0;
                if (!string.IsNullOrEmpty(TOTAL_ORDER_PRICE))
                {
                    amount = Convert.ToDouble(TOTAL_ORDER_PRICE, CultureHelper.TRCultureInfo);
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
                double amount = 0;
                if (!string.IsNullOrEmpty(TOTAL_ORDER_PRICE_TL))
                {
                    amount = Convert.ToDouble(TOTAL_ORDER_PRICE_TL, CultureHelper.TRCultureInfo);
                    return amount;
                }
                return amount;
            }
        }
        public string WAERK { get; set; } //para birimi

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
    }
}