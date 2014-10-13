using apitool.core.Models.Criteria;
using apitool.core.Models.Parameters;

namespace apitool.core.Providers
{
    public interface ICallCriteriaProvider
    {
        ICallCriteria Build(string key, CallParameters parameters);
    }
}