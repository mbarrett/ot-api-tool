using System;
using System.Security.Cryptography;
using apitool.core.Models;
using apitool.core.Models.Parameters;
using apitool.core.Providers;

namespace apitool.core.Validators
{
    public class OAuthValidator : IOAuthValidator
    {
        private readonly IConsumerProvider _consumerProvider;

        public OAuthValidator(IConsumerProvider consumerProvider)
        {
            _consumerProvider = consumerProvider;
        }

        public void ValidateParameters(CallParameters parameters, string consumerTimeStamp, string consumerNonce)
        {
            if (string.IsNullOrEmpty(_consumerProvider.Key))
            {
                ThrowAuthenticationException("Consumer Key must be provided");
            }

            if (string.IsNullOrEmpty(_consumerProvider.Secret))
            {
                ThrowAuthenticationException("Consumer Secret must be provided");
            }

            if (parameters.HttpMethod == null)
            {
                ThrowAuthenticationException("Http Method must be provided");
            }

            if (string.IsNullOrEmpty(parameters.Url))
            {
                ThrowAuthenticationException("Url must be provided");
            }

            if (string.IsNullOrEmpty(consumerTimeStamp))
            {
                ThrowAuthenticationException("Consumer timestamp must be provided");
            }

            if (string.IsNullOrEmpty(consumerNonce))
            {
                ThrowAuthenticationException("Consumer nonce must be provided");
            }
        }

        public void ValidateSignitureAndAlgorithm(OAuthSigniture signiture, HMACSHA1 hashAlgorithm)
        {
            if (signiture == null || string.IsNullOrEmpty(signiture.Value))
            {
                ThrowAuthenticationException("Signiture must be provided");
            }

            if (hashAlgorithm == null)
            {
                ThrowAuthenticationException("Hash algorithm must be provided");
            }
        }

        private void ThrowAuthenticationException(string message)
        {
            throw new Exception(string.Format("Exception was thrown validating authentication - {0}", message));
        }
    }
}