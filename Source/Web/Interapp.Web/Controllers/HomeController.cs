namespace Interapp.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Services.Contracts;
    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private IDirectorInfosService directors;
        private IStudentInfosService students;
        private IApplicationsService applications;
        private IUniversitiesService universities;

        public HomeController(
            IDirectorInfosService directors,
            IStudentInfosService students,
            IApplicationsService applications,
            IUniversitiesService universities)
        {
            this.directors = directors;
            this.students = students;
            this.applications = applications;
            this.universities = universities;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            return this.View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60 * 60)]
        public ActionResult Statistics()
        {
            var model = new StatisticsViewModel()
            {
                ApplicationsCount = this.applications.All().Count(),
                DirectorsCount = this.directors.All().Count(),
                StudentsCount = this.students.All().Count(),
                UniversitiesCount = this.universities.All().Count()
            };
            return this.PartialView("_Statistics", model);
        }
    }
}