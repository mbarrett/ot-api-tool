using apitool.core.Models;
using apitool.core.Models.Parameters;

namespace apitool.core.Builders.Authorization
{
    public interface IOAuthSignitureBuilder
    {
        OAuthSigniture Build(CallParameters callParameters, AuthorizationHeaderParameters authorizationHeaderParameters);
    }
}