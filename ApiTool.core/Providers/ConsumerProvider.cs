using System;
using System.Configuration;
using System.Globalization;

namespace apitool.core.Providers
{
    public class ConsumerProvider : IConsumerProvider
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public ConsumerProvider(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public string Key
        {
            get { return ConfigurationManager.AppSettings["ConsumerKey"]; }
        }

        public string Secret
        {
            get { return ConfigurationManager.AppSettings["ConsumerSecret"]; }
        }

        public string Nonce
        {
            get
            {
                return new Random()
                    .Next(123400, 9999999)
                    .ToString(CultureInfo.InvariantCulture);
            }
        }

        public string TimeStamp
        {
            get
            {
                TimeSpan currentUnixTime = _dateTimeProvider.CurrentUnixTime;
                return Convert.ToInt64(currentUnixTime.TotalSeconds).ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}