using System.Configuration;
using System.Net.Http;
using apitool.core.Extensions;
using apitool.core.Models.Criteria;
using apitool.core.Models.Parameters;

namespace apitool.core.Builders.Criteria
{
    public class CancelCriteriaBuilder : ICallCriteriaBuilder
    {
        public ICallCriteria Build(CallParameters parameters)
        {
            var url = string.Format("{0}.ashx/reservation/?pid={1}&rid={2}&email={3}&conf={4}",
                                    parameters.ApiVersion,
                                    ConfigurationManager.AppSettings["PartnerId"],
                                    parameters.RestaurantId, 
                                    parameters.Email.UrlEncode(), 
                                    parameters.ConfirmationNumber);

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