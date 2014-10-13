using System.Collections.Generic;
using apitool.core.Models.Parameters;

namespace apitool.core.Builders
{
    public interface IQueryParameterBuilder
    {
        IList<QueryParameter> Build(CallParameters callParameters, string consumerTimeStamp, string nonce);
    }
}