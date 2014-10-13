using System.Security.Cryptography;

namespace apitool.core.Builders.Authorization
{
    public interface IHashAlgorithmBuilder
    {
        HMACSHA1 Build(string consumerSecret, string tokenSecret);
    }
}