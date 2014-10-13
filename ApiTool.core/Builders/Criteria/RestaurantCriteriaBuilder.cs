using System.Configuration;
using System.Net.Http;
using apitool.core.Models.Criteria;
using apitool.core.Models.Parameters;

namespace apitool.core.Builders.Criteria
{
    public class RestaurantCriteriaBuilder : ICallCriteriaBuilder
    {
        public ICallCriteria Build(CallParameters parameters)
        {
            var url = string.Format("{0}.ashx/restaurant/?st=0&pid={1}&rid={2}&offerssearchmode=1",
                                       parameters.ApiVersion,
                                       ConfigurationManager.AppSettings["PartnerId"],
                                       parameters.RestaurantId);

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