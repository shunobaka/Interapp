namespace Interapp.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Kendo.Mvc.UI;
    using Models.UniversitiesViewModels;
    using Services.Contracts;

    public class UniversitiesController : AdminController
    {
        private IUniversitiesService universities;

        public UniversitiesController(IUniversitiesService universities)
        {
            this.universities = universities;
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}