using System;
using System.Collections.Generic;
using System.Text;

namespace BT67.util
{
   class Utils
    {
        public static string ConvertDatetimeToString(DateTime datetime)
        {
            return datetime.ToString("dd-MM-yyyy");
        }
        public static DateTime ConvertStringToDatetime(string str)
        {
            return DateTime.ParseExact(str, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
