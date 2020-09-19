using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.CustomHandler
{
    public static class Currency
    {
        public static string CurrencyFormat(double? input)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            //string a = input.ToString("#.###", cul.NumberFormat);
            return String.Format(cul, "{0:c0}", input);
        }
        public static int Percentage(double current, double maximum)
        {
            return (int)Math.Round((double)(100 * (maximum - current) / maximum));
        }
    }
}
