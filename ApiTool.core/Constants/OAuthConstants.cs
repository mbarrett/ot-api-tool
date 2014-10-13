namespace apitool.core.Constants
{
    public class OAuthConstants
    {
        public const string OAuthConsumerKeyKey = "oauth_consumer_key";
        public const string OAuthCallbackKey = "oauth_callback";
        public const string OAuthVersionKey = "oauth_version";
        public const string OAuthSignatureMethodKey = "oauth_signature_method";
        public const string OAuthSignatureKey = "oauth_signature";
        public const string OAuthTimestampKey = "oauth_timestamp";
        public const string OAuthNonceKey = "oauth_nonce";
        public const string OAuthTokenKey = "oauth_token";
        public const string OAuthTokenSecretKey = "oauth_token_secret";
        public const string OAuthVersion = "1.0";
        public const string OAuthParameterPrefix = "oauth_";
        public const string OAuthHeaderTemplate = "OAuth realm=\"http://www.opentable.com/, oauth_consumer_key=\"{0}\", oauth_signature_method=\"HMAC-SHA1\", oauth_signature=\"{1}\", oauth_timestamp=\"{2}\", oauth_token=\"\", oauth_nonce=\"{3}\", oauth_version=\"1.0\"";
    }
}