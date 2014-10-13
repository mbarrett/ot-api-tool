using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.Net.Http;
using apitool.core.Extensions;
using apitool.core.Models.Criteria;
using apitool.core.Models.Parameters;

namespace apitool.core.Builders.Criteria
{
    public class MakeCriteriaBuilder : ICallCriteriaBuilder
    {
        public ICallCriteria Build(CallParameters parameters)
        {
            var url = string.Format("{0}.ashx/reservation/?pid={1}&st=0",
                                   parameters.ApiVersion,
                                   ConfigurationManager.AppSettings["PartnerId"]);

            return new CallCriteria
            {
                CallParameters = new CallParameters
                {
                    Url = url,
                    HttpMethod = HttpMethod.Post
                },
                PostParameters = new NameValueCollection
                        {
                            {"email_address", parameters.Email},
                            {"RID", parameters.RestaurantId.ToString(CultureInfo.InvariantCulture)},
                            {"datetime", parameters.DateTime.ToApiDateTimeFormat()},
                            {"partysize", parameters.PartySize.ToString(CultureInfo.InvariantCulture)},
                            {"phone", "02012345678"},
                            {"OTannouncementOption", "0"},
                            {"RestaurantEmailOption", "0"},
                            {"firstname", "John"},
                            {"lastname", "Smith"},
                            {"timesecurityID", parameters.SecurityId},
                            {"resultskey", parameters.ResultsKey},
                            {"firsttimediner", "0"},
                            {"specialinstructions", string.Empty},
                            {"authkey", string.Empty},
                            {"points", "0"},
                            {"app_version", string.Empty},
                            {"slotlockid", parameters.SlotLockId.ToString(CultureInfo.InvariantCulture)},
                            {"cclast4", string.Empty},
                            {"cccustuuid", string.Empty},
                            {"ccpmtuuid", string.Empty},
                            {"cchttpstat", string.Empty},
                            {"ccresphash", string.Empty},
                            {"ccresptime", string.Empty},
                            {"phcountrycode", "UK"},
                            {"offerid", parameters.OfferId.ToString(CultureInfo.InvariantCulture)},
					        {"offerversion", parameters.OfferVersion},
                            {"restrefid", string.Empty}
                        }
            };
        }
    }
}