using apitool.core.Constants;
using apitool.core.Extensions;
using apitool.core.Models;
using apitool.core.Models.Parameters;
using apitool.core.Providers;

namespace apitool.core.Builders.Authorization
{
    public class AuthorizationHeaderBuilder : IAuthorizationHeaderBuilder
    {
        private readonly IOAuthSignitureProvider _oAuthSignitureProvider;
        private readonly IConsumerProvider _consumerProvider;

        public AuthorizationHeaderBuilder(IOAuthSignitureProvider oAuthSignitureProvider,
                                          IConsumerProvider consumerProvider)
        {
            _oAuthSignitureProvider = oAuthSignitureProvider;
            _consumerProvider = consumerProvider;
        }

        public AuthorizationHeader Build(CallParameters callParameters)
        {
            var authorizationHeaderParameters = new AuthorizationHeaderParameters(_consumerProvider.TimeStamp, _consumerProvider.Nonce);
            var encodedOAuthSigniture = _oAuthSignitureProvider.GetHashEncodedSignitureFor(callParameters, authorizationHeaderParameters).UrlEncode();

            return new AuthorizationHeader
            {
                Value = string.Format(
                    OAuthConstants.OAuthHeaderTemplate,
                    _consumerProvider.Key, 
                    encodedOAuthSigniture,
                    authorizationHeaderParameters.TimeStamp,
                    authorizationHeaderParameters.Nonce)
    //Value = "OAuth realm=\"http://www.opentable.com/, oauth_consumer_key=\"SquareMealV3TT\", oauth_signature_method=\"HMAC-SHA1\", oauth_signature=\"MvuuloU%2B5UW0TRxZUZald3xbc4Q%3D\", oauth_timestamp=\"1398761329\", oauth_token=\"\", oauth_nonce=\"521896\", oauth_version=\"1.0\""
            };
        }
    }
}