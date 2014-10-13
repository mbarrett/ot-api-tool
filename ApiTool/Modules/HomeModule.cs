using Nancy;

namespace apitool.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = render => View["index"];
        }
    }
}