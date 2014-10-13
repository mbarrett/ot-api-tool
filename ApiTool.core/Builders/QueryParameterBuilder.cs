﻿using System.Collections.Generic;
using apitool.core.Constants;
using apitool.core.Extensions;
using apitool.core.Models.Parameters;
using apitool.core.Providers;

namespace apitool.core.Builders
{
    public class QueryParameterBuilder : IQueryParameterBuilder
    {
        private readonly IConsumerProvider _consumerProvider;

        public QueryParameterBuilder(IConsumerProvider consumerProvider)
        {
            _consumerProvider = consumerProvider;
        }

        public IList<QueryParameter> Build(CallParameters callParameters, string consumerTimeStamp, string nonce)
        {
            var outcome = new List<QueryParameter>();
            var queryStringParameters = callParameters.Url.ToApiQuerystringParameters();

            if (!string.IsNullOrEmpty(queryStringParameters))
            {
                var p = queryStringParameters.Split('&');
                foreach (var s in p)
                {
                    if (!string.IsNullOrEmpty(s) && !s.StartsWith(OAuthConstants.OAuthParameterPrefix))
                    {
                        if (s.IndexOf('=') > -1)
                        {
                            var temp = s.Split('=');
                            outcome.Add(new QueryParameter(temp[0], temp[1]));
                        }
                        else
                        {
                            outcome.Add(new QueryParameter(s, string.Empty));
                        }
                    }
                }
            }

            outcome.Add(new QueryParameter(OAuthConstants.OAuthVersionKey, OAuthConstants.OAuthVersion));
            outcome.Add(new QueryParameter(OAuthConstants.OAuthNonceKey, nonce));
            outcome.Add(new QueryParameter(OAuthConstants.OAuthTimestampKey, consumerTimeStamp));
            outcome.Add(new QueryParameter(OAuthConstants.OAuthSignatureMethodKey, "HMAC-SHA1"));
            outcome.Add(new QueryParameter(OAuthConstants.OAuthConsumerKeyKey, _consumerProvider.Key));
            outcome.Add(new QueryParameter(OAuthConstants.OAuthTokenKey, callParameters.Token));

            outcome.Sort(new QueryParameterComparer());

            return outcome;
        }
    }
}