using System.Text;
using apitool.core.Extensions;
using apitool.core.Models;
using apitool.core.Models.Parameters;

namespace apitool.core.Builders.Authorization
{
    public class OAuthSignitureBuilder : IOAuthSignitureBuilder
    {
        private readonly IQueryParameterBuilder _queryParameterBuilder;

        public OAuthSignitureBuilder(IQueryParameterBuilder queryParameterBuilder)
        {
            _queryParameterBuilder = queryParameterBuilder;
        }

        public OAuthSigniture Build(CallParameters callParameters, AuthorizationHeaderParameters authorizationHeaderParameters)
        {
            var queryParameters = _queryParameterBuilder.Build(callParameters, authorizationHeaderParameters.TimeStamp, authorizationHeaderParameters.Nonce);
            var normalizedUrl = callParameters.Url.ToNormalizedUrl();
            var normalizedRequestParameters = queryParameters.ToNormalizedRequestParameters();

            var oAuthSignitureValue = new StringBuilder();
            oAuthSignitureValue.AppendFormat("{0}&", callParameters.HttpMethod.ToString().ToUpper());
            oAuthSignitureValue.AppendFormat("{0}&", normalizedUrl.UrlEncode());
            oAuthSignitureValue.AppendFormat("{0}", normalizedRequestParameters.UrlEncode());

            return new OAuthSigniture { Value = oAuthSignitureValue.ToString() };
        }
    }
}