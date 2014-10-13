using apitool.core.Builders.Authorization;
using apitool.core.Extensions;
using apitool.core.Models.Parameters;
using apitool.core.Validators;

namespace apitool.core.Providers
{
    public class OAuthSignitureProvider : IOAuthSignitureProvider
    {
        private readonly IOAuthValidator _oAuthValidator;
        private readonly IOAuthSignitureBuilder _oAuthSignitureBuilder;
        private readonly IHashAlgorithmBuilder _hashAlgorithmBuilder;
        private readonly IConsumerProvider _consumerProvider;

        public OAuthSignitureProvider(IOAuthValidator oAuthValidator, 
                                      IOAuthSignitureBuilder oAuthSignitureBuilder, 
                                      IHashAlgorithmBuilder hashAlgorithmBuilder,
                                      IConsumerProvider consumerProvider)
        {
            _oAuthValidator = oAuthValidator;
            _oAuthSignitureBuilder = oAuthSignitureBuilder;
            _hashAlgorithmBuilder = hashAlgorithmBuilder;
            _consumerProvider = consumerProvider;
        }

        public string GetHashEncodedSignitureFor(CallParameters callParameters, AuthorizationHeaderParameters authorizationHeaderParameters)
        {
            _oAuthValidator.ValidateParameters(callParameters, authorizationHeaderParameters.TimeStamp, authorizationHeaderParameters.Nonce);

            var oAuthSigniture = _oAuthSignitureBuilder.Build(callParameters, authorizationHeaderParameters);
            var hashAlgorithm = _hashAlgorithmBuilder.Build(_consumerProvider.Secret, callParameters.TokenSecret);

            _oAuthValidator.ValidateSignitureAndAlgorithm(oAuthSigniture, hashAlgorithm);

            return oAuthSigniture.ToBase64StringUsingHashAlgorithm(hashAlgorithm);
        }
    }
}