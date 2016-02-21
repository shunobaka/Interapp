namespace Interapp.Web.Areas.Director.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Contracts;
    using ViewModels.Home;

    public class HomeController : DirectorController
    {
        private IUniversitiesService universities;

        public HomeController(IUniversitiesService universities)
        {
            this.universities = universities;
        }

        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var model = this.universities
                .All()
                .Where(u => u.DirectorId == userId)
                .To<UniversityViewModel>()
                .ToList();

            return this.View(model);
        }
    }
}