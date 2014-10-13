using System;
using Acceptance.Shared;
using NUnit.Framework;
using Nancy.Testing;

namespace Acceptance.Modules
{
    public class Home : TestBase
    {
        [TestFixture]
        public class when_requesting_the_homepage : given_a_browser
        {
            private BrowserResponse _response;

            [SetUp]
            public new void Setup()
            {
                _response = _browser.Get("/", with => with.HttpRequest());
            }

            [Test]
            public void should_render_expected_elements()
            {
                _response.Body[".intro"]
                    .ShouldExistOnce()
                    .And.ShouldContain(
                     "Please select an option from the navigation",
                     StringComparison.InvariantCultureIgnoreCase);
            }
        }
    }
}
