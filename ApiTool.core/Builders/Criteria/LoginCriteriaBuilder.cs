using System.Configuration;
using System.Net.Http;
using apitool.core.Models.Criteria;
using apitool.core.Models.Parameters;

namespace apitool.core.Builders.Criteria
{
    public class LoginCriteriaBuilder : ICallCriteriaBuilder
    {
        public ICallCriteria Build(CallParameters parameters)
        {
            var url = string.Format("{0}.ashx/user/?st=0&pid={1}&email=slide.mb%2B2014%2B0.60.0.1%40gmail.com&pwd=password",
                                       parameters.ApiVersion,
                                       ConfigurationManager.AppSettings["PartnerId"]);

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