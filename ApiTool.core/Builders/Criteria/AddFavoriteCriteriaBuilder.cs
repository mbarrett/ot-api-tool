using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.Net.Http;
using apitool.core.Models.Criteria;
using apitool.core.Models.Parameters;

namespace apitool.core.Builders.Criteria
{
    public class AddFavoriteCriteriaBuilder : ICallCriteriaBuilder
    {
        public ICallCriteria Build(CallParameters parameters)
        {
            var url = string.Format("{0}.ashx/favorites/?st=0&pid={1}",
                                        parameters.ApiVersion,
                                        ConfigurationManager.AppSettings["PartnerId"]);

            return new CallCriteria
                {
                    CallParameters = new CallParameters
                        {
                            Url = url,
                            HttpMethod = HttpMethod.Post
                        },
                    PostParameters = new NameValueCollection
                        {
                            {"email", parameters.Email},
                            {"authkey", parameters.AuthToken},
                            {"rid", parameters.RestaurantId.ToString(CultureInfo.InvariantCulture)}
                        }
                };

        }
    }
}