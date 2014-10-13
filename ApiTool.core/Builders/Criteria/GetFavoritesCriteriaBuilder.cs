using System.Configuration;
using System.Net.Http;
using apitool.core.Models.Criteria;
using apitool.core.Models.Parameters;

namespace apitool.core.Builders.Criteria
{
    public class GetFavoritesCriteriaBuilder : ICallCriteriaBuilder
    {
        public ICallCriteria Build(CallParameters parameters)
        {
            var url = string.Format("{0}.ashx/favorites/?st=0&pid={1}&email=auto_user1@opentable.com&at={2}",
                                       parameters.ApiVersion,
                                       ConfigurationManager.AppSettings["PartnerId"],
                                       parameters.AuthToken);

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