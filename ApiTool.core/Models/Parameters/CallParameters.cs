using System;
using System.Configuration;
using System.Net.Http;

namespace apitool.core.Models.Parameters
{
    public class CallParameters
    {
        private string _url;
        private string _apiVersion;

        public string Url
        {
            get { return _url; }
            set { _url = string.Format("{0}{1}", ConfigurationManager.AppSettings["DomainUrl"], value); }
        }

        public string ApiVersion
        {
            get { return _apiVersion ?? "v3"; }
            set { _apiVersion = value; }
        }

        public HttpMethod HttpMethod { get; set; }
        public string Token { get { return string.Empty; } }
        public string TokenSecret { get { return string.Empty; } }
        public int RestaurantId { get; set; }
        public int PartySize { get; set; }
        public DateTime DateTime { get; set; }
        public string ResultsKey { get; set; }
        public string SecurityId { get; set; }
        public int SlotLockId { get; set; }
        public int OfferId { get; set; }
        public string OfferVersion { get; set; }
        public string Email { get; set; }
        public int ConfirmationNumber { get; set; }
        public string SearchTerm { get; set; }
        public string AuthToken { get; set; }
    }
}