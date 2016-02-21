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
        private const int PageSize = 3;
        private IUniversitiesService universities;

        public HomeController(IUniversitiesService universities)
        {
            this.universities = universities;
        }

        public ActionResult Index(int id = 1)
        {
            if (id < 1)
            {
                id = 1;
            }

            var userId = this.User.Identity.GetUserId();
            var universitiesList = this.universities
                .All()
                .Where(u => u.DirectorId == userId)
                .To<UniversityViewModel>()
                .OrderBy(u => u.Name);

            var universitiesCount = universitiesList.Count();
            var modelUniversities = universitiesList.Skip((id - 1) * PageSize).Take(PageSize).ToList();

            var model = new IndexViewModel()
            {
                Page = id,
                UniversitiesCount = universitiesCount,
                Universities = modelUniversities,
                PageSize = PageSize
            };

            return this.View(model);
        }
    }
}