using apitool.core.Models.Criteria;
using apitool.core.Models.Parameters;

namespace apitool.core.Builders.Criteria
{
    public interface ICallCriteriaBuilder
    {
        ICallCriteria Build(CallParameters parameters);
    }
}