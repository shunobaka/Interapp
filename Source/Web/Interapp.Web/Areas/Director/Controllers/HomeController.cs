namespace Interapp.Web.Areas.Director.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;
    using Models.UniversityViewModels;
    using Services.Contracts;
    using System.Linq;
    using System.Web.Mvc;

    [Authorize(Roles = "Director")]
    public class HomeController : Controller
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
                .ProjectTo<UniversityViewModel>()
                .ToList();

            return View(model);
        }
    }
}