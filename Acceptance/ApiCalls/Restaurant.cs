using Acceptance.Shared;
using NUnit.Framework;
using Nancy.Testing;

namespace Acceptance.ApiCalls
{
    public class Restaurant : TestBase
    {
        [TestFixture]
        public class when_requesting_the_restaurant_call : given_a_browser
        {
            private BrowserResponse _response;

            [SetUp]
            public new void Setup()
            {
                _response = _browser.Get("/restaurant", with => with.HttpRequest());
            }

            [Test]
            public void should_render_expected_elements()
            {
                _response.Body[".start-again"]
                    .ShouldExistOnce();
            }
        }

        [TestFixture]
        [Ignore("Still to figure this out")]
        public class when_invoking_the_restaurant_call : given_the_post_values
        {
            private BrowserResponse _response;

            [SetUp]
            public new void Setup()
            {
                _response = _browser.Post("/restaurant/invoke", valid_post_values);
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
                with.FormValue("RestaurantId", "18438");
            }
        }
    }
}
