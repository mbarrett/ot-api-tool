using System.Collections.Specialized;
using System.Configuration;
using System.Net.Http;
using apitool.core.Models.Criteria;
using apitool.core.Models.Parameters;

namespace apitool.core.Builders.Criteria
{
    public class RegisterCriteriaBuilder : ICallCriteriaBuilder
    {
        public ICallCriteria Build(CallParameters parameters)
        {
            var url = string.Format("{0}.ashx/register/?st=0&pid={1}",
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
                            {"firstname", "Test"},
                            {"lastname", "User"},
                            {"sortablefirstname", "Test"},
                            {"sortablelastname", "User"},
                            {"email", parameters.Email},
                            {"password", "password"},
                            {"phonecountryid", "UK"},
                            {"phone", "02012345678"},
                            {"phoneext", string.Empty},
                            {"mobilephonecountryid", "UK"},
                            {"mobilephone", "07012345678"},
                            {"primarymetroid", "72"},
                            {"diningoffers", "0"},
                            {"isadmin", "0"},
                            {"specialrequest", "versions 1 & 2 require special requests field not empty"},
                            {"app_version", string.Empty}
                        }
                };
        }
    }
}
