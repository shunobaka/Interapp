namespace Interapp.Web.Areas.Admin.Controllers
{
    using Models.UniversitiesViewModels;
    using Kendo.Mvc.UI;
    using Services.Contracts;
    using System.Web.Mvc;

    public class UniversitiesController : Controller
    {
        private IUniversitiesService universities;

        public UniversitiesController(IUniversitiesService universities)
        {
            this.universities = universities;
        }

        public ActionResult Index()
        {
            return View();
        }

        //public JsonResult UpdateUniversity([DataSourceRequest] DataSourceRequest request, UniversityViewModel university)
        //{

        //}
    }
}