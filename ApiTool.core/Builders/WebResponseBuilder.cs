using System;
using System.Net;
using System.Text;
using apitool.core.Models;
using apitool.core.Models.Criteria;

namespace apitool.core.Builders
{
    public class WebResponseBuilder : IWebResponseBuilder
    {
        public string GetResponseStringFor(ICallCriteria criteria, AuthorizationHeader authHeader)
        {
            ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

            var responseValue = string.Empty;

            var webClient = new WebClient();
            webClient.Headers.Add("AUTHORIZATION", authHeader.Value);
            webClient.Headers.Add("X-Forwarded-For", "testing - X-Forwarded-For");

            try
            {
                using (webClient)
                {
                    if (CallHasPostParameters(criteria))
                    {
                        var uploadResponse = webClient.UploadValues(criteria.CallParameters.Url, criteria.PostParameters);
                        responseValue = Encoding.ASCII.GetString(uploadResponse);
                    }
                    else
                    {
                        responseValue = webClient.DownloadString(criteria.CallParameters.Url);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get response for url '{0}' - {1}", ex);
            }

            return responseValue;
        }

        private static bool CallHasPostParameters(ICallCriteria criteria)
        {
            return criteria.PostParameters != null && criteria.PostParameters.Count > 0;
        }
    }
}