using Nancy;

namespace apitool.core.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = render => View["index"];
        }
    }
}