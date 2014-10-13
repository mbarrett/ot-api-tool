using System.Configuration;

namespace apitool.core.Providers
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public string RestaurantId { get { return ConfigurationManager.AppSettings["RestaurantId"]; }}
        public string PartySize { get { return ConfigurationManager.AppSettings["PartySize"]; }}
        public string PartnerId { get { return ConfigurationManager.AppSettings["PartnerId"]; }}
        public string SearchTerm { get { return ConfigurationManager.AppSettings["SearchTerm"]; }}
    }
}