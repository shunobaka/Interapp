namespace Interapp.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Contracts;
    using ViewModels.Responses;

    public class ResponsesController : AdminController
    {
        private IResponsesService responses;

        public ResponsesController(IResponsesService responses)
        {
            this.responses = responses;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult ResponsesRead([DataSourceRequest]DataSourceRequest request)
        {
            var model = this.responses.All().To<ResponseViewModel>();
            DataSourceResult result = model.ToDataSourceResult(request);

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ResponsesUpdate([DataSourceRequest]DataSourceRequest request, ResponseViewModel response)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.Mapper.Map<Response>(response);
                this.responses.Update(entity);
            }

            return this.Json(new[] { response }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ResponsesDestroy([DataSourceRequest]DataSourceRequest request, ResponseViewModel response)
        {
            this.responses.Delete(response.ApplicationId);

            return this.Json(new[] { response }.ToDataSourceResult(request, this.ModelState));
        }
    }
}