using System.Linq;
using apitool.core.Builders.Authorization;
using apitool.core.Extensions;
using apitool.core.Models.Criteria;
using apitool.core.Models.Parameters;
using apitool.core.Providers;
using apitool.core.ViewModels;

namespace apitool.core.Builders
{
    public class OtApiViewModelBuilder : IOtApiViewModelBuilder
    {
        private readonly IAuthorizationHeaderBuilder _authorizationHeaderBuilder;
        private readonly ICallCriteriaProvider _callCriteriaProvider;
        private readonly IWebResponseBuilder _webResponseBuilder;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IConsumerProvider _consumerProvider;
        private readonly IDateTimeProvider _dateTimeProvider;

        public OtApiViewModelBuilder(IAuthorizationHeaderBuilder authorizationHeaderBuilder,
                                     ICallCriteriaProvider callCriteriaProvider,
                                     IWebResponseBuilder webResponseBuilder,
                                     IConfigurationProvider configurationProvider,
                                     IConsumerProvider consumerProvider,
                                     IDateTimeProvider dateTimeProvider)
        {
            _authorizationHeaderBuilder = authorizationHeaderBuilder;
            _callCriteriaProvider = callCriteriaProvider;
            _webResponseBuilder = webResponseBuilder;
            _configurationProvider = configurationProvider;
            _consumerProvider = consumerProvider;
            _dateTimeProvider = dateTimeProvider;
        }

        public OtApiViewModel BuildDefaultModel(string call)
        {
            return new OtApiViewModel
                {
                    PartnerId = _configurationProvider.PartnerId,
                    ConsumerKey = _consumerProvider.Key,
                    ConsumerSecret = _consumerProvider.Secret,
                    DefaultDateTime = _dateTimeProvider.TomorrowAtSevenPm,
                    DefaultPartySize = _configurationProvider.PartySize,
                    DefaultRestaurantId = _configurationProvider.RestaurantId,
                    DefaultSearchTerm = _configurationProvider.SearchTerm
                };
        }

        public OtApiViewModel BuildResponseModel(dynamic call, CallParameters parameters)
        {
            var criteria = _callCriteriaProvider.Build(call, parameters);
            var authHeader = _authorizationHeaderBuilder.Build(criteria.CallParameters);
            var responseString = _webResponseBuilder.GetResponseStringFor(criteria, authHeader);
            
            var viewModel = BuildDefaultModel(call);

            viewModel.Url = criteria.CallParameters.Url;
            viewModel.Response = responseString;
            viewModel.AuthHeaders = authHeader.Value;
            viewModel.PostParameters = GetPostParameters(criteria);
            viewModel.ApiVersion = parameters.ApiVersion;

            return viewModel;
        }

        private static string GetPostParameters(ICallCriteria criteria)
        {
            return string.Join("&", criteria.PostParameters
                                                .AllKeys
                                                .Select(key => key + "=" + criteria.PostParameters[key])
                                                .ToArray());
        }
    }
}