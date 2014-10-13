using System.Security.Cryptography;
using System.Text;
using apitool.core.Extensions;

namespace apitool.core.Builders.Authorization
{
    public class HashAlgorithmBuilder : IHashAlgorithmBuilder
    {
        public HMACSHA1 Build(string consumerSecret, string tokenSecret)
        {
            return new HMACSHA1
            {
                Key = Encoding.UTF8.GetBytes(string.Format("{0}&{1}", consumerSecret.UrlEncode(), tokenSecret.UrlEncode()))
            };
        }
    }
}