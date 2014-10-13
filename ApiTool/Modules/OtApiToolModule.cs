using Nancy;
using Nancy.ModelBinding;
using apitool.core.Builders;
using apitool.core.Models.Parameters;

namespace apitool.Modules
{
    public class OtApiToolModule : NancyModule
    {
        private readonly IOtApiViewModelBuilder _otApiViewModelBuilder;

        public OtApiToolModule(IOtApiViewModelBuilder otApiViewModelBuilder)
        {
            _otApiViewModelBuilder = otApiViewModelBuilder;

            Get["/{call}"] = render =>
                {
                    var viewModel = _otApiViewModelBuilder.BuildDefaultModel(render.call);
                    return View[string.Format("{0}", render.call), viewModel];
                };

            Post["/{call}/invoke"] = render =>
                {
                    var parameters = this.Bind<CallParameters>();
                    var model = _otApiViewModelBuilder.BuildResponseModel(render.call, parameters);

                    return View[string.Format("{0}", render.call), model];
                };
        }
    }
}