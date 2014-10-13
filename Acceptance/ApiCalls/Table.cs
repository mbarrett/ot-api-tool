using Acceptance.Shared;
using NUnit.Framework;
using Nancy.Testing;
using apitool.core.Providers;

namespace Acceptance.ApiCalls
{
    public class Table : TestBase
    {
        [TestFixture]
        public class when_requesting_the_table_call : given_a_browser
        {
            private BrowserResponse _response;

            [SetUp]
            public new void Setup()
            {
                _response = _browser.Get("/table", with => with.HttpRequest());
            }

            [Test]
            public void should_render_expected_elements()
            {
                _response.Body[".start-again"]
                    .ShouldExistOnce();
            }
        }

        [Ignore("Still to figure this out")]
        [TestFixture]
        public class when_invoking_the_table_call : given_the_post_values
        {
            private BrowserResponse _response;

            [SetUp]
            public new void Setup()
            {
                _response = _browser.Post("/table/invoke", valid_post_values);
            }

            [Test]
            public void should_render_expected_elements()
            {
                _response.Body["#Response"].ShouldExistOnce();
                _response.Body["#Response"].ShouldContain(EmptyErrorCode);
                _response.Body["#Response"].ShouldContain(EmptyErrorMessage);
            }
        }

        public class given_the_post_values : given_a_browser
        {
            protected void valid_post_values(BrowserContext with)
            {
                with.HttpRequest();
                with.FormValue("ApiVersion", "v3");
                with.FormValue("PartnerId", "");
                with.FormValue("ConsumerKey", "");
                with.FormValue("ConsumerSecret", "");
                with.FormValue("RestaurantId", "18438");
                with.FormValue("PartySize", "2");
                with.FormValue("DateTime", new DateTimeProvider().TomorrowAtSevenPm.ToString());
            }
        }
    }
}
