using apitool.core.Models.Parameters;
using apitool.core.ViewModels;

namespace apitool.core.Builders
{
    public interface IOtApiViewModelBuilder
    {
        OtApiViewModel BuildResponseModel(dynamic call, CallParameters criteria);
        OtApiViewModel BuildDefaultModel(string call);
    }
}