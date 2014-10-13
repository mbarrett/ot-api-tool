using System;

namespace apitool.core.Providers
{
    public interface IDateTimeProvider
    {
        DateTime DateTimeNow { get; }
        TimeSpan CurrentUnixTime { get; }
        DateTime TomorrowAtSevenPm { get; }
    }
}