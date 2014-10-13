using System.Collections.Specialized;
using apitool.core.Models.Parameters;

namespace apitool.core.Models.Criteria
{
    public interface ICallCriteria
    {
        CallParameters CallParameters { get; set; }
        NameValueCollection PostParameters { get; set; }
    }
}