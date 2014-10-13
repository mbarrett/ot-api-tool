using apitool.core.Builders.Authorization;
using apitool.core.Models.Parameters;

namespace apitool.core.Providers
{
    public interface IOAuthSignitureProvider
    {
        string GetHashEncodedSignitureFor(CallParameters callParameters, AuthorizationHeaderParameters authorizationHeaderParameters);
    }
}