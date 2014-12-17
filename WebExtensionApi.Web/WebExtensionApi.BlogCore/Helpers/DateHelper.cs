using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExtensionApi.BlogCore.Helpers
{
    public static class DateHelper
    {
        public static DateTime ConvertFromCentralToUtc(this DateTime time)
        {
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            return TimeZoneInfo.ConvertTimeToUtc(time, tzi);
        }

        public static DateTime ConvertFromUtcToCentral(this DateTime time)
        {
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(time, tzi);
        }

        public static string DateFormat = "{0:MM/dd/yyyy hh:mm tt}";
    }
}
