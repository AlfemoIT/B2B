using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace B2B.Helper
{
    public static class CultureHelper
    {
        public static readonly CultureInfo TRCultureInfo;
        static CultureHelper()
        {
            TRCultureInfo = new CultureInfo("tr-TR");
            TRCultureInfo.NumberFormat.NumberDecimalSeparator = ".";
        }
    }
}