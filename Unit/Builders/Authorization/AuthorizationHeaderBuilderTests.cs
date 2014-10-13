using NSubstitute;
using NUnit.Framework;
using apitool.core.Builders.Authorization;
using apitool.core.Constants;
using apitool.core.Models;
using apitool.core.Models.Parameters;
using apitool.core.Providers;

namespace Unit.Builders.Authorization
{
    public class AuthorizationHeaderBuilderTests
    {
        [TestFixture]
        public class when_building_an_authorization_header : given_an_authorization_header_builder
        {
            [SetUp]
            public new void Setup()
            {
                given_the_call_parameters();
                given_the_consumer_timestamp_and_nonce();
                given_encoded_oauth_signiture();
                given_the_consumer_key();
                
                _outcome = _subject.Build(_callParameters);
            }

            [Test]
            public void should_return_an_authorized_header_with_correct_value_set()
            {
                Assert.That(_outcome, Is.TypeOf<AuthorizationHeader>());
            }

            [Test]
            public void should_set_the_correct_authorization_header_value()
            {
                var _expectedValue = string.Format(
                    OAuthConstants.OAuthHeaderTemplate,
                    _consumerKey,
                    _encodedOAuthSigniture,
                    _consumerTimeStamp,
                    _consumerNonce);

                Assert.That(_outcome.Value, Is.EqualTo(_expectedValue));
            }
        } 
    }

    public class given_an_authorization_header_builder
    {
        protected AuthorizationHeaderBuilder _subject;
        protected CallParameters _callParameters;
        protected AuthorizationHeader _outcome;

        protected string _encodedOAuthSigniture;
        protected string _consumerKey;
        protected string _consumerTimeStamp;
        protected string _consumerNonce;

        private IOAuthSignitureProvider _oAuthSignitureProvider;
        private IConsumerProvider _consumerProvider;

        [SetUp]
        public void Setup()
        {
            _oAuthSignitureProvider = Substitute.For<IOAuthSignitureProvider>();
            _consumerProvider = Substitute.For<IConsumerProvider>();

            _subject = new AuthorizationHeaderBuilder(_oAuthSignitureProvider, 
                                                      _consumerProvider);
        }

        protected void given_encoded_oauth_signiture()
        {
            _encodedOAuthSigniture = "encoded_oauth_signiture";

            _oAuthSignitureProvider
                .GetHashEncodedSignitureFor(_callParameters, Arg.Any<AuthorizationHeaderParameters>())
                .Returns(_encodedOAuthSigniture);
        }

        protected void given_the_consumer_key()
        {
            _consumerKey = "consumer_key";
            _consumerProvider.Key.Returns(_consumerKey);
        }

        protected void given_the_call_parameters()
        {
            _callParameters = new CallParameters();
        }

        protected void given_the_consumer_timestamp_and_nonce()
        {
            _consumerTimeStamp = "1372368097";
            _consumerNonce = "1579070";

            _consumerProvider.TimeStamp.Returns(_consumerTimeStamp);
            _consumerProvider.Nonce.Returns(_consumerNonce);
        }
    }
}