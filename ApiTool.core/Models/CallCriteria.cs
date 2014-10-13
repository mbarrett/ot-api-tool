using System.Collections.Specialized;
using apitool.core.Models.Parameters;

namespace apitool.core.Models.Criteria
{
    public class CallCriteria : ICallCriteria
    {
        public CallCriteria()
        {
            CallParameters = new CallParameters();
            PostParameters = new NameValueCollection();
        }

        public CallParameters CallParameters { get; set; }
        public NameValueCollection PostParameters { get; set; }
    }
}