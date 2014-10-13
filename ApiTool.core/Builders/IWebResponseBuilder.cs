using apitool.core.Models;
using apitool.core.Models.Criteria;

namespace apitool.core.Builders
{
    public interface IWebResponseBuilder
    {
        string GetResponseStringFor(ICallCriteria criteria, AuthorizationHeader authHeader);
    }
}