using B2B.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace B2B.Models
{
    public class ZALF_S_FIYAT_LIST
    {
        public string MATNR { get; set; }
        public string MAKTX { get; set; }
        public string ZCL_MAKTX { get; set; }   //uzun metin

        public string FIYAT1 { get; set; }
        public string CMPT_FIYAT1
        {
            get
            {
                double amount = 0;
                if (!string.IsNullOrEmpty(FIYAT1))
                {
                    amount = Convert.ToDouble(FIYAT1, CultureHelper.TRCultureInfo);
                    if (amount == 0)
                    {
                        return string.Empty;
                    }
                    return string.Format("{0:N0}", amount);
                }
                return amount.ToString();
            }
        }

        public string FIYAT2 { get; set; }
        public string CMPT_FIYAT2
        {
            get
            {
                double amount = 0;
                if (!string.IsNullOrEmpty(FIYAT2))
                {
                    amount = Convert.ToDouble(FIYAT2, CultureHelper.TRCultureInfo);
                    if (amount == 0)
                    {
                        return string.Empty;
                    }
                    return string.Format("{0:N0}", amount);
                }
                return amount.ToString();
            }
        }

        public string FIYAT3 { get; set; }
        public string CMPT_FIYAT3
        {
            get
            {
                double amount = 0;
                if (!string.IsNullOrEmpty(FIYAT3))
                {
                    amount = Convert.ToDouble(FIYAT3, CultureHelper.TRCultureInfo);
                    if (amount == 0)
                    {
                        return string.Empty;
                    }
                    return string.Format("{0:N0}", amount);
                }
                return amount.ToString();
            }
        }

        public string FIYAT4 { get; set; }
        public string CMPT_FIYAT4
        {
            get
            {
                double amount = 0;
                if (!string.IsNullOrEmpty(FIYAT4))
                {
                    amount = Convert.ToDouble(FIYAT4, CultureHelper.TRCultureInfo);
                    if (amount == 0)
                    {
                        return string.Empty;
                    }
                    return string.Format("{0:N0}", amount);
                }
                return amount.ToString();
            }
        }

        public string FIYAT5 { get; set; }
        public string CMPT_FIYAT5
        {
            get
            {
                double amount = 0;
                if (!string.IsNullOrEmpty(FIYAT5))
                {
                    amount = Convert.ToDouble(FIYAT5, CultureHelper.TRCultureInfo);
                    if (amount == 0)
                    {
                        return string.Empty;
                    }
                    return string.Format("{0:N0}", amount);
                }
                return amount.ToString();
            }
        }

        public string Z001 { get; set; }        //kampanya
        public string CMPT_Z001
        {
            get
            {
                double amount = 0;
                if (!string.IsNullOrEmpty(Z001))
                {
                    amount = Convert.ToDouble(Z001, CultureHelper.TRCultureInfo);
                    if (amount == 0)
                    {
                        return string.Empty;
                    }
                    return string.Format("{0:N0}", amount);
                }
                return amount.ToString();
            }
        }

        public string Z015 { get; set; }
        public string CMPT_Z015
        {
            get
            {
                double amount = 0;
                if (!string.IsNullOrEmpty(Z015))
                {
                    amount = Convert.ToDouble(Z015, CultureHelper.TRCultureInfo);
                    if (amount == 0)
                    {
                        return string.Empty;
                    }
                    return string.Format("{0:N0}", amount);
                }
                return amount.ToString();
            }
        }

        public string Z022 { get; set; }
        public string CMPT_Z022
        {
            get
            {
                double amount = 0;
                if (!string.IsNullOrEmpty(Z022))
                {
                    amount = Convert.ToDouble(Z022, CultureHelper.TRCultureInfo);
                    if (amount == 0)
                    {
                        return string.Empty;
                    }
                    return string.Format("{0:N0}", amount);
                }
                return amount.ToString();
            }
        }

        public string PARA_BIRIMI { get; set; }

        public string DATAB { get; set; }        //gecerlilik bas trh
        public string DATBI { get; set; }        //gecerlilik bit trh

        public string MVGR1 { get; set; }        //malzeme grubu 1
        public string BEZEI { get; set; }        //tanim

        public string MVGR2 { get; set; }
        public string BEZEI2 { get; set; }

        public string MVGR3 { get; set; }
        public string BEZEI3 { get; set; }

        public string MVGR4 { get; set; }
        public string BEZEI4 { get; set; }

        public string MVGR5 { get; set; }
        public string BEZEI5 { get; set; }
    }
}