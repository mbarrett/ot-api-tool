using System;
using apitool.core.Extensions;

namespace apitool.core.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime DateTimeNow { get { return DateTime.Now; } }
        public TimeSpan CurrentUnixTime { get { return DateTimeNow.ToUnixTime(); } }
        public DateTime TomorrowAtSevenPm { get { return new DateTime(DateTimeNow.AddDays(1).Year, DateTimeNow.AddDays(1).Month, DateTimeNow.AddDays(1).Day, 19, 00, 00); } }
    }
}