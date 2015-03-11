
using System.Configuration;
using System.Net.Http;
using apitool.core.Extensions;
using apitool.core.Models.Criteria;
using apitool.core.Models.Parameters;

namespace apitool.core.Builders.Criteria
{
    public class SearchRegionsCriteriaBuilder : ICallCriteriaBuilder
    {
        public ICallCriteria Build(CallParameters parameters)
        {
            var url = string.Format("{0}.ashx/table/?st=0&pid={1}&dt={2}&ps={3}&metroid=201&regids=1001",
                                        parameters.ApiVersion,
                                        ConfigurationManager.AppSettings["PartnerId"],
                                        parameters.DateTime.ToApiDateTimeFormat(parameters.IsUSDateFormat).UrlEncode(),
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
