namespace Interapp.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Contracts;
    using ViewModels.Essays;

    public class EssaysController : AdminController
    {
        private IEssaysService essays;

        public EssaysController(IEssaysService essays)
        {
            this.essays = essays;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult EssaysRead([DataSourceRequest]DataSourceRequest request)
        {
            var model = this.essays.All().To<EssayViewModel>();
            DataSourceResult result = model.ToDataSourceResult(request);

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EssaysUpdate([DataSourceRequest]DataSourceRequest request, EssayViewModel essay)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Essay
                {
                    AuthorId = essay.AuthorId,
                    Title = essay.Title,
                    Content = essay.Content
                };

                this.essays.Update(entity);
            }

            return this.Json(new[] { essay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EssaysDestroy([DataSourceRequest]DataSourceRequest request, EssayViewModel essay)
        {
            this.essays.Delete(essay.AuthorId);

            return this.Json(new[] { essay }.ToDataSourceResult(request, this.ModelState));
        }
    }
}