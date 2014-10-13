using System.Configuration;
using System.Net.Http;
using apitool.core.Models.Criteria;
using apitool.core.Models.Parameters;

namespace apitool.core.Builders.Criteria
{
    public class LocalRestaurantsByNameCriteriaBuilder : ICallCriteriaBuilder
    {
        public ICallCriteria Build(CallParameters parameters)
        {
            var url = string.Format("{0}.ashx/name_search/?st=0&pid={1}&partialname={2}&lat=51.517636&long=-0.120528",
                                        parameters.ApiVersion,
                                        ConfigurationManager.AppSettings["PartnerId"],
                                        parameters.SearchTerm);

            return new CallCriteria
            {
                CallParameters = new CallParameters
                {
                    Url = url,
                    HttpMethod = HttpMethod.Get
                }
            };
        }
    }
}