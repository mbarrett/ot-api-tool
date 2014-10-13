using System;
using Acceptance.Shared;
using NUnit.Framework;
using Nancy.Testing;

namespace Acceptance.ApiCalls
{
    public class SlotLock : TestBase
    {
        [TestFixture]
        public class when_requesting_the_slotlock_call : given_a_browser
        {
            private BrowserResponse _response;

            [SetUp]
            public new void Setup()
            {
                _response = _browser.Get("/slotlock", with => with.HttpRequest());
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
        public class when_invoking_the_slotlock_call : given_the_post_values
        {
            private BrowserResponse _response;

            [SetUp]
            public new void Setup()
            {
                _response = _browser.Post("/table/invoke", valid_post_values);

                var resultsKey = GetValueFor("ResultsKey", _response.Body.AsString());
                var timeSecurityId = GetValueFor("TimeSecurityId", _response.Body.AsString()); ;

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
                with.FormValue("RestaurantId", "18438");
            }

            protected string GetValueFor(string field, string content)
            {
                var amendedContent = content.Replace(":", string.Empty);
                amendedContent = amendedContent.Replace("&quot;", "_");
                var contentArray = amendedContent.Split('_');

                for (int i = 0; i < contentArray.Length; i++)
                {
                    if (contentArray[i].ToLower() == field.ToLower())
                    {
                        return contentArray[i + 1];
                    }
                }

                throw new Exception(string.Format("Value not found for '{0}'", field));
            }
        }
    }
}
