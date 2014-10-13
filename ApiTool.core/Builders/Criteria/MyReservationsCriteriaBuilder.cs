using System.Configuration;
using System.Net.Http;
using apitool.core.Models.Criteria;
using apitool.core.Models.Parameters;

namespace apitool.core.Builders.Criteria
{
    public class MyReservationsCriteriaBuilder : ICallCriteriaBuilder
    {
        public ICallCriteria Build(CallParameters parameters)
        {
            var url = string.Format("{0}.ashx/reservation/?st=0&pid={1}&email=mbarrett@opentable.com&at={2}",
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