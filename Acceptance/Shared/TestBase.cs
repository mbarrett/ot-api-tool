using Acceptance.IoC;
using NUnit.Framework;
using Nancy.Testing;

namespace Acceptance.Shared
{
    public class TestBase
    {
        public class given_a_browser
        {
            protected string EmptyErrorCode = "&quot;ErrorID&quot;: &quot;0&quot;";
            protected string EmptyErrorMessage = "&quot;ErrorMessage&quot;: &quot;&quot;";

            protected BrowserResponse _outcome;
            protected Browser _browser;
            protected string _username;

            [SetUp]
            public void Setup()
            {
                var test = new TestBootstrapper();
                test.Initialise();

                _browser = new Browser(test);
            }
        } 
    }
}