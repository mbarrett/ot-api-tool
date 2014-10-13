using System.Security.Cryptography;
using apitool.core.Models;
using apitool.core.Models.Parameters;

namespace apitool.core.Validators
{
    public interface IOAuthValidator
    {
        void ValidateParameters(CallParameters parameters, string consumerTimeStamp, string consumerNonce);
        void ValidateSignitureAndAlgorithm(OAuthSigniture signiture, HMACSHA1 hashAlgorithm);
    }
}