using System;

namespace apitool.core.Extensions
{
    public static class DateTimeExtensions
    {
         public static string ToApiDateTimeFormat(this DateTime value)
         {
             return value.ToString("dd/MM/yyyy HH:mm:ss");
         }

        public static TimeSpan ToUnixTime(this DateTime value)
        {
            return value - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        }
    }
}