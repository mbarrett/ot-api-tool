using System;

namespace apitool.core.ViewModels
{
    public class OtApiViewModel
    {
        public string Response { get; set; }
        public string AuthHeaders { get; set; }
        public string Url { get; set; }
        public string PostParameters { get; set; }
        public string PartnerId { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string ApiVersion { get; set; }
        
        public string DefaultRestaurantId { get; set; }
        public string DefaultPartySize { get; set; }
        public DateTime DefaultDateTime { get; set; }
        public string DefaultSearchTerm { get; set; }

        public bool HasUrl { get { return !String.IsNullOrEmpty(Url); }}
        public bool HasAuthHeaders { get { return !String.IsNullOrEmpty(AuthHeaders); } }
        public bool HasPostParameters { get { return !String.IsNullOrEmpty(PostParameters); } }
        public bool HasResponse { get { return !String.IsNullOrEmpty(Response); } }
    }
}