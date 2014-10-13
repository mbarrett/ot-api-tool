namespace apitool.core.Models.Parameters
{
    public class AuthorizationHeaderParameters
    {
        private readonly string _timeStamp;
        private readonly string _nonce;

        public AuthorizationHeaderParameters(string timeStamp, string nonce)
        {
            _timeStamp = timeStamp;
            _nonce = nonce;
        }

        public string Nonce { get { return _nonce; } }
        public string TimeStamp { get { return _timeStamp; } }
    }
}