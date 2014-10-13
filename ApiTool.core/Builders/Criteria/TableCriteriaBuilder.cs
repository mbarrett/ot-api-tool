using System.Configuration;
using System.Net.Http;
using apitool.core.Extensions;
using apitool.core.Models.Criteria;
using apitool.core.Models.Parameters;

namespace apitool.core.Builders.Criteria
{
    public class TableCriteriaBuilder : ICallCriteriaBuilder
    {
        public ICallCriteria Build(CallParameters parameters)
        {
            var url = string.Format("{0}.ashx/table/?st=0&pid={1}&rid={2}&dt={3}&ps={4}&offerssearchmode=1",
                                    parameters.ApiVersion,
                                    ConfigurationManager.AppSettings["PartnerId"],
                                    parameters.RestaurantId,
                                    parameters.DateTime.ToApiDateTimeFormat().UrlEncode(),
                                    parameters.PartySize);

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