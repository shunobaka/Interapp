namespace Interapp.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Contracts;
    using ViewModels.Scores;

    public class ScoresController : AdminController
    {
        private IScoresService scores;

        public ScoresController(IScoresService scores)
        {
            this.scores = scores;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult ScoresRead([DataSourceRequest]DataSourceRequest request)
        {
            var model = this.scores.All().To<ScoresViewModel>();
            DataSourceResult result = model.ToDataSourceResult(request);

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ScoresUpdate([DataSourceRequest]DataSourceRequest request, ScoresViewModel score)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.Mapper.Map<ScoreReport>(score);
                this.scores.Update(entity);
            }

            return this.Json(new[] { score }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ScoresDestroy([DataSourceRequest]DataSourceRequest request, ScoresViewModel score)
        {
            this.scores.Delete(score.StudentInfoId);

            return this.Json(new[] { score }.ToDataSourceResult(request, this.ModelState));
        }
    }
}