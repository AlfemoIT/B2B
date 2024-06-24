using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class VBAP
    {
        [Description("SatisBelgesi")]
        public string VBELN { get; set; }
        public string CMPT_VBELN
        {
            get
            {
                return VBELN.TrimStart(new Char[] { '0' });
            }
        }

        [Description("Kalem")]
        public string POSNR { get; set; }

        [Description("BelgeTarihi")]
        public string AUDAT { get; set; }
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

        [Description("Malzeme")]
        public string MATNR { get; set; }

        [Description("KalemTanimi")]
        public string ARKTX { get; set; }

        [Description("Malzeme Uzun Metni")]
        public string ZCL_MAKTX { get; set; }

        [Description("HedefÖB")]
        public string ZIEME { get; set; }

        [Description("SatisÖB")]
        public string VRKME { get; set; }

        [Description("KümSiparisMkt")]
        public string KWMENG { get; set; }
        public string CMPT_KWMENG
        {
            get
            {
                CultureInfo info = new CultureInfo("tr-TR");
                info.NumberFormat.NumberDecimalSeparator = ".";

                double amount = 0;
                if (!string.IsNullOrEmpty(KWMENG))
                {
                    amount = Convert.ToDouble(KWMENG, info);
                    return string.Format("{0:0}", amount);
                }
                return amount.ToString();
            }
        }

        [Description("TaahhütEdlTslTrh(YYYYMMDD)")]
        public string CMTD_DELIV_DATE { get; set; }
        public string CMPT_CMTD_DELIV_DATE
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

        [Description("Malı Teslim Alan")]
        public string ZZMUSTERI_AD { get; set; }
    }
}