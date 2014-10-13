using apitool.core.Models;
using apitool.core.Models.Parameters;

namespace apitool.core.Builders.Authorization
{
    public interface IAuthorizationHeaderBuilder
    {
        AuthorizationHeader Build(CallParameters callParameters);
    }
}